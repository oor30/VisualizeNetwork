using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VisualizeNetwork
{
	public partial class Form1 : Form
	{
		// Visualizerをリセットする
		private void ResetView()
		{
			if (scenario.algorithms.Count == 0) {
				MessageBox.Show("表示するシミュレーションシナリオがありません。",
					"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 座標を正規化する
			double maxX = double.MinValue;
			double minX = double.MaxValue;
			double maxY = double.MinValue;
			double minY = double.MaxValue;

			foreach (Node node in scenario.initialNodes)
			{
				if (maxX < node.X) maxX = node.X;
				if (minX > node.X) minX = node.X;
				if (maxY < node.Y) maxY = node.Y;
				if (minY > node.Y) minY = node.Y;
			}

			scenario.maxX = maxX;
			scenario.minX = minX;
			scenario.maxY = maxY;
			scenario.minY = minY;
			double w = maxX - minX;
			double h = maxY - minY;
			scenario.rw = scenario.canvasW / w;
			scenario.rh = scenario.canvasH / h;

			int maxRound = 0;
			foreach (Sim sim in scenario.algorithms)
			{
				if (maxRound < sim.LDN) maxRound = sim.LDN;
				if (sim.LDN == 0)
				{
					maxRound = Sim.R;
					break;
				}
			}

			// 変数を初期化
			tabControl.SelectedIndex = 0;
			round = 1;
			playSpeed = 1;
			trackBarPlaySpeed.Value = playSpeed;
			isPlaying = false;
			selectedNodeID = 0;
			labelRound.Text = "ラウンド：" + round;
			labelScenario.Text = "シナリオ：" + scenario.scenarioFile;
			trackBarRound.Value = 1;
			trackBarRound.Maximum = maxRound;
			resultTable.Rows.Clear();
			cmbBoxAlgo.Items.Clear();
			selectedNodeID = 0;

			// 結果表にシミュレーション結果を追加・コンボボックスにアルゴリズムを追加
			foreach (Sim sim in scenario.algorithms)
			{
				resultTable.Rows.Add(sim.AlgoName, sim.FDN, sim.LDN, Math.Round(sim.CHMean, 2), Math.Round(sim.CHSD, 2),
						Math.Round(sim.AveEnergyConsumption, 4), sim.CollectedDataNum);
				resultTable.Rows[resultTable.Rows.Count - 1].HeaderCell.Value = resultTable.Rows.Count.ToString();
				cmbBoxAlgo.Items.Add(sim.AlgoName);
			}

			DrawChart();
			ChangeEnabledAlgorithm(scenario.algorithms[0]);
		}

		// グラフを描画
		private void DrawChart()
		{
			PrintConsole("グラフを描画");
			int maxRound = 0;
			foreach (Sim sim in scenario.algorithms)
			{
				if (maxRound < sim.LDN) maxRound = sim.LDN;
				if (sim.LDN == 0)
				{
					maxRound = Sim.R;
					break;
				}
			}
			maxRound = ((maxRound / 100) + 1) * 100;

			List<Chart> charts = new List<Chart>
			{
				chartAliveNums,
				chartNumCH,
				chartReceivedData,
				chartTotalEnergyConsumption
			};

			List<string> yTitles = new List<string>
			{
				"Number of nodes alive",
				"Number of CH",
				"Number of received data as BS",
				"Total Energy Consumption of the Network(J)"
			};

			for (int i = 0; i < charts.Count; i++)
			{
				Chart chart = charts[i];
				string yTitle = yTitles[i];
				chart.ChartAreas.Clear();
				chart.Series.Clear();
				ChartArea chartArea = new ChartArea("chartArea");
				chartArea.AxisX.Minimum = 0;
				chartArea.AxisX.Maximum = maxRound;
				chartArea.AxisX.Title = "Number of rounds";
				chartArea.AxisY.Title = yTitle;
				chartArea.AxisX.ScaleView.Size = 1000;
				chartArea.AxisX.IsMarginVisible = false;
				chart.ChartAreas.Add(chartArea);
			}

			foreach (Sim sim in scenario.algorithms)
			{
				List<Series> seriesList = new List<Series>
				{
					CreateNewSeries(sim.AlgoName),
					CreateNewSeries(sim.AlgoName),
					CreateNewSeries(sim.AlgoName),
					CreateNewSeries(sim.AlgoName)
				};

				// 生存ノード数のグラフを描く
				for (int i = 0; i < sim.AliveNumList.Count; i++)
				{
					seriesList[0].Points.AddXY(i, sim.AliveNumList[i]);
					if (i % 50 == 0)
						seriesList[1].Points.AddXY(i, sim.CHNumList[i]);
					seriesList[2].Points.AddXY(i, sim.CollectedDataNumList[i]);
					seriesList[3].Points.AddXY(i, sim.TotalEnergyConsumptionList[i]);
				}
				for (int i = 0; i < charts.Count; i++)
				{
					charts[i].Series.Add(seriesList[i]);
				}
			}
		}

		// ラウンドテーブルを更新する
		private void RefreshRoundTable(List<Node> nodes)
		{
			roundTable.Rows.Clear();
			double sumEnergy = 0;
			double sumCmsEnergy = 0;
			double sumHasCHCnt = 0;
			int qualifiedNodeNum = 0;
			double sumPi = 0;
			int numCH = 0;
			for (int i = 0; i < scenario.N; i++)
			{
				Node node = nodes[i];

				roundTable.Rows.Add(i, node.Status.ToString(), node.CHID, Math.Round(node.E_r, 5), Math.Round(node.CmsEnergy, 5),
					node.HasCHCnt, node.UnqualifiedRound, Math.Round(node.Pi, 4));
				if (node.UnqualifiedRound == 0)
					roundTable.Rows[roundTable.Rows.Count - 1].Cells[6].Style.ForeColor = Color.Red;
				sumEnergy += node.E_r;
				sumCmsEnergy += node.CmsEnergy;
				sumHasCHCnt += node.HasCHCnt;
				sumPi += node.Pi;
				if (node.UnqualifiedRound == 0) qualifiedNodeNum++;
			}
			roundTable.Rows.Insert(0, "合計", "", numCH, Math.Round(sumEnergy, 5), Math.Round(sumCmsEnergy, 5),
				sumHasCHCnt, qualifiedNodeNum, Math.Round(sumPi, 4));
		}

		// Seriesを作成する(DrawChartの補助)
		private Series CreateNewSeries(string algoName)
		{
			Series series = new Series
			{
				ChartType = SeriesChartType.Line,
				LegendText = algoName
			};
			return series;
		}

		// ノード図を更新する
		private void RefreshPaint(List<Node> nodes)
		{
			// 座標リストからノードを描画する
			Graphics g = Graphics.FromImage(pictureBoxNodeMap.Image);
			g.Clear(Color.White);
			PaintLine(g);
			PaintEdges(g, nodes);
			PaintNodes(g, nodes);
			pictureBoxNodeMap.Invalidate();
			pictureBoxNodeMap.Refresh();
			g.Dispose();
		}

		// ノードを描画する
		private void PaintNodes(Graphics g, List<Node> nodes)
		{
			Pen pen = new Pen(Color.Black);
			Brush brush = Brushes.Gray;
			foreach (Node node in nodes)
			{
				pen.Width = 1;
				if (node.IsAlive)
				{
					if (node.IsCH && node.CHID != -1)
					{
						pen.Color = Color.Green;
						brush = Brushes.Green;
					}
					else if (node.IsCH)
					{
						pen.Color = Color.Blue;
						brush = Brushes.Blue;
					}
					else
					{
						pen.Color = Color.Black;
						brush = Brushes.Black;
					}
				}
				else pen.Color = Color.Red;
				if (node.ID == selectedNodeID)
				{
					pen.Width = 4;
					pen.Color = Color.LightBlue;
				}
				Point p = Normalize(node);
				lock (g)
				{
					g.DrawEllipse(pen, (p.X - 5), p.Y - 5, 10, 10);
					if (node.IsAlive)
						g.FillPie(brush, (p.X - 5), (p.Y - 5), 10, 10, 0, (int)(node.E_r / node.E_init * 360));
				}
			}
			return;
		}

		// エッジを描画する
		private void PaintEdges(Graphics g, List<Node> nodes)
		{
			Pen pen = new Pen(Color.Black);
			foreach (Node node in nodes)
			{
				Node head;
				if (node.CHID == -1)
				{
					head = Sim.BS;
					//continue;
				}
				else
				{
					head = nodes[node.CHID];

				}
				if (node.ID != head.ID)
				{
					if (node.IsCH) pen.Color = Color.Green;
					else pen.Color = Color.Black;
					g.DrawLine(pen, Normalize(node), Normalize(head));
				}
			}
			return;
		}

		// x軸,y軸と目盛りを描画する
		private void PaintLine(Graphics g)
		{
			Pen pen = new Pen(Color.Gray);
			for (int i = (int)(scenario.minX - 10) / 50; i <= (scenario.maxX + 10); i += 50)
			{
				var p = Normalize(new Point(i, i));
				g.DrawLine(pen, p.X, 0, p.X, scenario.canvasH);
				g.DrawString(i.ToString(), this.Font, Brushes.Black, p.X, 0);
			}
			for (int i = (int)(scenario.minY - 10) / 50; i <= (scenario.maxY + 10); i += 50)
			{
				var p = Normalize(new Point(i, i));
				g.DrawLine(pen, 0, p.Y, scenario.canvasW, p.Y);
				g.DrawString(i.ToString(), this.Font, Brushes.Black, 0, p.Y);
			}
		}

		// ノードの座標をノード図のピクセルに変換する
		private Point Normalize(Node node)
		{
			return new Point((int)((node.X - scenario.minX) * scenario.rw * 0.95 + scenario.canvasW * 0.025),
				(int)((node.Y - scenario.minY) * scenario.rh * 0.95 + scenario.canvasH * 0.025));
		}

		// ノードの座標をノード図のピクセルに変換する
		private Point Normalize(Point point)
		{
			Point p = new Point((int)((point.X - scenario.minX) * scenario.rw * 0.95 + scenario.canvasW * 0.025),
				(int)((point.Y - scenario.minY) * scenario.rh * 0.95 + scenario.canvasH * 0.025));
			return p;
		}

		// ノード図のピクセルをノードの座標に変換する
		private Point RevNormalize(Point p)
		{
			return new Point((int)((p.X - scenario.canvasW * 0.025) / scenario.rw / 0.95 + scenario.minX),
				(int)((p.Y - scenario.canvasH * 0.025) / scenario.rh / 0.95 + scenario.minY));
		}

		// ノード図を並列処理で再生する
		private async Task<int> PlayClustering(CancellationToken ct)
		{

			for (int i = round; i <= enabledAlgorithm.NodesList.Count; i++)
			{
				//ct.ThrowIfCancellationRequested();
				if (ct.IsCancellationRequested) return -1;

				ChangeRound(i);
				//trackBarRound.Value = round;
				await Task.Delay(1000 / playSpeed);
			}
			//round = 100;
			return 0;
		}
	}
}

using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VisualizeNetwork
{
	public partial class Form1 : Form
	{
		private bool processing = false;

		// ★★★ノード配置のファイルを開くボタン
		private void BtnOpenFile_Click(object sender, EventArgs e)
		{
			if (processing) return;

			OpenFileDialog ofDialog = new OpenFileDialog
			{
				Title = "座標ファイルを選択",
				Filter = "テキストファイル(*.txt)|*.txt"
			};

			if (ofDialog.ShowDialog() == DialogResult.OK)
			{
				using (Waiting waiting = new Waiting(this, labelProcessing))
				{
					PrintConsole("ファイルが選択されました。" + ofDialog.FileName);
					string fileName = ofDialog.FileName;
					using (StreamReader sr = new StreamReader(fileName))
					{
						if (!master.TryGetIntegers(sr, out List<int> integers)) return;

						tabCtrlBottom.SelectedTab = tabLog;
						ResetConfig();
						algorithms = master.Run(integers, Path.GetFileNameWithoutExtension(fileName));
						ResetView();
					}
				}
			}
			else
			{
				PrintConsole("キャンセルされました。");
			}
			ofDialog.Dispose();
		}

		// ★★★100回のシミュレーションを実行するボタン
		private async void D100ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (Waiting waiting = new Waiting(this, labelProcessing))
			{
				using (SaveFileDialog sfDialog = new SaveFileDialog()
				{
					Title = "シミュレーション結果の保存",
					FileName = @"シミュレーション結果" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".csv",
					Filter = "CSVファイル|*.csv"
				})
				{
					if (sfDialog.ShowDialog() == DialogResult.OK)
					{
						Dictionary<string, Record> record = null;
						//List<Record> record = null;
						progressBar1.Minimum = 0;
						progressBar1.Maximum = 10;
						progressBar1.Value = 0;
						progressBar1.Step = 1;
						progressBar1.Visible = true;
						tabCtrlBottom.SelectedTab = tabLog;
						ResetConfig();

						for (int i = 0; i < 10; i++)
						{
							progressBar1.PerformStep();
							labelProcessing.Text = (i + 1).ToString() + " / 100";
							processing = true;

							await Task.Run(() =>
							{
								string path = "D100.Data" + i.ToString() + ".txt";
								Assembly assembly = Assembly.GetExecutingAssembly();
								Stream stream = assembly.GetManifestResourceStream("VisualizeNetwork.Resources.配置データ." + path);
								using (StreamReader sr = new StreamReader(stream))
								{
									if (!master.TryGetIntegers(sr, out List<int> integers)) return;

									algorithms = master.Run(integers, "\\Data" + i.ToString());
									Application.DoEvents();

									if (record == null)
									{
										record = new Dictionary<string, Record>();
										foreach (Sim sim in algorithms)
										{
											record.Add(sim.AlgoName, new Record(sim.AlgoName));
										}
									}
									foreach (Sim sim in algorithms)
									{
										record[sim.AlgoName].Add(sim.FDN, sim.LDN, sim.CollectedDataNum);
									}

									//string fileName = sfDialog.SelectedPath + scenario.scenarioFile + ".vns";
									//SaveScenario(fileName);
								}
							});
						}

						processing = false;
						progressBar1.Visible = false;
						labelProcessing.Text = "準備完了";
						foreach (KeyValuePair<string, Record> kvp in record)
						{
							PrintConsole(kvp.Key + "：：" + kvp.Value.GetMean(), false);
						}
						//string jsonStr = JsonSerializer.Serialize(record);
						using (StreamWriter writer = new StreamWriter(
							sfDialog.FileName, false, Encoding.UTF8))
						{
							try
							{
								var config = new CsvConfiguration(CultureInfo.GetCultureInfo("ja-jp"))
								{
									// 全てダブルクォートで囲む
									Quote = '"',
									ShouldQuote = context => true,
									Encoding = Encoding.UTF8
								};
								var csv = new CsvWriter(writer, config);
								csv.WriteHeader<Record>();
								csv.NextRecord();
								foreach (var v in record.Values)
								{
									csv.WriteRecord(v);
									csv.NextRecord();
								}
								//records = new Records(record, BS);
								//string jsonStr = JsonSerializer.Serialize(records);
								//writer.WriteLine(jsonStr);
							}
							catch
							{
								MessageBox.Show("シナリオファイルを保存できませんでした。",
									"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
						ResetView();
					}
					else
					{
						PrintConsole("キャンセルされました。");
					}
				}
			}
		}

		// ★★★ノード配置を無作為に生成してシミュレーションするボタン
		private void MenuItemCreate_Click(object sender, EventArgs e)
		{
			if (processing) return;
			using (Waiting waiting = new Waiting(this, labelProcessing))
			{
				tabCtrlBottom.SelectedTab = tabLog;
				ResetConfig();
				List<int> integers = master.CreateIntegers((int)numericUpDownN.Value);
				algorithms = master.Run(integers, "無作為");
				ResetView();
			}
		}

		// ★設定を適用するボタン
		private void BtnApply_Click(object sender, EventArgs e)
		{
			if (processing) return;
			if (algorithms.Count == 0)
			{
				MessageBox.Show("表示するシミュレーションシナリオがありません。",
					"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			using (Waiting waiting = new Waiting(this, labelProcessing))
			{
				tabCtrlBottom.SelectedTab = tabLog;
				ResetConfig();
				algorithms = master.WholeSimulationProcess(SimMaster.InitialNodes);
				ResetView();
			}
		}

		// ★シナリオファイルを読み込むボタン
		private void OpenScenarioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (processing) return;
			using (OpenFileDialog ofDialog = new OpenFileDialog
			{
				Title = "シナリオファイルを選択",
				Filter = "シナリオファイル(*.vns)|*.vns"
			})
			{
				if (ofDialog.ShowDialog() == DialogResult.OK)
				{
					using (Waiting waiting = new Waiting(this, labelProcessing))
					{
						PrintConsole("ファイルが選択されました：" + ofDialog.FileName);
						string fileName = ofDialog.FileName;
						OpenScenario(fileName);
					}
				}
				else
				{
					Console.WriteLine("キャンセルされました。");
				}
			}
		}

		// シナリオファイルを保存するボタン
		private void SaveScenarioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (processing) return;
			using (SaveFileDialog sfDialog = new SaveFileDialog
			{
				Title = "ファイルを保存する",
				//FileName = scenario.scenarioFile + ".vns",
				FileName = master.SimName + ".vns",
				Filter = "シナリオファイル(*.vns)|*.vns"
			})
			{
				if (sfDialog.ShowDialog() == DialogResult.OK)
				{
					using (Waiting waiting = new Waiting(this, labelProcessing))
					{
						PrintConsole("ファイルが選択されました：" + sfDialog.FileName);
						string fileName = sfDialog.FileName;
						SaveScenario(fileName);
					}
				}
				else
				{
					Console.WriteLine("キャンセルされました。");
				}
			}

		}

		// ノード図上でカーソルが動いたとき、座標を変更する
		private void PictureBoxNodeMap_MouseMove(object sender, MouseEventArgs e)
		{
			Point p = nodeMap.RevNormalize(new Point(e.Location.X, e.Location.Y));
			labelCoordinate.Text = "座標：(" + p.X + ", " + p.Y + ")";
		}

		// ノード図上にカーソルが入ったとき、座標を可視にする
		private void PictureBoxNodeMap_MouseEnter(object sender, EventArgs e)
		{
			labelCoordinate.Visible = true;
		}

		// ノード図上からカーソルが出たとき、座標を不可視にする
		private void PictureBoxNodeMap_MouseLeave(object sender, EventArgs e)
		{
			labelCoordinate.Visible = false;
		}

		// ラウンドを変更するトラックバー
		private void TrackBarRound_Scroll(object sender, EventArgs e)
		{
			//round = trackBarRound.Value;
			ChangeRound(trackBarRound.Value, trackBarRound.Name);
		}

		// シミュレーション速度を変更するトラックバー
		private void TrackBarPlaySpeed_Scroll(object sender, EventArgs e)
		{
			playSpeed = trackBarPlaySpeed.Value;
			labelPlaySpeed.Text = (playSpeed) + " (round/s)";
		}

		// 表示するアルゴリズムを選択するコンボボックス
		private void CmbBoxAlgo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (changingEnabledAlgorithm) return;
			ChangeEnabledAlgorithm(algorithms[cmbBoxAlgo.SelectedIndex], cmbBoxAlgo.Name);
		}

		private void ChartReceivedData_MouseMove(object sender, MouseEventArgs e)
		{
			var pos = e.Location;
			if (prevPosition.HasValue && pos == prevPosition.Value) return;

			tooltip.RemoveAll();
			prevPosition = pos;
			var results = chartReceivedData.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
			foreach (var result in results)
			{
				if (result.ChartElementType == ChartElementType.DataPoint)
				{
					var valueX = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
					var valueY = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
					var text = "";
					text += "x: " + valueX;
					text += "\ny :" + ((float)valueY).ToString();
					tooltip.Show(text, chartReceivedData, pos.X + 10, pos.Y);
				}
			}
			//if (!chartReceivedData.ClientRectangle.Contains(chartReceivedData.Mouse)) return;
			//var x = (int)Math.Round(chartReceivedData.ChartAreas[0].AxisX.PixelPositionToValue(pos.X));
			//var str = "x : " + x + "\n";
			//foreach (Sim sim in Algorithms)
			//{
			//    var l = sim.CollectedDataNumList;
			//    str += sim.AlgoName + " : " + l[x] + "\n";
			//}
			//tooltip.Show(str, chartReceivedData, pos.X+10, pos.Y);
		}

		// ラウンドテーブルで違うノードが選択されたら、そのノードをハイライトする
		private void RoundTable_SelectionChanged(object sender, EventArgs e)
		{
			if (roundTable.SelectedRows.Count == 0) return;
			selectedNodeID = (int)roundTable.SelectedRows[0].Cells[0].Value;
			nodeMap.RefreshNodeMap(EnabledNodes, selectedNodeID);
		}

		// ラウンドテーブルの１列目をソートから外す
		private void RoundTable_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
		{
			if (e.RowIndex1 == 0 || e.RowIndex2 == 0) e.Handled = true;
		}

		// 結果表で違うアルゴリズムが選択されたら、ノード図のアルゴリズムを変更する
		private void ResultTable_SelectionChanged(object sender, EventArgs e)
		{
			if (changingEnabledAlgorithm) return;
			if (resultTable.SelectedRows.Count > 0)
			{
				string algoName = (string)resultTable.SelectedRows[0].Cells[0].Value;
				foreach (Sim sim in algorithms)
				{
					if (sim.AlgoName == algoName)
					{
						ChangeEnabledAlgorithm(sim, resultTable.Name);
						return;
					}
				}
			}
		}

		// 再生停止ボタン
		private async void BtnPlayPose_Click(object sender, EventArgs e)
		{
			if (isPlaying)  //停止が押されたとき
			{
				isPlaying = !isPlaying;
				//btnPlayPose.Text = "再生";
				btnPlayPose.BackgroundImage = Properties.Resources.再生ボタン;
				ChangeRound(Round);
				cts.Cancel();
			}
			else    //再生が押されたとき
			{
				if (Round >= enabledAlgorithm.NodesList.Count)
				{
					Round = 1;
				}
				isPlaying = !isPlaying;
				//btnPlayPose.Text = "停止";
				btnPlayPose.BackgroundImage = Properties.Resources.再生停止ボタン;
				cts = new CancellationTokenSource();
				Task<int> task = PlayClustering(cts.Token);
				await task;
				if (task.Result == 0)
				{
					btnPlayPose.PerformClick();
					Console.WriteLine("シミュレーション終了しました。");
				}
			}
		}

		// 次ボタン
		private void BtnBack_Click(object sender, EventArgs e)
		{
			if (Round == 1) return;
			ChangeRound(Round - 1);
		}

		// 前ボタン
		private void BtnNext_Click(object sender, EventArgs e)
		{
			if (Round == enabledAlgorithm.NodesList.Count) return;
			ChangeRound(Round + 1);
		}
	}
}

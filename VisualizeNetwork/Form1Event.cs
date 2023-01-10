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
		// ノード配置のファイルを開くボタン
		private void BtnOpenFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofDialog = new OpenFileDialog
			{
				Title = "座標ファイルを選択"
			};

			if (ofDialog.ShowDialog() == DialogResult.OK)
			{
				PrintConsole("ファイルが選択されました。" + ofDialog.FileName);
				string fileName = ofDialog.FileName;
				List<int> integers = GetIntegers(fileName);
				initialNodes = GetInitialNodes(integers);
				WholeSimulationProcess();
			}
			else
			{
				Console.WriteLine("キャンセルされました。");
			}
			ofDialog.Dispose();
		}

		private void MenuItemCreate_Click(object sender, EventArgs e)
		{
			initialNodes = GetInitialNodes(CreateIntegers());
			WholeSimulationProcess();
		}

		// ノード図上でカーソルが動いたとき、座標を変更する
		private void PictureBoxNodeMap_MouseMove(object sender, MouseEventArgs e)
		{
			Point p = RevNormalize(new Point(e.Location.X, e.Location.Y));
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
			//enabledNodesList = algorithms[cmbBoxAlgo.SelectedIndex].nodesList;
			//enabledAlgorithm = algorithms[cmbBoxAlgo.SelectedIndex];
			if (changingEnabledAlgorithm) return;
			ChangeEnabledAlgorithm(algorithms[cmbBoxAlgo.SelectedIndex], cmbBoxAlgo.Name);
			//ChangeRound();
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
			//foreach (Sim sim in algorithms)
			//{
			//    var l = sim.CollectedDataNumList;
			//    str += sim.AlgoName + " : " + l[x] + "\n";
			//}
			//tooltip.Show(str, chartReceivedData, pos.X+10, pos.Y);
		}

		// 設定を適用するボタン
		private void BtnApply_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < initialNodes.Count; i++)
			{
				Node node = initialNodes[i];
				node.Initialize();
				double initEnergy;
				if (radioBtnConstInitEnergy.Checked) initEnergy = (double)numericUpDownInitialEnergy.Value;
				else initEnergy = rand.NextDouble() * (double)numericUpDownRange.Value + (double)numericUpDownMin.Value;
				node.E_init = initEnergy;
				initialNodes[i] = node;
			}
			WholeSimulationProcess();
		}

		// ラウンドテーブルで違うノードが選択されたら、そのノードをハイライトする
		private void RoundTable_SelectionChanged(object sender, EventArgs e)
		{
			if (roundTable.SelectedRows.Count > 0)
			{
				if (roundTable.SelectedRows[0].Index == 0) return;
				selectedNodeID = (int)roundTable.SelectedRows[0].Cells[0].Value;
				RefreshPaint(EnabledNodes);
			}
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
						//enabledNodesList = sim.nodesList;
						//ChangeRound();
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
				ChangeRound(round);
				cts.Cancel();
			}
			else    //再生が押されたとき
			{
				if (round >= enabledAlgorithm.nodesList.Count)
				{
					round = 1;
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
			if (round == 1) return;
			//round--;
			//trackBarRound.Value = round;
			ChangeRound(round - 1);
		}

		// 前ボタン
		private void BtnNext_Click(object sender, EventArgs e)
		{
			if (round == enabledAlgorithm.nodesList.Count) return;
			//round++;
			//trackBarRound.Value = round;
			ChangeRound(round + 1);
		}
	}
}

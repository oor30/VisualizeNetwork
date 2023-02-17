using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualizeNetwork
{
	public partial class Form1 : Form
	{
		private readonly NodeMap nodeMap;

		/// <summary>
		/// Visualizerをリセットする
		/// </summary>
		private void ResetView()
		{
			nodeMap.SetParameters(SimMaster.InitialNodes);

			if (algorithms.Count == 0)
			{
				MessageBox.Show("表示するシミュレーションシナリオがありません。",
					"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int maxRound = 0;
			foreach (Sim sim in algorithms)
			{
				if (maxRound < sim.LDN) maxRound = sim.LDN;
				if (sim.LDN == 0)
				{
					maxRound = Sim.R;
					break;
				}
			}

			// 変数を初期化
			tabCtrlMiddle.SelectedTab = Simulation;
			tabCtrlBottom.SelectedTab = tabResultTable;
			Round = 1;
			playSpeed = 1;
			trackBarPlaySpeed.Value = playSpeed;
			isPlaying = false;
			selectedNodeID = 0;
			labelRound.Text = "ラウンド：" + Round;
			labelScenario.Text = "シナリオ：" + master.SimName;
			trackBarRound.Value = 1;
			trackBarRound.Maximum = maxRound;
			cmbBoxAlgo.Items.Clear();
			changingEnabledAlgorithm = true;

			// 結果表にシミュレーション結果を追加・コンボボックスにアルゴリズムを追加
			foreach (Sim sim in algorithms)
			{
				cmbBoxAlgo.Items.Add(sim.AlgoName);
			}

			simBindingSource.DataSource = algorithms;

			DrawChart();
			ChangeEnabledAlgorithm(algorithms[0]);
		}

		/// <summary>
		/// 表示するアルゴリズムを変更する関数
		/// </summary>
		/// <param name="sim">アルゴリズム</param>
		/// <param name="senderName">コンポーネントの名前</param>
		private void ChangeEnabledAlgorithm(Sim sim, string senderName = "")
		{
			changingEnabledAlgorithm = true;
			enabledAlgorithm = sim;
			if (senderName != cmbBoxAlgo.Name)
			{
				for (int i = 0; i < cmbBoxAlgo.Items.Count; i++)
				{
					if (cmbBoxAlgo.Items[i].ToString() == sim.AlgoName)
					{
						cmbBoxAlgo.SelectedIndex = i;
						break;
					}
				}
			}
			if (senderName != resultTable.Name)
			{
				for (int i = 0; i < resultTable.RowCount; i++)
				{
					if (resultTable.Rows[i].Cells[0].Value.ToString() == sim.AlgoName)
					{
						resultTable.Rows[i].Selected = true;
						break;
					}
				}
			}
			ChangeRound(Round);
			changingEnabledAlgorithm = false;
		}

		/// <summary>
		/// ノード図とラウンドテーブルを更新する関数
		/// </summary>
		/// <param name="r">ラウンド</param>
		/// <param name="senderName">コンポーネントの名前</param>
		private void ChangeRound(int r, string senderName = "")
		{
			Round = r;
			if (senderName != trackBarRound.Name)
			{
				trackBarRound.Value = Round;
			}
			PrintConsole(String.Format("ノード配置図を描画：{0}, ラウンド：{1}",
				enabledAlgorithm.AlgoName, Round));
			labelRound.Text = "ラウンド：" + Round;
			nodeMap.RefreshNodeMap(EnabledNodes, selectedNodeID, checkBoxGrid.Checked);
			if (!isPlaying) nodeBindingSource.DataSource = EnabledNodes;
		}

		/// <summary>
		/// ノード図を並列処理で再生する
		/// </summary>
		/// <param name="ct"></param>
		/// <returns></returns>
		private async Task<int> PlayClustering(CancellationToken ct)
		{

			for (int i = Round; i <= enabledAlgorithm.NodesList.Count; i++)
			{
				//ct.ThrowIfCancellationRequested();
				if (ct.IsCancellationRequested) return -1;

				ChangeRound(i);
				await Task.Delay(1000 / playSpeed);
			}
			//round = 100;
			return 0;
		}
	}
}

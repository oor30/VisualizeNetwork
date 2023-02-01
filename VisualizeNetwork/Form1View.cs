using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

using static VisualizeNetwork.Config;

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
			nodeMap.SetParameters(INITIAL_NODES);

			if (scenario.algorithms.Count == 0)
			{
				MessageBox.Show("表示するシミュレーションシナリオがありません。",
					"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

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
			tabCtrlMiddle.SelectedTab = Simulation;
			tabCtrlBottom.SelectedTab = tabResultTable;
			round = 1;
			playSpeed = 1;
			trackBarPlaySpeed.Value = playSpeed;
			isPlaying = false;
			selectedNodeID = 0;
			labelRound.Text = "ラウンド：" + round;
			labelScenario.Text = "シナリオ：" + scenario.scenarioFile;
			trackBarRound.Value = 1;
			trackBarRound.Maximum = maxRound;
			cmbBoxAlgo.Items.Clear();
			changingEnabledAlgorithm = true;

			// 結果表にシミュレーション結果を追加・コンボボックスにアルゴリズムを追加
			foreach (Sim sim in scenario.algorithms)
			{
				cmbBoxAlgo.Items.Add(sim.AlgoName);
			}

			resultTable.DataSource = scenario.algorithms;

			DrawChart();
			ChangeEnabledAlgorithm(scenario.algorithms[0]);
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
			ChangeRound(round);
			changingEnabledAlgorithm = false;
		}

		/// <summary>
		/// ノード図とラウンドテーブルを更新する関数
		/// </summary>
		/// <param name="r">ラウンド</param>
		/// <param name="senderName">コンポーネントの名前</param>
		private void ChangeRound(int r, string senderName = "")
		{
			round = r;
			if (senderName != trackBarRound.Name)
			{
				trackBarRound.Value = round;
			}
			PrintConsole(String.Format("ノード配置図を描画：{0}, ラウンド：{1}",
				enabledAlgorithm.AlgoName, round));
			labelRound.Text = "ラウンド：" + round;
			nodeMap.RefreshNodeMap(EnabledNodes, selectedNodeID);
			//if (!isPlaying) RefreshRoundTable(EnabledNodes);
			if (!isPlaying) roundTable.DataSource = EnabledNodes;
		}

		/// <summary>
		/// ノード図を並列処理で再生する
		/// </summary>
		/// <param name="ct"></param>
		/// <returns></returns>
		private async Task<int> PlayClustering(CancellationToken ct)
		{

			for (int i = round; i <= enabledAlgorithm.NodesList.Count; i++)
			{
				//ct.ThrowIfCancellationRequested();
				if (ct.IsCancellationRequested) return -1;

				ChangeRound(i);
				await Task.Delay(1000 / playSpeed);
			}
			//round = 100;
			return 0;
		}

		/// <summary>
		/// ラウンドテーブルを更新する
		/// </summary>
		/// <param name="nodes">ノードリスト</param>
		private void RefreshRoundTable(List<Node> nodes)
		{
			roundTable.DataSource = nodes;
		}
	}
}

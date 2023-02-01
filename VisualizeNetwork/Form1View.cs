using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VisualizeNetwork
{
	public partial class Form1 : Form
	{
		/// <summary>
		/// Visualizerをリセットする
		/// </summary>
		private void ResetView()
		{
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
			tabControl.SelectedIndex = 0;
			tabControl1.SelectedTab = tabResultTable;
			round = 1;
			playSpeed = 1;
			trackBarPlaySpeed.Value = playSpeed;
			isPlaying = false;
			selectedNodeID = 0;
			labelRound.Text = "ラウンド：" + round;
			labelScenario.Text = "シナリオ：" + scenario.scenarioFile;
			trackBarRound.Value = 1;
			trackBarRound.Maximum = maxRound;
			//resultTable.Rows.Clear();
			cmbBoxAlgo.Items.Clear();
			changingEnabledAlgorithm = true;

			// 結果表にシミュレーション結果を追加・コンボボックスにアルゴリズムを追加
			foreach (Sim sim in scenario.algorithms)
			{
				//resultTable.Rows.Add((resultTable.Rows.Count + 1).ToString(), sim.AlgoName,
				//	sim.FDN, sim.LDN, Math.Round(sim.CHMean, 2), Math.Round(sim.CHSD, 2),
				//	Math.Round(sim.AveEnergyConsumption, 4), sim.CollectedDataNum);
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
			RefreshNodeMap(EnabledNodes);
			if (!isPlaying) RefreshRoundTable(EnabledNodes);
		}

		/// <summary>
		/// ラウンドテーブルを更新する
		/// </summary>
		/// <param name="nodes">ノードリスト</param>
		private void RefreshRoundTable(List<Node> nodes)
		{
			//roundTable.Rows.Clear();
			//double sumEnergy = 0;
			//double sumCmsEnergy = 0;
			//double sumHasCHCnt = 0;
			//int qualifiedNodeNum = 0;
			//double sumPi = 0;
			//for (int i = 0; i < scenario.N; i++)
			//{
			//	Node node = nodes[i];

			//	roundTable.Rows.Add(i, node.Status.ToString(),
			//		node.Status == StatusEnum.dead ? "-" : node.CHID.ToString(),
			//		Math.Round(node.E_r, 5), Math.Round(node.CmsEnergy, 5),
			//		node.HasCHCnt, node.UnqualifiedRound, Math.Round(node.Pi, 4));
			//	if (node.Status == StatusEnum.dead)
			//		roundTable.Rows[roundTable.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Red;
			//	if (node.UnqualifiedRound != 0)
			//		roundTable.Rows[roundTable.Rows.Count - 1].Cells[6].Style.ForeColor = Color.Red;
			//	sumEnergy += node.E_r;
			//	sumCmsEnergy += node.CmsEnergy;
			//	sumHasCHCnt += node.HasCHCnt;
			//	sumPi += node.Pi;
			//	if (node.UnqualifiedRound == 0) qualifiedNodeNum++;
			//}
			//roundTable.Rows.Insert(0, "計" + Sim.N + "個",
			//	"生存" + enabledAlgorithm.AliveNumList[SafeRound - 1] + "個",
			//	enabledAlgorithm.CHNumList[SafeRound - 1] + "個",
			//	Math.Round(sumEnergy, 5), Math.Round(sumCmsEnergy, 5),
			//	sumHasCHCnt, qualifiedNodeNum, Math.Round(sumPi, 4));

			roundTable.DataSource = nodes;
		}
	}
}

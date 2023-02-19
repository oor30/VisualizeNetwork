using System;
using System.Collections.Generic;

using static VisualizeNetwork.Config;
using static VisualizeNetwork.EnergyModel;

namespace VisualizeNetwork
{
	[Serializable()]
	internal class LEACH : Sim
	{
		protected Random rand = new Random();
		protected List<int> CHIDs = new List<int>();    //CHのリスト

		public LEACH()
		{
			AlgoName = "LEACH";
		}

		protected override void OneRound(List<Node> nodes)
		{
			CHElection(nodes);
			ClusterFormation(nodes);
			SteadyState(nodes);
		}

		protected virtual void ResetUnqualifiedRound(List<Node> nodes)
		{
			if (Round % (1 / P) == 1)   // 1/Pラウンドごとに、(1,21,41,...ラウンド時に)
			{
				for (int i = 0; i < N; i++)
				{
					Node node = nodes[i];
					node.UnqualifiedRound = 0;
					nodes[i] = node;
				}
			}
		}

		protected virtual double GetPi(List<Node> nodes, int i)
		{
			if (nodes[i].UnqualifiedRound == 0) // CHの資格あり
				return P / (1 - P * ((Round - 1) % (1 / P)));
			return 0;
		}

		protected virtual int CalcUnqualifiedRound(Node node)
		{
			return (int)Math.Round(1 / node.Pi);
		}

		/// <summary>
		/// 引数のノードリストをもとにクラスタヘッドを選出し、クラスタヘッドフラグを立てる
		/// </summary>
		/// <param AlgoName="EnabledNodes">構造体Nodeのリスト</param>
		protected virtual void CHElection(List<Node> nodes)
		{
			CHIDs.Clear();
			ResetUnqualifiedRound(nodes);
			for (int i = 0; i < nodes.Count; i++)
			{
				Node node = nodes[i];
				if (!node.IsAlive) continue;// ノードが死んでたら次
				
				// ラウンド数に応じたCH選出確立を計算
				if (node.IsAlive) node.Pi = (float)GetPi(nodes, i);
				if (node.Pi > rand.NextDouble())  // 確立T(0<=T<=1)でCHになる
				{
					node.UnqualifiedRound = (short)CalcUnqualifiedRound(node);
					CHIDs.Add(node.ID);
					SetCH(ref node);
				}
				//}
				if (node.UnqualifiedRound > 0) // CHの資格なし
				{
					node.UnqualifiedRound--;
				}
				nodes[i] = node;
			}
			if (CHNum == 0)
			{
				ForceElection(nodes);
			}
		}

		/// <summary>
		/// CHが1つも選出されない場合、強制的に選出する
		/// </summary>
		/// <param name="nodes">構造体Nodeのリスト</param>
		private void ForceElection(List<Node> nodes)
		{
			int CHnum = 1 + AliveNum / 20;
			for (int ii = 0; ii < CHnum; ii++)
			{
				int max = -1;
				int imax = -1;
				for (int i = 0; i < nodes.Count; i++)
				{
					if (nodes[i].IsCH) continue;
					int tmp = rand.Next();
					if (tmp > max)
					{
						max = tmp;
						imax = i;
					}
				}
				Node node = nodes[imax];
				CHIDs.Add(imax);
				//CHNum++;
				SetCH(ref node);
				nodes[imax] = node;
			}
		}

		/// <summary>
		/// 引数をもとにメンバノードが参加するクラスタを選択する。
		/// 最短距離のクラスタヘッドを選択する。
		/// </summary>
		/// <param AlgoName="EnabledNodes">構造体Nodeのリスト</param>
		protected virtual void ClusterFormation(List<Node> nodes)
		{
			for (int i = 0; i < nodes.Count; i++)
			{
				if (!nodes[i].IsAlive) continue;
				if (nodes[i].IsCH) continue;
				Node node = nodes[i];
				Node head = node;
				double distMin = double.MaxValue;
				foreach (int headID in CHIDs)
				{
					Node tmp = nodes[headID];
					//double dist = Dist2(tmp, node);
					double dist = SimMaster.DistTable[tmp.ID, node.ID];
					if (dist < distMin)
					{
						head = tmp;
						distMin = dist;
					}
				}
				SetMN(ref node, ref head);
				nodes[i] = node;
				nodes[node.CHID] = head;
			}
		}

		/// <summary>
		/// SteadyState中で消費する電力を計算
		/// </summary>
		/// <param AlgoName="EnabledNodes">構造体Nodeのリスト</param>
		private void SteadyState(List<Node> nodes)
		{
			for (int i = 0; i < nodes.Count; i++)
			{
				if (!nodes[i].IsAlive) continue;
				Node node = nodes[i];
				double energy = CalcEnergyConsumption(node, nodes);
				ConsumeEnergy(energy, ref node);
				nodes[i] = node;
			}
		}
	}
}
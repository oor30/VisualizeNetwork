//using System;
//using System.Collections.Generic;

//using static VisualizeNetwork.Config;
//using static VisualizeNetwork.EnergyModel;

//namespace VisualizeNetwork
//{
//	internal class HEED : Sim
//	{
//		private const double Pmin = 1e-4;
//		private const double ClusterRadius = 25;
//		private readonly List<double> CHprobList = new List<double>();
//		private readonly List<bool> isFinalCH = new List<bool>();
//		private readonly HashSet<int> CHIDs = new HashSet<int>();
//		private readonly List<double> CostList = new List<double>();
//		private readonly List<HashSet<int>> withinMyClusterRangeList = new List<HashSet<int>>();
//		private readonly Random rand = new Random();

//		HEED(List<Node> initialNodes)
//		{
//			AlgoName = "HEED";
//			for (int i = 0; i < initialNodes.Count; i++)
//			{
//				int num = 0;
//				for (int j = 0; j < initialNodes.Count; j++)
//				{
//					if (i == j) continue;
//					if (Math.Sqrt(Program.Dist2(initialNodes[i], initialNodes[j])) <= ClusterRadius)
//					{
//						num++;
//						withinMyClusterRangeList[i].Add(j);
//					}
//				}
//				Node tmp = initialNodes[i];
//				tmp.IsCH = true;
//				tmp.MemberNum = num;
//				CostList.Add(CalcEnergyConsumption(tmp, initialNodes));
//			}
//		}

//		protected override void OneRound(List<Node> nodes)
//		{
//			Initialize(nodes);
//			Repeat(nodes);
//			Finalize_(nodes);
//		}

//		private void Initialize(List<Node> nodes)
//		{
//			CHprobList.Clear();
//			isFinalCH.Clear();
//			for (int i = 0; i < nodes.Count; i++)
//			{
//				CHprobList.Add(Math.Max(P * nodes[i].E_r / nodes[i].E_init, Pmin));
//				isFinalCH.Add(false);
//			}
//		}

//		private void Repeat(List<Node> nodes)
//		{
//			for (int i = 0; i < nodes.Count; i++)
//			{
//				if (nodes[i].IsCH) continue;

//				Node node = nodes[i];
//				var tmp = new HashSet<int>(withinMyClusterRangeList[i]);
//				tmp.IntersectWith(CHIDs);
//				// クラスタ半径内にCH候補がいれば
//				if (tmp.Count > 0)
//				{
//					int least_cost_id = -1;
//					double least_cost = double.PositiveInfinity;
//					foreach (int CHID in tmp)
//					{
//						if (least_cost > CostList[CHID])
//						{
//							least_cost = CostList[CHID];
//							least_cost_id = CHID;
//						}
//					}
//					node.CHID = least_cost_id;
//					if (node.CHID == node.ID)
//					{
//						if (CHprobList[i] == 1)
//						{
//							isFinalCH[i] = true;
//							node.SetCH();
//							CHIDs.Add(i);
//						}
//						else
//						{

//						}
//					}
//				}
//				// CH確率が1なら、CHを宣言
//				else if (CHprobList[i] == 1)
//				{
//					isFinalCH[i] = true;
//					//tmp.IsCH = true;
//					//tmp.Status = "CH";
//					node.SetCH();
//					CHIDs.Add(i);
//				}
//				// CH確率が乱数より高ければ、CH候補を宣言
//				else if (rand.NextDouble() <= CHprobList[i])
//				{
//					CHIDs.Add(i);

//				}
//				nodes[i] = node;
//				CHprobList[i] = Math.Min(CHprobList[i] * 2, 1);
//			}
//		}

//		private int GetLeastCostCHID(Node node, List<Node> nodes)
//		{
//			if (CHIDs.Contains(node.ID)) return -1;

//			int head = -1;
//			double distMin = ClusterRadius;
//			foreach (int headID in CHIDs)
//			{
//				Node tmp = nodes[headID];
//				double dist = Program.Dist2(tmp, node);
//				if (dist < distMin)
//				{
//					head = tmp.ID;
//					distMin = dist;
//				}
//			}
//			return head;
//		}

//		private void Finalize_(List<Node> nodes)
//		{

//		}
//	}
//}

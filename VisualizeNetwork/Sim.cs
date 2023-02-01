using System;
using System.Collections.Generic;

using static VisualizeNetwork.Config;

namespace VisualizeNetwork
{
	[Serializable()]
	internal abstract class Sim
	{
		// 定数
		public string AlgoName { get; protected set; }     // アルゴリズム名
		public const int R = 3500;          // 最大シミュレーションラウンド数
		// 変数
		public int Round { get; private set; }   // 現在のラウンド数
		[NonSerialized]
		protected int CHNum;        // CH数
		protected int AliveNum { get; private set; }     // 生存ノード数
		private double EnergyConsumption;   // エネルギー消費量

		// シミュレーションを評価する指標
		public int FDN { get; private set; } = 0;
		public int LDN { get; private set; } = 0;
		public double CHMean { get; private set; } = 0;
		public double CHSD { get; private set; } = 0;
		public double AveEnergyConsumption { get; private set; } = 0;
		public int CollectedDataNum { get; private set; } = 0;
		public List<int> CHNumList { get; } = new List<int>();      // CH数のリスト
		public List<int> AliveNumList { get; } = new List<int>();   // 生存ノード数のリスト
		public List<int> CollectedDataNumList { get; } = new List<int>();
		public List<double> TotalEnergyConsumptionList { get; } = new List<double>();

		// 全ラウンド分のノードリスト
		public List<List<Node>> NodesList { get; } = new List<List<Node>>();

		//// パラメーター(Form1.csで設定)
		//public static List<Node> INITIAL_NODES;   // 初期ノード(CnvIntToNodes)
		//public static double[,] DIST_TABLE;  // 各ノード間の距離(CnvIntToNodes)
		//public static Node BS;				// BS(ResetParameters)
		//public static double[] DIST_BS_LIST;  // 各ノードからBSまでの距離(ResetParameters)
		//public static double P;				// CHの割合(ResetParameters)
		//public static int N => INITIAL_NODES.Count;  // ノード数
		//public static int K => (int)(N * P);			// クラスタヘッド数
		////public const int INTERVAL = 20;     // (s/Round)

		public void Run()
		{
			Round = 0;
			AliveNum = N;
			List<Node> nodes = new List<Node>(INITIAL_NODES);
			for (int i = 0; i < R; i++)
			{
				nodes = new List<Node>(nodes);
				for (int j = 0; j < N; j++)
				{
					Node node = nodes[j];
					if (node.IsAlive) node.ResetParameter();
					else if (node.Status != StatusEnum.dead) node.SetDead();
					nodes[j] = node;
				}

				Round++;
				CHNum = 0;
				EnergyConsumption = 0;
				OneRound(nodes);
				NodesList.Add(nodes);
				CHNumList.Add(CHNum);
				AliveNumList.Add(AliveNum);
				CollectedDataNum += AliveNum;
				CollectedDataNumList.Add(CollectedDataNum);
				if (i == 0) TotalEnergyConsumptionList.Add(EnergyConsumption);
				else TotalEnergyConsumptionList.Add(TotalEnergyConsumptionList[i - 1] + EnergyConsumption);

				if (AliveNum == 0) break;
			}
			FinalizeSimulation();
		}

		/// <summary>
		/// 1ラウンドで行う処理。抽象メソッド。
		/// </summary>
		/// <param name="nodes">ノードリスト</param>
		/// <returns>ノードリスト</returns>
		protected abstract void OneRound(List<Node> nodes);

		//エネルギー消費モデル
		public const double E_init = 0.5;         //(J)ノードの初期エネルギー
		public const double E_elec = 50.0e-9;   //(nj/bit)
		public const double E_DA = 5.0e-9;      //(nj/bit/signal)
		public const double d_0 = 87.0;         //(m)
		public const double e_fs = 10.0e-12;    //(pj/bit/m^2)
		public const double e_mp = 0.0013e-12;  //(pj/bit/m^4)
		//public static double PACKET_SIZE = 4000;      //(bits/node/Round)1ラウンド毎に1ノードが送信するデータサイズ
		//public const double bandwidth = 1.0e6;  //(Mb/s)
		//public const double bandwidth = 4000;    //(bits/s)

		/// <summary>
		/// 送信エネルギーを計算する
		/// </summary>
		/// <param name="m">メッセージサイズ</param>
		/// <param name="d">送信距離</param>
		/// <returns>送信エネルギー</returns>
		protected static double E_TX(double m, double d)
		{
			if (d <= d_0)
				return m * E_elec + m * e_fs * Math.Pow(d, 2);
			else
				return m * E_elec + m * e_mp * Math.Pow(d, 4);
		}

		/// <summary>
		/// 受信エネルギーを計算する
		/// </summary>
		/// <param name="m">メッセージサイズ</param>
		/// <returns>受信エネルギー</returns>
		protected static double E_RX(double m)
		{
			return m * E_elec;
		}

		/// <summary>
		/// 1ラウンドでノードが消費するエネルギー量を計算する
		/// </summary>
		/// <param name="node">計算するノード</param>
		/// <param name="nodes">ノードリスト</param>
		/// <returns>消費エネルギー量</returns>
		protected static double CalcEnergyConsumption(Node node, List<Node> nodes)
		{
			double sendMessageBit = PACKET_SIZE;
			double energy;

			Node addressNode;
			if (node.CHID == -1) addressNode = BS;
			else addressNode = nodes[node.CHID];
			double dist = Math.Sqrt(Dist2(addressNode, node));
			if (node.IsCH)
			{
				energy = E_TX(sendMessageBit, dist) + E_DA * sendMessageBit * node.MemberNum
					+ E_RX(sendMessageBit) * node.MemberNum;
			}
			else
			{
				energy = E_TX(sendMessageBit, dist);
			}
			return energy;
		}

		/// <summary>
		/// エネルギーを消費する
		/// </summary>
		/// <param name="energy">消費エネルギー量</param>
		/// <param name="node">ノード</param>
		protected void ConsumeEnergy(double energy, ref Node node)
		{
			if (!node.IsAlive) return;
			energy = Math.Min(energy, node.E_r);
			node.E_r -= energy;
			node.CmsEnergy += energy;
			EnergyConsumption += energy;
			if (node.E_r <= 0)
			{
				node.IsAlive = false;
				AliveNum--;
				if (AliveNum == N - 1) FDN = Round;
				else if (AliveNum == 0) LDN = Round;
			}
		}

		/// <summary>
		/// 2つのノード間の距離二乗を計算する
		/// </summary>
		/// <param name="a">ノードa</param>
		/// <param name="b">ノードb</param>
		/// <returns>距離二乗</returns>
		internal static double Dist2(Node a, Node b)
		{
			return Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2);
		}

		/// <summary>
		/// シミュレーションの最後に評価指標を計算する
		/// </summary>
		protected void FinalizeSimulation()
		{
			for (int j = 0; j < FDN; j++)
			{
				CHMean += CHNumList[j];
				foreach (Node node in NodesList[j])
				{
					AveEnergyConsumption += node.CmsEnergy;
				}
			}
			CHMean /= FDN;
			AveEnergyConsumption /= FDN;

			for (int j = 0; j < FDN; j++)
			{
				CHSD += Math.Pow((CHNumList[j] - CHMean), 2);
			}
			CHSD = Math.Sqrt(CHSD / N);
		}
	}
}

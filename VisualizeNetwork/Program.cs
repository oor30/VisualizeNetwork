using System;
using System.Collections.Generic;
using System.Windows.Forms;

using static VisualizeNetwork.Config;

namespace VisualizeNetwork
{
	internal static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

		// doubleの拡張メソッド
		internal static double Sqrt(this double value)
		{
			return Math.Sqrt(value);
		}

		internal static T GetSafety<T>(this List<T> list, int index)
		{
			if (list == null) throw new ArgumentNullException("list");

			if (index >= list.Count) return list[list.Count - 1];
			else if (index < 0) return list[0];
			else return list[index];
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

	}

	/// <summary>
	/// シミュレーションの設定
	/// </summary>
	internal static class Config
	{
		// パラメーター(Form1.csで設定)
		public static List<Node> INITIAL_NODES { get; private set; }   // 初期ノード(CnvIntToNodes)
		public static Node BS { get; private set; }              // BS(ResetParameters)
		public static double P { get; private set; }             // CHの割合(ResetParameters)
		public static int N => INITIAL_NODES.Count;  // ノード数
		public static int K => (int)(N * P);            // クラスタヘッド数
		public static double PACKET_SIZE { get; private set; }      //(bits/node/Round)1ラウンド毎に1ノードが送信するデータサイズ
		public static bool CONST_E_INIT { get; private set; }
		public static double E_INIT { get; private set; }         //(J)ノードの初期エネルギー
		public static double E_INIT_RANGE { get; private set; }
		public static double[,] DIST_TABLE { get; private set; }  // 各ノード間の距離(CnvIntToNodes)
		public static double[] DIST_BS_LIST { get; private set; }  // 各ノードからBSまでの距離(ResetParameters)
																   //public const int INTERVAL = 20;     // (s/Round)

		public static bool ready = false;

		public static void ResetInitialNodes(List<Node> initialNodes)
		{
			INITIAL_NODES = initialNodes;

			//PrintConsole("各ノード間の距離を計算中");
			DIST_TABLE = new double[INITIAL_NODES.Count, INITIAL_NODES.Count];
			for (int i = 0; i < INITIAL_NODES.Count; i++)
			{
				for (int j = 0; j < INITIAL_NODES.Count; j++)
				{
					double dist;
					if (i == j) dist = 0;
					else if (i > j) dist = DIST_TABLE[j, i];
					else dist = Math.Sqrt(Program.Dist2(INITIAL_NODES[i], INITIAL_NODES[j]));
					DIST_TABLE[i, j] = dist;
				}
			}
		}

		public static void ResetParameter(Node bs, double p, double packetSize, bool constEInit, double E_init, double E_initRange)
		{
			BS = bs;
			P = p;
			PACKET_SIZE = packetSize;
			CONST_E_INIT = constEInit;
			E_INIT = E_init;
			E_INIT_RANGE = E_initRange;
		}

		public static void ResetDistBSList()
		{
			DIST_BS_LIST = new double[N];
			for (int i = 0; i < INITIAL_NODES.Count; i++)
			{
				double dist = Program.Dist2(INITIAL_NODES[i], BS).Sqrt();
				DIST_BS_LIST[i] = dist;
			}
			ready = true;
		}
	}

	//エネルギー消費モデル
	internal static class EnergyModel
	{
		private const double _E_elec = 50.0e-9;   //(nj/bit)
		private const double _E_DA = 5.0e-9;      //(nj/bit/signal)
		private const double _d_0 = 87.0;         //(m)
		private const double _e_fs = 10.0e-12;    //(pj/bit/m^2)
		private const double _e_mp = 0.0013e-12;  //(pj/bit/m^4)
		//public const double bandwidth = 1.0e6;  //(Mb/s)
		//public const double bandwidth = 4000;    //(bits/s)

		/// <summary>
		/// 送信エネルギーを計算する
		/// </summary>
		/// <param name="m">メッセージサイズ</param>
		/// <param name="d">送信距離</param>
		/// <returns>送信エネルギー</returns>
		internal static double E_TX(double m, double d)
		{
			if (d <= _d_0)
				return m * _E_elec + m * _e_fs * Math.Pow(d, 2);
			else
				return m * _E_elec + m * _e_mp * Math.Pow(d, 4);
		}

		/// <summary>
		/// 受信エネルギーを計算する
		/// </summary>
		/// <param name="m">メッセージサイズ</param>
		/// <returns>受信エネルギー</returns>
		internal static double E_RX(double m)
		{
			return m * _E_elec;
		}

		internal static double E_DA(double m)
		{
			return m * _E_DA;
		}

		/// <summary>
		/// 1ラウンドでノードが消費するエネルギー量を計算する
		/// </summary>
		/// <param name="node">計算するノード</param>
		/// <param name="nodes">ノードリスト</param>
		/// <returns>消費エネルギー量</returns>
		internal static double CalcEnergyConsumption(Node node, List<Node> nodes)
		{
			double sendMessageBit = PACKET_SIZE;
			double energy;

			Node addressNode;
			if (node.CHID == -1) addressNode = BS;
			else addressNode = nodes[node.CHID];
			double dist = Math.Sqrt(Program.Dist2(addressNode, node));
			if (node.IsCH)
			{
				energy = E_TX(sendMessageBit, dist) + E_DA(sendMessageBit) * node.MemberNum
					+ E_RX(sendMessageBit) * node.MemberNum;
			}
			else
			{
				energy = E_TX(sendMessageBit, dist);
			}
			return energy;
		}
	}
}
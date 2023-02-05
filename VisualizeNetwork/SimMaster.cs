using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using static VisualizeNetwork.Config;

namespace VisualizeNetwork
{
	internal class SimMaster
	{
		private readonly Random rand = new Random();
		internal delegate void PrintConsoleDelegate(string content, bool writeTime = true);
		private readonly PrintConsoleDelegate PrintConsole;
		internal delegate void ResetConfigDelegate();
		private readonly ResetConfigDelegate ResetConfig;

		internal static List<Node> InitialNodes { get; private set; }   // 初期ノード(CnvIntToNodes)
		internal static double[,] DistTable { get; private set; }  // 各ノード間の距離(CnvIntToNodes)
		internal static double[] DistBSList { get; private set; }  // 各ノードからBSまでの距離(ResetParameters)
		internal string SimName { get; private set; } = "なし";
		internal List<Sim> Algorithms { get; private set; } = new List<Sim>();

		internal SimMaster(PrintConsoleDelegate printConsole, ResetConfigDelegate resetConfig)
		{
			PrintConsole = printConsole;
			ResetConfig = resetConfig;
		}

		internal List<Sim> Run(List<int> integers, string SimName = "")
		{
			InitialNodes = CnvIntToNodes(integers);
			DistTable = GetDistTable(InitialNodes);
			return WholeSimulationProcess(InitialNodes, SimName);
		}

		internal List<Sim> WholeSimulationProcess(List<Node> initialNodes, string SimName = "")
		{
			this.SimName = SimName;
			ResetParameters(initialNodes);
			return RunSimulation();
		}

		// 座標数値をファイルから読み取る関数
		internal bool TryGetIntegers(StreamReader sr, out List<int> integers)
		{
			PrintConsole("座標を読み込み中");
			integers = new List<int>();
			// ファイルから座標を読み込む
			try
			{
				while (sr.Peek() >= 0)
				{
					string line = sr.ReadLine();
					if (line == "-1") break;

					if (!int.TryParse(line, out int i))
					{
						throw new Exception("数値に変換できませんでした。");
					}
					integers.Add(i);
				}
				if (integers.Count == 0) throw new Exception("数値が1つも読み込めませんでした。");
				//// ノード数
				//scenario.N = integers.Count;
				//// 一辺の長さ
				//scenario.widthHeight = (int)(Math.Ceiling(Math.Sqrt(integers.Max()) / 100) * 100);

				PrintConsole("読み込み完了");
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("ファイルを読み込めませんでした : " + ex.Message);
				MessageBox.Show("ファイルを読み込めませんでした。", "エラー",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		// 座標数値を無作為に生成する関数
		internal List<int> CreateIntegers(int N)
		{
			PrintConsole("座標を作成中");
			Random random = new Random();
			List<int> integers = new List<int>();

			for (int i = 0; i < N; i++)
			{
				integers.Add((int)(random.NextDouble() * Math.Pow(AREA, 2)));
			}
			integers.Sort();
			PrintConsole("作成完了");
			return integers;
		}

		// 座標数値をノードリストに変換する関数
		private List<Node> CnvIntToNodes(List<int> integers)
		{
			PrintConsole("座標を変換中");
			List<Node> initialNodes = new List<Node>();
			for (int j = 0; j < integers.Count; j++)
			{
				Node node = new Node(j, integers[j] % AREA,
					integers[j] / AREA);
				initialNodes.Add(node);
			}
			return initialNodes;
		}

		private static double[,] GetDistTable(List<Node> initialNodes)
		{
			//PrintConsole("各ノード間の距離を計算中");
			double[,] distTable = new double[initialNodes.Count, initialNodes.Count];
			for (int i = 0; i < initialNodes.Count; i++)
			{
				for (int j = 0; j < initialNodes.Count; j++)
				{
					double dist;
					if (i == j) dist = 0;
					else if (i > j) dist = distTable[j, i];
					else dist = Math.Sqrt(Program.Dist2(initialNodes[i], initialNodes[j]));
					distTable[i, j] = dist;
				}
			}
			return distTable;
		}

		private static double[] GetDistBSList(List<Node> initialNodes)
		{
			double[] distBSList = new double[N];
			for (int i = 0; i < initialNodes.Count; i++)
			{
				double dist = Program.Dist2(initialNodes[i], BS).Sqrt();
				distBSList[i] = dist;
			}
			return distBSList;
		}

		// シミュレーション前の下準備
		private void ResetParameters(List<Node> initialNodes)
		{
			PrintConsole("シミュレーションの準備中");

			DistBSList = GetDistBSList(initialNodes);
			// ノードを初期エネルギー
			for (int i = 0; i < initialNodes.Count; i++)
			{
				Node node = initialNodes[i];
				double initEnergy;
				if (CONST_E_INIT) initEnergy = E_INIT;
				else initEnergy = rand.NextDouble() * E_INIT + E_INIT_RANGE;
				node.Initialize(initEnergy);
				initialNodes[i] = node;
			}
		}

		// すべてのアルゴリズムのシミュレーションを実行
		private List<Sim> RunSimulation()
		{
			// 各アルゴリズムのインスタンスを生成してリストに格納
			Algorithms.Clear();
			//scenario.Algorithms = new List<Sim>();
			if (CHECKED_Direct) Algorithms.Add(new Direct());
			if (CHECKED_LEACH) Algorithms.Add(new LEACH());
			if (CHECKED_IEE_LEACH) Algorithms.Add(new IEE_LEACH(Mode.IEE_LEACH));
			if (CHECKED_IEE_LEACH_A) Algorithms.Add(new IEE_LEACH(Mode.IEE_LEACH_A));
			if (CHECKED_IEE_LEACH_B) Algorithms.Add(new IEE_LEACH(Mode.IEE_LEACH_B));
			if (CHECKED_My_IEE_LEACH_B) Algorithms.Add(new IEE_LEACH(Mode.My_IEE_LEACH_B));
			if (CHECKED_My_IEE_LEACH) Algorithms.Add(new IEE_LEACH(Mode.My_IEE_LEACH));

			//クラスタリングをRラウンド実行
			foreach (Sim sim in Algorithms)
			{
				PrintConsole(sim.AlgoName + ": シミュレーションを開始");
				sim.Run(InitialNodes);
			}
			PrintConsole("シミュレーションが終了しました。");

			return Algorithms;
		}
	}
}

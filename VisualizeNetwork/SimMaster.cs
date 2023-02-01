//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Windows.Forms;

//using static VisualizeNetwork.Config;

//namespace VisualizeNetwork
//{
//	internal class SimMaster
//	{
//		private Scenario scenario;
//		private readonly Random rand = new Random();
//		internal delegate void PrintConsoleDelegate(string content, bool writeTime = true);
//		private readonly PrintConsoleDelegate PrintConsole;

//		internal SimMaster(Scenario scenario, PrintConsoleDelegate printConsole)
//		{
//			this.scenario = scenario;
//			PrintConsole = printConsole;
//		}

//		public void GetInitialNodes()
//		{
//			List<int> integers = CreateIntegers();
//			List<Node> initialNodes = CnvIntToNodes(integers);
//			ResetInitialNodes(initialNodes);
//		}

//		private void WholeSimulationProcess()
//		{
//			ResetParameters();
//			RunSimulation();
//		}

//		// 座標数値をファイルから読み取る関数
//		private List<int> GetIntegers(StreamReader sr)
//		{
//			PrintConsole("座標を読み込み中");
//			List<int> integers = new List<int>();
//			// ファイルから座標を読み込む
//			try
//			{
//				string line = sr.ReadLine();
//				while (line != null && line != "-1")
//				{
//					int i = 0;
//					try
//					{
//						i = int.Parse(line);
//					}
//					catch
//					{
//						throw new Exception("数値に変換できませんでした。");
//					}
//					integers.Add(i);
//					line = sr.ReadLine();
//				}
//				if (integers.Count == 0) throw new Exception("数値が1つも読み込めませんでした。");
//				// ノード数
//				scenario.N = integers.Count;
//				// 一辺の長さ
//				scenario.widthHeight = (int)(Math.Ceiling(Math.Sqrt(integers.Max()) / 100) * 100);
//				PrintConsole("読み込み完了");
//				return integers;
//			}
//			catch (Exception ex)
//			{
//				Console.WriteLine("ファイルを読み込めませんでした : " + ex.Message);
//				MessageBox.Show("ファイルを読み込めませんでした。", "エラー",
//					MessageBoxButtons.OK, MessageBoxIcon.Error);
//				throw;
//			}
//		}

//		// 座標数値を無作為に生成する関数
//		private List<int> CreateIntegers(int N, int widthHeight)
//		{
//			PrintConsole("座標を作成中");
//			Random random = new Random();
//			List<int> integers = new List<int>();

//			for (int i = 0; i < N; i++)
//			{
//				integers.Add((int)(random.NextDouble() * Math.Pow(widthHeight, 2)));
//			}
//			integers.Sort();
//			PrintConsole("作成完了");
//			return integers;
//		}

//		// 座標数値をノードリストに変換する関数
//		private List<Node> CnvIntToNodes(List<int> integers)
//		{
//			PrintConsole("座標を変換中");
//			List<Node> initialNodes = new List<Node>();
//			for (int j = 0; j < integers.Count; j++)
//			{
//				Node node = new Node(j, integers[j] % scenario.widthHeight,
//					integers[j] / scenario.widthHeight);
//				initialNodes.Add(node);
//			}
//			return initialNodes;
//		}

//		// シミュレーション前の下準備
//		private void ResetParameters()
//		{
//			PrintConsole("シミュレーションの準備中");

//			// ノードを初期エネルギー
//			for (int i = 0; i < INITIAL_NODES.Count; i++)
//			{
//				Node node = INITIAL_NODES[i];
//				double initEnergy;
//				if (CONST_E_INIT) initEnergy = E_INIT;
//				else initEnergy = rand.NextDouble() * E_INIT + E_INIT_RANGE;
//				node.Initialize(initEnergy);
//				INITIAL_NODES[i] = node;
//			}
//		}

//		// すべてのアルゴリズムのシミュレーションを実行
//		private void RunSimulation()
//		{
//			// 各アルゴリズムのインスタンスを生成してリストに格納
//			scenario.algorithms = new List<Sim>();
//			if (cbDirect.Checked) scenario.algorithms.Add(new Direct());
//			if (cbLEACH.Checked) scenario.algorithms.Add(new LEACH());
//			if (cbIEE_LEACH.Checked) scenario.algorithms.Add(new IEE_LEACH(Mode.IEE_LEACH));
//			if (cbIEE_LEACH_A.Checked) scenario.algorithms.Add(new IEE_LEACH(Mode.IEE_LEACH_A));
//			if (cbIEE_LEACH_B.Checked) scenario.algorithms.Add(new IEE_LEACH(Mode.IEE_LEACH_B));
//			if (cbMy_IEE_LEACH_B.Checked) scenario.algorithms.Add(new IEE_LEACH(Mode.My_IEE_LEACH_B));
//			if (cbMy_IEE_LEACH.Checked) scenario.algorithms.Add(new IEE_LEACH(Mode.My_IEE_LEACH));

//			//クラスタリングをRラウンド実行
//			foreach (Sim sim in scenario.algorithms)
//			{
//				PrintConsole(sim.AlgoName + ": シミュレーションを開始");
//				sim.Run();
//			}
//			PrintConsole("シミュレーションが終了しました。");
//		}

//	}
//}

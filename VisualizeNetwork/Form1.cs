using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using VisualizeNetwork.Resources.配置データ.D600;

namespace VisualizeNetwork
{
	public partial class Form1 : Form
	{
		private Scenario scenario;
		private Sim enabledAlgorithm;
		private List<Node> EnabledNodes
		{
			get
			{
				if (round < enabledAlgorithm.NodesList.Count) return enabledAlgorithm.NodesList[round - 1];
				else return enabledAlgorithm.NodesList[enabledAlgorithm.NodesList.Count - 1];
			}
		}

		private int round = 1;
		private int playSpeed = 1;
		private bool isPlaying = false;
		private int selectedNodeID = 0;
		private CancellationTokenSource cts;
		private Point? prevPosition = null;
		private readonly ToolTip tooltip = new ToolTip();
		private static readonly Random rand = new Random();
		private bool changingEnabledAlgorithm = true;

		public Form1()
		{
			InitializeComponent();
			pictureBoxNodeMap.Image = new Bitmap(pictureBoxNodeMap.Width, pictureBoxNodeMap.Height);
			trackBarRound.Maximum = Sim.R;
			trackBarPlaySpeed.Maximum = 100;

			scenario = new Scenario
			{
				canvasW = pictureBoxNodeMap.Size.Width,
				canvasH = pictureBoxNodeMap.Size.Height,
			};
		}


		// 表示するアルゴリズムを変更する関数
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

		// ノード図とラウンドテーブルを更新する関数
		private void ChangeRound(int r, string senderName = "")
		{
			round = r;
			if (senderName != trackBarRound.Name)
			{
				trackBarRound.Value = round;
			}
			PrintConsole(String.Format("ノード配置図を描画：{0}, ラウンド：{1}", enabledAlgorithm.AlgoName, round));
			labelRound.Text = "ラウンド：" + round;
			RefreshPaint(EnabledNodes);
			if (!isPlaying) RefreshRoundTable(EnabledNodes);
		}

		// 1シミュレーション全体を実行する関数
		private void WholeSimulationProcess(string outputFolderPath = "")
		{
			ResetParameters();
			RunSimulation();
			SaveScenario(outputFolderPath);
		}

		private List<int> GetIntegers(StreamReader sr)
		{
			PrintConsole("座標を読み込み中");
			List<int> integers = new List<int>();
			// ファイルから座標を読み込む
			try
			{
				string line = sr.ReadLine();
				while (line != null && line != "-1")
				{
					int i = 0;
					try
					{
						i = int.Parse(line);
					}
					catch
					{
						throw new Exception("数値に変換できませんでした。");
					}
					integers.Add(i);
					line = sr.ReadLine();
				}
				if (integers.Count == 0) throw new Exception("数値が1つも読み込めませんでした。");
				// ノード数
				scenario.N = integers.Count;
				// 一辺の長さ
				scenario.widthHeight = (int)(Math.Ceiling(Math.Sqrt(integers.Max()) / 100) * 100);
				PrintConsole("読み込み完了");
				return integers;
			}
			catch(Exception ex)
			{
				Console.WriteLine("ファイルを読み込めませんでした : " + ex.Message);
				MessageBox.Show("ファイルを読み込めませんでした。", "エラー",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				throw;
			}
		}

		private List<int> CreateIntegers()
		{
			PrintConsole("座標を作成中");
			Random random = new Random();
			List<int> integers = new List<int>();
			// ノード数
			scenario.N = (int)numericUpDownN.Value;
			// 一辺の長さ
			scenario.widthHeight = (int)numericUpDownWidth.Value;

			for (int i = 0; i < scenario.N; i++)
			{
				integers.Add((int)(random.NextDouble() * Math.Pow(scenario.widthHeight, 2)));
			}
			integers.Sort();
			PrintConsole("作成完了");
			return integers;
		}

		private List<Node> CnvIntToNodes(List<int> integers)
		{
			PrintConsole("座標を変換中");
			List<Node> initialNodes = new List<Node>();
			for (int j = 0; j < integers.Count; j++)
			{
				double initEnergy;
				if (radioBtnConstInitEnergy.Checked) initEnergy = (double)numericUpDownInitialEnergy.Value;
				else initEnergy = rand.NextDouble() * (double)numericUpDownRange.Value + (double)numericUpDownMin.Value;
				Node node = new Node(j, integers[j] % scenario.widthHeight, integers[j] / scenario.widthHeight,
					initEnergy: initEnergy);
				initialNodes.Add(node);
			}
			return initialNodes;
		}

		// シミュレーション前の下準備
		private void ResetParameters()
		{
			PrintConsole("シミュレーションの準備中");

			// CH割合
			Sim.P = (double)numericUpDownP.Value;
			// 1ラウンドあたりの送信パケットサイズ
			Sim.packetSize = (int)numericUpDownPacketSize.Value;
			// BSの座標
			Sim.BS = new Node(-1, (int)numericUpDownBSX.Value, (int)numericUpDownBSY.Value, -1)
			{
				Status = VisualizeNetwork.status.BS
			};
			// ノードの初期エネルギー
			for (int i = 0; i < scenario.initialNodes.Count; i++)
			{
				Node node = scenario.initialNodes[i];
				node.Initialize();
				double initEnergy;
				if (radioBtnConstInitEnergy.Checked) initEnergy = (double)numericUpDownInitialEnergy.Value;
				else initEnergy = rand.NextDouble() * (double)numericUpDownRange.Value + (double)numericUpDownMin.Value;
				node.E_init = initEnergy;
				scenario.initialNodes[i] = node;
			}
		}

		// すべてのアルゴリズムのシミュレーションを実行
		private void RunSimulation()
		{
			// 各アルゴリズムのインスタンスを生成してリストに格納
			scenario.algorithms = new List<Sim>();
			if (cbDirect.Checked) scenario.algorithms.Add(new Direct());
			if (cbLEACH.Checked) scenario.algorithms.Add(new LEACH());
			if (cbIEE_LEACH.Checked) scenario.algorithms.Add(new IEE_LEACH(Mode.IEE_LEACH));
			if (cbIEE_LEACH_A.Checked) scenario.algorithms.Add(new IEE_LEACH(Mode.IEE_LEACH_A));
			if (cbIEE_LEACH_B.Checked) scenario.algorithms.Add(new IEE_LEACH(Mode.IEE_LEACH_B));
			if (cbMy_IEE_LEACH_B.Checked) scenario.algorithms.Add(new IEE_LEACH(Mode.My_IEE_LEACH_B));
			if (cbMy_IEE_LEACH.Checked) scenario.algorithms.Add(new IEE_LEACH(Mode.My_IEE_LEACH));

			//クラスタリングをRラウンド実行
			foreach (Sim sim in scenario.algorithms)
			{
				PrintConsole(sim.AlgoName + ": シミュレーションを開始");
				sim.Run(scenario.initialNodes);
			}
			PrintConsole("シミュレーションが終了しました。");
		}

		// コンソールとフォーム下部に出力
		private void PrintConsole(string content)
		{
			Console.WriteLine(string.Format("{0:HH:mm:ss.fff} : ", DateTime.Now) + content);
			labelProcessing.Text = content;
			labelProcessing.Refresh();
		}

		// シミュレーションシナリオを出力
		private void SaveScenario(string path)
		{
			PrintConsole("シミュレーションシナリオを書き出しています：" + path);
			string folderPath = "C:\\Users\\kazuk\\Desktop\\output\\" + path;
			if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
			using (FileStream fs = new FileStream(folderPath + scenario.scenarioFile + ".vns", FileMode.Create, FileAccess.Write))
			{
				try
				{
					BinaryFormatter bf = new BinaryFormatter();
					bf.Serialize(fs, scenario);
				}
				catch
				{
					MessageBox.Show("シナリオファイルを保存できませんでした。",
						"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		// シミュレーションシナリオを読み込む
		private void OpenScenario(string path)
		{
			PrintConsole("シミュレーションシナリオを読み込んでいます：" + Path.GetFileName(path));
			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				try
				{
					BinaryFormatter f = new BinaryFormatter();
					scenario = (Scenario)f.Deserialize(fs);
				}
				catch
				{
					MessageBox.Show("シナリオファイルを開けませんでした。",
						"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			ResetView();

		}
	}
}

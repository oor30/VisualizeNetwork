using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace VisualizeNetwork
{
	public partial class Form1 : Form
	{
		private readonly float canvasW, canvasH;
		private double minX, maxX, minY, maxY;
		private double rw, rh;
		private List<Node> initialNodes;
		private List<Sim> algorithms;
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
		private bool isPlaying;
		private int selectedNodeID;
		private CancellationTokenSource cts;
		private Point? prevPosition = null;
		private readonly ToolTip tooltip = new ToolTip();
		private static readonly Random rand = new Random();
		private bool changingEnabledAlgorithm = true;

		public Form1()
		{
			InitializeComponent();
			canvasW = pictureBoxNodeMap.Size.Width;
			canvasH = pictureBoxNodeMap.Size.Height;
			pictureBoxNodeMap.Image = new Bitmap(pictureBoxNodeMap.Width, pictureBoxNodeMap.Height);
			trackBarRound.Maximum = Sim.R;
			trackBarPlaySpeed.Maximum = 100;

			//algorithms = new List<Sim>
			//{
			//	new Direct(),
			//	new LEACH(),
			//	new IEE_LEACH(Mode.IEE_LEACH),
			//	new IEE_LEACH(Mode.IEE_LEACH_A),
			//	new IEE_LEACH(Mode.IEE_LEACH_B),
			//	new IEE_LEACH(Mode.My_IEE_LEACH_B),
			//	new IEE_LEACH(Mode.My_IEE_LEACH)
			//};

			//checkedListBoxAlgo.Items.Clear();
			//foreach (Sim sim in algorithms)
			//{
			//	checkedListBoxAlgo.Items.Add(sim.AlgoName);
			//	checkedListBoxAlgo.SetItemChecked(checkedListBoxAlgo.Items.Count - 1, true);
			//}
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
			tabControl.SelectedIndex = 0;
			DateTime start = DateTime.Now;
			Cursor = Cursors.WaitCursor;
			labelProcessing.Text = "...";
			labelProcessing.Visible = true;
			Setup();
			RunSimulation();
			//OutputResultJson(outputFolderPath);
			Cursor = Cursors.Default;
			labelProcessing.Visible = false;
			DateTime end = DateTime.Now;
			TimeSpan throughput = end - start;
			Console.WriteLine("合計処理時間 : {0:#.####}s", throughput.TotalSeconds);
		}

		private List<int> GetIntegers(string fileName)
		{
			PrintConsole("座標を読み込み中");
			List<int> integers = new List<int>();
			Sim.N = 100;
			Sim.widthHeight = 100;
			Sim.P = (double)numericUpDownP.Value;
			int i = 0;
			int min = int.MaxValue;
			int max = int.MinValue;
			int num = 0;
			// ファイルから座標を読み込む
			try
			{
				StreamReader sr = new StreamReader(fileName);
				string line = sr.ReadLine();
				while (line != null && line != "-1")
				{
					try
					{
						i = int.Parse(line);
					}
					catch (Exception)
					{
						Console.WriteLine("座標を数値に変換できませんでした");
						MessageBox.Show("座標を数値に変換できませんでした。", "エラー");
					}
					num++;
					if (min > i) min = i;
					if (max < i) max = i;
					integers.Add(i);
					line = sr.ReadLine();
				}
				sr.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine("ファイルを読み込めませんでした : " + ex.Message);
			}
			finally
			{
				PrintConsole("読み込み完了");
			}
			return integers;
		}

		private List<int> GetIntegersFromRes(string path)
		{
			var assm = Assembly.GetExecutingAssembly();
			var stream = assm.GetManifestResourceStream("VisualizeNetwork.Resources.配置データ." + path);
			PrintConsole("座標を読み込み中：path");
			List<int> integers = new List<int>();
			Sim.N = 100;
			Sim.widthHeight = 100;
			Sim.P = (double)numericUpDownP.Value;
			int i = 0;
			int min = int.MaxValue;
			int max = int.MinValue;
			int num = 0;
			// ファイルから座標を読み込む
			try
			{
				StreamReader sr = new StreamReader(stream);
				string line = sr.ReadLine();
				while (line != null && line != "-1")
				{
					try
					{
						i = int.Parse(line);
					}
					catch (Exception)
					{
						Console.WriteLine("座標を数値に変換できませんでした");
						MessageBox.Show("座標を数値に変換できませんでした。", "エラー");
					}
					num++;
					if (min > i) min = i;
					if (max < i) max = i;
					integers.Add(i);
					line = sr.ReadLine();
				}
				sr.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine("ファイルを読み込めませんでした : " + ex.Message);
			}
			finally
			{
				PrintConsole("読み込み完了");
			}
			return integers;
		}

		private List<int> CreateIntegers()
		{
			PrintConsole("座標を作成中");
			Random random = new Random();
			List<int> integers = new List<int>();
			Sim.N = (int)numericUpDownN.Value;
			Sim.widthHeight = (int)numericUpDownWidth.Value;
			Sim.P = (double)numericUpDownP.Value;

			for (int i = 0; i < Sim.N; i++)
			{
				integers.Add((int)(random.NextDouble() * Math.Pow(Sim.widthHeight, 2)));
			}
			integers.Sort();
			PrintConsole("作成完了");
			return integers;
		}

		private List<Node> GetInitialNodes(List<int> integers)
		{
			PrintConsole("座標を変換中");
			List<Node> initialNodes = new List<Node>();
			bool firstLoop;
			// Y軸の範囲を入力するダイアログを表示
			//ConfigFileDialog configFileDialog = new ConfigFileDialog();
			//configFileDialog.label1.Text = "ノード数：" + num;
			//configFileDialog.label2.Text = "最小値：" + min;
			//configFileDialog.label3.Text = "最大値：" + max;

			int y_range;
			//if (configFileDialog.ShowDialog() == DialogResult.OK)
			//    y_range = configFileDialog.getRangeY();
			//else
			//    return;

			y_range = Sim.widthHeight;

			// 座標に変換
			firstLoop = true;
			maxX = 0;
			minX = 0;
			maxY = 0;
			minY = 0;
			//Sim.packetSize = (int)numericUpDownPacketSize.Value;
			for (int j = 0; j < integers.Count; j++)
			{
				double initEnergy;
				if (radioBtnConstInitEnergy.Checked) initEnergy = (double)numericUpDownInitialEnergy.Value;
				else initEnergy = rand.NextDouble() * (double)numericUpDownRange.Value + (double)numericUpDownMin.Value;
				Node node = new Node(j, integers[j] % y_range, integers[j] / y_range, initEnergy: initEnergy);
				initialNodes.Add(node);
				if (firstLoop || minX > node.X) minX = node.X;
				if (firstLoop || minY > node.Y) minY = node.Y;
				if (firstLoop || maxX < node.X) maxX = node.X;
				if (firstLoop || maxY < node.Y) maxY = node.Y;
				if (firstLoop) firstLoop = false;
			}
			return initialNodes;
		}

		// シミュレーション前の下準備
		private void Setup()
		{
			PrintConsole("シミュレーションの準備中");
			// 座標を正規化する
			double w = maxX - minX;
			double h = maxY - minY;
			rw = canvasW / w;
			rh = canvasH / h;

			// 変数を初期化
			round = 1;
			labelRound.Text = "ラウンド：" + round;
			trackBarRound.Value = 1;
			isPlaying = false;
			resultTable.Rows.Clear();
			cmbBoxAlgo.Items.Clear();
			selectedNodeID = 0;
			Sim.packetSize = (int)numericUpDownPacketSize.Value;

			// 各アルゴリズムのインスタンスを生成してリストに格納
			algorithms = new List<Sim>();
			if (cbDirect.Checked) algorithms.Add(new Direct());
			if (cbLEACH.Checked) algorithms.Add(new LEACH());
			if (cbIEE_LEACH.Checked) algorithms.Add(new IEE_LEACH(Mode.IEE_LEACH));
			if (cbIEE_LEACH_A.Checked) algorithms.Add(new IEE_LEACH(Mode.IEE_LEACH_A));
			if (cbIEE_LEACH_B.Checked) algorithms.Add(new IEE_LEACH(Mode.IEE_LEACH_B));
			if (cbMy_IEE_LEACH_B.Checked) algorithms.Add(new IEE_LEACH(Mode.My_IEE_LEACH_B));
			if (cbMy_IEE_LEACH.Checked) algorithms.Add(new IEE_LEACH(Mode.My_IEE_LEACH));

			Sim.BS = new Node(-1, (int)numericUpDownBSX.Value, (int)numericUpDownBSY.Value, -1)
			{
				Status = VisualizeNetwork.status.BS
			};//BS
		}

		// すべてのアルゴリズムのシミュレーションを実行
		private void RunSimulation()
		{
			//クラスタリングをRラウンド実行
			foreach (Sim sim in algorithms)
			{
				PrintConsole(sim.AlgoName + ": シミュレーションを開始");
				sim.Run(initialNodes);
			}
			AddDataResultTable();
			ChangeEnabledAlgorithm(algorithms[0]);
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
			trackBarRound.Maximum = maxRound;

			DrawChart();
			PrintConsole("シミュレーションが終了しました。");
		}

		// コンソールとフォーム下部に出力
		private void PrintConsole(string content)
		{
			Console.WriteLine(string.Format("{0:HH:mm:ss.fff} : ", DateTime.Now) + content);
			labelProcessing.Text = content;
			labelProcessing.Refresh();
		}

		// シミュレーションをJSONで出力
		private void OutputResultJson(string path)
		{
			PrintConsole("シミュレーション結果を書き出しています：" + path);
			string folderPath = "C:\\Users\\kazuk\\OneDrive - 岐阜大学\\デスクトップ\\output\\" + path;
			if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
			foreach (var sim in algorithms)
			{
				PrintConsole("Jsonシリアライズ中");
				string jsonStr = JsonSerializer.Serialize(sim);
				PrintConsole("書き込み中");
				var writer = new StreamWriter(folderPath + sim.AlgoName + ".json", false, Encoding.UTF8);
				writer.Write(jsonStr);
				writer.Dispose();
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

using static VisualizeNetwork.Config;

namespace VisualizeNetwork
{
	public partial class Form1 : Form
	{
		private List<Sim> algorithms;
		private Sim enabledAlgorithm;
		private List<Node> EnabledNodes
		{
			get
			{
				if (Round < enabledAlgorithm.NodesList.Count) return enabledAlgorithm.NodesList[Round - 1];
				else return enabledAlgorithm.NodesList[enabledAlgorithm.NodesList.Count - 1];
			}
		}

		public int Round { get; set; } = 1;
		private int playSpeed = 1;
		private bool isPlaying = false;
		private int selectedNodeID = 0;
		private CancellationTokenSource cts;
		private Point? prevPosition = null;
		private readonly ToolTip tooltip = new ToolTip();
		private bool changingEnabledAlgorithm = true;
		readonly SimMaster master;

		public Form1()
		{
			InitializeComponent();
			pictureBoxNodeMap.Image = new Bitmap(pictureBoxNodeMap.Width, pictureBoxNodeMap.Height);
			trackBarPlaySpeed.Maximum = 50;
			//scenario = new Scenario();
			nodeMap = new NodeMap(pictureBoxNodeMap);
			form1BindingSource.DataSource = Round;
			master = new SimMaster(PrintConsole, ResetConfig);
		}

		private void ResetConfig()
		{
			BS = new Node(-1, (int)numericUpDownBSX.Value, (int)numericUpDownBSY.Value);
			P = (double)numericUpDownP.Value;
			PACKET_SIZE = (int)numericUpDownPacketSize.Value;
			CONST_E_INIT = radioBtnConstInitEnergy.Checked;
			E_INIT = (double)numericUpDownInitialEnergy.Value;
			E_INIT_RANGE = (double)numericUpDownRange.Value;
			AREA = (int)numericUpDownWidth.Value;

			if (cbDirect.Checked) CHECKED_Direct = true;
			if (cbLEACH.Checked) CHECKED_LEACH = true;
			if (cbIEE_LEACH.Checked) CHECKED_IEE_LEACH = true;
			if (cbIEE_LEACH_A.Checked) CHECKED_IEE_LEACH_A = true;
			if (cbIEE_LEACH_B.Checked) CHECKED_IEE_LEACH_B = true;
			if (cbMy_IEE_LEACH_B.Checked) CHECKED_My_IEE_LEACH_B = true;
			if (cbMy_IEE_LEACH.Checked) CHECKED_My_IEE_LEACH = true;
		}

		// コンソールとフォーム下部に出力
		internal void PrintConsole(string content, bool writeTime = true)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<string, bool>(PrintConsole), content, writeTime);
				return;
			}
			if (writeTime) content = string.Format("{0:HH:mm:ss.fff} : ", DateTime.Now) + content;
			Console.WriteLine(content);
			textBoxLog.AppendText(content + Environment.NewLine);
		}

		// シミュレーションシナリオを保存
		private void SaveScenario(string path)
		{
			PrintConsole("シミュレーションシナリオを書き出しています：" + path);
			using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
			{
				try
				{
					BinaryFormatter bf = new BinaryFormatter();
					bf.Serialize(fs, master.Algorithms);
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
					BinaryFormatter bf = new BinaryFormatter();
					algorithms = (List<Sim>)bf.Deserialize(fs);
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

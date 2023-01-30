using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VisualizeNetwork.Resources.配置データ.D600
{
	[Serializable()]
	public class Scenario
	{
		// 1.integers生成時
		public int N;
		public int widthHeight;
		// 2.integersからノードリストへ変換時
		public List<Node> initialNodes;
		public string scenarioFile = "なし";
		// 3.ResetParameters()内
		public float canvasW, canvasH;
		public double minX, maxX, minY, maxY;
		public double rw, rh;
		// 4.RunSimulation()内
		internal List<Sim> algorithms = new List<Sim>();
	}

	public readonly struct Records
	{
		public Point BS { get; }
		public Dictionary<string, Record> record { get; }

		public Records(Dictionary<string, Record> record, Node BS)
		{
			this.BS = new Point((int)BS.X, (int)BS.Y);
			this.record = record;
		}
	}

	public class Record
	{
		public List<int> FDN = new List<int>();
		public List<int> LDN = new List<int>();
		public double FDNMean
		{
			get
			{
				double sum = 0;
				foreach (int i in FDN)
				{
					sum += i;
				}
				return sum / FDN.Count;
			}
		}
		public double LDNMean
		{
			get
			{
				double sum = 0;
				foreach (int i in LDN)
				{
					sum += i;
				}
				return sum / FDN.Count;
			}
		}

		public void Add(int FDN, int LDN)
		{
			this.FDN.Add(FDN);
			this.LDN.Add(LDN);
		}

		public string GetMean()
		{
			return "平均FDN" + FDNMean.ToString() + ", 平均LDN：" + LDNMean;
		}
	}

	public class Waiting : IDisposable
	{
		private readonly Form1 form1;
		private readonly Label labelProcessing;
		private readonly DateTime start;
		public Waiting(Form1 form1, Label labelProcessing)
		{
			this.form1 = form1;
			form1.Cursor = Cursors.WaitCursor;
			this.labelProcessing = labelProcessing;
			labelProcessing.Text = "...";
			labelProcessing.Visible = true;
			start = DateTime.Now;
		}

		public void Dispose()
		{
			form1.Cursor = Cursors.Default;
			labelProcessing.Visible = false;
			DateTime end = DateTime.Now;
			TimeSpan throughput = end - start;
			form1.PrintConsole(string.Format("合計処理時間 : {0:#.####}s", throughput.TotalSeconds), false);
		}
	}
}

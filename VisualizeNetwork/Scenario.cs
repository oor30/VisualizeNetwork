using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VisualizeNetwork
{
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
		public List<int> CollectedDataNum = new List<int>();

		[Name("アルゴリズム")]
		public string Name { get; }
		[Name("FDN")]
		public double FDNMean { get { return Math.Round(FDN.Average(), 1); } }
		[Name("LDN")]
		public double LDNMean { get { return Math.Round(LDN.Average(), 1); } }
		[Name("収集データ数")]
		public double CollectedDataNumMean { get { return Math.Round(CollectedDataNum.Average(), 1); } }

		public Record(string name)
		{
			Name = name;
		}

		public void Add(int FDN, int LDN, int CollectedDataNum)
		{
			this.FDN.Add(FDN);
			this.LDN.Add(LDN);
			this.CollectedDataNum.Add(CollectedDataNum);
		}

		public string GetMean()
		{
			return "平均FDN" + FDNMean.ToString() + ", 平均LDN：" + LDNMean;
		}
	}

	public class Waiting : IDisposable
	{
		private readonly Form1 form1;
		private readonly ToolStripStatusLabel labelProcessing;
		private readonly DateTime start;
		public Waiting(Form1 form1, ToolStripStatusLabel labelProcessing)
		{
			this.form1 = form1;
			form1.Cursor = Cursors.WaitCursor;
			this.labelProcessing = labelProcessing;
			labelProcessing.Text = "...";
			start = DateTime.Now;
		}

		public void Dispose()
		{
			form1.Cursor = Cursors.Default;
			labelProcessing.Text = "準備完了";
			DateTime end = DateTime.Now;
			TimeSpan throughput = end - start;
			form1.PrintConsole(string.Format("合計処理時間 : {0:#.####}s", throughput.TotalSeconds), false);
		}
	}
}

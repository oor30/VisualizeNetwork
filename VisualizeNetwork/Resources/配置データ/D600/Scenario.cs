using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VisualizeNetwork.Resources.配置データ.D600
{
	[Serializable()]
	public class Scenario
	{
		public int N;
		public int widthHeight;
		public float canvasW, canvasH;
		public double minX, maxX, minY, maxY;
		public double rw, rh;
		public List<Node> initialNodes;
		public string scenarioFile = "なし";
		internal List<Sim> algorithms = new List<Sim>();
	}

	public class Waiting : IDisposable
	{
		private Cursor cursor;
		private Form1 form1;
		private Label labelProcessing;
		private readonly DateTime start;
		public Waiting(Form1 form1, Label labelProcessing)
		{
			this.form1 = form1;
			form1.Cursor = Cursors.WaitCursor;
			this.labelProcessing = labelProcessing;
			cursor = Cursors.WaitCursor;
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
			Console.WriteLine("合計処理時間 : {0:#.####}s", throughput.TotalSeconds);
		}
	}
}

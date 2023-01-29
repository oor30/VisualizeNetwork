using System;
using System.Collections.Generic;
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
			Console.WriteLine("合計処理時間 : {0:#.####}s", throughput.TotalSeconds);
		}
	}
}

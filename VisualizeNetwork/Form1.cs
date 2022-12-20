using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using MathNet.Numerics.Statistics;

namespace VisualizeNetwork
{
    public partial class Form1 : Form
    {
        private float canvasW, canvasH;
        private double minX, maxX, minY, maxY;
        private double rw, rh;
        private Graphics g;
        private List<List<Node>> nodesList;
        private List<Sim> algorithms;
        private bool isPlaying;
        private int round;
        private int playSpeed = 1;
        CancellationTokenSource cts;
        private Direct direct;
        private LEACH leach;
        private IEE_LEACH iee_leach;
        private IEE_LEACH iee_leach_a;
        private IEE_LEACH iee_leach_b;

        public Form1()
        {
            InitializeComponent();
            canvasW = pictureBox1.Size.Width;
            canvasH = pictureBox1.Size.Height;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            trackBar1.Maximum = Sim.R;
            trackBar2.Maximum = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Title = "座標ファイルを選択";

            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("ファイルが選択されました。" + ofDialog.FileName);
                string fileName = ofDialog.FileName;
                MainProcess(fileName);
            }
            else
            {
                Console.WriteLine("キャンセルされました。");
            }
            ofDialog.Dispose();
        }

        private async void MainProcess(string fileName)
        {
            List<Node> nodes = new List<Node>();
            List<int> integers = new List<int>();
            bool firstLoop;

            int i = 0;
            int min = 0;
            int max = 0;
            int num = 0;

            // ファイルから座標を読み込む
            try
            {
                StreamReader sr = new StreamReader(fileName);
                string line = sr.ReadLine();

                firstLoop = true;
                while (line != null && line != "-1")
                {
                    Console.WriteLine(line);
                    try
                    {
                        i = Int32.Parse(line);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("座標を数値に変換できませんでした");
                        MessageBox.Show("座標を数値に変換できませんでした。", "エラー");
                    }
                    num++;
                    if (firstLoop || min > i) min = i;
                    if (firstLoop || max < i) max = i;
                    integers.Add(i);

                    firstLoop = false;
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("エラー:" + ex.Message);
            }
            finally
            {
                Console.WriteLine("読み込み完了");
            }

            // Y軸の範囲を入力するダイアログを表示
            ConfigFileDialog configFileDialog = new ConfigFileDialog();
            configFileDialog.label1.Text = "ノード数：" + num;
            configFileDialog.label2.Text = "最小値：" + min;
            configFileDialog.label3.Text = "最大値：" + max;

            int y_range;
            //if (configFileDialog.ShowDialog() == DialogResult.OK)
            //    y_range = configFileDialog.getRangeY();
            //else
            //    return;

            y_range = 100;

            // 座標に変換
            firstLoop = true;
            maxX = 0;
            minX = 0;
            maxY = 0;
            minY = 0;
            for (int j = 0; j < integers.Count; j++)
            {
                Node node = new Node(j, integers[j] % y_range, integers[j] / y_range, j / 50);
                nodes.Add(node);
                if (firstLoop || minX > node.X) minX = node.X;
                if (firstLoop || minY > node.Y) minY = node.Y;
                if (firstLoop || maxX < node.X) maxX = node.X;
                if (firstLoop || maxY < node.Y) maxY = node.Y;
                if (firstLoop) firstLoop = false;
            }

            // 座標を正規化する
            double w = maxX - minX;
            double h = maxY - minY;
            rw = canvasW / w;
            rh = canvasH / h;

            round = 1;
            label2.Text = "ラウンド：" + round;
            trackBar1.Value = 1;
            isPlaying = false;

            direct = new Direct();
            leach = new LEACH();
            iee_leach = new IEE_LEACH(Mode.IEE_LEACH);
            iee_leach_a = new IEE_LEACH(Mode.IEE_LEACH_A);
            iee_leach_b = new IEE_LEACH(Mode.IEE_LEACH_B);
            algorithms = new List<Sim>();
            algorithms.Add(direct);
            algorithms.Add(leach);
            algorithms.Add(iee_leach);
            algorithms.Add(iee_leach_a);
            algorithms.Add(iee_leach_b);
            //クラスタリングをRラウンド実行
            resultTable.Rows.Clear();
            cmbBoxAlg.Items.Clear();
            foreach (Sim sim in algorithms)
            {
                sim.Run(nodes);
                double stdDev = 0;
                double mean = 0;
                for (int j = 0; j < sim.FDN; j++)
                {
                    mean += sim.CHNumList[j];
                }
                mean = mean / sim.FDN;
                for (int j = 0; j < sim.FDN; j++)
                {
                    stdDev += Math.Pow((sim.CHNumList[j] - mean), 2);
                }
                stdDev = Math.Sqrt(stdDev/Sim.N);
                resultTable.Rows.Add(sim.AlgoName, sim.FDN, sim.LDN, Math.Round(mean, 2), Math.Round(stdDev, 2));
                cmbBoxAlg.Items.Add(sim.AlgoName);
            }
            nodesList = algorithms[0].nodesList;
            cmbBoxAlg.SelectedIndex = 0;

            paint(g, nodesList[0]);
            g.Dispose();

            DrawChart();
        }

        private void DrawChart()
        {
            chartAliveNums.ChartAreas.Clear();
            chartAliveNums.Series.Clear();
            ChartArea chartArea = new ChartArea("chartArea");
            chartArea.AxisX.Minimum = 700;
            chartArea.AxisX.Maximum = 1700;
            chartArea.AxisX.Title = "Number of rounds";
            chartArea.AxisY.Title = "Number of nodes alive";
            chartAliveNums.ChartAreas.Add(chartArea);

            chartNumCH.ChartAreas.Clear();
            chartNumCH.Series.Clear();
            ChartArea chartArea1 = new ChartArea("chartArea1");
            chartArea1.AxisX.Minimum = 0;
            chartArea1.AxisX.Title = "Number of rounds";
            chartArea1.AxisY.Title = "Number of CH";
            chartNumCH.ChartAreas.Add(chartArea1);

            foreach (Sim sim in algorithms)
            {
                Series series = new Series();
                series.ChartType = SeriesChartType.Line;
                series.LegendText = sim.AlgoName;
                for (int i = 0; i < sim.AliveNumList.Count; i++)
                {
                    series.Points.AddXY(i, sim.AliveNumList[i]);
                }
                chartAliveNums.Series.Add(series); 

                series = new Series();
                series.ChartType = SeriesChartType.Line;
                series.LegendText = sim.AlgoName;
                for (int i = 0; i < sim.CHNumList.Count; i+=50)
                {
                    series.Points.AddXY(i, sim.CHNumList[i]);
                }
                chartNumCH.Series.Add(series);
            }
        }

        private async void paint(Graphics g, List<Node> nodes)
        {
            // 座標リストからノードを描画する
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            paintNodes(g, nodes);
            paintEdges(g, nodes);
            paintLine(g);
            pictureBox1.Invalidate();
            pictureBox1.Refresh();
            g.Dispose();

            RefreshTable(nodes);
        }

        private void paintNodes(Graphics g, List<Node> nodes)
        {
            Pen pen;
            foreach (Node node in nodes)
            {
                if (node.Alive)
                    if (node.IsCH) pen = new Pen(Color.Blue);
                    else pen = new Pen(Color.Black);
                else
                    pen = new Pen(Color.Red);
                Point p = normalize(node);
                lock (g)
                {
                    g.DrawEllipse(pen, (int)(p.X - 5), (int)(p.Y - 5), 10, 10);
                    if(node.IsCH) g.FillPie(Brushes.Blue, (int)(p.X - 5), (int)(p.Y - 5), 10, 10, 0, (int)(node.E_r / Sim.E_init * 360));
                    else g.FillPie(Brushes.Gray, (int)(p.X - 5), (int)(p.Y - 5), 10, 10, 0, (int)(node.E_r/Sim.E_init*360));
                }
            }
            return;
        }

        private void RefreshTable(List<Node> nodes)
        {
            tableEnergy.Rows.Clear();
            double sumEnergy = 0;
            double sumCmsEnergy = 0;
            double sumHasCHCnt = 0;
            int numCH = 0;
            for (int i = 0; i < Sim.N; i++)
            {
                string CHID = nodes[i].headID.ToString();
                if (nodes[i].IsCH)
                {
                    CHID = "CH";
                    numCH++;
                }
                else if (nodes[i].headID == -1) CHID = "BS";
                tableEnergy.Rows.Add(i, CHID, Math.Round(nodes[i].E_r, 5),
                    Math.Round(nodes[i].cmsEnergy, 5), nodes[i].hasCHCnt, nodes[i].unqualifiedRound);
                if (nodes[i].unqualifiedRound == 0)
                    tableEnergy.Rows[tableEnergy.Rows.Count-1].Cells[5].Style.ForeColor = Color.Red;
                sumEnergy += nodes[i].E_r;
                sumCmsEnergy += nodes[i].cmsEnergy;
                sumHasCHCnt += nodes[i].hasCHCnt;
            }
            tableEnergy.Rows.Insert(0, "合計", numCH, Math.Round(sumEnergy, 5),
                Math.Round(sumCmsEnergy, 5), sumHasCHCnt, "-");
        }

        private void paintEdges(Graphics g, List<Node> nodes)
        {
            Pen p = new Pen(Color.Black);
            foreach (Node node in nodes)
            {
                if (node.headID == -1)
                {
                    continue;
                }
                Node head = nodes[node.headID];
                if (node.ID != head.ID)
                {
                    g.DrawLine(p, normalize(node), normalize(head));
                }
            }
            return;
        }

        private void paintLine(Graphics g)
        {
            Pen pen = new Pen(Color.Gray);
            for (int i = (int)(minX - 10) / 50; i <= (maxX + 10); i += 50)
            {
                var p = normalize(new Point(i, i));
                g.DrawLine(pen, p.X, 0, p.X, canvasH);
            }
            for (int i = (int)(minY - 10) / 50; i <= (maxY + 10); i += 50)
            {
                var p = normalize(new Point(i, i));
                g.DrawLine(pen, 0, p.Y, canvasW, p.Y);
            }
        }

        private Point normalize(Node node)
        {
            return new Point((int)((node.X - minX) * rw * 0.95 + canvasW * 0.025),
                (int)((node.Y - minY) * rh * 0.95 + canvasH * 0.025));
        }

        private Point normalize(Point point)
        {
            Point p = new Point((int)((point.X - minX) * rw * 0.95 + canvasW * 0.025),
                (int)((point.Y - minY) * rh * 0.95 + canvasH * 0.025));
            return p;
        }

        private Point revNormalize(Point p)
        {
            return new Point((int)((p.X - canvasW * 0.025) / rw / 0.95 + minX),
                (int)((p.Y - canvasH * 0.025) / rh / 0.95 + minY));
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = revNormalize(new Point(e.Location.X, e.Location.Y));
            label1.Text = "座標：(" + p.X + ", " + p.Y + ")";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            round = trackBar1.Value;
            label2.Text = "ラウンド：" + round;
            Console.WriteLine(round);
            paint(g, nodesList[round - 1]);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            playSpeed = trackBar2.Value;
            label3.Text = (playSpeed) + " (round/s)";
        }

        private void cmbBoxAlg_SelectedIndexChanged(object sender, EventArgs e)
        {
            nodesList = algorithms[cmbBoxAlg.SelectedIndex].nodesList;
            paint(g, nodesList[round - 1]);
        }

        private void resultTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            cmbBoxAlg.SelectedIndex = e.RowIndex;
            nodesList = algorithms[e.RowIndex].nodesList;
            paint(g, nodesList[round - 1]);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (isPlaying)  //停止が押されたとき
            {
                isPlaying = !isPlaying;
                button2.Text = "再生";
                cts.Cancel();
            }
            else    //再生が押されたとき
            {
                if (round == nodesList.Count)
                {
                    round = 1;
                }
                isPlaying = !isPlaying;
                button2.Text = "停止";
                cts = new CancellationTokenSource();
                Task<int> task = playClustering(cts.Token);
                await task;
                if (task.Result == 0)
                {
                    button2.PerformClick();
                    Console.WriteLine("シミュレーション終了しました。");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (round == 1) return;
            round--;
            trackBar1.Value = round;
            label2.Text = "ラウンド：" + round;
            Console.WriteLine(round);
            paint(g, nodesList[round - 1]);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (round == Sim.R) return;
            round++;
            trackBar1.Value = round;
            label2.Text = "ラウンド：" + round;
            Console.WriteLine(round);
            paint(g, nodesList[round - 1]);
        }

        private async Task<int> playClustering(CancellationToken ct)
        {

            for (; round <= nodesList.Count; round++)
            {
                //ct.ThrowIfCancellationRequested();
                if (ct.IsCancellationRequested) return -1;

                paint(g, nodesList[round-1]);
                Console.WriteLine(round);
                label2.Text = "ラウンド：" + round;
                label2.Refresh();
                trackBar1.Value = round;
                await Task.Delay(1000/playSpeed);
            }
            round = 100;
            return 0;
        }
    }
}

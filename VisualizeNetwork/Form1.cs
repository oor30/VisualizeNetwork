using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VisualizeNetwork
{
    public partial class Form1 : Form
    {
        private readonly float canvasW, canvasH;
        private double minX, maxX, minY, maxY;
        private double rw, rh;
        private List<List<Node>> nodesList;
        private List<Sim> algorithms;
        private bool isPlaying;
        private int round;
        private int playSpeed = 1;
        CancellationTokenSource cts;
        private DateTime time;

        public Form1()
        {
            InitializeComponent();
            canvasW = pictureBoxNodeMap.Size.Width;
            canvasH = pictureBoxNodeMap.Size.Height;
            pictureBoxNodeMap.Image = new Bitmap(pictureBoxNodeMap.Width, pictureBoxNodeMap.Height);
            trackBarRound.Maximum = Sim.R;
            trackBarPlaySpeed.Maximum = 100;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog
            {
                Title = "座標ファイルを選択"
            };

            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("ファイルが選択されました。" + ofDialog.FileName);
                string fileName = ofDialog.FileName;
                Cursor = Cursors.WaitCursor;
                MainProcess(fileName);
                Cursor = Cursors.Default;
            }
            else
            {
                Console.WriteLine("キャンセルされました。");
            }
            ofDialog.Dispose();
        }

        private void PrintConsole(string content)
        {
            Console.WriteLine(string.Format("{0:HH:mm:ss.fff} : ", DateTime.Now) + content);
            time = DateTime.Now;
        }

        private void MainProcess(string fileName)
        {
            time = DateTime.Now;
            PrintConsole(": 座標を変換中");
            List<Node> initialNodes = GetInitialNodes(fileName);

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

            // 各アルゴリズムのインスタンスを生成してリストに格納
            algorithms = new List<Sim>
            {
                new Direct(this),
                new LEACH(this),
                new IEE_LEACH(this, Mode.IEE_LEACH),
                new IEE_LEACH(this, Mode.IEE_LEACH_A),
                new IEE_LEACH(this, Mode.IEE_LEACH_B),
                new IEE_LEACH(this, Mode.My_IEE_LEACH_B)
            };

            //クラスタリングをRラウンド実行
            foreach (Sim sim in algorithms)
            {
                PrintConsole(sim.AlgoName + ": シミュレーションを開始");
                sim.Run(initialNodes);
                AddDataResultTable(sim);
            }
            nodesList = algorithms[0].nodesList;
            cmbBoxAlgo.SelectedIndex = 0;

            PrintConsole("ノード配置図を描画");
            RefreshPaint(nodesList[0]);
            PrintConsole("グラフを描画");
            DrawChart();
        }

        private List<Node> GetInitialNodes(string fileName)
        {
            List<Node> initialNodes = new List<Node>();
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
                PrintConsole("読み込み完了");
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
                Node node = new Node(j, integers[j] % y_range, integers[j] / y_range, j / 50, radioButtonConst.Checked);
                initialNodes.Add(node);
                if (firstLoop || minX > node.X) minX = node.X;
                if (firstLoop || minY > node.Y) minY = node.Y;
                if (firstLoop || maxX < node.X) maxX = node.X;
                if (firstLoop || maxY < node.Y) maxY = node.Y;
                if (firstLoop) firstLoop = false;
            }
            return initialNodes;
        }

        private void AddDataResultTable(Sim sim)
        {
            resultTable.Rows.Add(sim.AlgoName, sim.FDN, sim.LDN, Math.Round(sim.CHMean, 2), Math.Round(sim.CHSD, 2),
                    Math.Round(sim.AveEnergyConsumption, 4), sim.CollectedDataNum);
            resultTable.Rows[resultTable.Rows.Count - 1].HeaderCell.Value = resultTable.Rows.Count.ToString();
            cmbBoxAlgo.Items.Add(sim.AlgoName);
        }

        // グラフを描画
        private void DrawChart()
        {
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
            maxRound = ((maxRound / 100) + 1) * 100;

            // 生存ノード数のグラフの設定
            chartAliveNums.ChartAreas.Clear();
            chartAliveNums.Series.Clear();
            ChartArea chartArea = new ChartArea("chartArea");
            chartArea.AxisX.Minimum = 700;
            chartArea.AxisX.Maximum = maxRound;
            chartArea.AxisX.Title = "Number of rounds";
            chartArea.AxisY.Title = "Number of nodes alive";
            chartAliveNums.ChartAreas.Add(chartArea);

            // クラスタヘッド数のグラフの設定
            chartNumCH.ChartAreas.Clear();
            chartNumCH.Series.Clear();
            ChartArea chartArea1 = new ChartArea("chartArea1");
            chartArea1.AxisX.Minimum = 0;
            chartArea1.AxisX.Maximum = maxRound;
            chartArea1.AxisX.Title = "Number of rounds";
            chartArea1.AxisY.Title = "Number of CH";
            chartNumCH.ChartAreas.Add(chartArea1);

            // クラスタヘッド数のグラフの設定
            chartReceivedData.ChartAreas.Clear();
            chartReceivedData.Series.Clear();
            ChartArea chartArea2 = new ChartArea("chartArea2");
            chartArea2.AxisX.Minimum = 0;
            chartArea2.AxisX.Maximum = maxRound;
            chartArea2.AxisX.Title = "Number of rounds";
            chartArea2.AxisY.Title = "Number of received data as BS";
            chartReceivedData.ChartAreas.Add(chartArea2);

            // クラスタヘッド数のグラフの設定
            chartTotalEnergyConsumption.ChartAreas.Clear();
            chartTotalEnergyConsumption.Series.Clear();
            ChartArea chartArea3 = new ChartArea("chartArea3");
            chartArea3.AxisX.Minimum = 0;
            chartArea3.AxisX.Maximum = maxRound;
            chartArea3.AxisX.Title = "Number of rounds";
            chartArea3.AxisY.Title = "Total Energy Consumption of the Network(J)";
            chartTotalEnergyConsumption.ChartAreas.Add(chartArea3);

            foreach (Sim sim in algorithms)
            {
                List<Series> seriesList = new List<Series>
                {
                    CreateNewSeries(sim.AlgoName),
                    CreateNewSeries(sim.AlgoName),
                    CreateNewSeries(sim.AlgoName),
                    CreateNewSeries(sim.AlgoName)
                };

                // 生存ノード数のグラフを描く
                for (int i = 0; i < sim.AliveNumList.Count; i++)
                {
                    seriesList[0].Points.AddXY(i, sim.AliveNumList[i]);
                    seriesList[2].Points.AddXY(i, sim.CollectedDataNumList[i]);
                    seriesList[3].Points.AddXY(i, sim.TotalEnergyConsumptionList[i]);
                }
                chartAliveNums.Series.Add(seriesList[0]); 
                chartReceivedData.Series.Add(seriesList[2]);
                chartTotalEnergyConsumption.Series.Add(seriesList[3]);

                // クラスタヘッド数のグラフを描く
                for (int i = 0; i < sim.CHNumList.Count; i += 50)
                {
                    seriesList[1].Points.AddXY(i, sim.CHNumList[i]);
                }
                chartNumCH.Series.Add(seriesList[1]);
            }
        }

        private Series CreateNewSeries(String algoName)
        {
            Series series = new Series
            {
                ChartType = SeriesChartType.Line,
                LegendText = algoName
            };
            return series;
        }

        private void RefreshPaint(List<Node> nodes)
        {
            labelRound.Text = "ラウンド：" + round;

            // 座標リストからノードを描画する
            Graphics g = Graphics.FromImage(pictureBoxNodeMap.Image);
            g.Clear(Color.White);
            PaintNodes(g, nodes);
            PaintEdges(g, nodes);
            PaintLine(g);
            pictureBoxNodeMap.Invalidate();
            pictureBoxNodeMap.Refresh();
            g.Dispose();

            if (!isPlaying) RefreshRoundTable(nodes);
        }

        private void PaintNodes(Graphics g, List<Node> nodes)
        {
            Pen pen;
            foreach (Node node in nodes)
            {
                if (node.IsAlive)
                    if (node.IsCH) pen = new Pen(Color.Blue);
                    else pen = new Pen(Color.Black);
                else
                    pen = new Pen(Color.Red);
                Point p = Normalize(node);
                lock (g)
                {
                    g.DrawEllipse(pen, (int)(p.X - 5), (int)(p.Y - 5), 10, 10);
                    if (node.IsCH) g.FillPie(Brushes.Blue, (int)(p.X - 5), (int)(p.Y - 5), 10, 10, 0, (int)(node.E_r / Sim.E_init * 360));
                    else g.FillPie(Brushes.Gray, (int)(p.X - 5), (int)(p.Y - 5), 10, 10, 0, (int)(node.E_r / Sim.E_init * 360));
                }
            }
            return;
        }

        private void RefreshRoundTable(List<Node> nodes)
        {
            tableEnergy.Rows.Clear();
            double sumEnergy = 0;
            double sumCmsEnergy = 0;
            double sumHasCHCnt = 0;
            int qualifiedNodeNum = 0;
            double sumPi = 0;
            int numCH = 0;
            for (int i = 0; i < Sim.N; i++)
            {
                Node node = nodes[i];
                string CHID = node.CHID.ToString();
                if (node.IsCH)
                {
                    CHID = "CH";
                    numCH++;
                }
                else if (node.CHID == -1) CHID = "BS";

                tableEnergy.Rows.Add(i, CHID, Math.Round(node.E_r, 5), Math.Round(node.CmsEnergy, 5),
                    node.HasCHCnt, node.UnqualifiedRound, Math.Round(node.Pi, 4));
                if (node.UnqualifiedRound == 0)
                    tableEnergy.Rows[tableEnergy.Rows.Count - 1].Cells[5].Style.ForeColor = Color.Red;
                sumEnergy += node.E_r;
                sumCmsEnergy += node.CmsEnergy;
                sumHasCHCnt += node.HasCHCnt;
                sumPi += node.Pi;
                if (node.UnqualifiedRound == 0) qualifiedNodeNum++;
            }
            tableEnergy.Rows.Insert(0, "合計", numCH, Math.Round(sumEnergy, 5), Math.Round(sumCmsEnergy, 5),
                sumHasCHCnt, qualifiedNodeNum, Math.Round(sumPi, 4));
        }

        private void PaintEdges(Graphics g, List<Node> nodes)
        {
            Pen p = new Pen(Color.Black);
            foreach (Node node in nodes)
            {
                if (node.CHID == -1)
                {
                    continue;
                }
                Node head = nodes[node.CHID];
                if (node.ID != head.ID)
                {
                    g.DrawLine(p, Normalize(node), Normalize(head));
                }
            }
            return;
        }

        private void PaintLine(Graphics g)
        {
            Pen pen = new Pen(Color.Gray);
            for (int i = (int)(minX - 10) / 50; i <= (maxX + 10); i += 50)
            {
                var p = Normalize(new Point(i, i));
                g.DrawLine(pen, p.X, 0, p.X, canvasH);
            }
            for (int i = (int)(minY - 10) / 50; i <= (maxY + 10); i += 50)
            {
                var p = Normalize(new Point(i, i));
                g.DrawLine(pen, 0, p.Y, canvasW, p.Y);
            }
        }

        private Point Normalize(Node node)
        {
            return new Point((int)((node.X - minX) * rw * 0.95 + canvasW * 0.025),
                (int)((node.Y - minY) * rh * 0.95 + canvasH * 0.025));
        }

        private Point Normalize(Point point)
        {
            Point p = new Point((int)((point.X - minX) * rw * 0.95 + canvasW * 0.025),
                (int)((point.Y - minY) * rh * 0.95 + canvasH * 0.025));
            return p;
        }

        private Point RevNormalize(Point p)
        {
            return new Point((int)((p.X - canvasW * 0.025) / rw / 0.95 + minX),
                (int)((p.Y - canvasH * 0.025) / rh / 0.95 + minY));
        }

        private void PictureBoxNodeMap_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = RevNormalize(new Point(e.Location.X, e.Location.Y));
            labelCoordinate.Text = "座標：(" + p.X + ", " + p.Y + ")";
        }

        private void TrackBarRound_Scroll(object sender, EventArgs e)
        {
            round = trackBarRound.Value;
            RefreshPaint(nodesList[round - 1]);
        }

        private void TrackBarPlaySpeed_Scroll(object sender, EventArgs e)
        {
            playSpeed = trackBarPlaySpeed.Value;
            labelPlaySpeed.Text = (playSpeed) + " (round/s)";
        }

        private void CmbBoxAlgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            nodesList = algorithms[cmbBoxAlgo.SelectedIndex].nodesList;
            RefreshPaint(nodesList[round - 1]);
        }

        private void ResultTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            cmbBoxAlgo.SelectedIndex = e.RowIndex;
            nodesList = algorithms[e.RowIndex].nodesList;
            RefreshPaint(nodesList[round - 1]);
        }

        private async void BtnPlayPose_Click(object sender, EventArgs e)
        {
            if (isPlaying)  //停止が押されたとき
            {
                isPlaying = !isPlaying;
                btnPlayPose.Text = "再生";
                RefreshPaint(nodesList[round - 1]);
                cts.Cancel();
            }
            else    //再生が押されたとき
            {
                if (round == nodesList.Count)
                {
                    round = 1;
                }
                isPlaying = !isPlaying;
                btnPlayPose.Text = "停止";
                cts = new CancellationTokenSource();
                Task<int> task = PlayClustering(cts.Token);
                await task;
                if (task.Result == 0)
                {
                    btnPlayPose.PerformClick();
                    Console.WriteLine("シミュレーション終了しました。");
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (round == 1) return;
            round--;
            trackBarRound.Value = round;
            RefreshPaint(nodesList[round - 1]);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (round == Sim.R) return;
            round++;
            trackBarRound.Value = round;
            RefreshPaint(nodesList[round - 1]);
        }

        private async Task<int> PlayClustering(CancellationToken ct)
        {

            for (; round <= nodesList.Count; round++)
            {
                //ct.ThrowIfCancellationRequested();
                if (ct.IsCancellationRequested) return -1;

                RefreshPaint(nodesList[round - 1]);
                trackBarRound.Value = round;
                await Task.Delay(1000 / playSpeed);
            }
            round = 100;
            return 0;
        }
    }
}

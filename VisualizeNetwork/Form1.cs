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
        private List<Node> initialNodes;
        private List<List<Node>> enabledNodesList;
        private List<Sim> algorithms;

        private int round;
        private int playSpeed = 1;
        private bool isPlaying;
        private int selectedNodeID;
        private CancellationTokenSource cts;
        private Point? prevPosition = null;
        private readonly ToolTip tooltip = new ToolTip();
        private static readonly Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            canvasW = pictureBoxNodeMap.Size.Width;
            canvasH = pictureBoxNodeMap.Size.Height;
            pictureBoxNodeMap.Image = new Bitmap(pictureBoxNodeMap.Width, pictureBoxNodeMap.Height);
            trackBarRound.Maximum = Sim.R;
            trackBarPlaySpeed.Maximum = 100;
        }

        // コンソールとフォーム下部に出力
        private void PrintConsole(string content)
        {
            Console.WriteLine(string.Format("{0:HH:mm:ss.fff} : ", DateTime.Now) + content);
            labelProcessing.Text = content;
            labelProcessing.Refresh();
        }

        private void WholeSimulationProcess()
        {
            DateTime start = DateTime.Now;
            Cursor = Cursors.WaitCursor;
            labelProcessing.Text = "...";
            labelProcessing.Visible = true;
            Setup();
            RunSimulation();
            Cursor = Cursors.Default;
            labelProcessing.Visible = false;
            DateTime end = DateTime.Now;
            TimeSpan throughput = end - start;
            Console.WriteLine("処理時間 : {0}ms", throughput.TotalMilliseconds);
        }

        private List<int> GetIntegers(string fileName)
        {
            PrintConsole("座標を読み込み中");
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
                Console.WriteLine("ファイルを読み込めませんでした : " + ex.Message);
            }
            finally
            {
                PrintConsole("読み込み完了");
            }
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

            y_range = 100;

            // 座標に変換
            firstLoop = true;
            maxX = 0;
            minX = 0;
            maxY = 0;
            minY = 0;
            Sim.packetSize = (int)numericUpDownPacketSize.Value;
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

            // 各アルゴリズムのインスタンスを生成してリストに格納
            algorithms = new List<Sim>
            {
                new Direct(),
                new LEACH(),
                new IEE_LEACH(Mode.IEE_LEACH),
                new IEE_LEACH(Mode.IEE_LEACH_A),
                new IEE_LEACH(Mode.IEE_LEACH_B),
                new IEE_LEACH(Mode.My_IEE_LEACH_B),
                new IEE_LEACH(Mode.My_IEE_LEACH)
            };
            Sim.BS = new Node(-1, (int)numericUpDownBSX.Value, (int)numericUpDownBSY.Value, -1);//BS
            Sim.BS.Status = "BS";
        }

        // すべてのアルゴリズムのシミュレーションを実行
        private void RunSimulation()
        {
            //クラスタリングをRラウンド実行
            foreach (Sim sim in algorithms)
            {
                PrintConsole(sim.AlgoName + ": シミュレーションを開始");
                sim.Run(initialNodes);
                AddDataResultTable(sim);
            }
            enabledNodesList = algorithms[0].nodesList;
            cmbBoxAlgo.SelectedIndex = 0;

            PrintConsole("ノード配置図を描画");
            RefreshPaintTable(enabledNodesList[0]);
            PrintConsole("グラフを描画");
            DrawChart();
            PrintConsole("シミュレーションが終了しました。");
        }

        // 結果表にシミュレーション結果を追加
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

            List<Chart> charts = new List<Chart>
            {
                chartAliveNums,
                chartNumCH,
                chartReceivedData,
                chartTotalEnergyConsumption
            };

            List<string> yTitles = new List<string>
            {
                "Number of nodes alive",
                "Number of CH",
                "Number of received data as BS",
                "Total Energy Consumption of the Network(J)"
            };

            for (int i = 0; i < charts.Count; i++)
            {
                Chart chart = charts[i];
                string yTitle = yTitles[i];
                chart.ChartAreas.Clear();
                chart.Series.Clear();
                ChartArea chartArea = new ChartArea("chartArea");
                chartArea.AxisX.Minimum = 0;
                chartArea.AxisX.Maximum = maxRound;
                chartArea.AxisX.Title = "Number of rounds";
                chartArea.AxisY.Title = yTitle;
                chartArea.AxisX.ScaleView.Size = 1000;
                chartArea.AxisX.IsMarginVisible = false;
                chart.ChartAreas.Add(chartArea);
            }

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
                    if (i % 50 == 0)
                        seriesList[1].Points.AddXY(i, sim.CHNumList[i]);
                    seriesList[2].Points.AddXY(i, sim.CollectedDataNumList[i]);
                    seriesList[3].Points.AddXY(i, sim.TotalEnergyConsumptionList[i]);
                }
                for (int i = 0; i < charts.Count; i++)
                {
                    charts[i].Series.Add(seriesList[i]);
                }
            }
        }

        // Seriesを作成する
        private Series CreateNewSeries(string algoName)
        {
            Series series = new Series
            {
                ChartType = SeriesChartType.Line,
                LegendText = algoName
            };
            return series;
        }

        // ノード図とラウンドテーブルを更新する
        private void RefreshPaintTable(List<Node> nodes)
        {
            labelRound.Text = "ラウンド：" + round;
            RefreshPaint(nodes);
            if (!isPlaying) RefreshRoundTable(nodes);
        }

        // ノード図を更新する
        private void RefreshPaint(List<Node> nodes)
        {
            // 座標リストからノードを描画する
            Graphics g = Graphics.FromImage(pictureBoxNodeMap.Image);
            g.Clear(Color.White);
            PaintNodes(g, nodes);
            PaintEdges(g, nodes);
            PaintLine(g);
            pictureBoxNodeMap.Invalidate();
            pictureBoxNodeMap.Refresh();
            g.Dispose();
        }

        // ノードを描画する
        private void PaintNodes(Graphics g, List<Node> nodes)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = Brushes.Gray;
            foreach (Node node in nodes)
            {
                pen.Width = 1;
                if (node.IsAlive)
                {
                    if (node.IsCH && node.CHID != -1)
                    {
                        pen.Color = Color.Green;
                        brush = Brushes.Green;
                    }
                    else if (node.IsCH)
                    {
                        pen.Color = Color.Blue;
                        brush = Brushes.Blue;
                    }
                    else
                    {
                        pen.Color = Color.Black;
                        brush = Brushes.Black;
                    }
                }
                else pen.Color = Color.Red;
                if (node.ID == selectedNodeID)
                {
                    pen.Width = 4;
                    pen.Color = Color.Yellow;
                }
                Point p = Normalize(node);
                lock (g)
                {
                    g.DrawEllipse(pen, (p.X - 5), p.Y - 5, 10, 10);
                    if (node.IsAlive)
                        g.FillPie(brush, (p.X - 5), (p.Y - 5), 10, 10, 0, (int)(node.E_r / node.E_init * 360));
                }
            }
            return;
        }

        // ラウンドテーブルを更新する
        private void RefreshRoundTable(List<Node> nodes)
        {
            roundTable.Rows.Clear();
            double sumEnergy = 0;
            double sumCmsEnergy = 0;
            double sumHasCHCnt = 0;
            int qualifiedNodeNum = 0;
            double sumPi = 0;
            int numCH = 0;
            for (int i = 0; i < Sim.N; i++)
            {
                Node node = nodes[i];

                roundTable.Rows.Add(i, node.Status, node.CHID, Math.Round(node.E_r, 5), Math.Round(node.CmsEnergy, 5),
                    node.HasCHCnt, node.UnqualifiedRound, Math.Round(node.Pi, 4));
                if (node.UnqualifiedRound == 0)
                    roundTable.Rows[roundTable.Rows.Count - 1].Cells[6].Style.ForeColor = Color.Red;
                sumEnergy += node.E_r;
                sumCmsEnergy += node.CmsEnergy;
                sumHasCHCnt += node.HasCHCnt;
                sumPi += node.Pi;
                if (node.UnqualifiedRound == 0) qualifiedNodeNum++;
            }
            roundTable.Rows.Insert(0, "合計", "", numCH, Math.Round(sumEnergy, 5), Math.Round(sumCmsEnergy, 5),
                sumHasCHCnt, qualifiedNodeNum, Math.Round(sumPi, 4));
        }

        // エッジを描画する
        private void PaintEdges(Graphics g, List<Node> nodes)
        {
            Pen pen = new Pen(Color.Black);
            foreach (Node node in nodes)
            {
                if (node.CHID == -1)
                {
                    continue;
                }
                Node head = nodes[node.CHID];
                if (node.ID != head.ID)
                {
                    if (node.IsCH) pen.Color = Color.Green;
                    else pen.Color = Color.Black;
                    g.DrawLine(pen, Normalize(node), Normalize(head));
                }
            }
            return;
        }

        // x軸,y軸を描画する
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

        // ノードの座標をノード図のピクセルに変換する
        private Point Normalize(Node node)
        {
            return new Point((int)((node.X - minX) * rw * 0.95 + canvasW * 0.025),
                (int)((node.Y - minY) * rh * 0.95 + canvasH * 0.025));
        }

        // ノードの座標をノード図のピクセルに変換する
        private Point Normalize(Point point)
        {
            Point p = new Point((int)((point.X - minX) * rw * 0.95 + canvasW * 0.025),
                (int)((point.Y - minY) * rh * 0.95 + canvasH * 0.025));
            return p;
        }

        // ノード図のピクセルをノードの座標に変換する
        private Point RevNormalize(Point p)
        {
            return new Point((int)((p.X - canvasW * 0.025) / rw / 0.95 + minX),
                (int)((p.Y - canvasH * 0.025) / rh / 0.95 + minY));
        }

        // ノード図を並列処理で再生する
        private async Task<int> PlayClustering(CancellationToken ct)
        {

            for (; round <= enabledNodesList.Count; round++)
            {
                //ct.ThrowIfCancellationRequested();
                if (ct.IsCancellationRequested) return -1;

                RefreshPaintTable(enabledNodesList[round - 1]);
                trackBarRound.Value = round;
                await Task.Delay(1000 / playSpeed);
            }
            round = 100;
            return 0;
        }
    }
}

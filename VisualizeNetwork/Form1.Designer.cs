namespace VisualizeNetwork
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param AlgoName="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBoxNodeMap = new System.Windows.Forms.PictureBox();
            this.labelCoordinate = new System.Windows.Forms.Label();
            this.trackBarRound = new System.Windows.Forms.TrackBar();
            this.labelRound = new System.Windows.Forms.Label();
            this.btnPlayPose = new System.Windows.Forms.Button();
            this.trackBarPlaySpeed = new System.Windows.Forms.TrackBar();
            this.labelPlaySpeed = new System.Windows.Forms.Label();
            this.resultTable = new System.Windows.Forms.DataGridView();
            this.algorithm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHsd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.平均消費量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS受信回数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.cmbBoxAlgo = new System.Windows.Forms.ComboBox();
            this.chartAliveNums = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartNumCH = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Simulation = new System.Windows.Forms.TabPage();
            this.tableEnergy = new System.Windows.Forms.DataGridView();
            this.nodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.残量E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.消費E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CH回数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CH無資格期間 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chart1 = new System.Windows.Forms.TabPage();
            this.Chart2 = new System.Windows.Forms.TabPage();
            this.chartTotalEnergyConsumption = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartReceivedData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.設定 = new System.Windows.Forms.TabPage();
            this.groupBoxInitialEnergy = new System.Windows.Forms.GroupBox();
            this.radioButtonRand = new System.Windows.Forms.RadioButton();
            this.radioButtonConst = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNodeMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaySpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAliveNums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNumCH)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Simulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableEnergy)).BeginInit();
            this.Chart1.SuspendLayout();
            this.Chart2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalEnergyConsumption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartReceivedData)).BeginInit();
            this.設定.SuspendLayout();
            this.groupBoxInitialEnergy.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxNodeMap
            // 
            this.pictureBoxNodeMap.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxNodeMap.Location = new System.Drawing.Point(0, 53);
            this.pictureBoxNodeMap.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxNodeMap.MaximumSize = new System.Drawing.Size(768, 750);
            this.pictureBoxNodeMap.Name = "pictureBoxNodeMap";
            this.pictureBoxNodeMap.Size = new System.Drawing.Size(764, 750);
            this.pictureBoxNodeMap.TabIndex = 0;
            this.pictureBoxNodeMap.TabStop = false;
            this.pictureBoxNodeMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxNodeMap_MouseMove);
            // 
            // labelCoordinate
            // 
            this.labelCoordinate.AutoSize = true;
            this.labelCoordinate.Location = new System.Drawing.Point(223, 20);
            this.labelCoordinate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCoordinate.Name = "labelCoordinate";
            this.labelCoordinate.Size = new System.Drawing.Size(53, 18);
            this.labelCoordinate.TabIndex = 2;
            this.labelCoordinate.Text = "座標：";
            // 
            // trackBarRound
            // 
            this.trackBarRound.Location = new System.Drawing.Point(128, 47);
            this.trackBarRound.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarRound.Maximum = 100;
            this.trackBarRound.Minimum = 1;
            this.trackBarRound.Name = "trackBarRound";
            this.trackBarRound.Size = new System.Drawing.Size(1309, 69);
            this.trackBarRound.TabIndex = 3;
            this.trackBarRound.Value = 1;
            this.trackBarRound.Scroll += new System.EventHandler(this.TrackBarRound_Scroll);
            // 
            // labelRound
            // 
            this.labelRound.AutoSize = true;
            this.labelRound.Location = new System.Drawing.Point(27, 58);
            this.labelRound.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(77, 18);
            this.labelRound.TabIndex = 4;
            this.labelRound.Text = "ラウンド：1";
            // 
            // btnPlayPose
            // 
            this.btnPlayPose.Location = new System.Drawing.Point(70, 102);
            this.btnPlayPose.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlayPose.Name = "btnPlayPose";
            this.btnPlayPose.Size = new System.Drawing.Size(77, 33);
            this.btnPlayPose.TabIndex = 5;
            this.btnPlayPose.Text = "再生";
            this.btnPlayPose.UseVisualStyleBackColor = true;
            this.btnPlayPose.Click += new System.EventHandler(this.BtnPlayPose_Click);
            // 
            // trackBarPlaySpeed
            // 
            this.trackBarPlaySpeed.Location = new System.Drawing.Point(218, 102);
            this.trackBarPlaySpeed.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarPlaySpeed.Minimum = 1;
            this.trackBarPlaySpeed.Name = "trackBarPlaySpeed";
            this.trackBarPlaySpeed.Size = new System.Drawing.Size(338, 69);
            this.trackBarPlaySpeed.TabIndex = 6;
            this.trackBarPlaySpeed.Value = 1;
            this.trackBarPlaySpeed.Scroll += new System.EventHandler(this.TrackBarPlaySpeed_Scroll);
            // 
            // labelPlaySpeed
            // 
            this.labelPlaySpeed.AutoSize = true;
            this.labelPlaySpeed.Location = new System.Drawing.Point(562, 110);
            this.labelPlaySpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlaySpeed.Name = "labelPlaySpeed";
            this.labelPlaySpeed.Size = new System.Drawing.Size(91, 18);
            this.labelPlaySpeed.TabIndex = 7;
            this.labelPlaySpeed.Text = "1 (round/s)";
            // 
            // resultTable
            // 
            this.resultTable.AllowUserToAddRows = false;
            this.resultTable.AllowUserToDeleteRows = false;
            this.resultTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.resultTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.resultTable.ColumnHeadersHeight = 34;
            this.resultTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.algorithm,
            this.FDN,
            this.LDN,
            this.CHave,
            this.CHsd,
            this.平均消費量,
            this.BS受信回数});
            this.resultTable.Location = new System.Drawing.Point(12, 1001);
            this.resultTable.Name = "resultTable";
            this.resultTable.ReadOnly = true;
            this.resultTable.RowHeadersWidth = 62;
            this.resultTable.RowTemplate.Height = 27;
            this.resultTable.Size = new System.Drawing.Size(1119, 238);
            this.resultTable.TabIndex = 8;
            this.resultTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultTable_CellDoubleClick);
            // 
            // algorithm
            // 
            this.algorithm.HeaderText = "アルゴリズム名";
            this.algorithm.MinimumWidth = 8;
            this.algorithm.Name = "algorithm";
            this.algorithm.ReadOnly = true;
            this.algorithm.Width = 146;
            // 
            // FDN
            // 
            this.FDN.HeaderText = "FDN";
            this.FDN.MinimumWidth = 8;
            this.FDN.Name = "FDN";
            this.FDN.ReadOnly = true;
            this.FDN.Width = 78;
            // 
            // LDN
            // 
            this.LDN.HeaderText = "LDN";
            this.LDN.MinimumWidth = 8;
            this.LDN.Name = "LDN";
            this.LDN.ReadOnly = true;
            this.LDN.Width = 78;
            // 
            // CHave
            // 
            this.CHave.HeaderText = "平均CH数";
            this.CHave.MinimumWidth = 8;
            this.CHave.Name = "CHave";
            this.CHave.ReadOnly = true;
            this.CHave.Width = 122;
            // 
            // CHsd
            // 
            this.CHsd.HeaderText = "CH数標準偏差";
            this.CHsd.MinimumWidth = 8;
            this.CHsd.Name = "CHsd";
            this.CHsd.ReadOnly = true;
            this.CHsd.Width = 158;
            // 
            // 平均消費量
            // 
            this.平均消費量.HeaderText = "平均消費量";
            this.平均消費量.MinimumWidth = 8;
            this.平均消費量.Name = "平均消費量";
            this.平均消費量.ReadOnly = true;
            this.平均消費量.Width = 134;
            // 
            // BS受信回数
            // 
            this.BS受信回数.HeaderText = "収集データ数";
            this.BS受信回数.MinimumWidth = 8;
            this.BS受信回数.Name = "BS受信回数";
            this.BS受信回数.ReadOnly = true;
            this.BS受信回数.Width = 140;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(13, 102);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(52, 33);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "前(&B)";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(152, 102);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(52, 33);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "次(&N)";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // cmbBoxAlgo
            // 
            this.cmbBoxAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxAlgo.FormattingEnabled = true;
            this.cmbBoxAlgo.Location = new System.Drawing.Point(5, 17);
            this.cmbBoxAlgo.Name = "cmbBoxAlgo";
            this.cmbBoxAlgo.Size = new System.Drawing.Size(213, 26);
            this.cmbBoxAlgo.TabIndex = 11;
            this.cmbBoxAlgo.SelectedIndexChanged += new System.EventHandler(this.CmbBoxAlgo_SelectedIndexChanged);
            // 
            // chartAliveNums
            // 
            chartArea1.Name = "ChartArea1";
            this.chartAliveNums.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartAliveNums.Legends.Add(legend1);
            this.chartAliveNums.Location = new System.Drawing.Point(5, 5);
            this.chartAliveNums.Name = "chartAliveNums";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartAliveNums.Series.Add(series1);
            this.chartAliveNums.Size = new System.Drawing.Size(754, 750);
            this.chartAliveNums.TabIndex = 12;
            this.chartAliveNums.Text = "v";
            // 
            // chartNumCH
            // 
            chartArea2.Name = "ChartArea1";
            this.chartNumCH.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartNumCH.Legends.Add(legend2);
            this.chartNumCH.Location = new System.Drawing.Point(765, 5);
            this.chartNumCH.Name = "chartNumCH";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartNumCH.Series.Add(series2);
            this.chartNumCH.Size = new System.Drawing.Size(786, 750);
            this.chartNumCH.TabIndex = 13;
            this.chartNumCH.Text = "v";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Simulation);
            this.tabControl1.Controls.Add(this.Chart1);
            this.tabControl1.Controls.Add(this.Chart2);
            this.tabControl1.Controls.Add(this.設定);
            this.tabControl1.Location = new System.Drawing.Point(13, 153);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1577, 843);
            this.tabControl1.TabIndex = 14;
            // 
            // Simulation
            // 
            this.Simulation.Controls.Add(this.tableEnergy);
            this.Simulation.Controls.Add(this.pictureBoxNodeMap);
            this.Simulation.Controls.Add(this.cmbBoxAlgo);
            this.Simulation.Controls.Add(this.labelCoordinate);
            this.Simulation.Location = new System.Drawing.Point(4, 28);
            this.Simulation.Margin = new System.Windows.Forms.Padding(2);
            this.Simulation.Name = "Simulation";
            this.Simulation.Padding = new System.Windows.Forms.Padding(2);
            this.Simulation.Size = new System.Drawing.Size(1569, 811);
            this.Simulation.TabIndex = 0;
            this.Simulation.Text = "Simulation";
            this.Simulation.UseVisualStyleBackColor = true;
            // 
            // tableEnergy
            // 
            this.tableEnergy.AllowUserToAddRows = false;
            this.tableEnergy.AllowUserToDeleteRows = false;
            this.tableEnergy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tableEnergy.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tableEnergy.ColumnHeadersHeight = 34;
            this.tableEnergy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nodeID,
            this.CHID,
            this.残量E,
            this.消費E,
            this.CH回数,
            this.CH無資格期間,
            this.Pi});
            this.tableEnergy.Location = new System.Drawing.Point(775, 53);
            this.tableEnergy.Margin = new System.Windows.Forms.Padding(2);
            this.tableEnergy.Name = "tableEnergy";
            this.tableEnergy.ReadOnly = true;
            this.tableEnergy.RowHeadersVisible = false;
            this.tableEnergy.RowHeadersWidth = 82;
            this.tableEnergy.RowTemplate.Height = 33;
            this.tableEnergy.Size = new System.Drawing.Size(826, 750);
            this.tableEnergy.TabIndex = 12;
            // 
            // nodeID
            // 
            this.nodeID.HeaderText = "nodeID";
            this.nodeID.MinimumWidth = 10;
            this.nodeID.Name = "nodeID";
            this.nodeID.ReadOnly = true;
            this.nodeID.Width = 96;
            // 
            // CHID
            // 
            this.CHID.HeaderText = "CHID";
            this.CHID.MinimumWidth = 8;
            this.CHID.Name = "CHID";
            this.CHID.ReadOnly = true;
            this.CHID.Width = 84;
            // 
            // 残量E
            // 
            this.残量E.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.残量E.HeaderText = "残量E";
            this.残量E.MinimumWidth = 10;
            this.残量E.Name = "残量E";
            this.残量E.ReadOnly = true;
            this.残量E.Width = 90;
            // 
            // 消費E
            // 
            this.消費E.HeaderText = "消費E";
            this.消費E.MinimumWidth = 10;
            this.消費E.Name = "消費E";
            this.消費E.ReadOnly = true;
            this.消費E.Width = 90;
            // 
            // CH回数
            // 
            this.CH回数.HeaderText = "CH回数";
            this.CH回数.MinimumWidth = 8;
            this.CH回数.Name = "CH回数";
            this.CH回数.ReadOnly = true;
            this.CH回数.Width = 104;
            // 
            // CH無資格期間
            // 
            this.CH無資格期間.HeaderText = "CH無資格期間";
            this.CH無資格期間.MinimumWidth = 8;
            this.CH無資格期間.Name = "CH無資格期間";
            this.CH無資格期間.ReadOnly = true;
            this.CH無資格期間.Width = 158;
            // 
            // Pi
            // 
            this.Pi.HeaderText = "Pi";
            this.Pi.MinimumWidth = 8;
            this.Pi.Name = "Pi";
            this.Pi.ReadOnly = true;
            this.Pi.Width = 59;
            // 
            // Chart1
            // 
            this.Chart1.Controls.Add(this.chartNumCH);
            this.Chart1.Controls.Add(this.chartAliveNums);
            this.Chart1.Location = new System.Drawing.Point(4, 28);
            this.Chart1.Margin = new System.Windows.Forms.Padding(2);
            this.Chart1.Name = "Chart1";
            this.Chart1.Padding = new System.Windows.Forms.Padding(2);
            this.Chart1.Size = new System.Drawing.Size(1569, 811);
            this.Chart1.TabIndex = 1;
            this.Chart1.Text = "Chart1";
            this.Chart1.UseVisualStyleBackColor = true;
            // 
            // Chart2
            // 
            this.Chart2.Controls.Add(this.chartTotalEnergyConsumption);
            this.Chart2.Controls.Add(this.chartReceivedData);
            this.Chart2.Location = new System.Drawing.Point(4, 28);
            this.Chart2.Name = "Chart2";
            this.Chart2.Padding = new System.Windows.Forms.Padding(3);
            this.Chart2.Size = new System.Drawing.Size(1569, 811);
            this.Chart2.TabIndex = 2;
            this.Chart2.Text = "Chart2";
            this.Chart2.UseVisualStyleBackColor = true;
            // 
            // chartTotalEnergyConsumption
            // 
            chartArea3.Name = "ChartArea1";
            this.chartTotalEnergyConsumption.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartTotalEnergyConsumption.Legends.Add(legend3);
            this.chartTotalEnergyConsumption.Location = new System.Drawing.Point(766, 6);
            this.chartTotalEnergyConsumption.Name = "chartTotalEnergyConsumption";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartTotalEnergyConsumption.Series.Add(series3);
            this.chartTotalEnergyConsumption.Size = new System.Drawing.Size(786, 750);
            this.chartTotalEnergyConsumption.TabIndex = 15;
            this.chartTotalEnergyConsumption.Text = "v";
            // 
            // chartReceivedData
            // 
            chartArea4.Name = "ChartArea1";
            this.chartReceivedData.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.chartReceivedData.Legends.Add(legend4);
            this.chartReceivedData.Location = new System.Drawing.Point(6, 6);
            this.chartReceivedData.Name = "chartReceivedData";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartReceivedData.Series.Add(series4);
            this.chartReceivedData.Size = new System.Drawing.Size(754, 750);
            this.chartReceivedData.TabIndex = 14;
            this.chartReceivedData.Text = "v";
            // 
            // 設定
            // 
            this.設定.Controls.Add(this.groupBoxInitialEnergy);
            this.設定.Location = new System.Drawing.Point(4, 28);
            this.設定.Name = "設定";
            this.設定.Padding = new System.Windows.Forms.Padding(3);
            this.設定.Size = new System.Drawing.Size(1569, 811);
            this.設定.TabIndex = 3;
            this.設定.Text = "設定";
            this.設定.UseVisualStyleBackColor = true;
            // 
            // groupBoxInitialEnergy
            // 
            this.groupBoxInitialEnergy.Controls.Add(this.radioButtonRand);
            this.groupBoxInitialEnergy.Controls.Add(this.radioButtonConst);
            this.groupBoxInitialEnergy.Location = new System.Drawing.Point(40, 46);
            this.groupBoxInitialEnergy.Name = "groupBoxInitialEnergy";
            this.groupBoxInitialEnergy.Size = new System.Drawing.Size(163, 79);
            this.groupBoxInitialEnergy.TabIndex = 0;
            this.groupBoxInitialEnergy.TabStop = false;
            this.groupBoxInitialEnergy.Text = "初期エネルギー";
            // 
            // radioButtonRand
            // 
            this.radioButtonRand.AutoSize = true;
            this.radioButtonRand.Location = new System.Drawing.Point(18, 52);
            this.radioButtonRand.Name = "radioButtonRand";
            this.radioButtonRand.Size = new System.Drawing.Size(86, 22);
            this.radioButtonRand.TabIndex = 1;
            this.radioButtonRand.TabStop = true;
            this.radioButtonRand.Text = "ランダム";
            this.radioButtonRand.UseVisualStyleBackColor = true;
            // 
            // radioButtonConst
            // 
            this.radioButtonConst.AutoSize = true;
            this.radioButtonConst.Checked = true;
            this.radioButtonConst.Location = new System.Drawing.Point(18, 24);
            this.radioButtonConst.Name = "radioButtonConst";
            this.radioButtonConst.Size = new System.Drawing.Size(69, 22);
            this.radioButtonConst.TabIndex = 0;
            this.radioButtonConst.TabStop = true;
            this.radioButtonConst.Text = "一定";
            this.radioButtonConst.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1605, 33);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開くOToolStripMenuItem,
            this.設定SToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 開くOToolStripMenuItem
            // 
            this.開くOToolStripMenuItem.Name = "開くOToolStripMenuItem";
            this.開くOToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.開くOToolStripMenuItem.Text = "開く(&O)...";
            this.開くOToolStripMenuItem.Click += new System.EventHandler(this.Button1_Click);
            // 
            // 設定SToolStripMenuItem
            // 
            this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
            this.設定SToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.設定SToolStripMenuItem.Text = "設定(&S)...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1605, 1295);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.resultTable);
            this.Controls.Add(this.labelPlaySpeed);
            this.Controls.Add(this.trackBarPlaySpeed);
            this.Controls.Add(this.btnPlayPose);
            this.Controls.Add(this.labelRound);
            this.Controls.Add(this.trackBarRound);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(963, 864);
            this.Name = "Form1";
            this.Text = "VisualizeNetwork";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNodeMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaySpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAliveNums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNumCH)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Simulation.ResumeLayout(false);
            this.Simulation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableEnergy)).EndInit();
            this.Chart1.ResumeLayout(false);
            this.Chart2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalEnergyConsumption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartReceivedData)).EndInit();
            this.設定.ResumeLayout(false);
            this.groupBoxInitialEnergy.ResumeLayout(false);
            this.groupBoxInitialEnergy.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxNodeMap;
        private System.Windows.Forms.Label labelCoordinate;
        private System.Windows.Forms.TrackBar trackBarRound;
        private System.Windows.Forms.Label labelRound;
        private System.Windows.Forms.Button btnPlayPose;
        private System.Windows.Forms.TrackBar trackBarPlaySpeed;
        private System.Windows.Forms.Label labelPlaySpeed;
        private System.Windows.Forms.DataGridView resultTable;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox cmbBoxAlgo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAliveNums;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNumCH;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Simulation;
        private System.Windows.Forms.TabPage Chart1;
        private System.Windows.Forms.DataGridView tableEnergy;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
        private System.Windows.Forms.TabPage Chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotalEnergyConsumption;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReceivedData;
        private System.Windows.Forms.TabPage 設定;
        private System.Windows.Forms.GroupBox groupBoxInitialEnergy;
        private System.Windows.Forms.RadioButton radioButtonRand;
        private System.Windows.Forms.RadioButton radioButtonConst;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 残量E;
        private System.Windows.Forms.DataGridViewTextBoxColumn 消費E;
        private System.Windows.Forms.DataGridViewTextBoxColumn CH回数;
        private System.Windows.Forms.DataGridViewTextBoxColumn CH無資格期間;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pi;
        private System.Windows.Forms.DataGridViewTextBoxColumn algorithm;
        private System.Windows.Forms.DataGridViewTextBoxColumn FDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn LDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHave;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHsd;
        private System.Windows.Forms.DataGridViewTextBoxColumn 平均消費量;
        private System.Windows.Forms.DataGridViewTextBoxColumn BS受信回数;
    }
}


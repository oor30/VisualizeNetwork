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
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelCoordinate = new System.Windows.Forms.Label();
            this.trackBarRound = new System.Windows.Forms.TrackBar();
            this.labelRound = new System.Windows.Forms.Label();
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
            this.cmbBoxAlgo = new System.Windows.Forms.ComboBox();
            this.chartAliveNums = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartNumCH = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Simulation = new System.Windows.Forms.TabPage();
            this.tableEnergy = new System.Windows.Forms.DataGridView();
            this.nodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.残量E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.消費E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CH回数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CH資格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBoxNodeMap = new System.Windows.Forms.PictureBox();
            this.Chart1 = new System.Windows.Forms.TabPage();
            this.Chart2 = new System.Windows.Forms.TabPage();
            this.chartTotalEnergyConsumption = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartReceivedData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.設定 = new System.Windows.Forms.TabPage();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownBSY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBSX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxInitialEnergy = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownInitialEnergy = new System.Windows.Forms.NumericUpDown();
            this.radioButtonRand = new System.Windows.Forms.RadioButton();
            this.radioButtonConst = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelProcessing = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPlayPose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaySpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAliveNums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNumCH)).BeginInit();
            this.tabControl.SuspendLayout();
            this.Simulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNodeMap)).BeginInit();
            this.Chart1.SuspendLayout();
            this.Chart2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalEnergyConsumption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartReceivedData)).BeginInit();
            this.設定.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBSY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBSX)).BeginInit();
            this.groupBoxInitialEnergy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialEnergy)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.labelCoordinate.Visible = false;
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
            this.labelRound.Location = new System.Drawing.Point(19, 56);
            this.labelRound.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(77, 18);
            this.labelRound.TabIndex = 4;
            this.labelRound.Text = "ラウンド：1";
            // 
            // trackBarPlaySpeed
            // 
            this.trackBarPlaySpeed.Location = new System.Drawing.Point(211, 120);
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
            this.labelPlaySpeed.Location = new System.Drawing.Point(553, 136);
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
            this.resultTable.Location = new System.Drawing.Point(12, 1034);
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
            legend9.Enabled = false;
            legend9.Name = "Legend1";
            this.chartAliveNums.Legends.Add(legend9);
            this.chartAliveNums.Location = new System.Drawing.Point(5, 5);
            this.chartAliveNums.Name = "chartAliveNums";
            this.chartAliveNums.Size = new System.Drawing.Size(754, 750);
            this.chartAliveNums.TabIndex = 12;
            this.chartAliveNums.Text = "v";
            // 
            // chartNumCH
            // 
            legend10.Name = "Legend1";
            this.chartNumCH.Legends.Add(legend10);
            this.chartNumCH.Location = new System.Drawing.Point(765, 5);
            this.chartNumCH.Name = "chartNumCH";
            this.chartNumCH.Size = new System.Drawing.Size(965, 750);
            this.chartNumCH.TabIndex = 13;
            this.chartNumCH.Text = "v";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Simulation);
            this.tabControl.Controls.Add(this.Chart1);
            this.tabControl.Controls.Add(this.Chart2);
            this.tabControl.Controls.Add(this.設定);
            this.tabControl.Location = new System.Drawing.Point(12, 186);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1743, 843);
            this.tabControl.TabIndex = 14;
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
            this.Simulation.Size = new System.Drawing.Size(1735, 811);
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
            this.CH資格,
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
            // CH資格
            // 
            this.CH資格.HeaderText = "CH資格";
            this.CH資格.MinimumWidth = 8;
            this.CH資格.Name = "CH資格";
            this.CH資格.ReadOnly = true;
            this.CH資格.Width = 104;
            // 
            // Pi
            // 
            this.Pi.HeaderText = "Pi";
            this.Pi.MinimumWidth = 8;
            this.Pi.Name = "Pi";
            this.Pi.ReadOnly = true;
            this.Pi.Width = 59;
            // 
            // pictureBoxNodeMap
            // 
            this.pictureBoxNodeMap.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxNodeMap.Location = new System.Drawing.Point(4, 53);
            this.pictureBoxNodeMap.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxNodeMap.MaximumSize = new System.Drawing.Size(768, 750);
            this.pictureBoxNodeMap.Name = "pictureBoxNodeMap";
            this.pictureBoxNodeMap.Size = new System.Drawing.Size(764, 750);
            this.pictureBoxNodeMap.TabIndex = 0;
            this.pictureBoxNodeMap.TabStop = false;
            this.pictureBoxNodeMap.MouseEnter += new System.EventHandler(this.PictureBoxNodeMap_MouseEnter);
            this.pictureBoxNodeMap.MouseLeave += new System.EventHandler(this.PictureBoxNodeMap_MouseLeave);
            this.pictureBoxNodeMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxNodeMap_MouseMove);
            // 
            // Chart1
            // 
            this.Chart1.Controls.Add(this.chartNumCH);
            this.Chart1.Controls.Add(this.chartAliveNums);
            this.Chart1.Location = new System.Drawing.Point(4, 28);
            this.Chart1.Margin = new System.Windows.Forms.Padding(2);
            this.Chart1.Name = "Chart1";
            this.Chart1.Padding = new System.Windows.Forms.Padding(2);
            this.Chart1.Size = new System.Drawing.Size(1735, 811);
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
            this.Chart2.Size = new System.Drawing.Size(1735, 811);
            this.Chart2.TabIndex = 2;
            this.Chart2.Text = "Chart2";
            this.Chart2.UseVisualStyleBackColor = true;
            // 
            // chartTotalEnergyConsumption
            // 
            chartArea5.Name = "ChartArea1";
            this.chartTotalEnergyConsumption.ChartAreas.Add(chartArea5);
            legend11.Name = "Legend1";
            this.chartTotalEnergyConsumption.Legends.Add(legend11);
            this.chartTotalEnergyConsumption.Location = new System.Drawing.Point(766, 6);
            this.chartTotalEnergyConsumption.Name = "chartTotalEnergyConsumption";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartTotalEnergyConsumption.Series.Add(series5);
            this.chartTotalEnergyConsumption.Size = new System.Drawing.Size(963, 750);
            this.chartTotalEnergyConsumption.TabIndex = 15;
            this.chartTotalEnergyConsumption.Text = "v";
            // 
            // chartReceivedData
            // 
            chartArea6.Name = "ChartArea1";
            this.chartReceivedData.ChartAreas.Add(chartArea6);
            legend12.Enabled = false;
            legend12.Name = "Legend1";
            this.chartReceivedData.Legends.Add(legend12);
            this.chartReceivedData.Location = new System.Drawing.Point(6, 6);
            this.chartReceivedData.Name = "chartReceivedData";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartReceivedData.Series.Add(series6);
            this.chartReceivedData.Size = new System.Drawing.Size(754, 750);
            this.chartReceivedData.TabIndex = 14;
            this.chartReceivedData.Text = "v";
            this.chartReceivedData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChartReceivedData_MouseMove);
            // 
            // 設定
            // 
            this.設定.Controls.Add(this.btnApply);
            this.設定.Controls.Add(this.groupBox1);
            this.設定.Controls.Add(this.groupBoxInitialEnergy);
            this.設定.Location = new System.Drawing.Point(4, 28);
            this.設定.Name = "設定";
            this.設定.Padding = new System.Windows.Forms.Padding(3);
            this.設定.Size = new System.Drawing.Size(1735, 811);
            this.設定.TabIndex = 3;
            this.設定.Text = "設定";
            this.設定.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(158, 307);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 34);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "適用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownBSY);
            this.groupBox1.Controls.Add(this.numericUpDownBSX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(40, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BSの位置";
            // 
            // numericUpDownBSY
            // 
            this.numericUpDownBSY.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownBSY.Location = new System.Drawing.Point(87, 62);
            this.numericUpDownBSY.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownBSY.Name = "numericUpDownBSY";
            this.numericUpDownBSY.Size = new System.Drawing.Size(120, 25);
            this.numericUpDownBSY.TabIndex = 3;
            this.numericUpDownBSY.Value = new decimal(new int[] {
            125,
            0,
            0,
            0});
            // 
            // numericUpDownBSX
            // 
            this.numericUpDownBSX.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownBSX.Location = new System.Drawing.Point(87, 34);
            this.numericUpDownBSX.Name = "numericUpDownBSX";
            this.numericUpDownBSX.Size = new System.Drawing.Size(120, 25);
            this.numericUpDownBSX.TabIndex = 2;
            this.numericUpDownBSX.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "y座標";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "x座標";
            // 
            // groupBoxInitialEnergy
            // 
            this.groupBoxInitialEnergy.Controls.Add(this.label1);
            this.groupBoxInitialEnergy.Controls.Add(this.numericUpDownInitialEnergy);
            this.groupBoxInitialEnergy.Controls.Add(this.radioButtonRand);
            this.groupBoxInitialEnergy.Controls.Add(this.radioButtonConst);
            this.groupBoxInitialEnergy.Location = new System.Drawing.Point(40, 46);
            this.groupBoxInitialEnergy.Name = "groupBoxInitialEnergy";
            this.groupBoxInitialEnergy.Size = new System.Drawing.Size(325, 85);
            this.groupBoxInitialEnergy.TabIndex = 0;
            this.groupBoxInitialEnergy.TabStop = false;
            this.groupBoxInitialEnergy.Text = "初期エネルギー";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "(J)";
            // 
            // numericUpDownInitialEnergy
            // 
            this.numericUpDownInitialEnergy.DecimalPlaces = 1;
            this.numericUpDownInitialEnergy.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownInitialEnergy.Location = new System.Drawing.Point(143, 24);
            this.numericUpDownInitialEnergy.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownInitialEnergy.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownInitialEnergy.Name = "numericUpDownInitialEnergy";
            this.numericUpDownInitialEnergy.Size = new System.Drawing.Size(120, 25);
            this.numericUpDownInitialEnergy.TabIndex = 2;
            this.numericUpDownInitialEnergy.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
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
            this.menuStrip1.Size = new System.Drawing.Size(1791, 33);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpen,
            this.設定SToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // toolStripMenuItemOpen
            // 
            this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            this.toolStripMenuItemOpen.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItemOpen.Text = "開く(&O)...";
            this.toolStripMenuItemOpen.Click += new System.EventHandler(this.Button1_Click);
            // 
            // 設定SToolStripMenuItem
            // 
            this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
            this.設定SToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.設定SToolStripMenuItem.Text = "設定(&S)...";
            // 
            // labelProcessing
            // 
            this.labelProcessing.AutoSize = true;
            this.labelProcessing.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelProcessing.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelProcessing.Location = new System.Drawing.Point(0, 1275);
            this.labelProcessing.Name = "labelProcessing";
            this.labelProcessing.Size = new System.Drawing.Size(124, 18);
            this.labelProcessing.TabIndex = 16;
            this.labelProcessing.Text = "labelProcessing";
            this.labelProcessing.Visible = false;
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = global::VisualizeNetwork.Properties.Resources.次ボタン;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(143, 125);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 40);
            this.btnNext.TabIndex = 10;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::VisualizeNetwork.Properties.Resources.前ボタン;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(16, 125);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 40);
            this.btnBack.TabIndex = 9;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnPlayPose
            // 
            this.btnPlayPose.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlayPose.BackgroundImage = global::VisualizeNetwork.Properties.Resources.再生ボタン;
            this.btnPlayPose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlayPose.FlatAppearance.BorderSize = 0;
            this.btnPlayPose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayPose.Location = new System.Drawing.Point(74, 120);
            this.btnPlayPose.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlayPose.Name = "btnPlayPose";
            this.btnPlayPose.Size = new System.Drawing.Size(50, 50);
            this.btnPlayPose.TabIndex = 5;
            this.btnPlayPose.UseVisualStyleBackColor = false;
            this.btnPlayPose.Click += new System.EventHandler(this.BtnPlayPose_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.trackBarRound);
            this.panel1.Controls.Add(this.trackBarPlaySpeed);
            this.panel1.Controls.Add(this.labelRound);
            this.panel1.Controls.Add(this.labelPlaySpeed);
            this.panel1.Controls.Add(this.btnPlayPose);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Controls.Add(this.resultTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1791, 1293);
            this.panel1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1791, 1293);
            this.Controls.Add(this.labelProcessing);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(963, 864);
            this.Name = "Form1";
            this.Text = "VisualizeNetwork";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaySpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAliveNums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNumCH)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.Simulation.ResumeLayout(false);
            this.Simulation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNodeMap)).EndInit();
            this.Chart1.ResumeLayout(false);
            this.Chart2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalEnergyConsumption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartReceivedData)).EndInit();
            this.設定.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBSY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBSX)).EndInit();
            this.groupBoxInitialEnergy.ResumeLayout(false);
            this.groupBoxInitialEnergy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialEnergy)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Simulation;
        private System.Windows.Forms.TabPage Chart1;
        private System.Windows.Forms.DataGridView tableEnergy;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
        private System.Windows.Forms.TabPage Chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotalEnergyConsumption;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReceivedData;
        private System.Windows.Forms.TabPage 設定;
        private System.Windows.Forms.GroupBox groupBoxInitialEnergy;
        private System.Windows.Forms.RadioButton radioButtonRand;
        private System.Windows.Forms.RadioButton radioButtonConst;
        private System.Windows.Forms.DataGridViewTextBoxColumn algorithm;
        private System.Windows.Forms.DataGridViewTextBoxColumn FDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn LDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHave;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHsd;
        private System.Windows.Forms.DataGridViewTextBoxColumn 平均消費量;
        private System.Windows.Forms.DataGridViewTextBoxColumn BS受信回数;
        private System.Windows.Forms.Label labelProcessing;
        private System.Windows.Forms.NumericUpDown numericUpDownInitialEnergy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 残量E;
        private System.Windows.Forms.DataGridViewTextBoxColumn 消費E;
        private System.Windows.Forms.DataGridViewTextBoxColumn CH回数;
        private System.Windows.Forms.DataGridViewTextBoxColumn CH資格;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownBSY;
        private System.Windows.Forms.NumericUpDown numericUpDownBSX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApply;
    }
}


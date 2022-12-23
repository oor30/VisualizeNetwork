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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.roundTable = new System.Windows.Forms.DataGridView();
            this.nodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownPacketSize = new System.Windows.Forms.NumericUpDown();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownBSY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBSX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxInitialEnergy = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownRange = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownInitialEnergy = new System.Windows.Forms.NumericUpDown();
            this.radioBtnRandInitEnergy = new System.Windows.Forms.RadioButton();
            this.radioBtnConstInitEnergy = new System.Windows.Forms.RadioButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.roundTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNodeMap)).BeginInit();
            this.Chart1.SuspendLayout();
            this.Chart2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalEnergyConsumption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartReceivedData)).BeginInit();
            this.設定.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBSY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBSX)).BeginInit();
            this.groupBoxInitialEnergy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).BeginInit();
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
            this.trackBarRound.Location = new System.Drawing.Point(128, 46);
            this.trackBarRound.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarRound.Maximum = 100;
            this.trackBarRound.Minimum = 1;
            this.trackBarRound.Name = "trackBarRound";
            this.trackBarRound.Size = new System.Drawing.Size(1308, 69);
            this.trackBarRound.TabIndex = 3;
            this.trackBarRound.Value = 1;
            this.trackBarRound.Scroll += new System.EventHandler(this.TrackBarRound_Scroll);
            // 
            // labelRound
            // 
            this.labelRound.AutoSize = true;
            this.labelRound.Location = new System.Drawing.Point(18, 56);
            this.labelRound.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(77, 18);
            this.labelRound.TabIndex = 4;
            this.labelRound.Text = "ラウンド：1";
            // 
            // trackBarPlaySpeed
            // 
            this.trackBarPlaySpeed.Location = new System.Drawing.Point(212, 120);
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
            this.resultTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.resultTable.MultiSelect = false;
            this.resultTable.Name = "resultTable";
            this.resultTable.ReadOnly = true;
            this.resultTable.RowHeadersWidth = 62;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            this.resultTable.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.resultTable.RowTemplate.Height = 27;
            this.resultTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultTable.Size = new System.Drawing.Size(1118, 238);
            this.resultTable.TabIndex = 8;
            this.resultTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultTable_CellDoubleClick);
            this.resultTable.SelectionChanged += new System.EventHandler(this.ResultTable_SelectionChanged);
            // 
            // algorithm
            // 
            this.algorithm.FillWeight = 140F;
            this.algorithm.HeaderText = "アルゴリズム";
            this.algorithm.MinimumWidth = 8;
            this.algorithm.Name = "algorithm";
            this.algorithm.ReadOnly = true;
            // 
            // FDN
            // 
            this.FDN.FillWeight = 80F;
            this.FDN.HeaderText = "FDN";
            this.FDN.MinimumWidth = 8;
            this.FDN.Name = "FDN";
            this.FDN.ReadOnly = true;
            this.FDN.ToolTipText = "最初にノードが死ぬまでのラウンド数";
            // 
            // LDN
            // 
            this.LDN.FillWeight = 80F;
            this.LDN.HeaderText = "LDN";
            this.LDN.MinimumWidth = 8;
            this.LDN.Name = "LDN";
            this.LDN.ReadOnly = true;
            this.LDN.ToolTipText = "最後のノードが死ぬまでのラウンド数";
            // 
            // CHave
            // 
            this.CHave.HeaderText = "CH平均";
            this.CHave.MinimumWidth = 8;
            this.CHave.Name = "CHave";
            this.CHave.ReadOnly = true;
            this.CHave.ToolTipText = "FDNまでの平均クラスタヘッド数";
            // 
            // CHsd
            // 
            this.CHsd.FillWeight = 130F;
            this.CHsd.HeaderText = "CH標準偏差";
            this.CHsd.MinimumWidth = 8;
            this.CHsd.Name = "CHsd";
            this.CHsd.ReadOnly = true;
            this.CHsd.ToolTipText = "FDNまでのクラスタヘッド数の標準偏差";
            // 
            // 平均消費量
            // 
            this.平均消費量.FillWeight = 130F;
            this.平均消費量.HeaderText = "平均消費量";
            this.平均消費量.MinimumWidth = 8;
            this.平均消費量.Name = "平均消費量";
            this.平均消費量.ReadOnly = true;
            this.平均消費量.ToolTipText = "FDNまでのラウンドあたりの平均エネルギー消費量(J)";
            // 
            // BS受信回数
            // 
            this.BS受信回数.FillWeight = 130F;
            this.BS受信回数.HeaderText = "収集データ数";
            this.BS受信回数.MinimumWidth = 8;
            this.BS受信回数.Name = "BS受信回数";
            this.BS受信回数.ReadOnly = true;
            this.BS受信回数.ToolTipText = "ノードからBSまで送られたパケット数";
            // 
            // cmbBoxAlgo
            // 
            this.cmbBoxAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxAlgo.FormattingEnabled = true;
            this.cmbBoxAlgo.Location = new System.Drawing.Point(5, 16);
            this.cmbBoxAlgo.Name = "cmbBoxAlgo";
            this.cmbBoxAlgo.Size = new System.Drawing.Size(212, 26);
            this.cmbBoxAlgo.TabIndex = 11;
            this.cmbBoxAlgo.SelectedIndexChanged += new System.EventHandler(this.CmbBoxAlgo_SelectedIndexChanged);
            // 
            // chartAliveNums
            // 
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartAliveNums.Legends.Add(legend1);
            this.chartAliveNums.Location = new System.Drawing.Point(5, 4);
            this.chartAliveNums.Name = "chartAliveNums";
            this.chartAliveNums.Size = new System.Drawing.Size(753, 750);
            this.chartAliveNums.TabIndex = 12;
            this.chartAliveNums.Text = "v";
            // 
            // chartNumCH
            // 
            legend2.Name = "Legend1";
            this.chartNumCH.Legends.Add(legend2);
            this.chartNumCH.Location = new System.Drawing.Point(765, 4);
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
            this.Simulation.Controls.Add(this.roundTable);
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
            // roundTable
            // 
            this.roundTable.AllowUserToAddRows = false;
            this.roundTable.AllowUserToDeleteRows = false;
            this.roundTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.roundTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.roundTable.ColumnHeadersHeight = 34;
            this.roundTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nodeID,
            this.status,
            this.CHID,
            this.残量E,
            this.消費E,
            this.CH回数,
            this.CH資格,
            this.Pi});
            this.roundTable.Location = new System.Drawing.Point(772, 52);
            this.roundTable.Margin = new System.Windows.Forms.Padding(2);
            this.roundTable.MultiSelect = false;
            this.roundTable.Name = "roundTable";
            this.roundTable.ReadOnly = true;
            this.roundTable.RowHeadersVisible = false;
            this.roundTable.RowHeadersWidth = 82;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roundTable.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.roundTable.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.roundTable.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.roundTable.RowTemplate.Height = 33;
            this.roundTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.roundTable.Size = new System.Drawing.Size(888, 750);
            this.roundTable.TabIndex = 12;
            this.roundTable.SelectionChanged += new System.EventHandler(this.RoundTable_SelectionChanged);
            this.roundTable.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.RoundTable_SortCompare);
            // 
            // nodeID
            // 
            this.nodeID.FillWeight = 80F;
            this.nodeID.HeaderText = "nodeID";
            this.nodeID.MinimumWidth = 10;
            this.nodeID.Name = "nodeID";
            this.nodeID.ReadOnly = true;
            // 
            // status
            // 
            this.status.FillWeight = 120F;
            this.status.HeaderText = "status";
            this.status.MinimumWidth = 8;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // CHID
            // 
            this.CHID.FillWeight = 80F;
            this.CHID.HeaderText = "CHID";
            this.CHID.MinimumWidth = 8;
            this.CHID.Name = "CHID";
            this.CHID.ReadOnly = true;
            // 
            // 残量E
            // 
            this.残量E.HeaderText = "残量E";
            this.残量E.MinimumWidth = 10;
            this.残量E.Name = "残量E";
            this.残量E.ReadOnly = true;
            this.残量E.ToolTipText = "残量エネルギー(J)";
            // 
            // 消費E
            // 
            this.消費E.HeaderText = "消費E";
            this.消費E.MinimumWidth = 10;
            this.消費E.Name = "消費E";
            this.消費E.ReadOnly = true;
            this.消費E.ToolTipText = "このラウンドにおける消費エネルギー(J)";
            // 
            // CH回数
            // 
            this.CH回数.FillWeight = 120F;
            this.CH回数.HeaderText = "CH回数";
            this.CH回数.MinimumWidth = 8;
            this.CH回数.Name = "CH回数";
            this.CH回数.ReadOnly = true;
            this.CH回数.ToolTipText = "CHになった回数";
            // 
            // CH資格
            // 
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.CH資格.DefaultCellStyle = dataGridViewCellStyle2;
            this.CH資格.FillWeight = 120F;
            this.CH資格.HeaderText = "CH資格";
            this.CH資格.MinimumWidth = 8;
            this.CH資格.Name = "CH資格";
            this.CH資格.ReadOnly = true;
            this.CH資格.ToolTipText = "CHになる資格がない残りのラウンド数(ヘッダーは資格を持つノード数)";
            // 
            // Pi
            // 
            this.Pi.FillWeight = 80F;
            this.Pi.HeaderText = "Pi";
            this.Pi.MinimumWidth = 8;
            this.Pi.Name = "Pi";
            this.Pi.ReadOnly = true;
            this.Pi.ToolTipText = "CHになる確率";
            // 
            // pictureBoxNodeMap
            // 
            this.pictureBoxNodeMap.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxNodeMap.Location = new System.Drawing.Point(3, 52);
            this.pictureBoxNodeMap.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxNodeMap.MaximumSize = new System.Drawing.Size(768, 750);
            this.pictureBoxNodeMap.Name = "pictureBoxNodeMap";
            this.pictureBoxNodeMap.Size = new System.Drawing.Size(763, 750);
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
            chartArea1.Name = "ChartArea1";
            this.chartTotalEnergyConsumption.ChartAreas.Add(chartArea1);
            legend3.Name = "Legend1";
            this.chartTotalEnergyConsumption.Legends.Add(legend3);
            this.chartTotalEnergyConsumption.Location = new System.Drawing.Point(767, 6);
            this.chartTotalEnergyConsumption.Name = "chartTotalEnergyConsumption";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTotalEnergyConsumption.Series.Add(series1);
            this.chartTotalEnergyConsumption.Size = new System.Drawing.Size(963, 750);
            this.chartTotalEnergyConsumption.TabIndex = 15;
            this.chartTotalEnergyConsumption.Text = "v";
            // 
            // chartReceivedData
            // 
            chartArea2.Name = "ChartArea1";
            this.chartReceivedData.ChartAreas.Add(chartArea2);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.chartReceivedData.Legends.Add(legend4);
            this.chartReceivedData.Location = new System.Drawing.Point(7, 6);
            this.chartReceivedData.Name = "chartReceivedData";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartReceivedData.Series.Add(series2);
            this.chartReceivedData.Size = new System.Drawing.Size(753, 750);
            this.chartReceivedData.TabIndex = 14;
            this.chartReceivedData.Text = "v";
            this.chartReceivedData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChartReceivedData_MouseMove);
            // 
            // 設定
            // 
            this.設定.Controls.Add(this.groupBox2);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownPacketSize);
            this.groupBox2.Location = new System.Drawing.Point(523, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "パケットサイズ(bits/round)";
            // 
            // numericUpDownPacketSize
            // 
            this.numericUpDownPacketSize.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownPacketSize.Location = new System.Drawing.Point(27, 38);
            this.numericUpDownPacketSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownPacketSize.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownPacketSize.Name = "numericUpDownPacketSize";
            this.numericUpDownPacketSize.Size = new System.Drawing.Size(120, 25);
            this.numericUpDownPacketSize.TabIndex = 0;
            this.numericUpDownPacketSize.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(158, 308);
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
            this.groupBox1.Size = new System.Drawing.Size(325, 112);
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
            this.numericUpDownBSY.Location = new System.Drawing.Point(87, 64);
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
            this.label3.Location = new System.Drawing.Point(17, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "y座標";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "x座標";
            // 
            // groupBoxInitialEnergy
            // 
            this.groupBoxInitialEnergy.Controls.Add(this.label4);
            this.groupBoxInitialEnergy.Controls.Add(this.numericUpDownRange);
            this.groupBoxInitialEnergy.Controls.Add(this.numericUpDownMin);
            this.groupBoxInitialEnergy.Controls.Add(this.label1);
            this.groupBoxInitialEnergy.Controls.Add(this.numericUpDownInitialEnergy);
            this.groupBoxInitialEnergy.Controls.Add(this.radioBtnRandInitEnergy);
            this.groupBoxInitialEnergy.Controls.Add(this.radioBtnConstInitEnergy);
            this.groupBoxInitialEnergy.Location = new System.Drawing.Point(40, 46);
            this.groupBoxInitialEnergy.Name = "groupBoxInitialEnergy";
            this.groupBoxInitialEnergy.Size = new System.Drawing.Size(440, 100);
            this.groupBoxInitialEnergy.TabIndex = 0;
            this.groupBoxInitialEnergy.TabStop = false;
            this.groupBoxInitialEnergy.Text = "初期エネルギー";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "+";
            // 
            // numericUpDownRange
            // 
            this.numericUpDownRange.DecimalPlaces = 1;
            this.numericUpDownRange.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownRange.Location = new System.Drawing.Point(292, 60);
            this.numericUpDownRange.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownRange.Name = "numericUpDownRange";
            this.numericUpDownRange.Size = new System.Drawing.Size(120, 25);
            this.numericUpDownRange.TabIndex = 5;
            this.numericUpDownRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numericUpDownMin
            // 
            this.numericUpDownMin.DecimalPlaces = 1;
            this.numericUpDownMin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownMin.Location = new System.Drawing.Point(142, 60);
            this.numericUpDownMin.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownMin.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownMin.Name = "numericUpDownMin";
            this.numericUpDownMin.Size = new System.Drawing.Size(120, 25);
            this.numericUpDownMin.TabIndex = 4;
            this.numericUpDownMin.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 28);
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
            // radioBtnRandInitEnergy
            // 
            this.radioBtnRandInitEnergy.AutoSize = true;
            this.radioBtnRandInitEnergy.Location = new System.Drawing.Point(17, 58);
            this.radioBtnRandInitEnergy.Name = "radioBtnRandInitEnergy";
            this.radioBtnRandInitEnergy.Size = new System.Drawing.Size(86, 22);
            this.radioBtnRandInitEnergy.TabIndex = 1;
            this.radioBtnRandInitEnergy.TabStop = true;
            this.radioBtnRandInitEnergy.Text = "ランダム";
            this.radioBtnRandInitEnergy.UseVisualStyleBackColor = true;
            // 
            // radioBtnConstInitEnergy
            // 
            this.radioBtnConstInitEnergy.AutoSize = true;
            this.radioBtnConstInitEnergy.Checked = true;
            this.radioBtnConstInitEnergy.Location = new System.Drawing.Point(18, 24);
            this.radioBtnConstInitEnergy.Name = "radioBtnConstInitEnergy";
            this.radioBtnConstInitEnergy.Size = new System.Drawing.Size(69, 22);
            this.radioBtnConstInitEnergy.TabIndex = 0;
            this.radioBtnConstInitEnergy.TabStop = true;
            this.radioBtnConstInitEnergy.Text = "一定";
            this.radioBtnConstInitEnergy.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1792, 33);
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
            this.toolStripMenuItemOpen.Size = new System.Drawing.Size(182, 34);
            this.toolStripMenuItemOpen.Text = "開く(&O)...";
            this.toolStripMenuItemOpen.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // 設定SToolStripMenuItem
            // 
            this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
            this.設定SToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
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
            this.btnNext.Location = new System.Drawing.Point(143, 124);
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
            this.btnBack.Location = new System.Drawing.Point(17, 124);
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
            this.btnPlayPose.Location = new System.Drawing.Point(73, 120);
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
            this.panel1.Size = new System.Drawing.Size(1792, 1293);
            this.panel1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1792, 1293);
            this.Controls.Add(this.labelProcessing);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(959, 856);
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
            ((System.ComponentModel.ISupportInitialize)(this.roundTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNodeMap)).EndInit();
            this.Chart1.ResumeLayout(false);
            this.Chart2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalEnergyConsumption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartReceivedData)).EndInit();
            this.設定.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBSY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBSX)).EndInit();
            this.groupBoxInitialEnergy.ResumeLayout(false);
            this.groupBoxInitialEnergy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).EndInit();
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
        private System.Windows.Forms.DataGridView roundTable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
        private System.Windows.Forms.TabPage Chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotalEnergyConsumption;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReceivedData;
        private System.Windows.Forms.TabPage 設定;
        private System.Windows.Forms.GroupBox groupBoxInitialEnergy;
        private System.Windows.Forms.RadioButton radioBtnRandInitEnergy;
        private System.Windows.Forms.RadioButton radioBtnConstInitEnergy;
        private System.Windows.Forms.Label labelProcessing;
        private System.Windows.Forms.NumericUpDown numericUpDownInitialEnergy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownBSY;
        private System.Windows.Forms.NumericUpDown numericUpDownBSX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.NumericUpDown numericUpDownRange;
        private System.Windows.Forms.NumericUpDown numericUpDownMin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownPacketSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 残量E;
        private System.Windows.Forms.DataGridViewTextBoxColumn 消費E;
        private System.Windows.Forms.DataGridViewTextBoxColumn CH回数;
        private System.Windows.Forms.DataGridViewTextBoxColumn CH資格;
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


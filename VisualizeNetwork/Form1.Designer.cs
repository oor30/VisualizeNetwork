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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.labelCoordinate = new System.Windows.Forms.Label();
			this.trackBarRound = new System.Windows.Forms.TrackBar();
			this.labelRound = new System.Windows.Forms.Label();
			this.trackBarPlaySpeed = new System.Windows.Forms.TrackBar();
			this.labelPlaySpeed = new System.Windows.Forms.Label();
			this.cmbBoxAlgo = new System.Windows.Forms.ComboBox();
			this.chartAliveNums = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.chartNumCH = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tabCtrlMiddle = new System.Windows.Forms.TabControl();
			this.Simulation = new System.Windows.Forms.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.panel3 = new System.Windows.Forms.Panel();
			this.pictureBoxNodeMap = new System.Windows.Forms.PictureBox();
			this.roundTable = new System.Windows.Forms.DataGridView();
			this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.xDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.yDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.einitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cHIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.memberNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.piDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cmsEnergyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.erDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hasCHCntDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.unqualifiedRoundDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.Chart1 = new System.Windows.Forms.TabPage();
			this.Chart2 = new System.Windows.Forms.TabPage();
			this.chartTotalEnergyConsumption = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.chartReceivedData = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.設定 = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.numericUpDownP = new System.Windows.Forms.NumericUpDown();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbMy_IEE_LEACH = new System.Windows.Forms.CheckBox();
			this.cbMy_IEE_LEACH_B = new System.Windows.Forms.CheckBox();
			this.cbIEE_LEACH_B = new System.Windows.Forms.CheckBox();
			this.cbIEE_LEACH_A = new System.Windows.Forms.CheckBox();
			this.cbIEE_LEACH = new System.Windows.Forms.CheckBox();
			this.cbLEACH = new System.Windows.Forms.CheckBox();
			this.cbDirect = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownN = new System.Windows.Forms.NumericUpDown();
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
			this.resultTable = new System.Windows.Forms.DataGridView();
			this.algoNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fDNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lDNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cHMeanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cHSDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.aveEnergyConsumptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.collectedDataNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.simBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.jsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.シナリオToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.d100ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.d400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.d600ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnPlayPose = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabCtrlBottom = new System.Windows.Forms.TabControl();
			this.tabResultTable = new System.Windows.Forms.TabPage();
			this.tabLog = new System.Windows.Forms.TabPage();
			this.textBoxLog = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.labelScenario = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.labelProcessing = new System.Windows.Forms.ToolStripStatusLabel();
			this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.process1 = new System.Diagnostics.Process();
			this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.trackBarRound)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarPlaySpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chartAliveNums)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chartNumCH)).BeginInit();
			this.tabCtrlMiddle.SuspendLayout();
			this.Simulation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNodeMap)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.roundTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nodeBindingSource)).BeginInit();
			this.flowLayoutPanel2.SuspendLayout();
			this.Chart1.SuspendLayout();
			this.Chart2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartTotalEnergyConsumption)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chartReceivedData)).BeginInit();
			this.設定.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownP)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketSize)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownBSY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownBSX)).BeginInit();
			this.groupBoxInitialEnergy.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRange)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialEnergy)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.resultTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.simBindingSource)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabCtrlBottom.SuspendLayout();
			this.tabResultTable.SuspendLayout();
			this.tabLog.SuspendLayout();
			this.panel2.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// labelCoordinate
			// 
			this.labelCoordinate.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelCoordinate.AutoSize = true;
			this.labelCoordinate.Location = new System.Drawing.Point(134, 6);
			this.labelCoordinate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.labelCoordinate.Name = "labelCoordinate";
			this.labelCoordinate.Size = new System.Drawing.Size(43, 15);
			this.labelCoordinate.TabIndex = 2;
			this.labelCoordinate.Text = "座標：";
			this.labelCoordinate.Visible = false;
			// 
			// trackBarRound
			// 
			this.trackBarRound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBarRound.Location = new System.Drawing.Point(99, 29);
			this.trackBarRound.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.trackBarRound.Maximum = 100;
			this.trackBarRound.MaximumSize = new System.Drawing.Size(785, 45);
			this.trackBarRound.Minimum = 1;
			this.trackBarRound.Name = "trackBarRound";
			this.trackBarRound.Size = new System.Drawing.Size(445, 45);
			this.trackBarRound.TabIndex = 3;
			this.trackBarRound.Value = 1;
			this.trackBarRound.Scroll += new System.EventHandler(this.TrackBarRound_Scroll);
			// 
			// labelRound
			// 
			this.labelRound.AutoSize = true;
			this.labelRound.Location = new System.Drawing.Point(11, 38);
			this.labelRound.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.labelRound.Name = "labelRound";
			this.labelRound.Size = new System.Drawing.Size(59, 15);
			this.labelRound.TabIndex = 4;
			this.labelRound.Text = "ラウンド：1";
			// 
			// trackBarPlaySpeed
			// 
			this.trackBarPlaySpeed.Location = new System.Drawing.Point(119, 74);
			this.trackBarPlaySpeed.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.trackBarPlaySpeed.Minimum = 1;
			this.trackBarPlaySpeed.Name = "trackBarPlaySpeed";
			this.trackBarPlaySpeed.Size = new System.Drawing.Size(203, 45);
			this.trackBarPlaySpeed.TabIndex = 6;
			this.trackBarPlaySpeed.Value = 1;
			this.trackBarPlaySpeed.Scroll += new System.EventHandler(this.TrackBarPlaySpeed_Scroll);
			// 
			// labelPlaySpeed
			// 
			this.labelPlaySpeed.AutoSize = true;
			this.labelPlaySpeed.Location = new System.Drawing.Point(331, 86);
			this.labelPlaySpeed.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.labelPlaySpeed.Name = "labelPlaySpeed";
			this.labelPlaySpeed.Size = new System.Drawing.Size(66, 15);
			this.labelPlaySpeed.TabIndex = 7;
			this.labelPlaySpeed.Text = "1 (round/s)";
			// 
			// cmbBoxAlgo
			// 
			this.cmbBoxAlgo.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmbBoxAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBoxAlgo.FormattingEnabled = true;
			this.cmbBoxAlgo.Location = new System.Drawing.Point(2, 2);
			this.cmbBoxAlgo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cmbBoxAlgo.Name = "cmbBoxAlgo";
			this.cmbBoxAlgo.Size = new System.Drawing.Size(129, 23);
			this.cmbBoxAlgo.TabIndex = 11;
			this.cmbBoxAlgo.SelectedIndexChanged += new System.EventHandler(this.CmbBoxAlgo_SelectedIndexChanged);
			// 
			// chartAliveNums
			// 
			legend1.Enabled = false;
			legend1.Name = "Legend1";
			this.chartAliveNums.Legends.Add(legend1);
			this.chartAliveNums.Location = new System.Drawing.Point(3, 2);
			this.chartAliveNums.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.chartAliveNums.Name = "chartAliveNums";
			this.chartAliveNums.Size = new System.Drawing.Size(452, 500);
			this.chartAliveNums.TabIndex = 12;
			this.chartAliveNums.Text = "v";
			// 
			// chartNumCH
			// 
			legend2.Name = "Legend1";
			this.chartNumCH.Legends.Add(legend2);
			this.chartNumCH.Location = new System.Drawing.Point(459, 2);
			this.chartNumCH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.chartNumCH.Name = "chartNumCH";
			this.chartNumCH.Size = new System.Drawing.Size(579, 500);
			this.chartNumCH.TabIndex = 13;
			this.chartNumCH.Text = "v";
			// 
			// tabCtrlMiddle
			// 
			this.tabCtrlMiddle.Controls.Add(this.Simulation);
			this.tabCtrlMiddle.Controls.Add(this.Chart1);
			this.tabCtrlMiddle.Controls.Add(this.Chart2);
			this.tabCtrlMiddle.Controls.Add(this.設定);
			this.tabCtrlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabCtrlMiddle.Location = new System.Drawing.Point(0, 0);
			this.tabCtrlMiddle.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.tabCtrlMiddle.Name = "tabCtrlMiddle";
			this.tabCtrlMiddle.SelectedIndex = 0;
			this.tabCtrlMiddle.Size = new System.Drawing.Size(961, 257);
			this.tabCtrlMiddle.TabIndex = 14;
			// 
			// Simulation
			// 
			this.Simulation.BackColor = System.Drawing.Color.Transparent;
			this.Simulation.Controls.Add(this.splitContainer2);
			this.Simulation.Controls.Add(this.flowLayoutPanel2);
			this.Simulation.Location = new System.Drawing.Point(4, 24);
			this.Simulation.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.Simulation.Name = "Simulation";
			this.Simulation.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.Simulation.Size = new System.Drawing.Size(953, 229);
			this.Simulation.TabIndex = 0;
			this.Simulation.Text = "Simulation";
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer2.Location = new System.Drawing.Point(1, 25);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.panel3);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.roundTable);
			this.splitContainer2.Size = new System.Drawing.Size(951, 202);
			this.splitContainer2.SplitterDistance = 520;
			this.splitContainer2.TabIndex = 8;
			// 
			// panel3
			// 
			this.panel3.AutoScroll = true;
			this.panel3.Controls.Add(this.pictureBoxNodeMap);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(520, 202);
			this.panel3.TabIndex = 8;
			// 
			// pictureBoxNodeMap
			// 
			this.pictureBoxNodeMap.BackColor = System.Drawing.SystemColors.Window;
			this.pictureBoxNodeMap.Location = new System.Drawing.Point(1, 2);
			this.pictureBoxNodeMap.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.pictureBoxNodeMap.MaximumSize = new System.Drawing.Size(500, 500);
			this.pictureBoxNodeMap.Name = "pictureBoxNodeMap";
			this.pictureBoxNodeMap.Size = new System.Drawing.Size(500, 500);
			this.pictureBoxNodeMap.TabIndex = 0;
			this.pictureBoxNodeMap.TabStop = false;
			this.pictureBoxNodeMap.MouseEnter += new System.EventHandler(this.PictureBoxNodeMap_MouseEnter);
			this.pictureBoxNodeMap.MouseLeave += new System.EventHandler(this.PictureBoxNodeMap_MouseLeave);
			this.pictureBoxNodeMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxNodeMap_MouseMove);
			// 
			// roundTable
			// 
			this.roundTable.AllowUserToAddRows = false;
			this.roundTable.AllowUserToDeleteRows = false;
			this.roundTable.AllowUserToOrderColumns = true;
			this.roundTable.AllowUserToResizeColumns = false;
			this.roundTable.AllowUserToResizeRows = false;
			this.roundTable.AutoGenerateColumns = false;
			this.roundTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.roundTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.roundTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.xDataGridViewTextBoxColumn,
            this.yDataGridViewTextBoxColumn,
            this.einitDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.cHIDDataGridViewTextBoxColumn,
            this.memberNumDataGridViewTextBoxColumn,
            this.piDataGridViewTextBoxColumn,
            this.cmsEnergyDataGridViewTextBoxColumn,
            this.erDataGridViewTextBoxColumn,
            this.hasCHCntDataGridViewTextBoxColumn,
            this.unqualifiedRoundDataGridViewTextBoxColumn});
			this.roundTable.DataSource = this.nodeBindingSource;
			this.roundTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.roundTable.Location = new System.Drawing.Point(0, 0);
			this.roundTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.roundTable.MultiSelect = false;
			this.roundTable.Name = "roundTable";
			this.roundTable.ReadOnly = true;
			this.roundTable.RowHeadersWidth = 30;
			this.roundTable.RowTemplate.Height = 27;
			this.roundTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.roundTable.Size = new System.Drawing.Size(427, 202);
			this.roundTable.TabIndex = 7;
			this.roundTable.SelectionChanged += new System.EventHandler(this.RoundTable_SelectionChanged);
			this.roundTable.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.RoundTable_SortCompare);
			// 
			// iDDataGridViewTextBoxColumn
			// 
			this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
			this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
			this.iDDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
			this.iDDataGridViewTextBoxColumn.ReadOnly = true;
			this.iDDataGridViewTextBoxColumn.Width = 43;
			// 
			// xDataGridViewTextBoxColumn
			// 
			this.xDataGridViewTextBoxColumn.DataPropertyName = "X";
			this.xDataGridViewTextBoxColumn.HeaderText = "X";
			this.xDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.xDataGridViewTextBoxColumn.Name = "xDataGridViewTextBoxColumn";
			this.xDataGridViewTextBoxColumn.ReadOnly = true;
			this.xDataGridViewTextBoxColumn.Width = 39;
			// 
			// yDataGridViewTextBoxColumn
			// 
			this.yDataGridViewTextBoxColumn.DataPropertyName = "Y";
			this.yDataGridViewTextBoxColumn.HeaderText = "Y";
			this.yDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.yDataGridViewTextBoxColumn.Name = "yDataGridViewTextBoxColumn";
			this.yDataGridViewTextBoxColumn.ReadOnly = true;
			this.yDataGridViewTextBoxColumn.Width = 39;
			// 
			// einitDataGridViewTextBoxColumn
			// 
			this.einitDataGridViewTextBoxColumn.DataPropertyName = "E_init";
			dataGridViewCellStyle1.Format = "N6";
			dataGridViewCellStyle1.NullValue = null;
			this.einitDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.einitDataGridViewTextBoxColumn.HeaderText = "初期E";
			this.einitDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.einitDataGridViewTextBoxColumn.Name = "einitDataGridViewTextBoxColumn";
			this.einitDataGridViewTextBoxColumn.ReadOnly = true;
			this.einitDataGridViewTextBoxColumn.Width = 62;
			// 
			// statusDataGridViewTextBoxColumn
			// 
			this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
			this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
			this.statusDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
			this.statusDataGridViewTextBoxColumn.ReadOnly = true;
			this.statusDataGridViewTextBoxColumn.Width = 64;
			// 
			// cHIDDataGridViewTextBoxColumn
			// 
			this.cHIDDataGridViewTextBoxColumn.DataPropertyName = "CHID";
			this.cHIDDataGridViewTextBoxColumn.HeaderText = "CHID";
			this.cHIDDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.cHIDDataGridViewTextBoxColumn.Name = "cHIDDataGridViewTextBoxColumn";
			this.cHIDDataGridViewTextBoxColumn.ReadOnly = true;
			this.cHIDDataGridViewTextBoxColumn.Width = 59;
			// 
			// memberNumDataGridViewTextBoxColumn
			// 
			this.memberNumDataGridViewTextBoxColumn.DataPropertyName = "MemberNum";
			this.memberNumDataGridViewTextBoxColumn.HeaderText = "メンバー数";
			this.memberNumDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.memberNumDataGridViewTextBoxColumn.Name = "memberNumDataGridViewTextBoxColumn";
			this.memberNumDataGridViewTextBoxColumn.ReadOnly = true;
			this.memberNumDataGridViewTextBoxColumn.Width = 79;
			// 
			// piDataGridViewTextBoxColumn
			// 
			this.piDataGridViewTextBoxColumn.DataPropertyName = "Pi";
			dataGridViewCellStyle2.Format = "N6";
			dataGridViewCellStyle2.NullValue = null;
			this.piDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
			this.piDataGridViewTextBoxColumn.HeaderText = "CH確率";
			this.piDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.piDataGridViewTextBoxColumn.Name = "piDataGridViewTextBoxColumn";
			this.piDataGridViewTextBoxColumn.ReadOnly = true;
			this.piDataGridViewTextBoxColumn.Width = 72;
			// 
			// cmsEnergyDataGridViewTextBoxColumn
			// 
			this.cmsEnergyDataGridViewTextBoxColumn.DataPropertyName = "CmsEnergy";
			dataGridViewCellStyle3.Format = "N6";
			dataGridViewCellStyle3.NullValue = null;
			this.cmsEnergyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
			this.cmsEnergyDataGridViewTextBoxColumn.HeaderText = "消費E";
			this.cmsEnergyDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.cmsEnergyDataGridViewTextBoxColumn.Name = "cmsEnergyDataGridViewTextBoxColumn";
			this.cmsEnergyDataGridViewTextBoxColumn.ReadOnly = true;
			this.cmsEnergyDataGridViewTextBoxColumn.Width = 62;
			// 
			// erDataGridViewTextBoxColumn
			// 
			this.erDataGridViewTextBoxColumn.DataPropertyName = "E_r";
			dataGridViewCellStyle4.Format = "N6";
			dataGridViewCellStyle4.NullValue = null;
			this.erDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
			this.erDataGridViewTextBoxColumn.HeaderText = "残量E";
			this.erDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.erDataGridViewTextBoxColumn.Name = "erDataGridViewTextBoxColumn";
			this.erDataGridViewTextBoxColumn.ReadOnly = true;
			this.erDataGridViewTextBoxColumn.Width = 62;
			// 
			// hasCHCntDataGridViewTextBoxColumn
			// 
			this.hasCHCntDataGridViewTextBoxColumn.DataPropertyName = "HasCHCnt";
			this.hasCHCntDataGridViewTextBoxColumn.HeaderText = "CH回数";
			this.hasCHCntDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.hasCHCntDataGridViewTextBoxColumn.Name = "hasCHCntDataGridViewTextBoxColumn";
			this.hasCHCntDataGridViewTextBoxColumn.ReadOnly = true;
			this.hasCHCntDataGridViewTextBoxColumn.Width = 72;
			// 
			// unqualifiedRoundDataGridViewTextBoxColumn
			// 
			this.unqualifiedRoundDataGridViewTextBoxColumn.DataPropertyName = "UnqualifiedRound";
			this.unqualifiedRoundDataGridViewTextBoxColumn.HeaderText = "CH資格";
			this.unqualifiedRoundDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.unqualifiedRoundDataGridViewTextBoxColumn.Name = "unqualifiedRoundDataGridViewTextBoxColumn";
			this.unqualifiedRoundDataGridViewTextBoxColumn.ReadOnly = true;
			this.unqualifiedRoundDataGridViewTextBoxColumn.Width = 72;
			// 
			// nodeBindingSource
			// 
			this.nodeBindingSource.DataSource = typeof(VisualizeNetwork.Node);
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.cmbBoxAlgo);
			this.flowLayoutPanel2.Controls.Add(this.labelCoordinate);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(1, 2);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(951, 23);
			this.flowLayoutPanel2.TabIndex = 8;
			// 
			// Chart1
			// 
			this.Chart1.Controls.Add(this.chartNumCH);
			this.Chart1.Controls.Add(this.chartAliveNums);
			this.Chart1.Location = new System.Drawing.Point(4, 24);
			this.Chart1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.Chart1.Name = "Chart1";
			this.Chart1.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.Chart1.Size = new System.Drawing.Size(745, 151);
			this.Chart1.TabIndex = 1;
			this.Chart1.Text = "Chart1";
			this.Chart1.UseVisualStyleBackColor = true;
			// 
			// Chart2
			// 
			this.Chart2.Controls.Add(this.chartTotalEnergyConsumption);
			this.Chart2.Controls.Add(this.chartReceivedData);
			this.Chart2.Location = new System.Drawing.Point(4, 24);
			this.Chart2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Chart2.Name = "Chart2";
			this.Chart2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Chart2.Size = new System.Drawing.Size(745, 151);
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
			this.chartTotalEnergyConsumption.Location = new System.Drawing.Point(460, 4);
			this.chartTotalEnergyConsumption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.chartTotalEnergyConsumption.Name = "chartTotalEnergyConsumption";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chartTotalEnergyConsumption.Series.Add(series1);
			this.chartTotalEnergyConsumption.Size = new System.Drawing.Size(578, 500);
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
			this.chartReceivedData.Location = new System.Drawing.Point(4, 4);
			this.chartReceivedData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.chartReceivedData.Name = "chartReceivedData";
			series2.ChartArea = "ChartArea1";
			series2.Legend = "Legend1";
			series2.Name = "Series1";
			this.chartReceivedData.Series.Add(series2);
			this.chartReceivedData.Size = new System.Drawing.Size(452, 500);
			this.chartReceivedData.TabIndex = 14;
			this.chartReceivedData.Text = "v";
			this.chartReceivedData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChartReceivedData_MouseMove);
			// 
			// 設定
			// 
			this.設定.Controls.Add(this.groupBox5);
			this.設定.Controls.Add(this.groupBox4);
			this.設定.Controls.Add(this.groupBox3);
			this.設定.Controls.Add(this.groupBox2);
			this.設定.Controls.Add(this.btnApply);
			this.設定.Controls.Add(this.groupBox1);
			this.設定.Controls.Add(this.groupBoxInitialEnergy);
			this.設定.Location = new System.Drawing.Point(4, 24);
			this.設定.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.設定.Name = "設定";
			this.設定.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.設定.Size = new System.Drawing.Size(745, 151);
			this.設定.TabIndex = 3;
			this.設定.Text = "設定";
			this.設定.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.numericUpDownP);
			this.groupBox5.Location = new System.Drawing.Point(314, 121);
			this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox5.Size = new System.Drawing.Size(111, 67);
			this.groupBox5.TabIndex = 6;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "PH比率";
			// 
			// numericUpDownP
			// 
			this.numericUpDownP.DecimalPlaces = 2;
			this.numericUpDownP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDownP.Location = new System.Drawing.Point(17, 31);
			this.numericUpDownP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericUpDownP.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownP.Name = "numericUpDownP";
			this.numericUpDownP.Size = new System.Drawing.Size(41, 23);
			this.numericUpDownP.TabIndex = 5;
			this.numericUpDownP.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cbMy_IEE_LEACH);
			this.groupBox4.Controls.Add(this.cbMy_IEE_LEACH_B);
			this.groupBox4.Controls.Add(this.cbIEE_LEACH_B);
			this.groupBox4.Controls.Add(this.cbIEE_LEACH_A);
			this.groupBox4.Controls.Add(this.cbIEE_LEACH);
			this.groupBox4.Controls.Add(this.cbLEACH);
			this.groupBox4.Controls.Add(this.cbDirect);
			this.groupBox4.Location = new System.Drawing.Point(534, 30);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(152, 198);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "アルゴリズム";
			// 
			// cbMy_IEE_LEACH
			// 
			this.cbMy_IEE_LEACH.AutoSize = true;
			this.cbMy_IEE_LEACH.Checked = true;
			this.cbMy_IEE_LEACH.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMy_IEE_LEACH.Location = new System.Drawing.Point(11, 166);
			this.cbMy_IEE_LEACH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cbMy_IEE_LEACH.Name = "cbMy_IEE_LEACH";
			this.cbMy_IEE_LEACH.Size = new System.Drawing.Size(104, 19);
			this.cbMy_IEE_LEACH.TabIndex = 6;
			this.cbMy_IEE_LEACH.Text = "My-IEE-LEACH";
			this.cbMy_IEE_LEACH.UseVisualStyleBackColor = true;
			// 
			// cbMy_IEE_LEACH_B
			// 
			this.cbMy_IEE_LEACH_B.AutoSize = true;
			this.cbMy_IEE_LEACH_B.Location = new System.Drawing.Point(11, 142);
			this.cbMy_IEE_LEACH_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cbMy_IEE_LEACH_B.Name = "cbMy_IEE_LEACH_B";
			this.cbMy_IEE_LEACH_B.Size = new System.Drawing.Size(116, 19);
			this.cbMy_IEE_LEACH_B.TabIndex = 5;
			this.cbMy_IEE_LEACH_B.Text = "My-IEE-LEACH-B";
			this.cbMy_IEE_LEACH_B.UseVisualStyleBackColor = true;
			// 
			// cbIEE_LEACH_B
			// 
			this.cbIEE_LEACH_B.AutoSize = true;
			this.cbIEE_LEACH_B.Location = new System.Drawing.Point(11, 117);
			this.cbIEE_LEACH_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cbIEE_LEACH_B.Name = "cbIEE_LEACH_B";
			this.cbIEE_LEACH_B.Size = new System.Drawing.Size(94, 19);
			this.cbIEE_LEACH_B.TabIndex = 4;
			this.cbIEE_LEACH_B.Text = "IEE-LEACH-B";
			this.cbIEE_LEACH_B.UseVisualStyleBackColor = true;
			// 
			// cbIEE_LEACH_A
			// 
			this.cbIEE_LEACH_A.AutoSize = true;
			this.cbIEE_LEACH_A.Location = new System.Drawing.Point(11, 93);
			this.cbIEE_LEACH_A.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cbIEE_LEACH_A.Name = "cbIEE_LEACH_A";
			this.cbIEE_LEACH_A.Size = new System.Drawing.Size(95, 19);
			this.cbIEE_LEACH_A.TabIndex = 3;
			this.cbIEE_LEACH_A.Text = "IEE-LEACH-A";
			this.cbIEE_LEACH_A.UseVisualStyleBackColor = true;
			// 
			// cbIEE_LEACH
			// 
			this.cbIEE_LEACH.AutoSize = true;
			this.cbIEE_LEACH.Checked = true;
			this.cbIEE_LEACH.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbIEE_LEACH.Location = new System.Drawing.Point(11, 69);
			this.cbIEE_LEACH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cbIEE_LEACH.Name = "cbIEE_LEACH";
			this.cbIEE_LEACH.Size = new System.Drawing.Size(82, 19);
			this.cbIEE_LEACH.TabIndex = 2;
			this.cbIEE_LEACH.Text = "IEE-LEACH";
			this.cbIEE_LEACH.UseVisualStyleBackColor = true;
			// 
			// cbLEACH
			// 
			this.cbLEACH.AutoSize = true;
			this.cbLEACH.Checked = true;
			this.cbLEACH.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbLEACH.Location = new System.Drawing.Point(11, 45);
			this.cbLEACH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cbLEACH.Name = "cbLEACH";
			this.cbLEACH.Size = new System.Drawing.Size(62, 19);
			this.cbLEACH.TabIndex = 1;
			this.cbLEACH.Text = "LEACH";
			this.cbLEACH.UseVisualStyleBackColor = true;
			// 
			// cbDirect
			// 
			this.cbDirect.AutoSize = true;
			this.cbDirect.Location = new System.Drawing.Point(11, 21);
			this.cbDirect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cbDirect.Name = "cbDirect";
			this.cbDirect.Size = new System.Drawing.Size(57, 19);
			this.cbDirect.TabIndex = 0;
			this.cbDirect.Text = "Direct";
			this.cbDirect.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.numericUpDownWidth);
			this.groupBox3.Controls.Add(this.numericUpDownN);
			this.groupBox3.Location = new System.Drawing.Point(830, 30);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox3.Size = new System.Drawing.Size(186, 88);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "その他";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 46);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 15);
			this.label6.TabIndex = 3;
			this.label6.Text = "一辺の長さ(m)";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 26);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 15);
			this.label5.TabIndex = 2;
			this.label5.Text = "ノード数 N";
			// 
			// numericUpDownWidth
			// 
			this.numericUpDownWidth.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDownWidth.Location = new System.Drawing.Point(94, 44);
			this.numericUpDownWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericUpDownWidth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numericUpDownWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDownWidth.Name = "numericUpDownWidth";
			this.numericUpDownWidth.Size = new System.Drawing.Size(41, 23);
			this.numericUpDownWidth.TabIndex = 1;
			this.numericUpDownWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// numericUpDownN
			// 
			this.numericUpDownN.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numericUpDownN.Location = new System.Drawing.Point(94, 22);
			this.numericUpDownN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericUpDownN.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numericUpDownN.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numericUpDownN.Name = "numericUpDownN";
			this.numericUpDownN.Size = new System.Drawing.Size(41, 23);
			this.numericUpDownN.TabIndex = 0;
			this.numericUpDownN.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.numericUpDownPacketSize);
			this.groupBox2.Location = new System.Drawing.Point(314, 30);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox2.Size = new System.Drawing.Size(173, 66);
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
			this.numericUpDownPacketSize.Location = new System.Drawing.Point(16, 26);
			this.numericUpDownPacketSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
			this.numericUpDownPacketSize.Size = new System.Drawing.Size(41, 23);
			this.numericUpDownPacketSize.TabIndex = 0;
			this.numericUpDownPacketSize.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(95, 206);
			this.btnApply.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(45, 22);
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
			this.groupBox1.Location = new System.Drawing.Point(24, 114);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Size = new System.Drawing.Size(195, 74);
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
			this.numericUpDownBSY.Location = new System.Drawing.Point(52, 42);
			this.numericUpDownBSY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericUpDownBSY.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numericUpDownBSY.Name = "numericUpDownBSY";
			this.numericUpDownBSY.Size = new System.Drawing.Size(41, 23);
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
            25,
            0,
            0,
            0});
			this.numericUpDownBSX.Location = new System.Drawing.Point(52, 22);
			this.numericUpDownBSX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.numericUpDownBSX.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numericUpDownBSX.Name = "numericUpDownBSX";
			this.numericUpDownBSX.Size = new System.Drawing.Size(41, 23);
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
			this.label3.Location = new System.Drawing.Point(10, 42);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "y座標";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 22);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 15);
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
			this.groupBoxInitialEnergy.Location = new System.Drawing.Point(24, 30);
			this.groupBoxInitialEnergy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBoxInitialEnergy.Name = "groupBoxInitialEnergy";
			this.groupBoxInitialEnergy.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBoxInitialEnergy.Size = new System.Drawing.Size(264, 66);
			this.groupBoxInitialEnergy.TabIndex = 0;
			this.groupBoxInitialEnergy.TabStop = false;
			this.groupBoxInitialEnergy.Text = "初期エネルギー";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(160, 40);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(19, 15);
			this.label4.TabIndex = 0;
			this.label4.Text = "＋";
			// 
			// numericUpDownRange
			// 
			this.numericUpDownRange.DecimalPlaces = 1;
			this.numericUpDownRange.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownRange.Location = new System.Drawing.Point(184, 39);
			this.numericUpDownRange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
			this.numericUpDownRange.Size = new System.Drawing.Size(41, 23);
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
			this.numericUpDownMin.Location = new System.Drawing.Point(86, 38);
			this.numericUpDownMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
			this.numericUpDownMin.Size = new System.Drawing.Size(41, 23);
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
			this.label1.Location = new System.Drawing.Point(161, 18);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 15);
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
			this.numericUpDownInitialEnergy.Location = new System.Drawing.Point(86, 16);
			this.numericUpDownInitialEnergy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
			this.numericUpDownInitialEnergy.Size = new System.Drawing.Size(41, 23);
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
			this.radioBtnRandInitEnergy.Location = new System.Drawing.Point(10, 38);
			this.radioBtnRandInitEnergy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.radioBtnRandInitEnergy.Name = "radioBtnRandInitEnergy";
			this.radioBtnRandInitEnergy.Size = new System.Drawing.Size(58, 19);
			this.radioBtnRandInitEnergy.TabIndex = 1;
			this.radioBtnRandInitEnergy.TabStop = true;
			this.radioBtnRandInitEnergy.Text = "ランダム";
			this.radioBtnRandInitEnergy.UseVisualStyleBackColor = true;
			// 
			// radioBtnConstInitEnergy
			// 
			this.radioBtnConstInitEnergy.AutoSize = true;
			this.radioBtnConstInitEnergy.Checked = true;
			this.radioBtnConstInitEnergy.Location = new System.Drawing.Point(11, 16);
			this.radioBtnConstInitEnergy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.radioBtnConstInitEnergy.Name = "radioBtnConstInitEnergy";
			this.radioBtnConstInitEnergy.Size = new System.Drawing.Size(49, 19);
			this.radioBtnConstInitEnergy.TabIndex = 0;
			this.radioBtnConstInitEnergy.TabStop = true;
			this.radioBtnConstInitEnergy.Text = "一定";
			this.radioBtnConstInitEnergy.UseVisualStyleBackColor = true;
			// 
			// resultTable
			// 
			this.resultTable.AllowUserToAddRows = false;
			this.resultTable.AllowUserToDeleteRows = false;
			this.resultTable.AllowUserToOrderColumns = true;
			this.resultTable.AllowUserToResizeColumns = false;
			this.resultTable.AllowUserToResizeRows = false;
			this.resultTable.AutoGenerateColumns = false;
			this.resultTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.resultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.resultTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.algoNameDataGridViewTextBoxColumn,
            this.fDNDataGridViewTextBoxColumn,
            this.lDNDataGridViewTextBoxColumn,
            this.cHMeanDataGridViewTextBoxColumn,
            this.cHSDDataGridViewTextBoxColumn,
            this.aveEnergyConsumptionDataGridViewTextBoxColumn,
            this.collectedDataNumDataGridViewTextBoxColumn});
			this.resultTable.DataSource = this.simBindingSource;
			this.resultTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultTable.Location = new System.Drawing.Point(3, 3);
			this.resultTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.resultTable.MultiSelect = false;
			this.resultTable.Name = "resultTable";
			this.resultTable.ReadOnly = true;
			this.resultTable.RowHeadersVisible = false;
			this.resultTable.RowHeadersWidth = 62;
			this.resultTable.RowTemplate.Height = 27;
			this.resultTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.resultTable.Size = new System.Drawing.Size(947, 118);
			this.resultTable.TabIndex = 7;
			this.resultTable.SelectionChanged += new System.EventHandler(this.ResultTable_SelectionChanged);
			// 
			// algoNameDataGridViewTextBoxColumn
			// 
			this.algoNameDataGridViewTextBoxColumn.DataPropertyName = "AlgoName";
			this.algoNameDataGridViewTextBoxColumn.HeaderText = "アルゴリズム";
			this.algoNameDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.algoNameDataGridViewTextBoxColumn.Name = "algoNameDataGridViewTextBoxColumn";
			this.algoNameDataGridViewTextBoxColumn.ReadOnly = true;
			this.algoNameDataGridViewTextBoxColumn.Width = 85;
			// 
			// fDNDataGridViewTextBoxColumn
			// 
			this.fDNDataGridViewTextBoxColumn.DataPropertyName = "FDN";
			this.fDNDataGridViewTextBoxColumn.HeaderText = "FDN";
			this.fDNDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.fDNDataGridViewTextBoxColumn.Name = "fDNDataGridViewTextBoxColumn";
			this.fDNDataGridViewTextBoxColumn.ReadOnly = true;
			this.fDNDataGridViewTextBoxColumn.Width = 55;
			// 
			// lDNDataGridViewTextBoxColumn
			// 
			this.lDNDataGridViewTextBoxColumn.DataPropertyName = "LDN";
			this.lDNDataGridViewTextBoxColumn.HeaderText = "LDN";
			this.lDNDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.lDNDataGridViewTextBoxColumn.Name = "lDNDataGridViewTextBoxColumn";
			this.lDNDataGridViewTextBoxColumn.ReadOnly = true;
			this.lDNDataGridViewTextBoxColumn.Width = 55;
			// 
			// cHMeanDataGridViewTextBoxColumn
			// 
			this.cHMeanDataGridViewTextBoxColumn.DataPropertyName = "CHMean";
			dataGridViewCellStyle5.Format = "N6";
			dataGridViewCellStyle5.NullValue = null;
			this.cHMeanDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
			this.cHMeanDataGridViewTextBoxColumn.HeaderText = "CH平均";
			this.cHMeanDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.cHMeanDataGridViewTextBoxColumn.Name = "cHMeanDataGridViewTextBoxColumn";
			this.cHMeanDataGridViewTextBoxColumn.ReadOnly = true;
			this.cHMeanDataGridViewTextBoxColumn.Width = 72;
			// 
			// cHSDDataGridViewTextBoxColumn
			// 
			this.cHSDDataGridViewTextBoxColumn.DataPropertyName = "CHSD";
			dataGridViewCellStyle6.Format = "N6";
			dataGridViewCellStyle6.NullValue = null;
			this.cHSDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
			this.cHSDDataGridViewTextBoxColumn.HeaderText = "CH標準偏差";
			this.cHSDDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.cHSDDataGridViewTextBoxColumn.Name = "cHSDDataGridViewTextBoxColumn";
			this.cHSDDataGridViewTextBoxColumn.ReadOnly = true;
			this.cHSDDataGridViewTextBoxColumn.Width = 96;
			// 
			// aveEnergyConsumptionDataGridViewTextBoxColumn
			// 
			this.aveEnergyConsumptionDataGridViewTextBoxColumn.DataPropertyName = "AveEnergyConsumption";
			dataGridViewCellStyle7.Format = "N6";
			dataGridViewCellStyle7.NullValue = null;
			this.aveEnergyConsumptionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
			this.aveEnergyConsumptionDataGridViewTextBoxColumn.HeaderText = "平均消費E";
			this.aveEnergyConsumptionDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.aveEnergyConsumptionDataGridViewTextBoxColumn.Name = "aveEnergyConsumptionDataGridViewTextBoxColumn";
			this.aveEnergyConsumptionDataGridViewTextBoxColumn.ReadOnly = true;
			this.aveEnergyConsumptionDataGridViewTextBoxColumn.Width = 86;
			// 
			// collectedDataNumDataGridViewTextBoxColumn
			// 
			this.collectedDataNumDataGridViewTextBoxColumn.DataPropertyName = "CollectedDataNum";
			this.collectedDataNumDataGridViewTextBoxColumn.HeaderText = "収集データ数";
			this.collectedDataNumDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.collectedDataNumDataGridViewTextBoxColumn.Name = "collectedDataNumDataGridViewTextBoxColumn";
			this.collectedDataNumDataGridViewTextBoxColumn.ReadOnly = true;
			this.collectedDataNumDataGridViewTextBoxColumn.Width = 94;
			// 
			// simBindingSource
			// 
			this.simBindingSource.DataSource = typeof(VisualizeNetwork.Sim);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.シナリオToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(963, 24);
			this.menuStrip1.TabIndex = 15;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ファイルFToolStripMenuItem
			// 
			this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpen,
            this.menuItemCreate,
            this.toolStripMenuItem1,
            this.jsonToolStripMenuItem,
            this.SaveToolStripMenuItem});
			this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
			this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
			// 
			// toolStripMenuItemOpen
			// 
			this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
			this.toolStripMenuItemOpen.Size = new System.Drawing.Size(172, 22);
			this.toolStripMenuItemOpen.Text = "開く(&O)...";
			this.toolStripMenuItemOpen.Click += new System.EventHandler(this.BtnOpenFile_Click);
			// 
			// menuItemCreate
			// 
			this.menuItemCreate.Name = "menuItemCreate";
			this.menuItemCreate.Size = new System.Drawing.Size(172, 22);
			this.menuItemCreate.Text = "ランダムに作成(&C)";
			this.menuItemCreate.Click += new System.EventHandler(this.MenuItemCreate_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(169, 6);
			// 
			// jsonToolStripMenuItem
			// 
			this.jsonToolStripMenuItem.Name = "jsonToolStripMenuItem";
			this.jsonToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.jsonToolStripMenuItem.Text = "シナリオファイルを開く";
			this.jsonToolStripMenuItem.Click += new System.EventHandler(this.OpenScenarioToolStripMenuItem_Click);
			// 
			// SaveToolStripMenuItem
			// 
			this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
			this.SaveToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.SaveToolStripMenuItem.Text = "保存";
			this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveScenarioToolStripMenuItem_Click);
			// 
			// シナリオToolStripMenuItem
			// 
			this.シナリオToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.d100ToolStripMenuItem1,
            this.d400ToolStripMenuItem,
            this.d600ToolStripMenuItem});
			this.シナリオToolStripMenuItem.Name = "シナリオToolStripMenuItem";
			this.シナリオToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
			this.シナリオToolStripMenuItem.Text = "100シナリオ";
			// 
			// d100ToolStripMenuItem1
			// 
			this.d100ToolStripMenuItem1.Name = "d100ToolStripMenuItem1";
			this.d100ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
			this.d100ToolStripMenuItem1.Text = "D100";
			this.d100ToolStripMenuItem1.Click += new System.EventHandler(this.D100ToolStripMenuItem_Click);
			// 
			// d400ToolStripMenuItem
			// 
			this.d400ToolStripMenuItem.Name = "d400ToolStripMenuItem";
			this.d400ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.d400ToolStripMenuItem.Text = "D400";
			// 
			// d600ToolStripMenuItem
			// 
			this.d600ToolStripMenuItem.Name = "d600ToolStripMenuItem";
			this.d600ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.d600ToolStripMenuItem.Text = "D600";
			// 
			// btnNext
			// 
			this.btnNext.BackgroundImage = global::VisualizeNetwork.Properties.Resources.次ボタン;
			this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnNext.FlatAppearance.BorderSize = 0;
			this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNext.Location = new System.Drawing.Point(86, 79);
			this.btnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(24, 26);
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
			this.btnBack.Location = new System.Drawing.Point(11, 79);
			this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(24, 26);
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
			this.btnPlayPose.Location = new System.Drawing.Point(46, 76);
			this.btnPlayPose.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.btnPlayPose.Name = "btnPlayPose";
			this.btnPlayPose.Size = new System.Drawing.Size(30, 34);
			this.btnPlayPose.TabIndex = 5;
			this.btnPlayPose.UseVisualStyleBackColor = false;
			this.btnPlayPose.Click += new System.EventHandler(this.BtnPlayPose_Click);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.splitContainer1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(963, 540);
			this.panel1.TabIndex = 17;
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(0, 120);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.AutoScroll = true;
			this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer1.Panel1.Controls.Add(this.tabCtrlMiddle);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabCtrlBottom);
			this.splitContainer1.Size = new System.Drawing.Size(963, 420);
			this.splitContainer1.SplitterDistance = 259;
			this.splitContainer1.SplitterWidth = 7;
			this.splitContainer1.TabIndex = 11;
			// 
			// tabCtrlBottom
			// 
			this.tabCtrlBottom.Controls.Add(this.tabResultTable);
			this.tabCtrlBottom.Controls.Add(this.tabLog);
			this.tabCtrlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabCtrlBottom.Location = new System.Drawing.Point(0, 0);
			this.tabCtrlBottom.Name = "tabCtrlBottom";
			this.tabCtrlBottom.SelectedIndex = 0;
			this.tabCtrlBottom.Size = new System.Drawing.Size(961, 152);
			this.tabCtrlBottom.TabIndex = 9;
			// 
			// tabResultTable
			// 
			this.tabResultTable.Controls.Add(this.resultTable);
			this.tabResultTable.Location = new System.Drawing.Point(4, 24);
			this.tabResultTable.Name = "tabResultTable";
			this.tabResultTable.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabResultTable.Size = new System.Drawing.Size(953, 124);
			this.tabResultTable.TabIndex = 0;
			this.tabResultTable.Text = "結果";
			this.tabResultTable.UseVisualStyleBackColor = true;
			// 
			// tabLog
			// 
			this.tabLog.Controls.Add(this.textBoxLog);
			this.tabLog.Location = new System.Drawing.Point(4, 24);
			this.tabLog.Name = "tabLog";
			this.tabLog.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabLog.Size = new System.Drawing.Size(745, 73);
			this.tabLog.TabIndex = 1;
			this.tabLog.Text = "ログ";
			this.tabLog.UseVisualStyleBackColor = true;
			// 
			// textBoxLog
			// 
			this.textBoxLog.BackColor = System.Drawing.SystemColors.HighlightText;
			this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxLog.Location = new System.Drawing.Point(3, 3);
			this.textBoxLog.Multiline = true;
			this.textBoxLog.Name = "textBoxLog";
			this.textBoxLog.ReadOnly = true;
			this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxLog.Size = new System.Drawing.Size(739, 67);
			this.textBoxLog.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.labelScenario);
			this.panel2.Controls.Add(this.labelPlaySpeed);
			this.panel2.Controls.Add(this.trackBarPlaySpeed);
			this.panel2.Controls.Add(this.trackBarRound);
			this.panel2.Controls.Add(this.labelRound);
			this.panel2.Controls.Add(this.btnNext);
			this.panel2.Controls.Add(this.btnPlayPose);
			this.panel2.Controls.Add(this.btnBack);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(0, 22, 0, 0);
			this.panel2.Size = new System.Drawing.Size(963, 120);
			this.panel2.TabIndex = 0;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(580, 38);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(38, 15);
			this.label7.TabIndex = 12;
			this.label7.Text = "label7";
			// 
			// labelScenario
			// 
			this.labelScenario.AutoSize = true;
			this.labelScenario.Location = new System.Drawing.Point(457, 81);
			this.labelScenario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelScenario.Name = "labelScenario";
			this.labelScenario.Size = new System.Drawing.Size(73, 15);
			this.labelScenario.TabIndex = 11;
			this.labelScenario.Text = "シナリオ：なし";
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelProcessing,
            this.progressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 540);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
			this.statusStrip1.Size = new System.Drawing.Size(963, 22);
			this.statusStrip1.TabIndex = 8;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// labelProcessing
			// 
			this.labelProcessing.Name = "labelProcessing";
			this.labelProcessing.Size = new System.Drawing.Size(55, 17);
			this.labelProcessing.Text = "準備完了";
			// 
			// progressBar1
			// 
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(100, 16);
			this.progressBar1.Step = 1;
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// process1
			// 
			this.process1.StartInfo.Domain = "";
			this.process1.StartInfo.LoadUserProfile = false;
			this.process1.StartInfo.Password = null;
			this.process1.StartInfo.StandardErrorEncoding = null;
			this.process1.StartInfo.StandardOutputEncoding = null;
			this.process1.StartInfo.UserName = "";
			this.process1.SynchronizingObject = this;
			// 
			// form1BindingSource
			// 
			this.form1BindingSource.DataSource = typeof(VisualizeNetwork.Form1);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(963, 562);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStrip1);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.MinimumSize = new System.Drawing.Size(964, 580);
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "VisualizeNetwork";
			((System.ComponentModel.ISupportInitialize)(this.trackBarRound)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarPlaySpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chartAliveNums)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chartNumCH)).EndInit();
			this.tabCtrlMiddle.ResumeLayout(false);
			this.Simulation.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNodeMap)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.roundTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nodeBindingSource)).EndInit();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.Chart1.ResumeLayout(false);
			this.Chart2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartTotalEnergyConsumption)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chartReceivedData)).EndInit();
			this.設定.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownP)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).EndInit();
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
			((System.ComponentModel.ISupportInitialize)(this.resultTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.simBindingSource)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabCtrlBottom.ResumeLayout(false);
			this.tabResultTable.ResumeLayout(false);
			this.tabLog.ResumeLayout(false);
			this.tabLog.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
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
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox cmbBoxAlgo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAliveNums;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNumCH;
        private System.Windows.Forms.TabControl tabCtrlMiddle;
        private System.Windows.Forms.TabPage Simulation;
        private System.Windows.Forms.TabPage Chart1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.TabPage Chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotalEnergyConsumption;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReceivedData;
        private System.Windows.Forms.TabPage 設定;
        private System.Windows.Forms.GroupBox groupBoxInitialEnergy;
        private System.Windows.Forms.RadioButton radioBtnRandInitEnergy;
        private System.Windows.Forms.RadioButton radioBtnConstInitEnergy;
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
        private System.Windows.Forms.ToolStripMenuItem menuItemCreate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownP;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox cbMy_IEE_LEACH;
		private System.Windows.Forms.CheckBox cbMy_IEE_LEACH_B;
		private System.Windows.Forms.CheckBox cbIEE_LEACH_B;
		private System.Windows.Forms.CheckBox cbIEE_LEACH_A;
		private System.Windows.Forms.CheckBox cbIEE_LEACH;
		private System.Windows.Forms.CheckBox cbLEACH;
		private System.Windows.Forms.CheckBox cbDirect;
		private System.Windows.Forms.ToolStripMenuItem jsonToolStripMenuItem;
		private System.Windows.Forms.Label labelScenario;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem シナリオToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem d100ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem d400ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem d600ToolStripMenuItem;
		private System.Windows.Forms.TabControl tabCtrlBottom;
		private System.Windows.Forms.TabPage tabResultTable;
		private System.Windows.Forms.TabPage tabLog;
		private System.Windows.Forms.TextBox textBoxLog;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.DataGridView roundTable;
		private System.Windows.Forms.BindingSource nodeBindingSource;
		private System.Windows.Forms.DataGridView resultTable;
		private System.Windows.Forms.BindingSource simBindingSource;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn xDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn yDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn einitDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cHIDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn memberNumDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn piDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cmsEnergyDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn erDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn hasCHCntDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn unqualifiedRoundDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn algoNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn fDNDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn lDNDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cHMeanDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cHSDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn aveEnergyConsumptionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn collectedDataNumDataGridViewTextBoxColumn;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel labelProcessing;
		private System.Windows.Forms.ToolStripProgressBar progressBar1;
		private System.Diagnostics.Process process1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.BindingSource form1BindingSource;
	}
}


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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.resultTable = new System.Windows.Forms.DataGridView();
            this.algorithm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHsd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.cmbBoxAlg = new System.Windows.Forms.ComboBox();
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
            this.Statics = new System.Windows.Forms.TabPage();
            this.CH無資格期間 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAliveNums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNumCH)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Simulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableEnergy)).BeginInit();
            this.Statics.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(0, 53);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(768, 750);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(764, 750);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(784, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "ファイルを選択";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 953);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "座標：";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(128, 9);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(650, 69);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "ラウンド：1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(70, 64);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 33);
            this.button2.TabIndex = 5;
            this.button2.Text = "再生";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(218, 64);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar2.Minimum = 1;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(338, 69);
            this.trackBar2.TabIndex = 6;
            this.trackBar2.Value = 1;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(562, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "1 (round/s)";
            // 
            // resultTable
            // 
            this.resultTable.AllowUserToAddRows = false;
            this.resultTable.AllowUserToDeleteRows = false;
            this.resultTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.resultTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.resultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.algorithm,
            this.FDN,
            this.LDN,
            this.CHave,
            this.CHsd});
            this.resultTable.Location = new System.Drawing.Point(10, 974);
            this.resultTable.Name = "resultTable";
            this.resultTable.ReadOnly = true;
            this.resultTable.RowHeadersVisible = false;
            this.resultTable.RowHeadersWidth = 62;
            this.resultTable.RowTemplate.Height = 27;
            this.resultTable.Size = new System.Drawing.Size(1030, 202);
            this.resultTable.TabIndex = 8;
            this.resultTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultTable_CellDoubleClick);
            // 
            // algorithm
            // 
            this.algorithm.HeaderText = "algorithm";
            this.algorithm.MinimumWidth = 8;
            this.algorithm.Name = "algorithm";
            this.algorithm.ReadOnly = true;
            this.algorithm.Width = 112;
            // 
            // FDN
            // 
            this.FDN.HeaderText = "FDN(rounds)";
            this.FDN.MinimumWidth = 8;
            this.FDN.Name = "FDN";
            this.FDN.ReadOnly = true;
            this.FDN.Width = 138;
            // 
            // LDN
            // 
            this.LDN.HeaderText = "LDN(rounds)";
            this.LDN.MinimumWidth = 8;
            this.LDN.Name = "LDN";
            this.LDN.ReadOnly = true;
            this.LDN.Width = 138;
            // 
            // CHave
            // 
            this.CHave.HeaderText = "CHave";
            this.CHave.MinimumWidth = 8;
            this.CHave.Name = "CHave";
            this.CHave.ReadOnly = true;
            this.CHave.Width = 95;
            // 
            // CHsd
            // 
            this.CHsd.HeaderText = "CHsd";
            this.CHsd.MinimumWidth = 8;
            this.CHsd.Name = "CHsd";
            this.CHsd.ReadOnly = true;
            this.CHsd.Width = 85;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(13, 64);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(52, 33);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "前";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(152, 64);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(52, 33);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "次";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // cmbBoxAlg
            // 
            this.cmbBoxAlg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxAlg.FormattingEnabled = true;
            this.cmbBoxAlg.Location = new System.Drawing.Point(5, 17);
            this.cmbBoxAlg.Name = "cmbBoxAlg";
            this.cmbBoxAlg.Size = new System.Drawing.Size(166, 26);
            this.cmbBoxAlg.TabIndex = 11;
            this.cmbBoxAlg.SelectedIndexChanged += new System.EventHandler(this.cmbBoxAlg_SelectedIndexChanged);
            // 
            // chartAliveNums
            // 
            chartArea1.Name = "ChartArea1";
            this.chartAliveNums.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartAliveNums.Legends.Add(legend1);
            this.chartAliveNums.Location = new System.Drawing.Point(13, 24);
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
            this.chartNumCH.Location = new System.Drawing.Point(773, 24);
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
            this.tabControl1.Controls.Add(this.Statics);
            this.tabControl1.Location = new System.Drawing.Point(13, 101);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1577, 843);
            this.tabControl1.TabIndex = 14;
            // 
            // Simulation
            // 
            this.Simulation.Controls.Add(this.tableEnergy);
            this.Simulation.Controls.Add(this.pictureBox1);
            this.Simulation.Controls.Add(this.cmbBoxAlg);
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
            this.tableEnergy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableEnergy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nodeID,
            this.CHID,
            this.残量E,
            this.消費E,
            this.CH回数,
            this.CH無資格期間});
            this.tableEnergy.Location = new System.Drawing.Point(775, 53);
            this.tableEnergy.Margin = new System.Windows.Forms.Padding(2);
            this.tableEnergy.Name = "tableEnergy";
            this.tableEnergy.ReadOnly = true;
            this.tableEnergy.RowHeadersVisible = false;
            this.tableEnergy.RowHeadersWidth = 82;
            this.tableEnergy.RowTemplate.Height = 33;
            this.tableEnergy.Size = new System.Drawing.Size(697, 750);
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
            // Statics
            // 
            this.Statics.Controls.Add(this.chartNumCH);
            this.Statics.Controls.Add(this.chartAliveNums);
            this.Statics.Location = new System.Drawing.Point(4, 28);
            this.Statics.Margin = new System.Windows.Forms.Padding(2);
            this.Statics.Name = "Statics";
            this.Statics.Padding = new System.Windows.Forms.Padding(2);
            this.Statics.Size = new System.Drawing.Size(1569, 811);
            this.Statics.TabIndex = 1;
            this.Statics.Text = "Statics";
            this.Statics.UseVisualStyleBackColor = true;
            // 
            // CH無資格期間
            // 
            this.CH無資格期間.HeaderText = "CH無資格期間";
            this.CH無資格期間.MinimumWidth = 8;
            this.CH無資格期間.Name = "CH無資格期間";
            this.CH無資格期間.ReadOnly = true;
            this.CH無資格期間.Width = 113;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1605, 1186);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.resultTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(963, 864);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAliveNums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNumCH)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Simulation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableEnergy)).EndInit();
            this.Statics.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView resultTable;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox cmbBoxAlg;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAliveNums;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNumCH;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Simulation;
        private System.Windows.Forms.TabPage Statics;
        private System.Windows.Forms.DataGridView tableEnergy;
        private System.Windows.Forms.DataGridViewTextBoxColumn algorithm;
        private System.Windows.Forms.DataGridViewTextBoxColumn FDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn LDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHave;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHsd;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 残量E;
        private System.Windows.Forms.DataGridViewTextBoxColumn 消費E;
        private System.Windows.Forms.DataGridViewTextBoxColumn CH回数;
        private System.Windows.Forms.DataGridViewTextBoxColumn CH無資格期間;
    }
}


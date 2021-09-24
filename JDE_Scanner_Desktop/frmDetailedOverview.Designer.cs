namespace JDE_Scanner_Desktop
{
    partial class frmDetailedOverview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetailedOverview));
            this.pnlImages = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLeftSide = new System.Windows.Forms.Panel();
            this.pnlSplitterLeft = new System.Windows.Forms.Panel();
            this.pnlActionsProgress = new System.Windows.Forms.Panel();
            this.chartProgress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlMiddleSpacer = new System.Windows.Forms.Panel();
            this.pnlProcesses = new System.Windows.Forms.Panel();
            this.pnlSpacer = new System.Windows.Forms.Panel();
            this.pnlTopSpacer = new System.Windows.Forms.Panel();
            this.chrtSets = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlLeftSide.SuspendLayout();
            this.pnlActionsProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProgress)).BeginInit();
            this.pnlProcesses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtSets)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlImages
            // 
            this.pnlImages.AutoScroll = true;
            this.pnlImages.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlImages.Location = new System.Drawing.Point(0, 0);
            this.pnlImages.Name = "pnlImages";
            this.pnlImages.Size = new System.Drawing.Size(170, 542);
            this.pnlImages.TabIndex = 0;
            // 
            // pnlLeftSide
            // 
            this.pnlLeftSide.Controls.Add(this.chrtSets);
            this.pnlLeftSide.Controls.Add(this.pnlSplitterLeft);
            this.pnlLeftSide.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLeftSide.Location = new System.Drawing.Point(600, 0);
            this.pnlLeftSide.Name = "pnlLeftSide";
            this.pnlLeftSide.Size = new System.Drawing.Size(200, 542);
            this.pnlLeftSide.TabIndex = 1;
            // 
            // pnlSplitterLeft
            // 
            this.pnlSplitterLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSplitterLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlSplitterLeft.Name = "pnlSplitterLeft";
            this.pnlSplitterLeft.Size = new System.Drawing.Size(10, 542);
            this.pnlSplitterLeft.TabIndex = 0;
            // 
            // pnlActionsProgress
            // 
            this.pnlActionsProgress.Controls.Add(this.chartProgress);
            this.pnlActionsProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActionsProgress.Location = new System.Drawing.Point(170, 170);
            this.pnlActionsProgress.Name = "pnlActionsProgress";
            this.pnlActionsProgress.Size = new System.Drawing.Size(430, 200);
            this.pnlActionsProgress.TabIndex = 8;
            // 
            // chartProgress
            // 
            this.chartProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartProgress.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend2.Name = "Legend1";
            this.chartProgress.Legends.Add(legend2);
            this.chartProgress.Location = new System.Drawing.Point(21, 3);
            this.chartProgress.MaximumSize = new System.Drawing.Size(800, 200);
            this.chartProgress.MinimumSize = new System.Drawing.Size(400, 190);
            this.chartProgress.Name = "chartProgress";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Konserwacje";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Smarowania";
            this.chartProgress.Series.Add(series2);
            this.chartProgress.Series.Add(series3);
            this.chartProgress.Size = new System.Drawing.Size(409, 194);
            this.chartProgress.TabIndex = 5;
            this.chartProgress.Text = "chart1";
            // 
            // pnlMiddleSpacer
            // 
            this.pnlMiddleSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddleSpacer.Location = new System.Drawing.Point(170, 160);
            this.pnlMiddleSpacer.Name = "pnlMiddleSpacer";
            this.pnlMiddleSpacer.Size = new System.Drawing.Size(430, 10);
            this.pnlMiddleSpacer.TabIndex = 7;
            // 
            // pnlProcesses
            // 
            this.pnlProcesses.Controls.Add(this.pnlSpacer);
            this.pnlProcesses.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProcesses.Location = new System.Drawing.Point(170, 10);
            this.pnlProcesses.Name = "pnlProcesses";
            this.pnlProcesses.Size = new System.Drawing.Size(430, 150);
            this.pnlProcesses.TabIndex = 6;
            // 
            // pnlSpacer
            // 
            this.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSpacer.Location = new System.Drawing.Point(0, 0);
            this.pnlSpacer.Name = "pnlSpacer";
            this.pnlSpacer.Size = new System.Drawing.Size(50, 150);
            this.pnlSpacer.TabIndex = 0;
            // 
            // pnlTopSpacer
            // 
            this.pnlTopSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopSpacer.Location = new System.Drawing.Point(170, 0);
            this.pnlTopSpacer.Name = "pnlTopSpacer";
            this.pnlTopSpacer.Size = new System.Drawing.Size(430, 10);
            this.pnlTopSpacer.TabIndex = 5;
            // 
            // chrtSets
            // 
            chartArea1.Name = "ChartArea1";
            this.chrtSets.ChartAreas.Add(chartArea1);
            this.chrtSets.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Legend1";
            this.chrtSets.Legends.Add(legend1);
            this.chrtSets.Location = new System.Drawing.Point(10, 0);
            this.chrtSets.Name = "chrtSets";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrtSets.Series.Add(series1);
            this.chrtSets.Size = new System.Drawing.Size(190, 542);
            this.chrtSets.TabIndex = 1;
            // 
            // frmDetailedOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.pnlActionsProgress);
            this.Controls.Add(this.pnlMiddleSpacer);
            this.Controls.Add(this.pnlProcesses);
            this.Controls.Add(this.pnlTopSpacer);
            this.Controls.Add(this.pnlLeftSide);
            this.Controls.Add(this.pnlImages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDetailedOverview";
            this.Text = "frmDetailedOverview";
            this.Load += new System.EventHandler(this.frmDetailedOverview_Load);
            this.pnlLeftSide.ResumeLayout(false);
            this.pnlActionsProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartProgress)).EndInit();
            this.pnlProcesses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrtSets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlImages;
        private System.Windows.Forms.Panel pnlLeftSide;
        private System.Windows.Forms.Panel pnlActionsProgress;
        private System.Windows.Forms.Panel pnlMiddleSpacer;
        private System.Windows.Forms.Panel pnlProcesses;
        private System.Windows.Forms.Panel pnlSpacer;
        private System.Windows.Forms.Panel pnlTopSpacer;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProgress;
        private System.Windows.Forms.Panel pnlSplitterLeft;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtSets;
    }
}
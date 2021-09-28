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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetailedOverview));
            this.pnlImages = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMiddleSpacer = new System.Windows.Forms.Panel();
            this.pnlProcesses = new System.Windows.Forms.Panel();
            this.pnlSpacer = new System.Windows.Forms.Panel();
            this.pnlTopSpacer = new System.Windows.Forms.Panel();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pnlMidBottom = new System.Windows.Forms.Panel();
            this.chrtSets = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlMidSpacer = new System.Windows.Forms.Panel();
            this.pnlActionsProgress = new System.Windows.Forms.Panel();
            this.chartProgress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlMidRight = new System.Windows.Forms.Panel();
            this.pnlProcesses.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlMidBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtSets)).BeginInit();
            this.pnlActionsProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProgress)).BeginInit();
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
            // pnlMiddleSpacer
            // 
            this.pnlMiddleSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddleSpacer.Location = new System.Drawing.Point(170, 160);
            this.pnlMiddleSpacer.Name = "pnlMiddleSpacer";
            this.pnlMiddleSpacer.Size = new System.Drawing.Size(630, 10);
            this.pnlMiddleSpacer.TabIndex = 7;
            // 
            // pnlProcesses
            // 
            this.pnlProcesses.Controls.Add(this.pnlSpacer);
            this.pnlProcesses.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProcesses.Location = new System.Drawing.Point(170, 10);
            this.pnlProcesses.Name = "pnlProcesses";
            this.pnlProcesses.Size = new System.Drawing.Size(630, 150);
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
            this.pnlTopSpacer.Size = new System.Drawing.Size(630, 10);
            this.pnlTopSpacer.TabIndex = 5;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.pnlMidBottom);
            this.pnlMiddle.Controls.Add(this.pnlMidSpacer);
            this.pnlMiddle.Controls.Add(this.pnlActionsProgress);
            this.pnlMiddle.Controls.Add(this.pnlMidRight);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(170, 170);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(630, 372);
            this.pnlMiddle.TabIndex = 8;
            // 
            // pnlMidBottom
            // 
            this.pnlMidBottom.Controls.Add(this.chrtSets);
            this.pnlMidBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMidBottom.Location = new System.Drawing.Point(0, 210);
            this.pnlMidBottom.Name = "pnlMidBottom";
            this.pnlMidBottom.Size = new System.Drawing.Size(430, 162);
            this.pnlMidBottom.TabIndex = 11;
            // 
            // chrtSets
            // 
            this.chrtSets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chrtSets.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chrtSets.Legends.Add(legend1);
            this.chrtSets.Location = new System.Drawing.Point(0, 8);
            this.chrtSets.Name = "chrtSets";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.SmartLabelStyle.IsMarkerOverlappingAllowed = true;
            this.chrtSets.Series.Add(series1);
            this.chrtSets.Size = new System.Drawing.Size(430, 142);
            this.chrtSets.TabIndex = 4;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            title1.Name = "Title1";
            title1.Text = "Najbardziej angażujące instalacje";
            this.chrtSets.Titles.Add(title1);
            this.chrtSets.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chrtSets_MouseDown);
            this.chrtSets.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chrtSets_MouseMove);
            // 
            // pnlMidSpacer
            // 
            this.pnlMidSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMidSpacer.Location = new System.Drawing.Point(0, 200);
            this.pnlMidSpacer.Name = "pnlMidSpacer";
            this.pnlMidSpacer.Size = new System.Drawing.Size(430, 10);
            this.pnlMidSpacer.TabIndex = 10;
            // 
            // pnlActionsProgress
            // 
            this.pnlActionsProgress.Controls.Add(this.chartProgress);
            this.pnlActionsProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActionsProgress.Location = new System.Drawing.Point(0, 0);
            this.pnlActionsProgress.Name = "pnlActionsProgress";
            this.pnlActionsProgress.Size = new System.Drawing.Size(430, 200);
            this.pnlActionsProgress.TabIndex = 9;
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
            this.chartProgress.Location = new System.Drawing.Point(15, 0);
            this.chartProgress.MaximumSize = new System.Drawing.Size(800, 200);
            this.chartProgress.MinimumSize = new System.Drawing.Size(400, 190);
            this.chartProgress.Name = "chartProgress";
            this.chartProgress.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            this.chartProgress.Size = new System.Drawing.Size(400, 200);
            this.chartProgress.TabIndex = 6;
            this.chartProgress.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            title2.Name = "Title1";
            title2.Text = "Realizacja zaplanowanych czynności";
            this.chartProgress.Titles.Add(title2);
            // 
            // pnlMidRight
            // 
            this.pnlMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMidRight.Location = new System.Drawing.Point(430, 0);
            this.pnlMidRight.Name = "pnlMidRight";
            this.pnlMidRight.Size = new System.Drawing.Size(200, 372);
            this.pnlMidRight.TabIndex = 0;
            // 
            // frmDetailedOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlMiddleSpacer);
            this.Controls.Add(this.pnlProcesses);
            this.Controls.Add(this.pnlTopSpacer);
            this.Controls.Add(this.pnlImages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDetailedOverview";
            this.Text = "frmDetailedOverview";
            this.Load += new System.EventHandler(this.frmDetailedOverview_Load);
            this.pnlProcesses.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMidBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrtSets)).EndInit();
            this.pnlActionsProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlImages;
        private System.Windows.Forms.Panel pnlMiddleSpacer;
        private System.Windows.Forms.Panel pnlProcesses;
        private System.Windows.Forms.Panel pnlSpacer;
        private System.Windows.Forms.Panel pnlTopSpacer;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlMidBottom;
        private System.Windows.Forms.Panel pnlMidSpacer;
        private System.Windows.Forms.Panel pnlActionsProgress;
        private System.Windows.Forms.Panel pnlMidRight;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtSets;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProgress;
    }
}
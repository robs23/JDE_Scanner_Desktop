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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetailedOverview));
            this.pnlImages = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTopSpacer = new System.Windows.Forms.Panel();
            this.pnlProcesses = new System.Windows.Forms.Panel();
            this.pnlSpacer = new System.Windows.Forms.Panel();
            this.pnlMiddleSpacer = new System.Windows.Forms.Panel();
            this.pnlActionsProgress = new System.Windows.Forms.Panel();
            this.chartProgress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlProcesses.SuspendLayout();
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
            this.pnlImages.Size = new System.Drawing.Size(170, 450);
            this.pnlImages.TabIndex = 0;
            // 
            // pnlTopSpacer
            // 
            this.pnlTopSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopSpacer.Location = new System.Drawing.Point(170, 0);
            this.pnlTopSpacer.Name = "pnlTopSpacer";
            this.pnlTopSpacer.Size = new System.Drawing.Size(630, 10);
            this.pnlTopSpacer.TabIndex = 1;
            // 
            // pnlProcesses
            // 
            this.pnlProcesses.Controls.Add(this.pnlSpacer);
            this.pnlProcesses.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProcesses.Location = new System.Drawing.Point(170, 10);
            this.pnlProcesses.Name = "pnlProcesses";
            this.pnlProcesses.Size = new System.Drawing.Size(630, 150);
            this.pnlProcesses.TabIndex = 2;
            // 
            // pnlSpacer
            // 
            this.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSpacer.Location = new System.Drawing.Point(0, 0);
            this.pnlSpacer.Name = "pnlSpacer";
            this.pnlSpacer.Size = new System.Drawing.Size(50, 150);
            this.pnlSpacer.TabIndex = 0;
            // 
            // pnlMiddleSpacer
            // 
            this.pnlMiddleSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddleSpacer.Location = new System.Drawing.Point(170, 160);
            this.pnlMiddleSpacer.Name = "pnlMiddleSpacer";
            this.pnlMiddleSpacer.Size = new System.Drawing.Size(630, 10);
            this.pnlMiddleSpacer.TabIndex = 3;
            // 
            // pnlActionsProgress
            // 
            this.pnlActionsProgress.Controls.Add(this.chartProgress);
            this.pnlActionsProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActionsProgress.Location = new System.Drawing.Point(170, 170);
            this.pnlActionsProgress.Name = "pnlActionsProgress";
            this.pnlActionsProgress.Size = new System.Drawing.Size(630, 200);
            this.pnlActionsProgress.TabIndex = 4;
            // 
            // chartProgress
            // 
            this.chartProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            chartArea1.Name = "ChartArea1";
            this.chartProgress.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Legend1";
            this.chartProgress.Legends.Add(legend1);
            this.chartProgress.Location = new System.Drawing.Point(21, 3);
            this.chartProgress.Name = "chartProgress";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Konserwacje";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Smarowania";
            this.chartProgress.Series.Add(series1);
            this.chartProgress.Series.Add(series2);
            this.chartProgress.Size = new System.Drawing.Size(597, 194);
            this.chartProgress.TabIndex = 5;
            this.chartProgress.Text = "chart1";
            // 
            // frmDetailedOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlActionsProgress);
            this.Controls.Add(this.pnlMiddleSpacer);
            this.Controls.Add(this.pnlProcesses);
            this.Controls.Add(this.pnlTopSpacer);
            this.Controls.Add(this.pnlImages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDetailedOverview";
            this.Text = "frmDetailedOverview";
            this.Load += new System.EventHandler(this.frmDetailedOverview_Load);
            this.pnlProcesses.ResumeLayout(false);
            this.pnlActionsProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlImages;
        private System.Windows.Forms.Panel pnlTopSpacer;
        private System.Windows.Forms.Panel pnlProcesses;
        private System.Windows.Forms.Panel pnlSpacer;
        private System.Windows.Forms.Panel pnlMiddleSpacer;
        private System.Windows.Forms.Panel pnlActionsProgress;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProgress;
    }
}
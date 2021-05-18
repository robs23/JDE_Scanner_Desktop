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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetailedOverview));
            this.pnlImages = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTopSpacer = new System.Windows.Forms.Panel();
            this.pnlProcesses = new System.Windows.Forms.Panel();
            this.pnlSpacer = new System.Windows.Forms.Panel();
            this.pnlProcesses.SuspendLayout();
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
            // frmDetailedOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlProcesses);
            this.Controls.Add(this.pnlTopSpacer);
            this.Controls.Add(this.pnlImages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDetailedOverview";
            this.Text = "frmDetailedOverview";
            this.Load += new System.EventHandler(this.frmDetailedOverview_Load);
            this.pnlProcesses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlImages;
        private System.Windows.Forms.Panel pnlTopSpacer;
        private System.Windows.Forms.Panel pnlProcesses;
        private System.Windows.Forms.Panel pnlSpacer;
    }
}
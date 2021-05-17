namespace JDE_Scanner_Desktop.CustomControls
{
    partial class ImageInfoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlImage = new System.Windows.Forms.Panel();
            this.pnlData = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.pnlShadow = new System.Windows.Forms.Panel();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlImage
            // 
            this.pnlImage.Controls.Add(this.pbImage);
            this.pnlImage.Controls.Add(this.pnlData);
            this.pnlImage.Location = new System.Drawing.Point(0, 0);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(150, 115);
            this.pnlImage.TabIndex = 0;
            // 
            // pnlData
            // 
            this.pnlData.Location = new System.Drawing.Point(0, 117);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(150, 74);
            this.pnlData.TabIndex = 1;
            this.pnlData.Click += new System.EventHandler(this.pnlData_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.Location = new System.Drawing.Point(8, 118);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(133, 44);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Tytuł";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblDetails
            // 
            this.lblDetails.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDetails.Location = new System.Drawing.Point(7, 162);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(134, 29);
            this.lblDetails.TabIndex = 2;
            this.lblDetails.Text = "Szczegóły";
            this.lblDetails.Click += new System.EventHandler(this.lblDetails_Click);
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(3, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(144, 108);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 2;
            this.pbImage.TabStop = false;
            this.pbImage.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // pnlShadow
            // 
            this.pnlShadow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlShadow.BackColor = System.Drawing.Color.DimGray;
            this.pnlShadow.Location = new System.Drawing.Point(0, 197);
            this.pnlShadow.Name = "pnlShadow";
            this.pnlShadow.Size = new System.Drawing.Size(150, 3);
            this.pnlShadow.TabIndex = 3;
            // 
            // ImageInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlShadow);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlImage);
            this.Name = "ImageInfoControl";
            this.Size = new System.Drawing.Size(150, 200);
            this.Click += new System.EventHandler(this.ImageInfoControl_Click);
            this.MouseEnter += new System.EventHandler(this.ImageInfoControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ImageInfoControl_MouseLeave);
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Panel pnlShadow;
    }
}

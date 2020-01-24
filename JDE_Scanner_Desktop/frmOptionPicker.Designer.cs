namespace JDE_Scanner_Desktop
{
    partial class frmOptionPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptionPicker));
            this.clbItems = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // clbItems
            // 
            this.clbItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbItems.FormattingEnabled = true;
            this.clbItems.Location = new System.Drawing.Point(0, 0);
            this.clbItems.Name = "clbItems";
            this.clbItems.Size = new System.Drawing.Size(222, 229);
            this.clbItems.TabIndex = 0;
            // 
            // frmOptionPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(225, 229);
            this.Controls.Add(this.clbItems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptionPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Wybierz opcje..";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOptionPicker_FormClosing);
            this.Load += new System.EventHandler(this.frmOptionPicker_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbItems;
    }
}
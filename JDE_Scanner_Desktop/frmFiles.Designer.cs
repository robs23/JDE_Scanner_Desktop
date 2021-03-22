namespace JDE_Scanner_Desktop
{
    partial class frmFiles
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
            this.components = new System.ComponentModel.Container();
            this.tlpGallery = new System.Windows.Forms.TableLayoutPanel();
            this.lvImages = new System.Windows.Forms.ListView();
            this.tlpGalleryButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbView = new System.Windows.Forms.ComboBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.iList = new System.Windows.Forms.ImageList(this.components);
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tlpGallery.SuspendLayout();
            this.tlpGalleryButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGallery
            // 
            this.tlpGallery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpGallery.ColumnCount = 1;
            this.tlpGallery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGallery.Controls.Add(this.lvImages, 0, 1);
            this.tlpGallery.Controls.Add(this.tlpGalleryButtons, 0, 0);
            this.tlpGallery.Location = new System.Drawing.Point(0, 4);
            this.tlpGallery.Name = "tlpGallery";
            this.tlpGallery.RowCount = 2;
            this.tlpGallery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpGallery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGallery.Size = new System.Drawing.Size(604, 447);
            this.tlpGallery.TabIndex = 1;
            // 
            // lvImages
            // 
            this.lvImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImages.HideSelection = false;
            this.lvImages.Location = new System.Drawing.Point(3, 38);
            this.lvImages.Name = "lvImages";
            this.lvImages.Size = new System.Drawing.Size(598, 406);
            this.lvImages.TabIndex = 2;
            this.lvImages.UseCompatibleStateImageBehavior = false;
            this.lvImages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvImages_MouseDoubleClick);
            // 
            // tlpGalleryButtons
            // 
            this.tlpGalleryButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpGalleryButtons.ColumnCount = 6;
            this.tlpGalleryButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpGalleryButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpGalleryButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGalleryButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpGalleryButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpGalleryButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpGalleryButtons.Controls.Add(this.label1, 4, 0);
            this.tlpGalleryButtons.Controls.Add(this.cmbView, 5, 0);
            this.tlpGalleryButtons.Controls.Add(this.btnUpload, 3, 0);
            this.tlpGalleryButtons.Controls.Add(this.btnAddFile, 1, 0);
            this.tlpGalleryButtons.Controls.Add(this.btnDeleteFile, 0, 0);
            this.tlpGalleryButtons.Location = new System.Drawing.Point(3, 3);
            this.tlpGalleryButtons.Name = "tlpGalleryButtons";
            this.tlpGalleryButtons.RowCount = 1;
            this.tlpGalleryButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGalleryButtons.Size = new System.Drawing.Size(598, 29);
            this.tlpGalleryButtons.TabIndex = 3;
            // 
            // btnAddFile
            // 
            this.btnAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFile.Location = new System.Drawing.Point(153, 3);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(144, 23);
            this.btnAddFile.TabIndex = 0;
            this.btnAddFile.Text = "Dodaj plik";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFile.Location = new System.Drawing.Point(3, 3);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(144, 23);
            this.btnDeleteFile.TabIndex = 1;
            this.btnDeleteFile.Text = "Usuń plik";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(451, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Widok";
            // 
            // cmbView
            // 
            this.cmbView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbView.FormattingEnabled = true;
            this.cmbView.Location = new System.Drawing.Point(501, 4);
            this.cmbView.Name = "cmbView";
            this.cmbView.Size = new System.Drawing.Size(94, 21);
            this.cmbView.TabIndex = 3;
            this.cmbView.SelectedIndexChanged += new System.EventHandler(this.cmbView_SelectedIndexChanged);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.Image = global::JDE_Scanner_Desktop.Properties.Resources.upload_24;
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpload.Location = new System.Drawing.Point(351, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 23);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // iList
            // 
            this.iList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.iList.ImageSize = new System.Drawing.Size(50, 50);
            this.iList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 450);
            this.Controls.Add(this.tlpGallery);
            this.Name = "frmFiles";
            this.Text = "Pliki";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFiles_FormClosing);
            this.Load += new System.EventHandler(this.frmFiles_Load);
            this.tlpGallery.ResumeLayout(false);
            this.tlpGalleryButtons.ResumeLayout(false);
            this.tlpGalleryButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGallery;
        private System.Windows.Forms.ListView lvImages;
        private System.Windows.Forms.TableLayoutPanel tlpGalleryButtons;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.ImageList iList;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbView;
        private System.Windows.Forms.Button btnUpload;
    }
}
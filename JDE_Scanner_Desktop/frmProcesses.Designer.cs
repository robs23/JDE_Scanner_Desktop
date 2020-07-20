﻿using JDE_Scanner_Desktop.CustomControls;

namespace JDE_Scanner_Desktop
{
    partial class frmProcesses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesses));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnReassign = new System.Windows.Forms.Button();
            this.btnComment = new System.Windows.Forms.Button();
            this.dgItems = new JDE_Scanner_Desktop.CustomControls.DBDataGridView();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.sumStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpButtons, 0, 0);
            this.tlpMain.Controls.Add(this.dgItems, 0, 1);
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(571, 363);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpButtons
            // 
            this.tlpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpButtons.ColumnCount = 8;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 405F));
            this.tlpButtons.Controls.Add(this.btnAdd, 0, 0);
            this.tlpButtons.Controls.Add(this.btnRefresh, 3, 0);
            this.tlpButtons.Controls.Add(this.btnFinish, 4, 0);
            this.tlpButtons.Controls.Add(this.btnDelete, 1, 0);
            this.tlpButtons.Controls.Add(this.btnFilter, 2, 0);
            this.tlpButtons.Controls.Add(this.btnReassign, 5, 0);
            this.tlpButtons.Controls.Add(this.btnComment, 6, 0);
            this.tlpButtons.Location = new System.Drawing.Point(3, 3);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(565, 34);
            this.tlpButtons.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 28);
            this.btnAdd.TabIndex = 0;
            this.tooltip.SetToolTip(this.btnAdd, "Dodaj nowy zasób..");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.Add);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(123, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRefresh.Size = new System.Drawing.Size(34, 28);
            this.btnRefresh.TabIndex = 2;
            this.tooltip.SetToolTip(this.btnRefresh, "Odśwież..");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.Refresh);
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Image = global::JDE_Scanner_Desktop.Properties.Resources.finish_icon;
            this.btnFinish.Location = new System.Drawing.Point(163, 3);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(34, 28);
            this.btnFinish.TabIndex = 3;
            this.tooltip.SetToolTip(this.btnFinish, "Zakończ zaznaczone zgłoszenia..");
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(43, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(34, 28);
            this.btnDelete.TabIndex = 1;
            this.tooltip.SetToolTip(this.btnDelete, "Usuń zaznaczony zasób/zasoby");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.Delete);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Image = global::JDE_Scanner_Desktop.Properties.Resources.icon_filter_off;
            this.btnFilter.Location = new System.Drawing.Point(83, 3);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(34, 28);
            this.btnFilter.TabIndex = 4;
            this.tooltip.SetToolTip(this.btnFilter, "Konfiguracja filtra..");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnReassign
            // 
            this.btnReassign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReassign.Image = global::JDE_Scanner_Desktop.Properties.Resources.people_24;
            this.btnReassign.Location = new System.Drawing.Point(203, 3);
            this.btnReassign.Name = "btnReassign";
            this.btnReassign.Size = new System.Drawing.Size(34, 28);
            this.btnReassign.TabIndex = 5;
            this.tooltip.SetToolTip(this.btnReassign, "Zmień przypisanych użytkowników..");
            this.btnReassign.UseVisualStyleBackColor = true;
            this.btnReassign.Click += new System.EventHandler(this.btnReassign_Click);
            // 
            // btnComment
            // 
            this.btnComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComment.Image = global::JDE_Scanner_Desktop.Properties.Resources.Comment_20;
            this.btnComment.Location = new System.Drawing.Point(243, 3);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(34, 28);
            this.btnComment.TabIndex = 6;
            this.tooltip.SetToolTip(this.btnComment, "Dodaj komentarz..");
            this.btnComment.UseVisualStyleBackColor = true;
            this.btnComment.Click += new System.EventHandler(this.btnComment_Click);
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.DoubleBuffered = true;
            this.dgItems.Location = new System.Drawing.Point(3, 43);
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(565, 317);
            this.dgItems.TabIndex = 2;
            this.dgItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgItems_DataError);
            this.dgItems.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgItems_Scroll);
            this.dgItems.DoubleClick += new System.EventHandler(this.View);
            // 
            // sumStatusStrip
            // 
            this.sumStatusStrip.Location = new System.Drawing.Point(0, 378);
            this.sumStatusStrip.Name = "sumStatusStrip";
            this.sumStatusStrip.Size = new System.Drawing.Size(595, 22);
            this.sumStatusStrip.TabIndex = 1;
            this.sumStatusStrip.Text = "statusStrip1";
            // 
            // frmProcesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 400);
            this.Controls.Add(this.sumStatusStrip);
            this.Controls.Add(this.tlpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProcesses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Zgłoszenia";
            this.Load += new System.EventHandler(this.FormLoaded);
            this.tlpMain.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolTip tooltip;
        private DBDataGridView dgItems;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnReassign;
        private System.Windows.Forms.StatusStrip sumStatusStrip;
        private System.Windows.Forms.Button btnComment;
    }
}


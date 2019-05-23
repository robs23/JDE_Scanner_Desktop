namespace JDE_Scanner_Desktop
{
    partial class frmBomItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBomItem));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.tplTextboxes = new System.Windows.Forms.TableLayoutPanel();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tlpPlace = new System.Windows.Forms.TableLayoutPanel();
            this.cmbPlace = new System.Windows.Forms.ComboBox();
            this.btnSearchPlace = new System.Windows.Forms.Button();
            this.tlpPart = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearchPart = new System.Windows.Forms.Button();
            this.cmbPart = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDFrom = new System.Windows.Forms.DateTimePicker();
            this.txtDTo = new System.Windows.Forms.DateTimePicker();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tplTextboxes.SuspendLayout();
            this.tlpPlace.SuspendLayout();
            this.tlpPart.SuspendLayout();
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
            this.tlpMain.Controls.Add(this.tplTextboxes, 0, 1);
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(597, 308);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpButtons
            // 
            this.tlpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpButtons.ColumnCount = 3;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 511F));
            this.tlpButtons.Controls.Add(this.btnSave, 0, 0);
            this.tlpButtons.Location = new System.Drawing.Point(3, 3);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpButtons.Size = new System.Drawing.Size(591, 34);
            this.tlpButtons.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(34, 28);
            this.btnSave.TabIndex = 0;
            this.tooltip.SetToolTip(this.btnSave, "Zapisz zmiany..");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Save);
            // 
            // tplTextboxes
            // 
            this.tplTextboxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplTextboxes.ColumnCount = 2;
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplTextboxes.Controls.Add(this.txtAmount, 1, 2);
            this.tplTextboxes.Controls.Add(this.label2, 0, 0);
            this.tplTextboxes.Controls.Add(this.label4, 0, 2);
            this.tplTextboxes.Controls.Add(this.label5, 0, 3);
            this.tplTextboxes.Controls.Add(this.tlpPlace, 1, 0);
            this.tplTextboxes.Controls.Add(this.tlpPart, 1, 1);
            this.tplTextboxes.Controls.Add(this.label10, 0, 1);
            this.tplTextboxes.Controls.Add(this.cmbUnit, 1, 3);
            this.tplTextboxes.Controls.Add(this.label1, 0, 4);
            this.tplTextboxes.Controls.Add(this.label3, 0, 5);
            this.tplTextboxes.Controls.Add(this.txtDFrom, 1, 4);
            this.tplTextboxes.Controls.Add(this.txtDTo, 1, 5);
            this.tplTextboxes.Location = new System.Drawing.Point(3, 43);
            this.tplTextboxes.Name = "tplTextboxes";
            this.tplTextboxes.RowCount = 11;
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.Size = new System.Drawing.Size(591, 232);
            this.tplTextboxes.TabIndex = 1;
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.Location = new System.Drawing.Point(123, 75);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(465, 20);
            this.txtAmount.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Zasób";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ilość";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Jednostka";
            // 
            // tlpPlace
            // 
            this.tlpPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPlace.ColumnCount = 2;
            this.tlpPlace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPlace.Controls.Add(this.cmbPlace, 0, 0);
            this.tlpPlace.Controls.Add(this.btnSearchPlace, 1, 0);
            this.tlpPlace.Location = new System.Drawing.Point(123, 3);
            this.tlpPlace.Name = "tlpPlace";
            this.tlpPlace.RowCount = 1;
            this.tlpPlace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpPlace.Size = new System.Drawing.Size(465, 29);
            this.tlpPlace.TabIndex = 26;
            // 
            // cmbPlace
            // 
            this.cmbPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPlace.FormattingEnabled = true;
            this.cmbPlace.Location = new System.Drawing.Point(3, 4);
            this.cmbPlace.Name = "cmbPlace";
            this.cmbPlace.Size = new System.Drawing.Size(429, 21);
            this.cmbPlace.TabIndex = 27;
            // 
            // btnSearchPlace
            // 
            this.btnSearchPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchPlace.Image = global::JDE_Scanner_Desktop.Properties.Resources.search_16;
            this.btnSearchPlace.Location = new System.Drawing.Point(438, 3);
            this.btnSearchPlace.Name = "btnSearchPlace";
            this.btnSearchPlace.Size = new System.Drawing.Size(24, 23);
            this.btnSearchPlace.TabIndex = 28;
            this.tooltip.SetToolTip(this.btnSearchPlace, "Wyszukaj..");
            this.btnSearchPlace.UseVisualStyleBackColor = true;
            this.btnSearchPlace.Click += new System.EventHandler(this.btnSearchPlace_Click);
            // 
            // tlpPart
            // 
            this.tlpPart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPart.ColumnCount = 2;
            this.tlpPart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPart.Controls.Add(this.btnSearchPart, 1, 0);
            this.tlpPart.Controls.Add(this.cmbPart, 0, 0);
            this.tlpPart.Location = new System.Drawing.Point(123, 38);
            this.tlpPart.Name = "tlpPart";
            this.tlpPart.RowCount = 1;
            this.tlpPart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpPart.Size = new System.Drawing.Size(465, 29);
            this.tlpPart.TabIndex = 27;
            // 
            // btnSearchPart
            // 
            this.btnSearchPart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchPart.Image = global::JDE_Scanner_Desktop.Properties.Resources.search_16;
            this.btnSearchPart.Location = new System.Drawing.Point(438, 3);
            this.btnSearchPart.Name = "btnSearchPart";
            this.btnSearchPart.Size = new System.Drawing.Size(24, 23);
            this.btnSearchPart.TabIndex = 29;
            this.tooltip.SetToolTip(this.btnSearchPart, "Wyszukaj..");
            this.btnSearchPart.UseVisualStyleBackColor = true;
            // 
            // cmbPart
            // 
            this.cmbPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPart.FormattingEnabled = true;
            this.cmbPart.Location = new System.Drawing.Point(3, 4);
            this.cmbPart.Name = "cmbPart";
            this.cmbPart.Size = new System.Drawing.Size(429, 21);
            this.cmbPart.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Część";
            // 
            // cmbUnit
            // 
            this.cmbUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(123, 104);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(465, 21);
            this.cmbUnit.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Ważne od";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Ważne do";
            // 
            // txtDFrom
            // 
            this.txtDFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDFrom.Location = new System.Drawing.Point(123, 135);
            this.txtDFrom.Name = "txtDFrom";
            this.txtDFrom.Size = new System.Drawing.Size(465, 20);
            this.txtDFrom.TabIndex = 32;
            this.txtDFrom.ValueChanged += new System.EventHandler(this.txtDFrom_ValueChanged);
            // 
            // txtDTo
            // 
            this.txtDTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDTo.Location = new System.Drawing.Point(123, 167);
            this.txtDTo.Name = "txtDTo";
            this.txtDTo.Size = new System.Drawing.Size(465, 20);
            this.txtDTo.TabIndex = 33;
            this.txtDTo.ValueChanged += new System.EventHandler(this.txtDTo_ValueChanged);
            // 
            // frmBomItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 332);
            this.Controls.Add(this.tlpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBomItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Szczegóły pozycji w bomie";
            this.Load += new System.EventHandler(this.FormLoaded);
            this.tlpMain.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.tplTextboxes.ResumeLayout(false);
            this.tplTextboxes.PerformLayout();
            this.tlpPlace.ResumeLayout(false);
            this.tlpPart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.TableLayoutPanel tplTextboxes;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tlpPlace;
        private System.Windows.Forms.ComboBox cmbPlace;
        private System.Windows.Forms.Button btnSearchPlace;
        private System.Windows.Forms.TableLayoutPanel tlpPart;
        private System.Windows.Forms.Button btnSearchPart;
        private System.Windows.Forms.ComboBox cmbPart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtDFrom;
        private System.Windows.Forms.DateTimePicker txtDTo;
    }
}
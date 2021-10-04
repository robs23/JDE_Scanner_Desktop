namespace JDE_Scanner_Desktop
{
    partial class frmOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrder));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboxArchived = new System.Windows.Forms.CheckBox();
            this.cboxShowFinder = new System.Windows.Forms.CheckBox();
            this.lblCreated = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pgGeneral = new System.Windows.Forms.TabPage();
            this.tlpMajor = new System.Windows.Forms.TableLayoutPanel();
            this.tplTextboxes = new System.Windows.Forms.TableLayoutPanel();
            this.txtSupplierOrderNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.txtDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.dgvItems = new JDE_Scanner_Desktop.CustomControls.SpecKeysDataGridView();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.btnArchiveItem = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.pgGeneral.SuspendLayout();
            this.tlpMajor.SuspendLayout();
            this.tplTextboxes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
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
            this.tlpMain.Controls.Add(this.lblCreated, 0, 2);
            this.tlpMain.Controls.Add(this.tabControl, 0, 1);
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(611, 467);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpButtons
            // 
            this.tlpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpButtons.ColumnCount = 6;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpButtons.Controls.Add(this.btnSave, 0, 0);
            this.tlpButtons.Controls.Add(this.cboxArchived, 5, 0);
            this.tlpButtons.Controls.Add(this.cboxShowFinder, 2, 0);
            this.tlpButtons.Controls.Add(this.btnArchiveItem, 1, 0);
            this.tlpButtons.Location = new System.Drawing.Point(3, 3);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(605, 34);
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
            // cboxArchived
            // 
            this.cboxArchived.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cboxArchived.AutoSize = true;
            this.cboxArchived.Location = new System.Drawing.Point(525, 8);
            this.cboxArchived.Name = "cboxArchived";
            this.cboxArchived.Size = new System.Drawing.Size(77, 17);
            this.cboxArchived.TabIndex = 3;
            this.cboxArchived.Text = "Archiwalny";
            this.cboxArchived.ThreeState = true;
            this.cboxArchived.UseVisualStyleBackColor = true;
            // 
            // cboxShowFinder
            // 
            this.cboxShowFinder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxShowFinder.AutoSize = true;
            this.cboxShowFinder.Checked = true;
            this.cboxShowFinder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxShowFinder.Location = new System.Drawing.Point(95, 8);
            this.cboxShowFinder.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.cboxShowFinder.Name = "cboxShowFinder";
            this.cboxShowFinder.Size = new System.Drawing.Size(132, 17);
            this.cboxShowFinder.TabIndex = 4;
            this.cboxShowFinder.Text = "Podpowiadaj części";
            this.tooltip.SetToolTip(this.cboxShowFinder, "Czy program ma podpowiadać indeksy części wg wprowadzonych liter w polu ID części" +
        "?");
            this.cboxShowFinder.UseVisualStyleBackColor = true;
            // 
            // lblCreated
            // 
            this.lblCreated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreated.AutoSize = true;
            this.lblCreated.Location = new System.Drawing.Point(3, 445);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(605, 13);
            this.lblCreated.TabIndex = 2;
            this.lblCreated.Text = "lblCreated";
            this.lblCreated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.pgGeneral);
            this.tabControl.Location = new System.Drawing.Point(3, 43);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(605, 391);
            this.tabControl.TabIndex = 3;
            // 
            // pgGeneral
            // 
            this.pgGeneral.Controls.Add(this.tlpMajor);
            this.pgGeneral.Location = new System.Drawing.Point(4, 22);
            this.pgGeneral.Name = "pgGeneral";
            this.pgGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.pgGeneral.Size = new System.Drawing.Size(597, 365);
            this.pgGeneral.TabIndex = 0;
            this.pgGeneral.Text = "Ogólne";
            this.pgGeneral.UseVisualStyleBackColor = true;
            // 
            // tlpMajor
            // 
            this.tlpMajor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMajor.ColumnCount = 1;
            this.tlpMajor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMajor.Controls.Add(this.tplTextboxes, 0, 0);
            this.tlpMajor.Controls.Add(this.dgvItems, 0, 1);
            this.tlpMajor.Location = new System.Drawing.Point(3, 6);
            this.tlpMajor.Name = "tlpMajor";
            this.tlpMajor.RowCount = 2;
            this.tlpMajor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMajor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMajor.Size = new System.Drawing.Size(591, 356);
            this.tlpMajor.TabIndex = 0;
            // 
            // tplTextboxes
            // 
            this.tplTextboxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplTextboxes.ColumnCount = 4;
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplTextboxes.Controls.Add(this.txtSupplierOrderNo, 1, 1);
            this.tplTextboxes.Controls.Add(this.label2, 0, 0);
            this.tplTextboxes.Controls.Add(this.lblName, 0, 1);
            this.tplTextboxes.Controls.Add(this.txtNumber, 1, 0);
            this.tplTextboxes.Controls.Add(this.label1, 2, 0);
            this.tplTextboxes.Controls.Add(this.label3, 2, 1);
            this.tplTextboxes.Controls.Add(this.cmbSupplier, 3, 0);
            this.tplTextboxes.Controls.Add(this.txtDeliveryDate, 3, 1);
            this.tplTextboxes.Location = new System.Drawing.Point(3, 3);
            this.tplTextboxes.Name = "tplTextboxes";
            this.tplTextboxes.RowCount = 3;
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.Size = new System.Drawing.Size(585, 74);
            this.tplTextboxes.TabIndex = 3;
            // 
            // txtSupplierOrderNo
            // 
            this.txtSupplierOrderNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSupplierOrderNo.Location = new System.Drawing.Point(123, 35);
            this.txtSupplierOrderNo.Name = "txtSupplierOrderNo";
            this.txtSupplierOrderNo.Size = new System.Drawing.Size(166, 20);
            this.txtSupplierOrderNo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Numer";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 38);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(114, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Numer u dostawcy";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumber.Location = new System.Drawing.Point(123, 5);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(166, 20);
            this.txtNumber.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Dostawca";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Data dostawy";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(415, 4);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(167, 21);
            this.cmbSupplier.TabIndex = 33;
            // 
            // txtDeliveryDate
            // 
            this.txtDeliveryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDeliveryDate.Location = new System.Drawing.Point(415, 35);
            this.txtDeliveryDate.Name = "txtDeliveryDate";
            this.txtDeliveryDate.Size = new System.Drawing.Size(167, 20);
            this.txtDeliveryDate.TabIndex = 34;
            // 
            // dgvItems
            // 
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.DoubleBuffered = true;
            this.dgvItems.EnterAction = null;
            this.dgvItems.EnterListeningColumns = null;
            this.dgvItems.EscapeAction = null;
            this.dgvItems.EscapeListeningColumns = null;
            this.dgvItems.KeyDownAction = null;
            this.dgvItems.KeyDownListeningColumns = null;
            this.dgvItems.Location = new System.Drawing.Point(3, 83);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(585, 270);
            this.dgvItems.TabAction = null;
            this.dgvItems.TabIndex = 4;
            this.dgvItems.TabListeningColumns = null;
            this.dgvItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvItems_CellBeginEdit);
            this.dgvItems.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvItems_CellValidating);
            this.dgvItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellValueChanged);
            this.dgvItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvItems_EditingControlShowing);
            // 
            // btnArchiveItem
            // 
            this.btnArchiveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchiveItem.Image = global::JDE_Scanner_Desktop.Properties.Resources.delete_24;
            this.btnArchiveItem.Location = new System.Drawing.Point(43, 3);
            this.btnArchiveItem.Name = "btnArchiveItem";
            this.btnArchiveItem.Size = new System.Drawing.Size(34, 28);
            this.btnArchiveItem.TabIndex = 5;
            this.tooltip.SetToolTip(this.btnArchiveItem, "Usuń zaznaczone pozycje");
            this.btnArchiveItem.UseVisualStyleBackColor = true;
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 491);
            this.Controls.Add(this.tlpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Szczegóły zamówienia";
            this.Load += new System.EventHandler(this.FormLoaded);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.tlpButtons.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.pgGeneral.ResumeLayout(false);
            this.tlpMajor.ResumeLayout(false);
            this.tplTextboxes.ResumeLayout(false);
            this.tplTextboxes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.CheckBox cboxArchived;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pgGeneral;
        private System.Windows.Forms.TableLayoutPanel tlpMajor;
        private System.Windows.Forms.TableLayoutPanel tplTextboxes;
        private System.Windows.Forms.TextBox txtSupplierOrderNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.DateTimePicker txtDeliveryDate;
        private CustomControls.SpecKeysDataGridView dgvItems;
        private System.Windows.Forms.CheckBox cboxShowFinder;
        private System.Windows.Forms.Button btnArchiveItem;
    }
}
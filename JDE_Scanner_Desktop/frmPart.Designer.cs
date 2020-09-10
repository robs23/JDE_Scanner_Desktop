namespace JDE_Scanner_Desktop
{
    partial class frmPart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPart));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.cboxArchived = new System.Windows.Forms.CheckBox();
            this.lblCreated = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pgGeneral = new System.Windows.Forms.TabPage();
            this.tplTextboxes = new System.Windows.Forms.TableLayoutPanel();
            this.txtEAN = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUlica = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtProducersCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tlpSupplier = new System.Windows.Forms.TableLayoutPanel();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.btnEditSupplier = new System.Windows.Forms.Button();
            this.tlpProducer = new System.Windows.Forms.TableLayoutPanel();
            this.cmbProducer = new System.Windows.Forms.ComboBox();
            this.btnAddProducer = new System.Windows.Forms.Button();
            this.btnEditProducer = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtAppliance = new System.Windows.Forms.TextBox();
            this.txtUsedOn = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbQrCode = new System.Windows.Forms.PictureBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.pgBoms = new System.Windows.Forms.TabPage();
            this.tlpBoms = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBomsControl = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRefreshBoms = new System.Windows.Forms.Button();
            this.dgvBoms = new System.Windows.Forms.DataGridView();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.pgPlaces = new System.Windows.Forms.TabPage();
            this.dgvPlaces = new JDE_Scanner_Desktop.CustomControls.DBDataGridView();
            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.pgGeneral.SuspendLayout();
            this.tplTextboxes.SuspendLayout();
            this.tlpSupplier.SuspendLayout();
            this.tlpProducer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQrCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.pgBoms.SuspendLayout();
            this.tlpBoms.SuspendLayout();
            this.tlpBomsControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoms)).BeginInit();
            this.pgPlaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaces)).BeginInit();
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
            this.tlpMain.Size = new System.Drawing.Size(597, 500);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpButtons
            // 
            this.tlpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpButtons.ColumnCount = 5;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpButtons.Controls.Add(this.btnSave, 0, 0);
            this.tlpButtons.Controls.Add(this.btnPrint, 1, 0);
            this.tlpButtons.Controls.Add(this.btnAttach, 2, 0);
            this.tlpButtons.Controls.Add(this.cboxArchived, 4, 0);
            this.tlpButtons.Location = new System.Drawing.Point(3, 3);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
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
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::JDE_Scanner_Desktop.Properties.Resources.print_24;
            this.btnPrint.Location = new System.Drawing.Point(43, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(34, 28);
            this.btnPrint.TabIndex = 1;
            this.tooltip.SetToolTip(this.btnPrint, "Drukuj QR..");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttach.Image = global::JDE_Scanner_Desktop.Properties.Resources.Attach_24;
            this.btnAttach.Location = new System.Drawing.Point(83, 3);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(34, 28);
            this.btnAttach.TabIndex = 2;
            this.tooltip.SetToolTip(this.btnAttach, "Powiązane pliki..");
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // cboxArchived
            // 
            this.cboxArchived.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cboxArchived.AutoSize = true;
            this.cboxArchived.Location = new System.Drawing.Point(511, 8);
            this.cboxArchived.Name = "cboxArchived";
            this.cboxArchived.Size = new System.Drawing.Size(77, 17);
            this.cboxArchived.TabIndex = 3;
            this.cboxArchived.Text = "Archiwalny";
            this.cboxArchived.ThreeState = true;
            this.cboxArchived.UseVisualStyleBackColor = true;
            // 
            // lblCreated
            // 
            this.lblCreated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreated.AutoSize = true;
            this.lblCreated.Location = new System.Drawing.Point(3, 478);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(591, 13);
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
            this.tabControl.Controls.Add(this.pgBoms);
            this.tabControl.Controls.Add(this.pgPlaces);
            this.tabControl.Location = new System.Drawing.Point(3, 43);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(591, 424);
            this.tabControl.TabIndex = 3;
            // 
            // pgGeneral
            // 
            this.pgGeneral.Controls.Add(this.tplTextboxes);
            this.pgGeneral.Location = new System.Drawing.Point(4, 22);
            this.pgGeneral.Name = "pgGeneral";
            this.pgGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.pgGeneral.Size = new System.Drawing.Size(583, 398);
            this.pgGeneral.TabIndex = 0;
            this.pgGeneral.Text = "Ogólne";
            this.pgGeneral.UseVisualStyleBackColor = true;
            // 
            // tplTextboxes
            // 
            this.tplTextboxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplTextboxes.ColumnCount = 2;
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplTextboxes.Controls.Add(this.txtEAN, 1, 2);
            this.tplTextboxes.Controls.Add(this.txtDescription, 1, 1);
            this.tplTextboxes.Controls.Add(this.label2, 0, 0);
            this.tplTextboxes.Controls.Add(this.lblUlica, 0, 1);
            this.tplTextboxes.Controls.Add(this.label4, 0, 2);
            this.tplTextboxes.Controls.Add(this.label5, 0, 3);
            this.tplTextboxes.Controls.Add(this.txtName, 1, 0);
            this.tplTextboxes.Controls.Add(this.txtProducersCode, 1, 3);
            this.tplTextboxes.Controls.Add(this.label1, 0, 4);
            this.tplTextboxes.Controls.Add(this.label6, 0, 5);
            this.tplTextboxes.Controls.Add(this.label7, 0, 6);
            this.tplTextboxes.Controls.Add(this.txtSymbol, 1, 4);
            this.tplTextboxes.Controls.Add(this.label3, 0, 7);
            this.tplTextboxes.Controls.Add(this.tlpSupplier, 1, 6);
            this.tplTextboxes.Controls.Add(this.tlpProducer, 1, 5);
            this.tplTextboxes.Controls.Add(this.label8, 0, 8);
            this.tplTextboxes.Controls.Add(this.label9, 0, 9);
            this.tplTextboxes.Controls.Add(this.txtDestination, 1, 7);
            this.tplTextboxes.Controls.Add(this.txtAppliance, 1, 8);
            this.tplTextboxes.Controls.Add(this.txtUsedOn, 1, 9);
            this.tplTextboxes.Controls.Add(this.tableLayoutPanel1, 1, 10);
            this.tplTextboxes.Location = new System.Drawing.Point(-4, 0);
            this.tplTextboxes.Name = "tplTextboxes";
            this.tplTextboxes.RowCount = 11;
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.Size = new System.Drawing.Size(591, 411);
            this.tplTextboxes.TabIndex = 2;
            // 
            // txtEAN
            // 
            this.txtEAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEAN.Location = new System.Drawing.Point(123, 65);
            this.txtEAN.Name = "txtEAN";
            this.txtEAN.Size = new System.Drawing.Size(465, 20);
            this.txtEAN.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(123, 35);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(465, 20);
            this.txtDescription.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nazwa";
            // 
            // lblUlica
            // 
            this.lblUlica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUlica.AutoSize = true;
            this.lblUlica.Location = new System.Drawing.Point(3, 38);
            this.lblUlica.Name = "lblUlica";
            this.lblUlica.Size = new System.Drawing.Size(114, 13);
            this.lblUlica.TabIndex = 1;
            this.lblUlica.Text = "Opis";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Kod EAN";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Kod producenta";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(123, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(465, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtProducersCode
            // 
            this.txtProducersCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProducersCode.Location = new System.Drawing.Point(123, 95);
            this.txtProducersCode.Name = "txtProducersCode";
            this.txtProducersCode.Size = new System.Drawing.Size(465, 20);
            this.txtProducersCode.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Symbol";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Producent";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Dostawca";
            // 
            // txtSymbol
            // 
            this.txtSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSymbol.Location = new System.Drawing.Point(123, 125);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(465, 20);
            this.txtSymbol.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Przeznaczenie";
            // 
            // tlpSupplier
            // 
            this.tlpSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSupplier.ColumnCount = 3;
            this.tlpSupplier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSupplier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSupplier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSupplier.Controls.Add(this.cmbSupplier, 0, 0);
            this.tlpSupplier.Controls.Add(this.btnAddSupplier, 1, 0);
            this.tlpSupplier.Controls.Add(this.btnEditSupplier, 2, 0);
            this.tlpSupplier.Location = new System.Drawing.Point(123, 188);
            this.tlpSupplier.Name = "tlpSupplier";
            this.tlpSupplier.RowCount = 1;
            this.tlpSupplier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSupplier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpSupplier.Size = new System.Drawing.Size(465, 29);
            this.tlpSupplier.TabIndex = 19;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(3, 4);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(399, 21);
            this.cmbSupplier.TabIndex = 0;
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSupplier.Image = global::JDE_Scanner_Desktop.Properties.Resources.Add_16;
            this.btnAddSupplier.Location = new System.Drawing.Point(408, 3);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(24, 23);
            this.btnAddSupplier.TabIndex = 1;
            this.tooltip.SetToolTip(this.btnAddSupplier, "Dodaj nowego..");
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Click += new System.EventHandler(this.AddCompany);
            // 
            // btnEditSupplier
            // 
            this.btnEditSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnEditSupplier.Image")));
            this.btnEditSupplier.Location = new System.Drawing.Point(438, 3);
            this.btnEditSupplier.Name = "btnEditSupplier";
            this.btnEditSupplier.Size = new System.Drawing.Size(24, 23);
            this.btnEditSupplier.TabIndex = 2;
            this.btnEditSupplier.UseVisualStyleBackColor = true;
            this.btnEditSupplier.Click += new System.EventHandler(this.EditSupplier);
            // 
            // tlpProducer
            // 
            this.tlpProducer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpProducer.ColumnCount = 3;
            this.tlpProducer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProducer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpProducer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpProducer.Controls.Add(this.cmbProducer, 0, 0);
            this.tlpProducer.Controls.Add(this.btnAddProducer, 1, 0);
            this.tlpProducer.Controls.Add(this.btnEditProducer, 2, 0);
            this.tlpProducer.Location = new System.Drawing.Point(123, 153);
            this.tlpProducer.Name = "tlpProducer";
            this.tlpProducer.RowCount = 1;
            this.tlpProducer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProducer.Size = new System.Drawing.Size(465, 29);
            this.tlpProducer.TabIndex = 18;
            // 
            // cmbProducer
            // 
            this.cmbProducer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProducer.FormattingEnabled = true;
            this.cmbProducer.Location = new System.Drawing.Point(3, 4);
            this.cmbProducer.Name = "cmbProducer";
            this.cmbProducer.Size = new System.Drawing.Size(399, 21);
            this.cmbProducer.TabIndex = 0;
            // 
            // btnAddProducer
            // 
            this.btnAddProducer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProducer.Image = global::JDE_Scanner_Desktop.Properties.Resources.Add_16;
            this.btnAddProducer.Location = new System.Drawing.Point(408, 3);
            this.btnAddProducer.Name = "btnAddProducer";
            this.btnAddProducer.Size = new System.Drawing.Size(24, 23);
            this.btnAddProducer.TabIndex = 1;
            this.tooltip.SetToolTip(this.btnAddProducer, "Dodaj nowego..");
            this.btnAddProducer.UseVisualStyleBackColor = true;
            this.btnAddProducer.Click += new System.EventHandler(this.AddCompany);
            // 
            // btnEditProducer
            // 
            this.btnEditProducer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditProducer.Image = ((System.Drawing.Image)(resources.GetObject("btnEditProducer.Image")));
            this.btnEditProducer.Location = new System.Drawing.Point(438, 3);
            this.btnEditProducer.Name = "btnEditProducer";
            this.btnEditProducer.Size = new System.Drawing.Size(24, 23);
            this.btnEditProducer.TabIndex = 2;
            this.btnEditProducer.UseVisualStyleBackColor = true;
            this.btnEditProducer.Click += new System.EventHandler(this.EditProducer);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Zastosowanie";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Używany do";
            // 
            // txtDestination
            // 
            this.txtDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestination.Location = new System.Drawing.Point(123, 225);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(465, 20);
            this.txtDestination.TabIndex = 22;
            // 
            // txtAppliance
            // 
            this.txtAppliance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppliance.Location = new System.Drawing.Point(123, 255);
            this.txtAppliance.Name = "txtAppliance";
            this.txtAppliance.Size = new System.Drawing.Size(465, 20);
            this.txtAppliance.TabIndex = 23;
            // 
            // txtUsedOn
            // 
            this.txtUsedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsedOn.Location = new System.Drawing.Point(123, 285);
            this.txtUsedOn.Name = "txtUsedOn";
            this.txtUsedOn.Size = new System.Drawing.Size(465, 20);
            this.txtUsedOn.TabIndex = 24;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pbQrCode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbImage, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(123, 313);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 82);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // pbQrCode
            // 
            this.pbQrCode.Location = new System.Drawing.Point(235, 3);
            this.pbQrCode.Name = "pbQrCode";
            this.pbQrCode.Size = new System.Drawing.Size(100, 76);
            this.pbQrCode.TabIndex = 28;
            this.pbQrCode.TabStop = false;
            // 
            // pbImage
            // 
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbImage.Image = global::JDE_Scanner_Desktop.Properties.Resources.Image_icon_64;
            this.pbImage.InitialImage = global::JDE_Scanner_Desktop.Properties.Resources.Image_icon_64;
            this.pbImage.Location = new System.Drawing.Point(3, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(105, 76);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbImage.TabIndex = 29;
            this.pbImage.TabStop = false;
            this.tooltip.SetToolTip(this.pbImage, "Wybierz zdjęcie..");
            this.pbImage.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // pgBoms
            // 
            this.pgBoms.Controls.Add(this.tlpBoms);
            this.pgBoms.Location = new System.Drawing.Point(4, 22);
            this.pgBoms.Name = "pgBoms";
            this.pgBoms.Padding = new System.Windows.Forms.Padding(3);
            this.pgBoms.Size = new System.Drawing.Size(583, 398);
            this.pgBoms.TabIndex = 1;
            this.pgBoms.Text = "W BOMach";
            this.pgBoms.UseVisualStyleBackColor = true;
            // 
            // tlpBoms
            // 
            this.tlpBoms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpBoms.ColumnCount = 1;
            this.tlpBoms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBoms.Controls.Add(this.tlpBomsControl, 0, 0);
            this.tlpBoms.Controls.Add(this.dgvBoms, 0, 1);
            this.tlpBoms.Location = new System.Drawing.Point(6, 6);
            this.tlpBoms.Name = "tlpBoms";
            this.tlpBoms.RowCount = 2;
            this.tlpBoms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpBoms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBoms.Size = new System.Drawing.Size(571, 386);
            this.tlpBoms.TabIndex = 0;
            // 
            // tlpBomsControl
            // 
            this.tlpBomsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpBomsControl.ColumnCount = 4;
            this.tlpBomsControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpBomsControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpBomsControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBomsControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBomsControl.Controls.Add(this.btnAdd, 0, 0);
            this.tlpBomsControl.Controls.Add(this.btnRemove, 1, 0);
            this.tlpBomsControl.Controls.Add(this.btnRefreshBoms, 2, 0);
            this.tlpBomsControl.Location = new System.Drawing.Point(3, 3);
            this.tlpBomsControl.Name = "tlpBomsControl";
            this.tlpBomsControl.RowCount = 1;
            this.tlpBomsControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBomsControl.Size = new System.Drawing.Size(565, 29);
            this.tlpBomsControl.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(144, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Dodaj przypisanie";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(153, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(144, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Usuń przypisanie";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRefreshBoms
            // 
            this.btnRefreshBoms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshBoms.Image = global::JDE_Scanner_Desktop.Properties.Resources.Cloud_30;
            this.btnRefreshBoms.Location = new System.Drawing.Point(303, 3);
            this.btnRefreshBoms.Name = "btnRefreshBoms";
            this.btnRefreshBoms.Size = new System.Drawing.Size(24, 23);
            this.btnRefreshBoms.TabIndex = 2;
            this.tooltip.SetToolTip(this.btnRefreshBoms, "Odśwież..");
            this.btnRefreshBoms.UseVisualStyleBackColor = true;
            this.btnRefreshBoms.Click += new System.EventHandler(this.btnRefreshBoms_Click);
            // 
            // dgvBoms
            // 
            this.dgvBoms.AllowUserToAddRows = false;
            this.dgvBoms.AllowUserToDeleteRows = false;
            this.dgvBoms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoms.Location = new System.Drawing.Point(3, 38);
            this.dgvBoms.Name = "dgvBoms";
            this.dgvBoms.ReadOnly = true;
            this.dgvBoms.Size = new System.Drawing.Size(565, 345);
            this.dgvBoms.TabIndex = 1;
            this.dgvBoms.DoubleClick += new System.EventHandler(this.dgvBoms_DoubleClick);
            // 
            // pgPlaces
            // 
            this.pgPlaces.Controls.Add(this.dgvPlaces);
            this.pgPlaces.Location = new System.Drawing.Point(4, 22);
            this.pgPlaces.Name = "pgPlaces";
            this.pgPlaces.Padding = new System.Windows.Forms.Padding(3);
            this.pgPlaces.Size = new System.Drawing.Size(583, 398);
            this.pgPlaces.TabIndex = 2;
            this.pgPlaces.Text = "W zasobach";
            this.pgPlaces.UseVisualStyleBackColor = true;
            // 
            // dgvPlaces
            // 
            this.dgvPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlaces.DoubleBuffered = true;
            this.dgvPlaces.Location = new System.Drawing.Point(3, 3);
            this.dgvPlaces.Name = "dgvPlaces";
            this.dgvPlaces.Size = new System.Drawing.Size(577, 392);
            this.dgvPlaces.TabIndex = 0;
            // 
            // frmPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 524);
            this.Controls.Add(this.tlpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Szczegóły części";
            this.Load += new System.EventHandler(this.FormLoaded);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.tlpButtons.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.pgGeneral.ResumeLayout(false);
            this.tplTextboxes.ResumeLayout(false);
            this.tplTextboxes.PerformLayout();
            this.tlpSupplier.ResumeLayout(false);
            this.tlpProducer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbQrCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.pgBoms.ResumeLayout(false);
            this.tlpBoms.ResumeLayout(false);
            this.tlpBomsControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoms)).EndInit();
            this.pgPlaces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaces)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pgGeneral;
        private System.Windows.Forms.TableLayoutPanel tplTextboxes;
        private System.Windows.Forms.TextBox txtEAN;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUlica;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtProducersCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tlpSupplier;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Button btnEditSupplier;
        private System.Windows.Forms.TableLayoutPanel tlpProducer;
        private System.Windows.Forms.ComboBox cmbProducer;
        private System.Windows.Forms.Button btnAddProducer;
        private System.Windows.Forms.Button btnEditProducer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtAppliance;
        private System.Windows.Forms.TextBox txtUsedOn;
        private System.Windows.Forms.TabPage pgBoms;
        private System.Windows.Forms.TableLayoutPanel tlpBoms;
        private System.Windows.Forms.TableLayoutPanel tlpBomsControl;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvBoms;
        private System.Windows.Forms.Button btnRefreshBoms;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbQrCode;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.CheckBox cboxArchived;
        private System.Windows.Forms.TabPage pgPlaces;
        private CustomControls.DBDataGridView dgvPlaces;
    }
}
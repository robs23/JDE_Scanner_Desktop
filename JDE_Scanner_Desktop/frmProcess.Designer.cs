namespace JDE_Scanner_Desktop
{
    partial class frmProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcess));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCreated = new System.Windows.Forms.Label();
            this.tplTextboxes = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFinishedBy = new System.Windows.Forms.ComboBox();
            this.cmbActionType = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbStartedBy = new System.Windows.Forms.ComboBox();
            this.cmbPlace = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tlpStartedOn = new System.Windows.Forms.TableLayoutPanel();
            this.txtStartedOn = new System.Windows.Forms.DateTimePicker();
            this.btnStartedOnClear = new System.Windows.Forms.Button();
            this.tlpFinishedOn = new System.Windows.Forms.TableLayoutPanel();
            this.txtFinishedOn = new System.Windows.Forms.DateTimePicker();
            this.btnFinishedOnClear = new System.Windows.Forms.Button();
            this.lblInitialDiagnosis = new System.Windows.Forms.Label();
            this.lblRepairActions = new System.Windows.Forms.Label();
            this.txtInitialDiagnosis = new System.Windows.Forms.TextBox();
            this.txtRepairActions = new System.Windows.Forms.TextBox();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.lblMesId = new System.Windows.Forms.Label();
            this.txtMesId = new System.Windows.Forms.TextBox();
            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tplTextboxes.SuspendLayout();
            this.tlpStartedOn.SuspendLayout();
            this.tlpFinishedOn.SuspendLayout();
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
            this.tlpMain.Controls.Add(this.tplTextboxes, 0, 1);
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(602, 519);
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
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 526F));
            this.tlpButtons.Controls.Add(this.btnSave, 0, 0);
            this.tlpButtons.Location = new System.Drawing.Point(3, 3);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpButtons.Size = new System.Drawing.Size(596, 34);
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
            // lblCreated
            // 
            this.lblCreated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreated.AutoSize = true;
            this.lblCreated.Location = new System.Drawing.Point(3, 497);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(596, 13);
            this.lblCreated.TabIndex = 2;
            this.lblCreated.Text = "lblCreated";
            this.lblCreated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tplTextboxes
            // 
            this.tplTextboxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplTextboxes.ColumnCount = 2;
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplTextboxes.Controls.Add(this.lblDescription, 0, 1);
            this.tplTextboxes.Controls.Add(this.label3, 0, 2);
            this.tplTextboxes.Controls.Add(this.label4, 0, 3);
            this.tplTextboxes.Controls.Add(this.label5, 0, 4);
            this.tplTextboxes.Controls.Add(this.label1, 0, 5);
            this.tplTextboxes.Controls.Add(this.label6, 0, 6);
            this.tplTextboxes.Controls.Add(this.label7, 0, 7);
            this.tplTextboxes.Controls.Add(this.cmbFinishedBy, 1, 5);
            this.tplTextboxes.Controls.Add(this.cmbActionType, 1, 6);
            this.tplTextboxes.Controls.Add(this.txtDescription, 1, 1);
            this.tplTextboxes.Controls.Add(this.cmbStartedBy, 1, 3);
            this.tplTextboxes.Controls.Add(this.cmbPlace, 1, 7);
            this.tplTextboxes.Controls.Add(this.label8, 0, 8);
            this.tplTextboxes.Controls.Add(this.cmbStatus, 1, 8);
            this.tplTextboxes.Controls.Add(this.txtOutput, 1, 9);
            this.tplTextboxes.Controls.Add(this.label9, 0, 9);
            this.tplTextboxes.Controls.Add(this.tlpStartedOn, 1, 2);
            this.tplTextboxes.Controls.Add(this.tlpFinishedOn, 1, 4);
            this.tplTextboxes.Controls.Add(this.lblInitialDiagnosis, 0, 10);
            this.tplTextboxes.Controls.Add(this.lblRepairActions, 0, 11);
            this.tplTextboxes.Controls.Add(this.txtInitialDiagnosis, 1, 10);
            this.tplTextboxes.Controls.Add(this.txtRepairActions, 1, 11);
            this.tplTextboxes.Controls.Add(this.lblMesId, 0, 0);
            this.tplTextboxes.Controls.Add(this.txtMesId, 1, 0);
            this.tplTextboxes.Location = new System.Drawing.Point(3, 43);
            this.tplTextboxes.Name = "tplTextboxes";
            this.tplTextboxes.RowCount = 13;
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplTextboxes.Size = new System.Drawing.Size(596, 443);
            this.tplTextboxes.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 38);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(144, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Opis";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Data rozpoczęcia";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Rozpoczęty przez";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Data zakończenia";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Zakończony przez";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Typ zlecenia";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Zasób";
            // 
            // cmbFinishedBy
            // 
            this.cmbFinishedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFinishedBy.FormattingEnabled = true;
            this.cmbFinishedBy.Location = new System.Drawing.Point(153, 154);
            this.cmbFinishedBy.Name = "cmbFinishedBy";
            this.cmbFinishedBy.Size = new System.Drawing.Size(440, 21);
            this.cmbFinishedBy.TabIndex = 12;
            // 
            // cmbActionType
            // 
            this.cmbActionType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbActionType.FormattingEnabled = true;
            this.cmbActionType.Location = new System.Drawing.Point(153, 184);
            this.cmbActionType.Name = "cmbActionType";
            this.cmbActionType.Size = new System.Drawing.Size(440, 21);
            this.cmbActionType.TabIndex = 13;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(153, 35);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(440, 20);
            this.txtDescription.TabIndex = 7;
            // 
            // cmbStartedBy
            // 
            this.cmbStartedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStartedBy.FormattingEnabled = true;
            this.cmbStartedBy.Location = new System.Drawing.Point(153, 94);
            this.cmbStartedBy.Name = "cmbStartedBy";
            this.cmbStartedBy.Size = new System.Drawing.Size(440, 21);
            this.cmbStartedBy.TabIndex = 16;
            // 
            // cmbPlace
            // 
            this.cmbPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPlace.FormattingEnabled = true;
            this.cmbPlace.Location = new System.Drawing.Point(153, 214);
            this.cmbPlace.Name = "cmbPlace";
            this.cmbPlace.Size = new System.Drawing.Size(440, 21);
            this.cmbPlace.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Nierozpoczęty",
            "Rozpoczęty",
            "Wstrzymany",
            "Zakończony",
            "Zrealizowany"});
            this.cmbStatus.Location = new System.Drawing.Point(153, 244);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(440, 21);
            this.cmbStatus.TabIndex = 20;
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(153, 273);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(440, 44);
            this.txtOutput.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 50);
            this.label9.TabIndex = 22;
            this.label9.Text = "Rezultat";
            // 
            // tlpStartedOn
            // 
            this.tlpStartedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpStartedOn.ColumnCount = 2;
            this.tlpStartedOn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStartedOn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpStartedOn.Controls.Add(this.txtStartedOn, 0, 0);
            this.tlpStartedOn.Controls.Add(this.btnStartedOnClear, 1, 0);
            this.tlpStartedOn.Location = new System.Drawing.Point(153, 63);
            this.tlpStartedOn.Name = "tlpStartedOn";
            this.tlpStartedOn.RowCount = 1;
            this.tlpStartedOn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStartedOn.Size = new System.Drawing.Size(440, 24);
            this.tlpStartedOn.TabIndex = 23;
            // 
            // txtStartedOn
            // 
            this.txtStartedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartedOn.Location = new System.Drawing.Point(3, 3);
            this.txtStartedOn.Name = "txtStartedOn";
            this.txtStartedOn.Size = new System.Drawing.Size(404, 20);
            this.txtStartedOn.TabIndex = 15;
            this.txtStartedOn.ValueChanged += new System.EventHandler(this.txtStartedOn_ValueChanged);
            // 
            // btnStartedOnClear
            // 
            this.btnStartedOnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartedOnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnStartedOnClear.Image")));
            this.btnStartedOnClear.Location = new System.Drawing.Point(413, 3);
            this.btnStartedOnClear.Name = "btnStartedOnClear";
            this.btnStartedOnClear.Size = new System.Drawing.Size(24, 18);
            this.btnStartedOnClear.TabIndex = 16;
            this.tooltip.SetToolTip(this.btnStartedOnClear, "Wyczyść datę..");
            this.btnStartedOnClear.UseVisualStyleBackColor = true;
            this.btnStartedOnClear.Click += new System.EventHandler(this.btnStartedOnClear_Click);
            // 
            // tlpFinishedOn
            // 
            this.tlpFinishedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFinishedOn.ColumnCount = 2;
            this.tlpFinishedOn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFinishedOn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpFinishedOn.Controls.Add(this.txtFinishedOn, 0, 0);
            this.tlpFinishedOn.Controls.Add(this.btnFinishedOnClear, 1, 0);
            this.tlpFinishedOn.Location = new System.Drawing.Point(153, 123);
            this.tlpFinishedOn.Name = "tlpFinishedOn";
            this.tlpFinishedOn.RowCount = 1;
            this.tlpFinishedOn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFinishedOn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpFinishedOn.Size = new System.Drawing.Size(440, 24);
            this.tlpFinishedOn.TabIndex = 24;
            // 
            // txtFinishedOn
            // 
            this.txtFinishedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinishedOn.Location = new System.Drawing.Point(3, 3);
            this.txtFinishedOn.Name = "txtFinishedOn";
            this.txtFinishedOn.Size = new System.Drawing.Size(404, 20);
            this.txtFinishedOn.TabIndex = 17;
            this.txtFinishedOn.ValueChanged += new System.EventHandler(this.txtFinishedOn_ValueChanged);
            // 
            // btnFinishedOnClear
            // 
            this.btnFinishedOnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinishedOnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnFinishedOnClear.Image")));
            this.btnFinishedOnClear.Location = new System.Drawing.Point(413, 3);
            this.btnFinishedOnClear.Name = "btnFinishedOnClear";
            this.btnFinishedOnClear.Size = new System.Drawing.Size(24, 18);
            this.btnFinishedOnClear.TabIndex = 18;
            this.tooltip.SetToolTip(this.btnFinishedOnClear, "Wyczyść datę..");
            this.btnFinishedOnClear.UseVisualStyleBackColor = true;
            this.btnFinishedOnClear.Click += new System.EventHandler(this.btnFinishedOnClear_Click);
            // 
            // lblInitialDiagnosis
            // 
            this.lblInitialDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInitialDiagnosis.AutoSize = true;
            this.lblInitialDiagnosis.Location = new System.Drawing.Point(3, 338);
            this.lblInitialDiagnosis.Name = "lblInitialDiagnosis";
            this.lblInitialDiagnosis.Size = new System.Drawing.Size(144, 13);
            this.lblInitialDiagnosis.TabIndex = 25;
            this.lblInitialDiagnosis.Text = "Wstępne rozpoznanie";
            // 
            // lblRepairActions
            // 
            this.lblRepairActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRepairActions.AutoSize = true;
            this.lblRepairActions.Location = new System.Drawing.Point(3, 388);
            this.lblRepairActions.Name = "lblRepairActions";
            this.lblRepairActions.Size = new System.Drawing.Size(144, 13);
            this.lblRepairActions.TabIndex = 26;
            this.lblRepairActions.Text = "Czynności naprawcze";
            // 
            // txtInitialDiagnosis
            // 
            this.txtInitialDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInitialDiagnosis.Location = new System.Drawing.Point(153, 323);
            this.txtInitialDiagnosis.Multiline = true;
            this.txtInitialDiagnosis.Name = "txtInitialDiagnosis";
            this.txtInitialDiagnosis.Size = new System.Drawing.Size(440, 44);
            this.txtInitialDiagnosis.TabIndex = 27;
            // 
            // txtRepairActions
            // 
            this.txtRepairActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRepairActions.Location = new System.Drawing.Point(153, 373);
            this.txtRepairActions.Multiline = true;
            this.txtRepairActions.Name = "txtRepairActions";
            this.txtRepairActions.Size = new System.Drawing.Size(440, 44);
            this.txtRepairActions.TabIndex = 28;
            // 
            // lblMesId
            // 
            this.lblMesId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMesId.AutoSize = true;
            this.lblMesId.Location = new System.Drawing.Point(3, 8);
            this.lblMesId.Name = "lblMesId";
            this.lblMesId.Size = new System.Drawing.Size(144, 13);
            this.lblMesId.TabIndex = 29;
            this.lblMesId.Text = "MES Id";
            // 
            // txtMesId
            // 
            this.txtMesId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMesId.Location = new System.Drawing.Point(153, 5);
            this.txtMesId.Name = "txtMesId";
            this.txtMesId.Size = new System.Drawing.Size(440, 20);
            this.txtMesId.TabIndex = 30;
            // 
            // frmProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 543);
            this.Controls.Add(this.tlpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Szczegóły zgłoszenia";
            this.Load += new System.EventHandler(this.FormLoaded);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.tplTextboxes.ResumeLayout(false);
            this.tplTextboxes.PerformLayout();
            this.tlpStartedOn.ResumeLayout(false);
            this.tlpFinishedOn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.TableLayoutPanel tplTextboxes;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFinishedBy;
        private System.Windows.Forms.ComboBox cmbActionType;
        private System.Windows.Forms.DateTimePicker txtStartedOn;
        private System.Windows.Forms.ComboBox cmbStartedBy;
        private System.Windows.Forms.DateTimePicker txtFinishedOn;
        private System.Windows.Forms.ComboBox cmbPlace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tlpStartedOn;
        private System.Windows.Forms.TableLayoutPanel tlpFinishedOn;
        private System.Windows.Forms.Button btnStartedOnClear;
        private System.Windows.Forms.Button btnFinishedOnClear;
        private System.Windows.Forms.Label lblInitialDiagnosis;
        private System.Windows.Forms.Label lblRepairActions;
        private System.Windows.Forms.TextBox txtInitialDiagnosis;
        private System.Windows.Forms.TextBox txtRepairActions;
        private System.Windows.Forms.Label lblMesId;
        private System.Windows.Forms.TextBox txtMesId;
    }
}
namespace JDE_Scanner_Desktop
{
    partial class frmActionType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActionType));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.tplTextboxes = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMesSync = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbShowInPlanning = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRequireInitialDiagnosis = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbAllowDuplicates = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbQrToStart = new System.Windows.Forms.ComboBox();
            this.cmbQrToFinish = new System.Windows.Forms.ComboBox();
            this.cmbClosePrevious = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbPartsApplicable = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbActionsApplicable = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbRequireUserAssignment = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbShowOnDashboard = new System.Windows.Forms.ComboBox();
            this.lblCreated = new System.Windows.Forms.Label();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.cmbLeaveable = new System.Windows.Forms.ComboBox();
            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tplTextboxes.SuspendLayout();
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
            this.tlpMain.Controls.Add(this.lblCreated, 0, 2);
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(597, 538);
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
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplTextboxes.Controls.Add(this.label2, 0, 0);
            this.tplTextboxes.Controls.Add(this.txtName, 1, 0);
            this.tplTextboxes.Controls.Add(this.label3, 0, 1);
            this.tplTextboxes.Controls.Add(this.txtDescription, 1, 1);
            this.tplTextboxes.Controls.Add(this.label4, 0, 4);
            this.tplTextboxes.Controls.Add(this.cmbMesSync, 1, 4);
            this.tplTextboxes.Controls.Add(this.label1, 0, 3);
            this.tplTextboxes.Controls.Add(this.cmbShowInPlanning, 1, 3);
            this.tplTextboxes.Controls.Add(this.label5, 0, 2);
            this.tplTextboxes.Controls.Add(this.cmbRequireInitialDiagnosis, 1, 2);
            this.tplTextboxes.Controls.Add(this.label6, 0, 5);
            this.tplTextboxes.Controls.Add(this.cmbAllowDuplicates, 1, 5);
            this.tplTextboxes.Controls.Add(this.label7, 0, 6);
            this.tplTextboxes.Controls.Add(this.label8, 0, 7);
            this.tplTextboxes.Controls.Add(this.label9, 0, 8);
            this.tplTextboxes.Controls.Add(this.cmbQrToStart, 1, 6);
            this.tplTextboxes.Controls.Add(this.cmbQrToFinish, 1, 7);
            this.tplTextboxes.Controls.Add(this.cmbClosePrevious, 1, 8);
            this.tplTextboxes.Controls.Add(this.label10, 0, 9);
            this.tplTextboxes.Controls.Add(this.cmbPartsApplicable, 1, 9);
            this.tplTextboxes.Controls.Add(this.label11, 0, 10);
            this.tplTextboxes.Controls.Add(this.cmbActionsApplicable, 1, 10);
            this.tplTextboxes.Controls.Add(this.label12, 0, 11);
            this.tplTextboxes.Controls.Add(this.cmbRequireUserAssignment, 1, 11);
            this.tplTextboxes.Controls.Add(this.label13, 0, 12);
            this.tplTextboxes.Controls.Add(this.cmbShowOnDashboard, 1, 12);
            this.tplTextboxes.Controls.Add(this.label14, 0, 13);
            this.tplTextboxes.Controls.Add(this.cmbLeaveable, 1, 13);
            this.tplTextboxes.Location = new System.Drawing.Point(3, 43);
            this.tplTextboxes.Name = "tplTextboxes";
            this.tplTextboxes.RowCount = 15;
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTextboxes.Size = new System.Drawing.Size(591, 462);
            this.tplTextboxes.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nazwa";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(153, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(435, 20);
            this.txtName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Opis";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(153, 35);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(435, 20);
            this.txtDescription.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Synchronizacja z MES";
            // 
            // cmbMesSync
            // 
            this.cmbMesSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMesSync.FormattingEnabled = true;
            this.cmbMesSync.Location = new System.Drawing.Point(153, 124);
            this.cmbMesSync.Name = "cmbMesSync";
            this.cmbMesSync.Size = new System.Drawing.Size(435, 21);
            this.cmbMesSync.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pokaż w planowaniu";
            this.tooltip.SetToolTip(this.label1, "Czy dany typ operacji można planować? Jeśli tak, będzie można utworzyć planowane " +
        "zgłoszenie tego typu z przyszłą datą realizacji.");
            // 
            // cmbShowInPlanning
            // 
            this.cmbShowInPlanning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbShowInPlanning.FormattingEnabled = true;
            this.cmbShowInPlanning.Location = new System.Drawing.Point(153, 94);
            this.cmbShowInPlanning.Name = "cmbShowInPlanning";
            this.cmbShowInPlanning.Size = new System.Drawing.Size(435, 21);
            this.cmbShowInPlanning.TabIndex = 7;
            this.tooltip.SetToolTip(this.cmbShowInPlanning, "Czy dany typ operacji można planować? Jeśli tak, będzie można utworzyć planowane " +
        "zgłoszenie tego typu z przyszłą datą realizacji");
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Wymaga wstępnej diagnozy";
            this.tooltip.SetToolTip(this.label5, "Czy wymagana jest wstępna diagnoza? Jeśli tak, pole rezultat jest zastępywane pol" +
        "ami wstępna diagnoza i czynności naprawcze.");
            // 
            // cmbRequireInitialDiagnosis
            // 
            this.cmbRequireInitialDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRequireInitialDiagnosis.FormattingEnabled = true;
            this.cmbRequireInitialDiagnosis.Location = new System.Drawing.Point(153, 64);
            this.cmbRequireInitialDiagnosis.Name = "cmbRequireInitialDiagnosis";
            this.cmbRequireInitialDiagnosis.Size = new System.Drawing.Size(435, 21);
            this.cmbRequireInitialDiagnosis.TabIndex = 11;
            this.tooltip.SetToolTip(this.cmbRequireInitialDiagnosis, "Czy wymagana jest wstępna diagnoza? Jeśli tak, pole rezultat jest zastępywane pol" +
        "ami wstępna diagnoza i czynności naprawcze.");
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Zezwalaj na duplikaty";
            this.tooltip.SetToolTip(this.label6, "Czy mogą być otwarte 2 operacje tego samego typu (np. awaria) na tym samym zasobi" +
        "e w tym samym czasie?");
            // 
            // cmbAllowDuplicates
            // 
            this.cmbAllowDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAllowDuplicates.FormattingEnabled = true;
            this.cmbAllowDuplicates.Location = new System.Drawing.Point(153, 154);
            this.cmbAllowDuplicates.Name = "cmbAllowDuplicates";
            this.cmbAllowDuplicates.Size = new System.Drawing.Size(435, 21);
            this.cmbAllowDuplicates.TabIndex = 13;
            this.tooltip.SetToolTip(this.cmbAllowDuplicates, "Czy mogą być otwarte 2 operacje tego samego typu (np. awaria) na tym samym zasobi" +
        "e w tym samym czasie?");
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 26);
            this.label7.TabIndex = 14;
            this.label7.Text = "Wymagaj skanowania QR by rozpocząć";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 26);
            this.label8.TabIndex = 15;
            this.label8.Text = "Wymagaj skanowania QR by zakończyć";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 26);
            this.label9.TabIndex = 16;
            this.label9.Text = "Zamknij poprzednie zgłoszenia";
            // 
            // cmbQrToStart
            // 
            this.cmbQrToStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQrToStart.FormattingEnabled = true;
            this.cmbQrToStart.Location = new System.Drawing.Point(153, 184);
            this.cmbQrToStart.Name = "cmbQrToStart";
            this.cmbQrToStart.Size = new System.Drawing.Size(435, 21);
            this.cmbQrToStart.TabIndex = 17;
            // 
            // cmbQrToFinish
            // 
            this.cmbQrToFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQrToFinish.FormattingEnabled = true;
            this.cmbQrToFinish.Location = new System.Drawing.Point(153, 214);
            this.cmbQrToFinish.Name = "cmbQrToFinish";
            this.cmbQrToFinish.Size = new System.Drawing.Size(435, 21);
            this.cmbQrToFinish.TabIndex = 18;
            // 
            // cmbClosePrevious
            // 
            this.cmbClosePrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbClosePrevious.FormattingEnabled = true;
            this.cmbClosePrevious.Location = new System.Drawing.Point(153, 244);
            this.cmbClosePrevious.Name = "cmbClosePrevious";
            this.cmbClosePrevious.Size = new System.Drawing.Size(435, 21);
            this.cmbClosePrevious.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 278);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Konsumpcja części";
            // 
            // cmbPartsApplicable
            // 
            this.cmbPartsApplicable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPartsApplicable.FormattingEnabled = true;
            this.cmbPartsApplicable.Location = new System.Drawing.Point(153, 274);
            this.cmbPartsApplicable.Name = "cmbPartsApplicable";
            this.cmbPartsApplicable.Size = new System.Drawing.Size(435, 21);
            this.cmbPartsApplicable.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 308);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Zawiera czynności";
            // 
            // cmbActionsApplicable
            // 
            this.cmbActionsApplicable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbActionsApplicable.FormattingEnabled = true;
            this.cmbActionsApplicable.Location = new System.Drawing.Point(153, 304);
            this.cmbActionsApplicable.Name = "cmbActionsApplicable";
            this.cmbActionsApplicable.Size = new System.Drawing.Size(435, 21);
            this.cmbActionsApplicable.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 332);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 26);
            this.label12.TabIndex = 24;
            this.label12.Text = "Wymaga przypisania użytkownika";
            // 
            // cmbRequireUserAssignment
            // 
            this.cmbRequireUserAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRequireUserAssignment.FormattingEnabled = true;
            this.cmbRequireUserAssignment.Location = new System.Drawing.Point(153, 334);
            this.cmbRequireUserAssignment.Name = "cmbRequireUserAssignment";
            this.cmbRequireUserAssignment.Size = new System.Drawing.Size(435, 21);
            this.cmbRequireUserAssignment.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 368);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Pokaż na pulpicie";
            // 
            // cmbShowOnDashboard
            // 
            this.cmbShowOnDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbShowOnDashboard.FormattingEnabled = true;
            this.cmbShowOnDashboard.Location = new System.Drawing.Point(153, 364);
            this.cmbShowOnDashboard.Name = "cmbShowOnDashboard";
            this.cmbShowOnDashboard.Size = new System.Drawing.Size(435, 21);
            this.cmbShowOnDashboard.TabIndex = 27;
            // 
            // lblCreated
            // 
            this.lblCreated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreated.AutoSize = true;
            this.lblCreated.Location = new System.Drawing.Point(3, 516);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(591, 13);
            this.lblCreated.TabIndex = 2;
            this.lblCreated.Text = "lblCreated";
            this.lblCreated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 392);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 26);
            this.label14.TabIndex = 28;
            this.label14.Text = "Proponuj pozostawienie otwartego zgłoszenia";
            // 
            // cmbLeaveable
            // 
            this.cmbLeaveable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLeaveable.FormattingEnabled = true;
            this.cmbLeaveable.Location = new System.Drawing.Point(153, 394);
            this.cmbLeaveable.Name = "cmbLeaveable";
            this.cmbLeaveable.Size = new System.Drawing.Size(435, 21);
            this.cmbLeaveable.TabIndex = 29;
            // 
            // frmActionType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 562);
            this.Controls.Add(this.tlpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmActionType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Szczegóły typu zgłoszenia";
            this.Load += new System.EventHandler(this.FormLoaded);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.tplTextboxes.ResumeLayout(false);
            this.tplTextboxes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.TableLayoutPanel tplTextboxes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMesSync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbShowInPlanning;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbRequireInitialDiagnosis;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAllowDuplicates;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbQrToStart;
        private System.Windows.Forms.ComboBox cmbQrToFinish;
        private System.Windows.Forms.ComboBox cmbClosePrevious;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbPartsApplicable;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbActionsApplicable;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbRequireUserAssignment;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbShowOnDashboard;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbLeaveable;
    }
}
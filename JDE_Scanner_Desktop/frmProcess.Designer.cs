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
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStartedOnClear = new System.Windows.Forms.Button();
            this.btnFinishedOnClear = new System.Windows.Forms.Button();
            this.btnEditAssignedList = new System.Windows.Forms.Button();
            this.btnAttachments = new System.Windows.Forms.Button();
            this.lblCreated = new System.Windows.Forms.Label();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.lblAssignedUsers = new System.Windows.Forms.Label();
            this.btnChangeState = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tab = new System.Windows.Forms.TabControl();
            this.pgProcess = new System.Windows.Forms.TabPage();
            this.tplTextboxes = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbActionType = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbPlace = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tlpStartedOn = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStartedOn = new System.Windows.Forms.DateTimePicker();
            this.cmbStartedBy = new System.Windows.Forms.ComboBox();
            this.lblInitialDiagnosis = new System.Windows.Forms.Label();
            this.lblRepairActions = new System.Windows.Forms.Label();
            this.txtInitialDiagnosis = new System.Windows.Forms.TextBox();
            this.txtRepairActions = new System.Windows.Forms.TextBox();
            this.lblMesId = new System.Windows.Forms.Label();
            this.txtMesId = new System.Windows.Forms.TextBox();
            this.tlpFinishedOn = new System.Windows.Forms.TableLayoutPanel();
            this.cmbFinishedBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFinishedOn = new System.Windows.Forms.DateTimePicker();
            this.txtPlannedStart = new System.Windows.Forms.DateTimePicker();
            this.txtPlannedFinish = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.pgHandling = new System.Windows.Forms.TabPage();
            this.lvHandlings = new System.Windows.Forms.ListView();
            this.pgHistory = new System.Windows.Forms.TabPage();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.pgActions = new System.Windows.Forms.TabPage();
            this.dgvActions = new System.Windows.Forms.DataGridView();
            this.pbParts = new System.Windows.Forms.TabPage();
            this.dgvUsedParts = new System.Windows.Forms.DataGridView();
            this.tlpButtons.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tab.SuspendLayout();
            this.pgProcess.SuspendLayout();
            this.tplTextboxes.SuspendLayout();
            this.tlpStartedOn.SuspendLayout();
            this.tlpFinishedOn.SuspendLayout();
            this.pgHandling.SuspendLayout();
            this.pgHistory.SuspendLayout();
            this.pgActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActions)).BeginInit();
            this.pbParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsedParts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(4, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(45, 33);
            this.btnSave.TabIndex = 0;
            this.tooltip.SetToolTip(this.btnSave, "Zapisz zmiany..");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Save);
            // 
            // btnStartedOnClear
            // 
            this.btnStartedOnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartedOnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnStartedOnClear.Image")));
            this.btnStartedOnClear.Location = new System.Drawing.Point(233, 4);
            this.btnStartedOnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartedOnClear.Name = "btnStartedOnClear";
            this.btnStartedOnClear.Size = new System.Drawing.Size(32, 21);
            this.btnStartedOnClear.TabIndex = 16;
            this.tooltip.SetToolTip(this.btnStartedOnClear, "Wyczyść datę..");
            this.btnStartedOnClear.UseVisualStyleBackColor = true;
            // 
            // btnFinishedOnClear
            // 
            this.btnFinishedOnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinishedOnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnFinishedOnClear.Image")));
            this.btnFinishedOnClear.Location = new System.Drawing.Point(233, 4);
            this.btnFinishedOnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinishedOnClear.Name = "btnFinishedOnClear";
            this.btnFinishedOnClear.Size = new System.Drawing.Size(32, 21);
            this.btnFinishedOnClear.TabIndex = 18;
            this.tooltip.SetToolTip(this.btnFinishedOnClear, "Wyczyść datę..");
            this.btnFinishedOnClear.UseVisualStyleBackColor = true;
            // 
            // btnEditAssignedList
            // 
            this.btnEditAssignedList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditAssignedList.Image = global::JDE_Scanner_Desktop.Properties.Resources.Edit_16;
            this.btnEditAssignedList.Location = new System.Drawing.Point(754, 4);
            this.btnEditAssignedList.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditAssignedList.Name = "btnEditAssignedList";
            this.btnEditAssignedList.Size = new System.Drawing.Size(33, 33);
            this.btnEditAssignedList.TabIndex = 5;
            this.tooltip.SetToolTip(this.btnEditAssignedList, "Edytuj przypisanych użytkowników..");
            this.btnEditAssignedList.UseVisualStyleBackColor = true;
            this.btnEditAssignedList.Visible = false;
            this.btnEditAssignedList.Click += new System.EventHandler(this.btnEditAssignedList_Click);
            // 
            // btnAttachments
            // 
            this.btnAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttachments.Image = global::JDE_Scanner_Desktop.Properties.Resources.Attach_24;
            this.btnAttachments.Location = new System.Drawing.Point(57, 4);
            this.btnAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Size = new System.Drawing.Size(45, 33);
            this.btnAttachments.TabIndex = 6;
            this.tooltip.SetToolTip(this.btnAttachments, "Zobacz załączone pliki..");
            this.btnAttachments.UseVisualStyleBackColor = true;
            this.btnAttachments.Click += new System.EventHandler(this.btnAttachments_Click);
            // 
            // lblCreated
            // 
            this.lblCreated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreated.AutoSize = true;
            this.lblCreated.Location = new System.Drawing.Point(4, 707);
            this.lblCreated.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(791, 17);
            this.lblCreated.TabIndex = 2;
            this.lblCreated.Text = "lblCreated";
            this.lblCreated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 5;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlpButtons.Controls.Add(this.btnSave, 0, 0);
            this.tlpButtons.Controls.Add(this.lblAssignedUsers, 3, 0);
            this.tlpButtons.Controls.Add(this.btnEditAssignedList, 4, 0);
            this.tlpButtons.Controls.Add(this.btnAttachments, 1, 0);
            this.tlpButtons.Controls.Add(this.btnChangeState, 2, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpButtons.Location = new System.Drawing.Point(4, 4);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(4);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(791, 41);
            this.tlpButtons.TabIndex = 0;
            // 
            // lblAssignedUsers
            // 
            this.lblAssignedUsers.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAssignedUsers.AutoSize = true;
            this.lblAssignedUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAssignedUsers.Location = new System.Drawing.Point(665, 12);
            this.lblAssignedUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAssignedUsers.Name = "lblAssignedUsers";
            this.lblAssignedUsers.Size = new System.Drawing.Size(81, 17);
            this.lblAssignedUsers.TabIndex = 4;
            this.lblAssignedUsers.Text = "Przypisani: ";
            this.lblAssignedUsers.Visible = false;
            // 
            // btnChangeState
            // 
            this.btnChangeState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeState.BackColor = System.Drawing.Color.PaleGreen;
            this.btnChangeState.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnChangeState.Location = new System.Drawing.Point(109, 3);
            this.btnChangeState.Name = "btnChangeState";
            this.btnChangeState.Size = new System.Drawing.Size(134, 35);
            this.btnChangeState.TabIndex = 7;
            this.btnChangeState.Text = "ROZPOCZNIJ";
            this.btnChangeState.UseVisualStyleBackColor = false;
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
            this.tlpMain.Controls.Add(this.tab, 0, 1);
            this.tlpMain.Location = new System.Drawing.Point(16, 15);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpMain.Size = new System.Drawing.Size(799, 734);
            this.tlpMain.TabIndex = 0;
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.pgProcess);
            this.tab.Controls.Add(this.pgHandling);
            this.tab.Controls.Add(this.pgHistory);
            this.tab.Controls.Add(this.pgActions);
            this.tab.Controls.Add(this.pbParts);
            this.tab.Location = new System.Drawing.Point(4, 53);
            this.tab.Margin = new System.Windows.Forms.Padding(4);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(791, 640);
            this.tab.TabIndex = 3;
            // 
            // pgProcess
            // 
            this.pgProcess.Controls.Add(this.tplTextboxes);
            this.pgProcess.Location = new System.Drawing.Point(4, 25);
            this.pgProcess.Margin = new System.Windows.Forms.Padding(4);
            this.pgProcess.Name = "pgProcess";
            this.pgProcess.Padding = new System.Windows.Forms.Padding(4);
            this.pgProcess.Size = new System.Drawing.Size(783, 611);
            this.pgProcess.TabIndex = 0;
            this.pgProcess.Text = "Zgłoszenie";
            this.pgProcess.UseVisualStyleBackColor = true;
            // 
            // tplTextboxes
            // 
            this.tplTextboxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplTextboxes.ColumnCount = 2;
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tplTextboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplTextboxes.Controls.Add(this.lblDescription, 0, 1);
            this.tplTextboxes.Controls.Add(this.label3, 0, 2);
            this.tplTextboxes.Controls.Add(this.label4, 0, 3);
            this.tplTextboxes.Controls.Add(this.label5, 0, 4);
            this.tplTextboxes.Controls.Add(this.label1, 0, 5);
            this.tplTextboxes.Controls.Add(this.label6, 0, 6);
            this.tplTextboxes.Controls.Add(this.label7, 0, 7);
            this.tplTextboxes.Controls.Add(this.cmbActionType, 1, 6);
            this.tplTextboxes.Controls.Add(this.txtDescription, 1, 1);
            this.tplTextboxes.Controls.Add(this.cmbPlace, 1, 7);
            this.tplTextboxes.Controls.Add(this.label8, 0, 8);
            this.tplTextboxes.Controls.Add(this.cmbStatus, 1, 8);
            this.tplTextboxes.Controls.Add(this.txtOutput, 1, 9);
            this.tplTextboxes.Controls.Add(this.label9, 0, 9);
            this.tplTextboxes.Controls.Add(this.tlpStartedOn, 1, 4);
            this.tplTextboxes.Controls.Add(this.lblInitialDiagnosis, 0, 10);
            this.tplTextboxes.Controls.Add(this.lblRepairActions, 0, 11);
            this.tplTextboxes.Controls.Add(this.txtInitialDiagnosis, 1, 10);
            this.tplTextboxes.Controls.Add(this.txtRepairActions, 1, 11);
            this.tplTextboxes.Controls.Add(this.lblMesId, 0, 0);
            this.tplTextboxes.Controls.Add(this.txtMesId, 1, 0);
            this.tplTextboxes.Controls.Add(this.tlpFinishedOn, 1, 5);
            this.tplTextboxes.Controls.Add(this.txtPlannedStart, 1, 2);
            this.tplTextboxes.Controls.Add(this.txtPlannedFinish, 1, 3);
            this.tplTextboxes.Controls.Add(this.label11, 0, 12);
            this.tplTextboxes.Controls.Add(this.txtComment, 1, 12);
            this.tplTextboxes.Location = new System.Drawing.Point(-5, 4);
            this.tplTextboxes.Margin = new System.Windows.Forms.Padding(4);
            this.tplTextboxes.Name = "tplTextboxes";
            this.tplTextboxes.RowCount = 14;
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tplTextboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplTextboxes.Size = new System.Drawing.Size(753, 620);
            this.tplTextboxes.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(4, 47);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(171, 17);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Opis";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Planowane rozpoczęcie";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Planowane zakończenie";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Rozpoczęcie";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 195);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Zakończenie";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 232);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Typ zlecenia";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 269);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Zasób";
            // 
            // cmbActionType
            // 
            this.cmbActionType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbActionType.FormattingEnabled = true;
            this.cmbActionType.Location = new System.Drawing.Point(183, 228);
            this.cmbActionType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbActionType.Name = "cmbActionType";
            this.cmbActionType.Size = new System.Drawing.Size(566, 24);
            this.cmbActionType.TabIndex = 13;
            this.cmbActionType.SelectedIndexChanged += new System.EventHandler(this.cmbActionType_SelectedIndexChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(183, 44);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(566, 22);
            this.txtDescription.TabIndex = 7;
            // 
            // cmbPlace
            // 
            this.cmbPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPlace.FormattingEnabled = true;
            this.cmbPlace.Location = new System.Drawing.Point(183, 265);
            this.cmbPlace.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPlace.Name = "cmbPlace";
            this.cmbPlace.Size = new System.Drawing.Size(566, 24);
            this.cmbPlace.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 306);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Planowany",
            "Rozpoczęty",
            "Wstrzymany",
            "Zakończony",
            "Zrealizowany"});
            this.cmbStatus.Location = new System.Drawing.Point(183, 302);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(566, 24);
            this.cmbStatus.TabIndex = 20;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(183, 337);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(566, 54);
            this.txtOutput.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 333);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 62);
            this.label9.TabIndex = 22;
            this.label9.Text = "Rezultat";
            // 
            // tlpStartedOn
            // 
            this.tlpStartedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpStartedOn.ColumnCount = 4;
            this.tlpStartedOn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStartedOn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpStartedOn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tlpStartedOn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStartedOn.Controls.Add(this.label10, 2, 0);
            this.tlpStartedOn.Controls.Add(this.btnStartedOnClear, 1, 0);
            this.tlpStartedOn.Controls.Add(this.txtStartedOn, 0, 0);
            this.tlpStartedOn.Controls.Add(this.cmbStartedBy, 3, 0);
            this.tlpStartedOn.Location = new System.Drawing.Point(183, 152);
            this.tlpStartedOn.Margin = new System.Windows.Forms.Padding(4);
            this.tlpStartedOn.Name = "tlpStartedOn";
            this.tlpStartedOn.RowCount = 1;
            this.tlpStartedOn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStartedOn.Size = new System.Drawing.Size(566, 29);
            this.tlpStartedOn.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 6);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "przez";
            // 
            // txtStartedOn
            // 
            this.txtStartedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartedOn.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.txtStartedOn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtStartedOn.Location = new System.Drawing.Point(4, 4);
            this.txtStartedOn.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartedOn.Name = "txtStartedOn";
            this.txtStartedOn.Size = new System.Drawing.Size(221, 22);
            this.txtStartedOn.TabIndex = 15;
            this.txtStartedOn.ValueChanged += new System.EventHandler(this.txtStartedOn_ValueChanged);
            // 
            // cmbStartedBy
            // 
            this.cmbStartedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStartedBy.FormattingEnabled = true;
            this.cmbStartedBy.Location = new System.Drawing.Point(340, 4);
            this.cmbStartedBy.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStartedBy.Name = "cmbStartedBy";
            this.cmbStartedBy.Size = new System.Drawing.Size(222, 24);
            this.cmbStartedBy.TabIndex = 16;
            // 
            // lblInitialDiagnosis
            // 
            this.lblInitialDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInitialDiagnosis.AutoSize = true;
            this.lblInitialDiagnosis.Location = new System.Drawing.Point(4, 417);
            this.lblInitialDiagnosis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInitialDiagnosis.Name = "lblInitialDiagnosis";
            this.lblInitialDiagnosis.Size = new System.Drawing.Size(171, 17);
            this.lblInitialDiagnosis.TabIndex = 25;
            this.lblInitialDiagnosis.Text = "Wstępne rozpoznanie";
            // 
            // lblRepairActions
            // 
            this.lblRepairActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRepairActions.AutoSize = true;
            this.lblRepairActions.Location = new System.Drawing.Point(4, 479);
            this.lblRepairActions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRepairActions.Name = "lblRepairActions";
            this.lblRepairActions.Size = new System.Drawing.Size(171, 17);
            this.lblRepairActions.TabIndex = 26;
            this.lblRepairActions.Text = "Czynności naprawcze";
            // 
            // txtInitialDiagnosis
            // 
            this.txtInitialDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInitialDiagnosis.Location = new System.Drawing.Point(183, 399);
            this.txtInitialDiagnosis.Margin = new System.Windows.Forms.Padding(4);
            this.txtInitialDiagnosis.Multiline = true;
            this.txtInitialDiagnosis.Name = "txtInitialDiagnosis";
            this.txtInitialDiagnosis.Size = new System.Drawing.Size(566, 54);
            this.txtInitialDiagnosis.TabIndex = 27;
            // 
            // txtRepairActions
            // 
            this.txtRepairActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRepairActions.Location = new System.Drawing.Point(183, 461);
            this.txtRepairActions.Margin = new System.Windows.Forms.Padding(4);
            this.txtRepairActions.Multiline = true;
            this.txtRepairActions.Name = "txtRepairActions";
            this.txtRepairActions.Size = new System.Drawing.Size(566, 54);
            this.txtRepairActions.TabIndex = 28;
            // 
            // lblMesId
            // 
            this.lblMesId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMesId.AutoSize = true;
            this.lblMesId.Location = new System.Drawing.Point(4, 10);
            this.lblMesId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMesId.Name = "lblMesId";
            this.lblMesId.Size = new System.Drawing.Size(171, 17);
            this.lblMesId.TabIndex = 29;
            this.lblMesId.Text = "MES Id";
            // 
            // txtMesId
            // 
            this.txtMesId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMesId.Location = new System.Drawing.Point(183, 7);
            this.txtMesId.Margin = new System.Windows.Forms.Padding(4);
            this.txtMesId.Name = "txtMesId";
            this.txtMesId.Size = new System.Drawing.Size(566, 22);
            this.txtMesId.TabIndex = 30;
            // 
            // tlpFinishedOn
            // 
            this.tlpFinishedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFinishedOn.ColumnCount = 4;
            this.tlpFinishedOn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFinishedOn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFinishedOn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tlpFinishedOn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFinishedOn.Controls.Add(this.cmbFinishedBy, 3, 0);
            this.tlpFinishedOn.Controls.Add(this.label2, 2, 0);
            this.tlpFinishedOn.Controls.Add(this.btnFinishedOnClear, 1, 0);
            this.tlpFinishedOn.Controls.Add(this.txtFinishedOn, 0, 0);
            this.tlpFinishedOn.Location = new System.Drawing.Point(183, 189);
            this.tlpFinishedOn.Margin = new System.Windows.Forms.Padding(4);
            this.tlpFinishedOn.Name = "tlpFinishedOn";
            this.tlpFinishedOn.RowCount = 1;
            this.tlpFinishedOn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFinishedOn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpFinishedOn.Size = new System.Drawing.Size(566, 29);
            this.tlpFinishedOn.TabIndex = 31;
            // 
            // cmbFinishedBy
            // 
            this.cmbFinishedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFinishedBy.FormattingEnabled = true;
            this.cmbFinishedBy.Location = new System.Drawing.Point(340, 4);
            this.cmbFinishedBy.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFinishedBy.Name = "cmbFinishedBy";
            this.cmbFinishedBy.Size = new System.Drawing.Size(222, 24);
            this.cmbFinishedBy.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "przez";
            // 
            // txtFinishedOn
            // 
            this.txtFinishedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinishedOn.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.txtFinishedOn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFinishedOn.Location = new System.Drawing.Point(4, 4);
            this.txtFinishedOn.Margin = new System.Windows.Forms.Padding(4);
            this.txtFinishedOn.Name = "txtFinishedOn";
            this.txtFinishedOn.Size = new System.Drawing.Size(221, 22);
            this.txtFinishedOn.TabIndex = 17;
            this.txtFinishedOn.ValueChanged += new System.EventHandler(this.txtFinishedOn_ValueChanged);
            // 
            // txtPlannedStart
            // 
            this.txtPlannedStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlannedStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.txtPlannedStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtPlannedStart.Location = new System.Drawing.Point(183, 81);
            this.txtPlannedStart.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlannedStart.Name = "txtPlannedStart";
            this.txtPlannedStart.Size = new System.Drawing.Size(566, 22);
            this.txtPlannedStart.TabIndex = 32;
            // 
            // txtPlannedFinish
            // 
            this.txtPlannedFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlannedFinish.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.txtPlannedFinish.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtPlannedFinish.Location = new System.Drawing.Point(183, 118);
            this.txtPlannedFinish.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlannedFinish.Name = "txtPlannedFinish";
            this.txtPlannedFinish.Size = new System.Drawing.Size(566, 22);
            this.txtPlannedFinish.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 541);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(171, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "Komentarz";
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(183, 523);
            this.txtComment.Margin = new System.Windows.Forms.Padding(4);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(566, 54);
            this.txtComment.TabIndex = 35;
            // 
            // pgHandling
            // 
            this.pgHandling.Controls.Add(this.lvHandlings);
            this.pgHandling.Location = new System.Drawing.Point(4, 25);
            this.pgHandling.Margin = new System.Windows.Forms.Padding(4);
            this.pgHandling.Name = "pgHandling";
            this.pgHandling.Padding = new System.Windows.Forms.Padding(4);
            this.pgHandling.Size = new System.Drawing.Size(783, 611);
            this.pgHandling.TabIndex = 1;
            this.pgHandling.Text = "Obsługa";
            this.pgHandling.UseVisualStyleBackColor = true;
            // 
            // lvHandlings
            // 
            this.lvHandlings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvHandlings.HideSelection = false;
            this.lvHandlings.Location = new System.Drawing.Point(4, 4);
            this.lvHandlings.Margin = new System.Windows.Forms.Padding(4);
            this.lvHandlings.Name = "lvHandlings";
            this.lvHandlings.Size = new System.Drawing.Size(775, 603);
            this.lvHandlings.TabIndex = 0;
            this.lvHandlings.UseCompatibleStateImageBehavior = false;
            this.lvHandlings.View = System.Windows.Forms.View.Details;
            // 
            // pgHistory
            // 
            this.pgHistory.Controls.Add(this.lvHistory);
            this.pgHistory.Location = new System.Drawing.Point(4, 25);
            this.pgHistory.Margin = new System.Windows.Forms.Padding(4);
            this.pgHistory.Name = "pgHistory";
            this.pgHistory.Padding = new System.Windows.Forms.Padding(4);
            this.pgHistory.Size = new System.Drawing.Size(783, 611);
            this.pgHistory.TabIndex = 2;
            this.pgHistory.Text = "Historia";
            this.pgHistory.UseVisualStyleBackColor = true;
            // 
            // lvHistory
            // 
            this.lvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvHistory.HideSelection = false;
            this.lvHistory.Location = new System.Drawing.Point(4, 4);
            this.lvHistory.Margin = new System.Windows.Forms.Padding(4);
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(775, 603);
            this.lvHistory.TabIndex = 0;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            // 
            // pgActions
            // 
            this.pgActions.Controls.Add(this.dgvActions);
            this.pgActions.Location = new System.Drawing.Point(4, 25);
            this.pgActions.Margin = new System.Windows.Forms.Padding(4);
            this.pgActions.Name = "pgActions";
            this.pgActions.Padding = new System.Windows.Forms.Padding(4);
            this.pgActions.Size = new System.Drawing.Size(783, 611);
            this.pgActions.TabIndex = 3;
            this.pgActions.Text = "Czynności";
            this.pgActions.UseVisualStyleBackColor = true;
            // 
            // dgvActions
            // 
            this.dgvActions.AllowUserToAddRows = false;
            this.dgvActions.AllowUserToDeleteRows = false;
            this.dgvActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActions.Location = new System.Drawing.Point(4, 4);
            this.dgvActions.Margin = new System.Windows.Forms.Padding(4);
            this.dgvActions.Name = "dgvActions";
            this.dgvActions.RowHeadersWidth = 51;
            this.dgvActions.Size = new System.Drawing.Size(776, 518);
            this.dgvActions.TabIndex = 0;
            // 
            // pbParts
            // 
            this.pbParts.Controls.Add(this.dgvUsedParts);
            this.pbParts.Location = new System.Drawing.Point(4, 25);
            this.pbParts.Margin = new System.Windows.Forms.Padding(4);
            this.pbParts.Name = "pbParts";
            this.pbParts.Padding = new System.Windows.Forms.Padding(4);
            this.pbParts.Size = new System.Drawing.Size(783, 611);
            this.pbParts.TabIndex = 4;
            this.pbParts.Text = "Użyte części";
            this.pbParts.UseVisualStyleBackColor = true;
            // 
            // dgvUsedParts
            // 
            this.dgvUsedParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsedParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsedParts.Location = new System.Drawing.Point(4, 4);
            this.dgvUsedParts.Margin = new System.Windows.Forms.Padding(4);
            this.dgvUsedParts.Name = "dgvUsedParts";
            this.dgvUsedParts.RowHeadersWidth = 51;
            this.dgvUsedParts.Size = new System.Drawing.Size(775, 603);
            this.dgvUsedParts.TabIndex = 0;
            // 
            // frmProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(831, 763);
            this.Controls.Add(this.tlpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Szczegóły zgłoszenia";
            this.Load += new System.EventHandler(this.FormLoaded);
            this.tlpButtons.ResumeLayout(false);
            this.tlpButtons.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tab.ResumeLayout(false);
            this.pgProcess.ResumeLayout(false);
            this.tplTextboxes.ResumeLayout(false);
            this.tplTextboxes.PerformLayout();
            this.tlpStartedOn.ResumeLayout(false);
            this.tlpStartedOn.PerformLayout();
            this.tlpFinishedOn.ResumeLayout(false);
            this.tlpFinishedOn.PerformLayout();
            this.pgHandling.ResumeLayout(false);
            this.pgHistory.ResumeLayout(false);
            this.pgActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActions)).EndInit();
            this.pbParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsedParts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage pgProcess;
        private System.Windows.Forms.TableLayoutPanel tplTextboxes;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFinishedBy;
        private System.Windows.Forms.ComboBox cmbActionType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbStartedBy;
        private System.Windows.Forms.ComboBox cmbPlace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker txtStartedOn;
        private System.Windows.Forms.Button btnStartedOnClear;
        private System.Windows.Forms.TableLayoutPanel tlpStartedOn;
        private System.Windows.Forms.DateTimePicker txtFinishedOn;
        private System.Windows.Forms.Button btnFinishedOnClear;
        private System.Windows.Forms.Label lblInitialDiagnosis;
        private System.Windows.Forms.Label lblRepairActions;
        private System.Windows.Forms.TextBox txtInitialDiagnosis;
        private System.Windows.Forms.TextBox txtRepairActions;
        private System.Windows.Forms.Label lblMesId;
        private System.Windows.Forms.TextBox txtMesId;
        private System.Windows.Forms.TabPage pgHandling;
        private System.Windows.Forms.ListView lvHandlings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tlpFinishedOn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker txtPlannedStart;
        private System.Windows.Forms.DateTimePicker txtPlannedFinish;
        private System.Windows.Forms.TabPage pgHistory;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.TabPage pgActions;
        private System.Windows.Forms.DataGridView dgvActions;
        private System.Windows.Forms.Label lblAssignedUsers;
        private System.Windows.Forms.Button btnEditAssignedList;
        private System.Windows.Forms.TabPage pbParts;
        private System.Windows.Forms.DataGridView dgvUsedParts;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnAttachments;
        private System.Windows.Forms.Button btnChangeState;
    }
}
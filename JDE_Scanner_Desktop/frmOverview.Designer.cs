namespace JDE_Scanner_Desktop
{
    partial class frmOverview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOverview));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnPrevMonth = new FontAwesome.Sharp.IconButton();
            this.btnThisMonth = new FontAwesome.Sharp.IconButton();
            this.btnPrevWeek = new FontAwesome.Sharp.IconButton();
            this.btnThisWeek = new FontAwesome.Sharp.IconButton();
            this.btnYesterday = new FontAwesome.Sharp.IconButton();
            this.btnToday = new FontAwesome.Sharp.IconButton();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlSide.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlSide.Controls.Add(this.btnPrevMonth);
            this.pnlSide.Controls.Add(this.btnThisMonth);
            this.pnlSide.Controls.Add(this.btnPrevWeek);
            this.pnlSide.Controls.Add(this.btnThisWeek);
            this.pnlSide.Controls.Add(this.btnYesterday);
            this.pnlSide.Controls.Add(this.btnToday);
            this.pnlSide.Controls.Add(this.panel1);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(267, 681);
            this.pnlSide.TabIndex = 2;
            // 
            // btnPrevMonth
            // 
            this.btnPrevMonth.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrevMonth.FlatAppearance.BorderSize = 0;
            this.btnPrevMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrevMonth.ForeColor = System.Drawing.Color.White;
            this.btnPrevMonth.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnPrevMonth.IconColor = System.Drawing.Color.Black;
            this.btnPrevMonth.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrevMonth.Location = new System.Drawing.Point(0, 434);
            this.btnPrevMonth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrevMonth.Name = "btnPrevMonth";
            this.btnPrevMonth.Size = new System.Drawing.Size(267, 62);
            this.btnPrevMonth.TabIndex = 5;
            this.btnPrevMonth.Text = "Poprzedni miesiąc";
            this.btnPrevMonth.UseVisualStyleBackColor = true;
            this.btnPrevMonth.Click += new System.EventHandler(this.btnPrevMonth_Click);
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThisMonth.FlatAppearance.BorderSize = 0;
            this.btnThisMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnThisMonth.ForeColor = System.Drawing.Color.White;
            this.btnThisMonth.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnThisMonth.IconColor = System.Drawing.Color.Black;
            this.btnThisMonth.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThisMonth.Location = new System.Drawing.Point(0, 372);
            this.btnThisMonth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(267, 62);
            this.btnThisMonth.TabIndex = 4;
            this.btnThisMonth.Text = "Ten miesiąc";
            this.btnThisMonth.UseVisualStyleBackColor = true;
            this.btnThisMonth.Click += new System.EventHandler(this.btnThisMonth_Click);
            // 
            // btnPrevWeek
            // 
            this.btnPrevWeek.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrevWeek.FlatAppearance.BorderSize = 0;
            this.btnPrevWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrevWeek.ForeColor = System.Drawing.Color.White;
            this.btnPrevWeek.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnPrevWeek.IconColor = System.Drawing.Color.Black;
            this.btnPrevWeek.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrevWeek.Location = new System.Drawing.Point(0, 310);
            this.btnPrevWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrevWeek.Name = "btnPrevWeek";
            this.btnPrevWeek.Size = new System.Drawing.Size(267, 62);
            this.btnPrevWeek.TabIndex = 3;
            this.btnPrevWeek.Text = "Poprzedni tydzień";
            this.btnPrevWeek.UseVisualStyleBackColor = true;
            this.btnPrevWeek.Click += new System.EventHandler(this.btnPrevWeek_Click);
            // 
            // btnThisWeek
            // 
            this.btnThisWeek.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnThisWeek.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThisWeek.FlatAppearance.BorderSize = 0;
            this.btnThisWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnThisWeek.ForeColor = System.Drawing.Color.White;
            this.btnThisWeek.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnThisWeek.IconColor = System.Drawing.Color.Black;
            this.btnThisWeek.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThisWeek.Location = new System.Drawing.Point(0, 248);
            this.btnThisWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThisWeek.Name = "btnThisWeek";
            this.btnThisWeek.Size = new System.Drawing.Size(267, 62);
            this.btnThisWeek.TabIndex = 2;
            this.btnThisWeek.Text = "Ten tydzień";
            this.btnThisWeek.UseVisualStyleBackColor = false;
            this.btnThisWeek.Click += new System.EventHandler(this.btnThisWeek_Click);
            // 
            // btnYesterday
            // 
            this.btnYesterday.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnYesterday.FlatAppearance.BorderSize = 0;
            this.btnYesterday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYesterday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnYesterday.ForeColor = System.Drawing.Color.White;
            this.btnYesterday.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnYesterday.IconColor = System.Drawing.Color.Black;
            this.btnYesterday.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnYesterday.Location = new System.Drawing.Point(0, 186);
            this.btnYesterday.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnYesterday.Name = "btnYesterday";
            this.btnYesterday.Size = new System.Drawing.Size(267, 62);
            this.btnYesterday.TabIndex = 1;
            this.btnYesterday.Text = "Wczoraj";
            this.btnYesterday.UseVisualStyleBackColor = true;
            this.btnYesterday.Click += new System.EventHandler(this.btnYesterday_Click);
            // 
            // btnToday
            // 
            this.btnToday.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnToday.FlatAppearance.BorderSize = 0;
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnToday.ForeColor = System.Drawing.Color.White;
            this.btnToday.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnToday.IconColor = System.Drawing.Color.Black;
            this.btnToday.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnToday.Location = new System.Drawing.Point(0, 124);
            this.btnToday.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(267, 62);
            this.btnToday.TabIndex = 0;
            this.btnToday.Text = "Dzisiaj";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(267, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1192, 62);
            this.pnlTop.TabIndex = 3;
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(267, 62);
            this.panelDesktop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1192, 619);
            this.panelDesktop.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 124);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1459, 681);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlSide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmOverview";
            this.Text = "Podsumowanie";
            this.pnlSide.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlSide;
        private FontAwesome.Sharp.IconButton btnToday;
        private FontAwesome.Sharp.IconButton btnPrevMonth;
        private FontAwesome.Sharp.IconButton btnThisMonth;
        private FontAwesome.Sharp.IconButton btnPrevWeek;
        private FontAwesome.Sharp.IconButton btnThisWeek;
        private FontAwesome.Sharp.IconButton btnYesterday;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
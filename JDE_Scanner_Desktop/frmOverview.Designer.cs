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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlDesktop = new System.Windows.Forms.Panel();
            this.btnThisShift = new FontAwesome.Sharp.IconButton();
            this.btnPrevShift = new FontAwesome.Sharp.IconButton();
            this.btnThisQuarter = new FontAwesome.Sharp.IconButton();
            this.btnPrevQuarter = new FontAwesome.Sharp.IconButton();
            this.pnlSide.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlSide.Controls.Add(this.btnPrevQuarter);
            this.pnlSide.Controls.Add(this.btnThisQuarter);
            this.pnlSide.Controls.Add(this.btnPrevMonth);
            this.pnlSide.Controls.Add(this.btnThisMonth);
            this.pnlSide.Controls.Add(this.btnPrevWeek);
            this.pnlSide.Controls.Add(this.btnThisWeek);
            this.pnlSide.Controls.Add(this.btnYesterday);
            this.pnlSide.Controls.Add(this.btnToday);
            this.pnlSide.Controls.Add(this.btnPrevShift);
            this.pnlSide.Controls.Add(this.btnThisShift);
            this.pnlSide.Controls.Add(this.panel1);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(200, 629);
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
            this.btnPrevMonth.Location = new System.Drawing.Point(0, 451);
            this.btnPrevMonth.Name = "btnPrevMonth";
            this.btnPrevMonth.Size = new System.Drawing.Size(200, 50);
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
            this.btnThisMonth.Location = new System.Drawing.Point(0, 401);
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(200, 50);
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
            this.btnPrevWeek.Location = new System.Drawing.Point(0, 351);
            this.btnPrevWeek.Name = "btnPrevWeek";
            this.btnPrevWeek.Size = new System.Drawing.Size(200, 50);
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
            this.btnThisWeek.Location = new System.Drawing.Point(0, 301);
            this.btnThisWeek.Name = "btnThisWeek";
            this.btnThisWeek.Size = new System.Drawing.Size(200, 50);
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
            this.btnYesterday.Location = new System.Drawing.Point(0, 251);
            this.btnYesterday.Name = "btnYesterday";
            this.btnYesterday.Size = new System.Drawing.Size(200, 50);
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
            this.btnToday.Location = new System.Drawing.Point(0, 201);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(200, 50);
            this.btnToday.TabIndex = 0;
            this.btnToday.Text = "Dzisiaj";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 101);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(200, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(894, 50);
            this.pnlTop.TabIndex = 3;
            // 
            // pnlDesktop
            // 
            this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktop.Location = new System.Drawing.Point(200, 50);
            this.pnlDesktop.Name = "pnlDesktop";
            this.pnlDesktop.Size = new System.Drawing.Size(894, 579);
            this.pnlDesktop.TabIndex = 4;
            // 
            // btnThisShift
            // 
            this.btnThisShift.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThisShift.FlatAppearance.BorderSize = 0;
            this.btnThisShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnThisShift.ForeColor = System.Drawing.Color.White;
            this.btnThisShift.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnThisShift.IconColor = System.Drawing.Color.Black;
            this.btnThisShift.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThisShift.Location = new System.Drawing.Point(0, 101);
            this.btnThisShift.Name = "btnThisShift";
            this.btnThisShift.Size = new System.Drawing.Size(200, 50);
            this.btnThisShift.TabIndex = 7;
            this.btnThisShift.Text = "Ta zmiana";
            this.btnThisShift.UseVisualStyleBackColor = true;
            this.btnThisShift.Click += new System.EventHandler(this.btnThisShift_Click);
            // 
            // btnPrevShift
            // 
            this.btnPrevShift.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrevShift.FlatAppearance.BorderSize = 0;
            this.btnPrevShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrevShift.ForeColor = System.Drawing.Color.White;
            this.btnPrevShift.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnPrevShift.IconColor = System.Drawing.Color.Black;
            this.btnPrevShift.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrevShift.Location = new System.Drawing.Point(0, 151);
            this.btnPrevShift.Name = "btnPrevShift";
            this.btnPrevShift.Size = new System.Drawing.Size(200, 50);
            this.btnPrevShift.TabIndex = 8;
            this.btnPrevShift.Text = "Poprzednia zmiana";
            this.btnPrevShift.UseVisualStyleBackColor = true;
            this.btnPrevShift.Click += new System.EventHandler(this.btnPrevShift_Click);
            // 
            // btnThisQuarter
            // 
            this.btnThisQuarter.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThisQuarter.FlatAppearance.BorderSize = 0;
            this.btnThisQuarter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisQuarter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnThisQuarter.ForeColor = System.Drawing.Color.White;
            this.btnThisQuarter.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnThisQuarter.IconColor = System.Drawing.Color.Black;
            this.btnThisQuarter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThisQuarter.Location = new System.Drawing.Point(0, 501);
            this.btnThisQuarter.Name = "btnThisQuarter";
            this.btnThisQuarter.Size = new System.Drawing.Size(200, 50);
            this.btnThisQuarter.TabIndex = 9;
            this.btnThisQuarter.Text = "Ten kwartał";
            this.btnThisQuarter.UseVisualStyleBackColor = true;
            this.btnThisQuarter.Click += new System.EventHandler(this.btnThisQuarter_Click);
            // 
            // btnPrevQuarter
            // 
            this.btnPrevQuarter.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrevQuarter.FlatAppearance.BorderSize = 0;
            this.btnPrevQuarter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevQuarter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrevQuarter.ForeColor = System.Drawing.Color.White;
            this.btnPrevQuarter.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnPrevQuarter.IconColor = System.Drawing.Color.Black;
            this.btnPrevQuarter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrevQuarter.Location = new System.Drawing.Point(0, 551);
            this.btnPrevQuarter.Name = "btnPrevQuarter";
            this.btnPrevQuarter.Size = new System.Drawing.Size(200, 50);
            this.btnPrevQuarter.TabIndex = 10;
            this.btnPrevQuarter.Text = "Poprzedni kwartał";
            this.btnPrevQuarter.UseVisualStyleBackColor = true;
            this.btnPrevQuarter.Click += new System.EventHandler(this.btnPrevQuarter_Click);
            // 
            // frmOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 629);
            this.Controls.Add(this.pnlDesktop);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlSide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Panel pnlDesktop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnPrevShift;
        private FontAwesome.Sharp.IconButton btnThisShift;
        private FontAwesome.Sharp.IconButton btnThisQuarter;
        private FontAwesome.Sharp.IconButton btnPrevQuarter;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop
{
    public partial class frmToast : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public frmToast(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
        }

        public frmToast(Form parent, string message)
        {
            InitializeComponent();
            this.Owner = parent;
            lblMain.Text = message;
        }

        private void frmToast_Load(object sender, EventArgs e)
        {
            int newWidth = TextRenderer.MeasureText(lblMain.Text, SystemFonts.CaptionFont).Width;
            if (newWidth < this.Owner.Width)
            {
                this.Width = newWidth;
            }
            else
            {
                this.Width = this.Owner.Width - 100;
            }
            this.Location = new Point(this.Owner.Location.X + (this.Owner.Width / 2) - (this.Width / 2), this.Owner.Location.Y + (this.Owner.Height / 2) - (this.Height / 2));
            timer.Interval = 2000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

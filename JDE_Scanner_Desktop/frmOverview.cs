using FontAwesome.Sharp;
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
    public partial class frmOverview : Form
    {
        private Panel LeftBorderBtn;
        private IconButton CurrentButton;
        private Form CurrentChildForm;

        public frmOverview()
        {
            InitializeComponent();
            LeftBorderBtn = new Panel();
            LeftBorderBtn.Size = new Size(7, 50);
            pnlSide.Controls.Add(LeftBorderBtn);
        }

        private void ActivateButton(object sender, Color color)
        {
            if(sender != null)
            {
                DeactivateButton();
                CurrentButton = (IconButton)sender;
                CurrentButton.BackColor = Color.FromArgb(134, 191, 224);
                CurrentButton.ForeColor = color;
                CurrentButton.IconColor = color;

                LeftBorderBtn.BackColor = color;
                LeftBorderBtn.Location = new Point(0, CurrentButton.Location.Y);
                LeftBorderBtn.Visible = true;
                LeftBorderBtn.BringToFront();
            }
        }

        private void DeactivateButton()
        {
            if(CurrentButton != null)
            {
                CurrentButton.BackColor = Color.LightSkyBlue;
                CurrentButton.ForeColor = Color.White;
                CurrentButton.IconColor = Color.White;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            CurrentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.BlueViolet);
        }

        private void btnYesterday_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Coral);
        }

        private void btnThisWeek_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.ForestGreen);
        }

        private void btnPrevWeek_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.DarkKhaki);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Chocolate);
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.DeepPink);
        }
    }
}

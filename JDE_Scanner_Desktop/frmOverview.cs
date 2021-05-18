using FontAwesome.Sharp;
using JDE_Scanner_Desktop.Static;
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
            TodayClicked(btnToday);
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
            pnlDesktop.Controls.Add(childForm);
            pnlDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            TodayClicked(sender);
        }

        private void TodayClicked(object sender)
        {
            ActivateButton(sender, Color.BlueViolet);
            DateTime now = DateTime.Now;
            frmDetailedOverview DetailForm = new frmDetailedOverview(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0), new DateTime(now.Year, now.Month, now.Day, 23, 59, 59));
            DetailForm.ShowInPanel(pnlDesktop);
        }

        private void btnYesterday_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Coral);
            DateTime now = DateTime.Now.AddDays(-1);
            frmDetailedOverview DetailForm = new frmDetailedOverview(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0), new DateTime(now.Year, now.Month, now.Day, 23, 59, 59));
            DetailForm.ShowInPanel(pnlDesktop);
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
            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            DateTime end = start.AddMonths(1).AddDays(-1);
            frmDetailedOverview DetailForm = new frmDetailedOverview(start, end);
            DetailForm.ShowInPanel(pnlDesktop);
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.DeepPink);
            DateTime start = new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, 1, 0, 0, 0);
            DateTime end = start.AddMonths(1).AddDays(-1);
            frmDetailedOverview DetailForm = new frmDetailedOverview(start, end);
            DetailForm.ShowInPanel(pnlDesktop);
        }
    }
}

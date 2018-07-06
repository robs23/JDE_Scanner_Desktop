using JDE_Scanner_Desktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop
{
    public partial class frmUsers : Form
    {
        UsersKeeper Keeper = new UsersKeeper();
        frmLooper looper;
        int page;

        public frmUsers(frmStarter parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
        }

        private async void Reload()
        {
            looper.Show(this);
            await Keeper.Refresh();
            dgUsers.DataSource = null;
            dgUsers.DataSource = Keeper.Items;
            looper.Hide();
            page = 1;
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            looper = new frmLooper(this);
            looper.TopMost = true;
            Reload();
        }

        private void AddUser(object sender, EventArgs e)
        {
            frmUser FrmUser = new frmUser(this);
            FrmUser.Show();
        }

        private void ViewUser(object sender, EventArgs e)
        {

            int UserId = Convert.ToInt32(dgUsers.Rows[dgUsers.CurrentCell.RowIndex].Cells[0].Value);

            User User = new User();
            User = Keeper.Items.Where(u => u.UserId == UserId).FirstOrDefault();
            frmUser FrmUser = new frmUser(User, this);
            FrmUser.Show();
        }


        private void Refresh(object sender, EventArgs e)
        {
            Reload();
        }

        private void DeleteUser(object sender, EventArgs e)
        {
            if (dgUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Żaden wiersz nie jest zaznaczony. Aby usunąć wybrane wiersze, najpierw zaznacz je kliknięciem po ich lewej stronie.");
            }
            else
            {
                List<int> SelectedRows = new List<int>();
                for (int i = 0; i < dgUsers.SelectedRows.Count; i++)
                {
                    SelectedRows.Add((int)dgUsers.SelectedRows[i].Cells[0].Value);
                }
                Keeper.Remove(SelectedRows);
                Reload();
            }
        }

        private void dgUsers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(this, "Wystąpił problem z dostępem do danych. Szczegóły: " + e.Exception.Message, "Error");
            e.ThrowException = false;
            e.Cancel = false;
        }

        private async void dgUsers_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue < e.NewValue)
            {
                var visibleRowsCount = dgUsers.DisplayedRowCount(true);
                var firstDisplayedRowIndex = dgUsers.FirstDisplayedScrollingRowIndex;
                var lastvisibleRowIndex = (firstDisplayedRowIndex + visibleRowsCount);
                if (lastvisibleRowIndex == RuntimeSettings.PageSize * page)
                {
                    int x = dgUsers.FirstDisplayedScrollingRowIndex;
                    looper.Show(this);
                    page++;
                    //int nextPage = (int)Math.Ceiling((double)((double)dgItems.Rows.Count / (double)RuntimeSettings.PageSize)) + 1;
                    bool _IsMore = await Keeper.GetMore(page);
                    if (_IsMore)
                    {
                        dgUsers.DataSource = null;
                        dgUsers.DataSource = Keeper.Items;
                        dgUsers.Refresh();
                        dgUsers.FirstDisplayedScrollingRowIndex = x;
                        looper.Hide();
                    }
                    else
                    {
                        looper.Hide();
                        frmToast FrmToast = new frmToast(this, "Osiągnięto koniec rekordów");
                        FrmToast.Show(this);
                    }
                    dgUsers.Select();
                }
            }
        }
    }
}

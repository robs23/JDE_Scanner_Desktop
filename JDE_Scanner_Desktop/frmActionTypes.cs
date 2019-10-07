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
    public partial class frmActionTypes : Form
    {
        ActionTypesKeeper Keeper = new ActionTypesKeeper();
        frmLooper looper;
        int page;
        BindingSource source = new BindingSource();

        public frmActionTypes(frmStarter parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
        }

        private async void Reload()
        {
            looper.Show(this);
            await Keeper.Refresh();
            source.DataSource = Keeper.Items;
            dgItems.DataSource = source;
            source.ResetBindings(false);
            looper.Hide();
            page = 1;
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            looper = new frmLooper(this);
            looper.TopMost = true;
            Reload();
        }

        private void Add(object sender, EventArgs e)
        {
            frmActionType FrmActionType = new frmActionType(this);
            FrmActionType.Show();
        }

        private void View(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(dgItems.Rows[dgItems.CurrentCell.RowIndex].Cells[0].Value);

            ActionType Item = new ActionType();
            Item = Keeper.Items.Where(u => u.ActionTypeId == id).FirstOrDefault();
            frmActionType FrmActionType = new frmActionType(Item, this);
            FrmActionType.Show();
        }


        private void Refresh(object sender, EventArgs e)
        {
            Reload();
        }

        private async void Delete(object sender, EventArgs e)
        {
            if (dgItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Żaden wiersz nie jest zaznaczony. Aby usunąć wybrane wiersze, najpierw zaznacz je kliknięciem po ich lewej stronie.");
            }
            else
            {
                List<int> SelectedRows = new List<int>();
                for (int i = 0; i < dgItems.SelectedRows.Count; i++)
                {
                    SelectedRows.Add((int)dgItems.SelectedRows[i].Cells[0].Value);
                }
                Keeper.Remove(SelectedRows);
                Reload();
            }
        }

        private void dgItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(this, "Wystąpił problem z dostępem do danych. Szczegóły: " + e.Exception.Message, "Error");
            e.ThrowException = false;
            e.Cancel = false;
        }

        private async void dgItems_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue < e.NewValue)
            {
                var visibleRowsCount = dgItems.DisplayedRowCount(true);
                var firstDisplayedRowIndex = dgItems.FirstDisplayedScrollingRowIndex;
                var lastvisibleRowIndex = (firstDisplayedRowIndex + visibleRowsCount);
                if (lastvisibleRowIndex >= RuntimeSettings.PageSize * page)
                {
                    int x = dgItems.FirstDisplayedScrollingRowIndex;
                    looper.Show(this);
                    page++;
                    //int nextPage = (int)Math.Ceiling((double)((double)dgItems.Rows.Count / (double)RuntimeSettings.PageSize)) + 1;
                    bool _IsMore = await Keeper.GetMore(page);
                    if (_IsMore)
                    {
                        source.ResetBindings(false);
                        dgItems.FirstDisplayedScrollingRowIndex = x;
                        looper.Hide();
                    }
                    else
                    {
                        looper.Hide();
                        frmToast FrmToast = new frmToast(this, "Osiągnięto koniec rekordów");
                        FrmToast.Show(this);
                    }
                    dgItems.Select();
                }
            }
        }
    }
}

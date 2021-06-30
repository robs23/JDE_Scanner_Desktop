using JDE_Scanner_Desktop.Classes;
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
    public partial class frmOrders : Form
    {
        OrderKeeper Keeper = new OrderKeeper();
        frmLooper looper;
        int page;
        frmFilter FrmFilter;
        BindingSource source = new BindingSource();
        int previousRow = -1;
        int currentRow = -1;


        public frmOrders(frmStarter parent)
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
            //Initialize auto sum in status here
            AutoSum autoSum = new AutoSum(this.sumStatusStrip, this.dgItems);
            autoSum.Initilize();
        }

        private void Add(object sender, EventArgs e)
        {
            frmOrder FrmItem = new frmOrder(this);
            FrmItem.Show();
        }

        private void View(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgItems.Rows[dgItems.CurrentCell.RowIndex].Cells[0].Value);

            var item = new Order();
            item = Keeper.Items.Where(u => u.OrderId == id).FirstOrDefault();
            frmOrder ItemForm = new frmOrder(item, this);
            ItemForm.Show();
        }


        private void Refresh(object sender, EventArgs e)
        {
            Reload();
        }

        private void Delete(object sender, EventArgs e)
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (FrmFilter == null)
            {
                FrmFilter = new frmFilter(this, dgItems, Keeper);
            }

            var res = FrmFilter.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                //Filter has been applied
                if (!string.IsNullOrEmpty(FrmFilter.FilterString))
                {
                    btnFilter.Image = JDE_Scanner_Desktop.Properties.Resources.icon_filter_on;
                }
                Reload();
            }
            else if (res == DialogResult.Cancel)
            {
                btnFilter.Image = JDE_Scanner_Desktop.Properties.Resources.icon_filter_off;
                Reload();
                FrmFilter.Dispose();
                FrmFilter = null;
            }
        }


        private async void btnArchive_Click(object sender, EventArgs e)
        {
            if (dgItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Żaden wiersz nie jest zaznaczony. Aby zarchiwizować wybrane wiersze, najpierw zaznacz je kliknięciem po ich lewej stronie.");
            }
            else
            {
                List<int> SelectedRows = new List<int>();
                for (int i = 0; i < dgItems.SelectedRows.Count; i++)
                {
                    SelectedRows.Add((int)dgItems.SelectedRows[i].Cells[0].Value);
                }
                await Keeper.Archive(SelectedRows);
                Reload();
            }
        }

        private void dgItems_MouseLeave(object sender, EventArgs e)
        {

        }

        private void dgItems_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}

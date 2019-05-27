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
    public partial class frmLogs : Form
    {
        LogsKeeper Keeper = new LogsKeeper();
        frmLooper looper;
        int page;

        public frmLogs(frmStarter parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
        }

        private async void Reload()
        {
            looper.Show(this);
            await Keeper.Refresh();
            dgItems.DataSource = null;
            dgItems.DataSource = Keeper.Items;
            looper.Hide();
            page = 1;
            adjustColumnWidths();
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            looper = new frmLooper(this);
            looper.TopMost = true;
            Reload();
        }

        private void View(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(dgItems.Rows[dgItems.CurrentCell.RowIndex].Cells[0].Value);

            Log Item = new Log();
            Item = Keeper.Items.Where(u => u.LogId == id).FirstOrDefault();
            frmLog FrmLog = new frmLog(Item, this);
            FrmLog.Show();
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
            if(e.OldValue < e.NewValue)
            {
                var visibleRowsCount = dgItems.DisplayedRowCount(true);
                var firstDisplayedRowIndex = dgItems.FirstDisplayedScrollingRowIndex;
                var lastvisibleRowIndex = (firstDisplayedRowIndex + visibleRowsCount);
                if (lastvisibleRowIndex == RuntimeSettings.PageSize*page)
                {
                    int x = dgItems.FirstDisplayedScrollingRowIndex;
                    looper.Show(this);
                    page++;
                    //int nextPage = (int)Math.Ceiling((double)((double)dgItems.Rows.Count / (double)RuntimeSettings.PageSize)) + 1;
                    bool _IsMore = await Keeper.GetMore(page);
                    if (_IsMore)
                    {
                        dgItems.DataSource = null;
                        dgItems.DataSource = Keeper.Items;
                        dgItems.Refresh();
                        dgItems.FirstDisplayedScrollingRowIndex = x;
                        looper.Hide();
                    }
                    else
                    {
                        looper.Hide();
                        frmToast FrmToast = new frmToast(this, "Osiągnięto koniec rekordów");
                        FrmToast.Show(this);
                    }
                    adjustColumnWidths();
                    dgItems.Select();
                }
            }
            
        }

        private void adjustColumnWidths()
        {
            dgItems.Columns[0].Width = 45;
            dgItems.Columns[2].Width = 130;
            dgItems.Columns[4].Width = 600;
            dgItems.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //Filter Filter = new Filter();
            //List<FilterRow> Rows = new List<FilterRow>();
            //for (int i = 0; i < 12; i++)
            //{
            //    Rows.Clear();
            //    for (int x = 0; x < 20; x++)
            //    {
            //        FilterRow Row = new FilterRow
            //        {
            //            ValueMember = x,
            //            DisplayMember = "Wiersz" + x
            //        };
            //        Rows.Add(Row);
            //    }
                
            //    FilterColumn Column = new FilterColumn(Rows, Filter, FilterColumnValueType.Text, "Kolumna" + i);
                
            //}
            //FilterColumn column = new FilterColumn("Length", Filter, FilterColumnValueType.Number);
            //column = new FilterColumn("Height", Filter, FilterColumnValueType.Number);
            //column = new FilterColumn("Depth", Filter, FilterColumnValueType.Number);
            frmFilter FrmFilter = new frmFilter(this, dgItems);
            FrmFilter.Show();
        }
    }
}

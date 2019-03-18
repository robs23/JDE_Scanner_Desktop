using JDE_Scanner_Desktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop
{
    public partial class frmPlacesY : Form
    {
        PlacesKeeper Keeper = new PlacesKeeper();
        frmLooper looper;
        int page;

        public frmPlacesY(frmStarter parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
        }

        private async Task Reload(string query = null)
        {
            looper.Show(this);
            await Keeper.Refresh(query);
            dgItems.DataSource = null;
            dgItems.DataSource = new BindingList<Place>(Keeper.Items);
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
            //frmPlace FrmPlace = new frmPlace(this);
            //FrmPlace.Show();
            string x = Static.Utilities.FilterStringconverter(dgItems.FilterString);
            Reload(x);
        }

        private void View(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(dgItems.Rows[dgItems.CurrentCell.RowIndex].Cells[0].Value);

            Place Place = new Place();
            Place = Keeper.Items.Where(u => u.PlaceId == id).FirstOrDefault();
            frmPlace FrmPlace = new frmPlace(Place, this);
            FrmPlace.Show();
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
                if (lastvisibleRowIndex == RuntimeSettings.PageSize * page)
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
                    dgItems.Select();
                }
            }
        }

        private async void dgItems_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(dgItems.FilterString) == true)
                {
                    Reload();
                }
                else
                {
                    var listfilter = Static.Utilities.FilterStringconverter(dgItems.FilterString);
                    Reload(listfilter);

                }
            }
            catch (Exception ex)
            {
                //Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}

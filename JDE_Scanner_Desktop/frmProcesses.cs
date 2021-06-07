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
    public partial class frmProcesses : Form
    {
        ProcessesKeeper Keeper = new ProcessesKeeper();
        frmLooper looper;
        frmFilter FrmFilter;
        int page;
        BindingSource source = new BindingSource();
        int? TypeId = null;
        string QueryParameters = null;

        public frmProcesses(Form parent, int? typeId = null, string queryParameters = null)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            TypeId = typeId;
            if (queryParameters != null)
                QueryParameters = queryParameters;
        
            if(typeId != null)
            {
                if(typeId == 2)
                {
                    //Maintenance only
                    Keeper.PageSize = 100;
                    this.Text = "Konserwacje";
                }else if(typeId == 24)
                {
                    //Operators only
                    Keeper.PageSize = 100;
                    this.Text = "Smarowanie";
                }
            }
        }

        private async void Reload()
        {
            looper.Show(this);
            if(TypeId != null)
            {
                string connector = QueryParameters == null ? "" : " AND ";
                
                await Keeper.Refresh($"ActionTypeId={TypeId}{connector}{QueryParameters}" , 'p', "GivenTime=true&FinishRate=true&HandlingsLength=true");
            }
            else
            {
                await Keeper.Refresh(query: QueryParameters, parameters: "HandlingsLength=true");
            }
            
            source.DataSource = Keeper.Items;
            dgItems.DataSource = source;
            source.ResetBindings(false);
            if (TypeId != null)
            {
                if(TypeId ==2 || TypeId == 24)
                {
                    List<string> Columns = new List<string>() { "ProcessId", "Comment", "Status", "PlannedStart", "PlannedFinish", "PlaceId", "PlaceName", "AssignedUserNames", "StartedOn", "StartedByName", "FinishedOn", "FinishedByName", "Length", "GivenTime", "TimingStatus", "FinishRate", "TimingVsPlan", "HandlingsLength", "ProcessLength" };
                    AdjustColumnVisibility(Columns);
                }
                else
                {
                    List<string> Columns = new List<string>() { "PlannedStart", "PlannedFinish", "Comment", "GivenTime", "TimingStatus", "FinishRate", "TimingVsPlan" };
                    AdjustColumnVisibility(null, Columns);
                }
                
            }
            else
            {
                List<string> Columns = new List<string>() { "PlannedStart", "PlannedFinish","Comment", "GivenTime", "TimingStatus", "FinishRate", "TimingVsPlan"};
                AdjustColumnVisibility(null,Columns);
            }
            looper.Hide();
            page = 1;
            adjustColumnWidths();
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
            frmProcess FrmProcess = new frmProcess(this);
            FrmProcess.Show();
        }

        private void View(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(dgItems.Rows[dgItems.CurrentCell.RowIndex].Cells[0].Value);

            Process Process = new Process();
            Process = Keeper.Items.Where(u => u.ProcessId == id).FirstOrDefault();
            frmProcess FrmProcess = new frmProcess(Process, this);
            FrmProcess.Show();
            if (FrmProcess.ForceRefresh)
            {
                Reload();
            }
        }

        private void adjustColumnWidths()
        {
            dgItems.Columns[0].Width = 45;
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
                looper.Show(this);
                List<int> SelectedRows = new List<int>();
                for (int i = 0; i < dgItems.SelectedRows.Count; i++)
                {
                    SelectedRows.Add((int)dgItems.SelectedRows[i].Cells[0].Value);
                }
                await Keeper.Remove(SelectedRows);
                looper.Hide();
                Reload();
            }
        }

        private void dgItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(this, "Wystąpił problem z dostępem do danych. Szczegóły: " + e.Exception.Message, "Error");
            e.ThrowException = false;
            e.Cancel = false;
        }

        private void AdjustColumnVisibility(List<string> ToShow = null, List<string> ToHide = null)
        {

                foreach(DataGridViewColumn c in dgItems.Columns)
                {
                    if (ToShow != null)
                    {
                        if (!ToShow.Contains(c.Name))
                        {
                            c.Visible = false;
                        }
                        else
                        {
                            c.Visible = true;
                        }
                    }
                if (ToHide != null)
                {
                    if (ToHide.Contains(c.Name))
                    {
                        c.Visible = false;
                    }
                }
            }
        }

        private async void dgItems_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue < e.NewValue)
            {
                int PageSize = RuntimeSettings.PageSize;
                if (Keeper.PageSize != null)
                {
                    PageSize = (int)Keeper.PageSize;
                }
                var visibleRowsCount = dgItems.DisplayedRowCount(true);
                var firstDisplayedRowIndex = dgItems.FirstDisplayedScrollingRowIndex;
                var lastvisibleRowIndex = (firstDisplayedRowIndex + visibleRowsCount);
                if (lastvisibleRowIndex >= PageSize * page)
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
                    adjustColumnWidths();
                    dgItems.Select();
                }
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (dgItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Żaden wiersz nie jest zaznaczony. Aby zamknąć wybrane zgłoszenia, najpierw zaznacz je kliknięciem po ich lewej stronie.");
            }
            else
            {
                List<int> SelectedRows = new List<int>();
                for (int i = 0; i < dgItems.SelectedRows.Count; i++)
                {
                    SelectedRows.Add((int)dgItems.SelectedRows[i].Cells[0].Value);
                }
                Keeper.Finish(SelectedRows);
                Reload();
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

        private async void btnReassign_Click(object sender, EventArgs e)
        {
            if (dgItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Żaden wiersz nie jest zaznaczony. Aby zmienić przpisanych obsługujących do wybranych wierszy, najpierw zaznacz je kliknięciem po ich lewej stronie.");
            }
            else
            {
                
                List<int> SelectedRows = new List<int>();
                for (int i = 0; i < dgItems.SelectedRows.Count; i++)
                {
                    SelectedRows.Add((int)dgItems.SelectedRows[i].Cells[0].Value);
                }
                AssignedUsersHandler assignedUsersHandler = new AssignedUsersHandler(this);
                await assignedUsersHandler.LoadUsers();
                assignedUsersHandler.ShowDialog();
                looper.Show(this);
                await Keeper.ReassignUsers(SelectedRows,assignedUsersHandler.AssignedUsers);
                looper.Hide();
            }
            
        }

        private async void btnComment_Click(object sender, EventArgs e)
        {
            if (dgItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Żaden wiersz nie jest zaznaczony. Aby dodać komentarz do wybranych wierszy, najpierw zaznacz je kliknięciem po ich lewej stronie.");
            }
            else
            {

                List<int> SelectedRows = new List<int>();
                for (int i = 0; i < dgItems.SelectedRows.Count; i++)
                {
                    SelectedRows.Add((int)dgItems.SelectedRows[i].Cells[0].Value);
                }
                using(frmInputBox InputBox = new frmInputBox(this, "Wpisz treść komentarza poniżej", "Komentarz", ""))
                {
                    DialogResult res = InputBox.ShowDialog(this);
                    if (res == DialogResult.OK)
                    {
                        looper.Show(this);
                        await Keeper.AddComment(SelectedRows, InputBox.Response);
                        looper.Hide();
                        Reload();
                        
                    }
                }
                
            }
        }
    }
}

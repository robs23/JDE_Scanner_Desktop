using JDE_Scanner_Desktop.Models;
using JDE_Scanner_Desktop.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.CustomControls
{
    public partial class PartFinder : UserControl
    {
        PartKeeper Keeper = new PartKeeper();
        List<Part> CurrentSelection = new List<Part>();
        public Part ChosenPart { get; set; }
        public DataGridView DGV { get; set; }

        public bool IsInitialized { get; set; } = false;
        public bool IsShown { get; set; } = false; 

        public PartFinder(Control parent)
        {
            InitializeComponent();
            this.Parent = parent;
            this.CausesValidation = false;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            DGV = (DataGridView)parent;
            this.Visible = false;
        }

        public async Task Init()
        {
            await Keeper.Refresh(type: 't');
            CurrentSelection = Keeper.Items;
            IsInitialized = true;
        }

        public async Task Find(string word)
        {
            if (IsInitialized)
            {
                CurrentSelection = Keeper.Items.Where(i => i.PartId.ToString().Contains(word)
                                                         || i.Name.ToLower().Contains(word.ToLower())).ToList();
            }
            //dgvItems.DataSource = CurrentSelection;
        }

        public void AdjustColumns(List<string> columns = null)
        {
            if (columns != null)
            {
                if (columns.Any())
                {
                    dgvItems.AdjustColumnVisibility(columns);
                } 
            }
            dgvItems.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

        }

        public async Task Show(Point position)
        {
            if (!IsShown)
            {
                Point pnt = this.PointToClient(position);
                this.Left = pnt.X;
                this.Top = pnt.Y;
                this.Visible = true;
                this.BringToFront();
                IsShown = true;
            }
            dgvItems.DataSource = CurrentSelection;
        }

        public bool Hide()
        {
            bool res = false;

            if (this.IsShown)
            {
                this.Visible = false;
                this.IsShown = false;
                res = true;
            }
            return res;

        }

        public void TabPressed()
        {
            ReturnPart();

        }

        public void ReturnPart()
        {
            int recordsCount = dgvItems.Rows.Count;
            if (recordsCount ==1)
            {
                ChosenPart = CurrentSelection.FirstOrDefault();
                DGV.CurrentCell.Value = ChosenPart.PartId;

            }
            else if (recordsCount > 1)
            {
                if (dgvItems.SelectedRows.Count == 1)
                {
                    //single row is selected, let's choose it
                    int id = (int)dgvItems.SelectedRows[0].Cells[0].Value;
                    if (id > 0)
                    {
                        ChosenPart = Keeper.Items.Where(i => i.PartId == id).FirstOrDefault();
                        DGV.CurrentCell.Value = ChosenPart.PartId;
                    }
                }
            }
            Hide();
        }

        public bool GetFocus()
        {
            if (dgvItems.Rows.Count >0)
            {
                this.Focus();
                return true;
            }
            Hide();
            return false;
        }

        private void dgvItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Escape)
            {
                LeaveFocus();
                Hide();
            }else if(e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Enter)
            {
                ReturnPart();
            }
        }

        private void LeaveFocus()
        {
            DGV.BeginEdit(false);
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReturnPart();
        }
    }
}

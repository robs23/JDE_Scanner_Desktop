using JDE_Scanner_Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public async Task Hide()
        {
            this.Visible = false;
            this.IsShown = false;
        }

        public void TabPressed()
        {
            if (dgvItems.Rows.Count == 1)
            {
                ChosenPart = CurrentSelection.FirstOrDefault();
                DGV.CurrentCell.Value = ChosenPart.PartId;  
            }
            Hide();

        }
    }
}

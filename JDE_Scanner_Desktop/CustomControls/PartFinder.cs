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

        public bool IsInitialized { get; set; } = false;
        public bool IsShown { get; set; } = false; 

        public PartFinder()
        {
            InitializeComponent();
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
                this.Left = position.X;
                this.Top = position.Y;
                this.Visible = true;
                this.BringToFront();
                IsShown = true;
            }
            dgvItems.DataSource = CurrentSelection;
        }
    }
}

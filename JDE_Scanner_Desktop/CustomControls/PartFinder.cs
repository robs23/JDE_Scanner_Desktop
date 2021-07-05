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

        public PartFinder()
        {
            InitializeComponent();
        }

        public async Task Init()
        {
            await Keeper.Refresh();
            CurrentSelection = Keeper.Items;
            dgvItems.DataSource = CurrentSelection;
            IsInitialized = true;
        }

        public async Task Find(string word)
        {
            if (IsInitialized)
            {
                CurrentSelection = Keeper.Items.Where(i => i.PartId.ToString().Contains(word)
                                                         || i.Name.Contains(word)
                                                         || i.Symbol.Contains(word)).ToList();
            }
            //dgvItems.DataSource = CurrentSelection;
        }
    }
}

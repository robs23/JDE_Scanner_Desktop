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

namespace JDE_Scanner_Desktop
{
    public partial class frmResourceFinder : Form
    {
        public AreasKeeper Areas { get; set; }
        public SetsKeeper Sets { get; set; }
        public PlacesKeeper Places { get; set; }

        public frmResourceFinder(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
        }

        private async void frmResourceFinder_Load(object sender, EventArgs e)
        {
            Areas = new AreasKeeper();
            await Areas.Refresh();
            cmbArea.DataSource = Areas.Items;
            cmbArea.ValueMember = "AreaId";
            cmbArea.DisplayMember = "Name";
            Sets = new SetsKeeper();
            await Sets.Refresh();
            Places = new PlacesKeeper();
            await Places.Refresh();

        }

        private async void ReloadSet()
        {
            int areaId = Convert.ToInt32(cmbArea.SelectedIndex);
            List<Place> sPlaces = Places.Items.Where(i => i.AreaId == areaId).ToList();
            List<Set> sSets = new List<Set>();

            foreach(Place p in sPlaces)
            {
                sSets.Add(Sets.Items.Where(i => i.SetId == p.SetId).FirstOrDefault());
            }
            cmbSet.DataSource = Sets.Items;
            cmbSet.ValueMember = "SetId";
            cmbSet.DisplayMember = "Name";
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadSet();
        }
    }
}

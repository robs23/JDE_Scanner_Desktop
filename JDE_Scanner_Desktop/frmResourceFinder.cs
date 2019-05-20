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
        public int? PlaceId { get
            {
                if (cmbPlace.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return (int)cmbPlace.SelectedValue;
                }
            } }

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
            await Places.Refresh(null,'a');

        }

        private async void ReloadSet()
        {
            if (cmbArea.Focused)
            {
                if (cmbArea.SelectedValue.GetType().Name == "Int32" && Places!=null)
                {
                    int areaId = (int)cmbArea.SelectedValue;
                    if (areaId > 0)
                    {
                        List<Place> sPlaces = new List<Place>();
                        try
                        {
                            sPlaces = Places.Items.Where(i => i.AreaId == areaId).ToList();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        
                        List<Set> sSets = new List<Set>();

                        foreach (Place p in sPlaces)
                        {
                            if (!sSets.Where(s => s.SetId == p.SetId).Any())
                            {
                                sSets.Add(Sets.Items.Where(i => i.SetId == p.SetId).FirstOrDefault());
                            }
                        }
                        cmbSet.DataSource = sSets;
                        cmbSet.ValueMember = "SetId";
                        cmbSet.DisplayMember = "Name";
                    }
                    else
                    {
                        cmbSet.DataSource = null;
                    }
                    cmbSet.Focus();
                    ReloadPlace();
                }
            }
        }

        private async void ReloadPlace()
        {
            if (cmbSet.Focused)
            {
                int setId = (int)cmbSet.SelectedValue;
                if (setId > 0)
                {
                    List<Place> sPlaces = Places.Items.Where(i => i.SetId == setId).ToList();

                    cmbPlace.DataSource = sPlaces;
                    cmbPlace.ValueMember = "PlaceId";
                    cmbPlace.DisplayMember = "Name";
                }
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadSet();
        }

        private void cmbSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadPlace();
        }

        private void frmResourceFinder_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

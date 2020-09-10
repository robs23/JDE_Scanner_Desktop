using JDE_Scanner_Desktop.Classes;
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
using Component = JDE_Scanner_Desktop.Models.Component;

namespace JDE_Scanner_Desktop
{
    public partial class frmAddComponents : Form
    {
        int mode;
        frmLooper Looper;
        PlacesKeeper places;
        public int? PlaceId { get; set; }
        public frmAddComponents(Form parent, int? placeId = null)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            this.Text = "Masowe dodawanie komponentów";
            this.PlaceId = placeId;
        }

        private void btnSearchPlace_Click(object sender, EventArgs e)
        {
            using (frmResourceFinder ResourceFinder = new frmResourceFinder(this))
            {
                var res = ResourceFinder.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    int? placeId = ResourceFinder.PlaceId;
                    if (placeId != null)
                    {
                        cmbPlace.SetSelectedValue<Place>(placeId);
                    }
                }
            }
        }

        private async Task SetComboboxes()
        {
            await places.Refresh(null, 'a');
            new AutoCompleteBehavior<Place>(this.cmbPlace, places.Items);
            cmbPlace.DisplayMember = "Name";
            cmbPlace.ValueMember = "PlaceId";
            if (this.PlaceId != null)
            {
                //placd reference is given
                cmbPlace.SetSelectedValue<Place>(this.PlaceId);
            }

        }

        private async void frmAddComponents_Load(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            Looper.Show(this);
            places = new PlacesKeeper();
            await SetComboboxes();
            Looper.Hide();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            PlaceId = cmbPlace.GetSelectedValue<Place>();
            if(PlaceId==null || PlaceId == 0)
            {
                MessageBox.Show("Z listy rozwijanej wybierz zasób, dla którego chcesz utworzyć komponenty.", "Nie wybrano zasobu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string[] components;
                components = txtComponents.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                List<Task<bool>> tasks = new List<Task<bool>>();
                if(components.Length > 0)
                {
                    foreach (string s in components)
                    {
                        Component c = new Component();
                        c.CreatedBy = RuntimeSettings.UserId;
                        c.CreatedOn = DateTime.Now;
                        c.PlaceId = PlaceId;
                        c.Name = s;
                        tasks.Add(c.Add());
                    }

                    string response = "";
                    IEnumerable<bool> res = await Task.WhenAll<bool>(tasks);
                    if (res.Where(r => r == false).Any())
                    {
                        MessageBox.Show($"Nie udało się dodać {res.Count(r => r == false)} komponentów. Dodano {res.Count(r => r)} komponentów.", "Niepełne powodzenie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Dodawanie {res.Count(r => r)} komponentów zakończone powodzeniem.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("W polu tekstowym wpisz nazwy komponentów dla tego zasobu. Jeden komponent w jednej linii!", "Nie podano komponentów", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            
        }
    }
}

using JDE_Scanner_Desktop.Classes;
using JDE_Scanner_Desktop.Models;
using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Menu;
using Component = JDE_Scanner_Desktop.Models.Component;

namespace JDE_Scanner_Desktop
{
    public partial class frmComponent : Form
    {
        int mode; //1-add, 2-edit, 3-view
        Component _this;
        frmLooper Looper;
        PlacesKeeper Places;
        ContextMenu buttonContextMenu;

        public frmComponent(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            lblCreated.Visible = false;
            cboxArchived.CheckState = CheckState.Indeterminate;
            this.Text = "Nowy komponent";
            _this = new Component();
        }

        public frmComponent(Component Item, Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły komponentu";
            _this = Item;
            txtName.Text = _this.Name;
            txtDescription.Text = _this.Description;
            cboxArchived.CheckState  = _this.IsArchived.ToCheckboxState();
            if(_this.CreatedOn != null && _this.CreatedBy != 0)
            {
                lblCreated.Text = "Utworzone w dniu " + _this.CreatedOn + " przez " + _this.CreatedByName;
                lblCreated.Visible = true;
            }
        }

        private async Task SetComboboxes()
        {
            await Places.Refresh();

            new AutoCompleteBehavior<Place>(cmbPlace, Places.Items);
            cmbPlace.DisplayMember = "Name";
            cmbPlace.ValueMember = "PlaceId";
            new AutoCompleteBehavior<Place>(cmbPlace, Places.Items);
            if (mode != 1)
            {
                cmbPlace.SelectedIndex = cmbPlace.FindStringExact(_this.PlaceName);
            }
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            Looper.Show(this);
            Places = new PlacesKeeper();
            SetComboboxes();
            Looper.Hide();
        }
        

        private async void Save(object sender, EventArgs e)
        {
            _this.Name = txtName.Text;
            _this.Description = txtDescription.Text;
            _this.PlaceId = cmbPlace.GetSelectedValue<Place>();

            try
            {
                Looper.Show(this);
                if (mode == 1)
                {
                    _this.CreatedBy = RuntimeSettings.UserId;
                    _this.CreatedOn = DateTime.Now;
                    
                    if(await _this.Add())
                    {
                        mode = 2;
                        this.Text = "Szczegóły komponentu";
                    }
                    
                }
                else if (mode == 2)
                {
                    _this.Edit();
                }
            }catch(Exception ex)
            {

            }
            finally
            {
                Looper.Hide();
            }
                
        }

        private void AddPlace(object sender, EventArgs e)
        {
            frmPlace Item = new frmPlace(this);
            Item.FormClosed += Company_FormClosed;
            Item.Show(this);
        }

        private async void Company_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetComboboxes();
        }

        private void EditPlace(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cmbPlace.GetSelectedValue<Place>());

            Place item = new Place();
            item = Places.Items.Where(u => u.PlaceId == id).FirstOrDefault();
            frmPlace ItemForm = new frmPlace(item, this);
            ItemForm.FormClosed += Company_FormClosed;
            ItemForm.Show();
        }
    }
}

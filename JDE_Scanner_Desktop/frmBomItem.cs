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
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop
{
    public partial class frmBomItem : Form
    {
        int mode; //1-add, 2-edit, 3-view
        Bom _this;
        frmLooper Looper;
        PlacesKeeper places;
        PartKeeper parts;

        public frmBomItem(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            this.Text = "Nowy Bom";
            _this = new Bom();
        }

        public frmBomItem(Bom Item, Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły bomu";
            _this = Item;

        }

        private async void SetComboboxes()
        {
            await places.Refresh();
            await parts.Refresh();
            cmbPlace.DataSource = places.Items;
            cmbPlace.DisplayMember = "Name";
            cmbPlace.ValueMember = "PlaceId";
            cmbPart.DataSource = parts.Items;
            cmbPart.DisplayMember = "Name";
            cmbPart.ValueMember = "PartId";
            if (mode != 1)
            {
                cmbPlace.SelectedIndex = cmbPlace.FindStringExact(_this.PlaceName);
                cmbPart.SelectedIndex = cmbPart.FindStringExact(_this.PartName);
            }
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            Looper.Show(this);
            places = new PlacesKeeper();
            parts = new PartKeeper();
            SetComboboxes();
            Looper.Hide();
        }

        private async void Save(object sender, EventArgs e)
        {
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
                        this.Text = "Szczegóły pozycji w Bomie";
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
    }
}

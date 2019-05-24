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
        public int? PlaceId { get; set; }
        public int? PartId { get; set; }
        UnitKeeper Units;

        public frmBomItem(Form parent, int? partId=null, int? placeId=null)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            this.Text = "Nowy Bom";
            this.PlaceId = placeId;
            this.PartId = partId;
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

        private async Task SetComboboxes()
        {
            await places.Refresh(null,'a');
            await parts.Refresh();
            cmbPlace.DataSource = places.Items;
            cmbPlace.DisplayMember = "Name";
            cmbPlace.ValueMember = "PlaceId";
           //cmbPart.DataSource = parts.Items;
            //cmbPart1.DataSource = parts.Items;
            new AutoCompleteBehavior<Part>(this.cmbPart, parts.Items);
            //cmbPart1.DisplayMember = "Name";
            //cmbPart1.ValueMember = "PartId";
            cmbPart.DisplayMember = "Name";
            cmbPart.ValueMember = "PartId";
            cmbPlace.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbPlace.AutoCompleteSource = AutoCompleteSource.ListItems;
            if(this.PartId != null)
            {
                //part reference is given
                //cmbPart.SelectedValue = this.PartId;
                cmbPart.SetSelectedValue<Part>(this.PartId);
            }
            if(this.PlaceId != null)
            {
                //placd reference is given
                cmbPlace.SelectedValue = this.PlaceId;
            }
            Units = new UnitKeeper();
            cmbUnit.DataSource = Units.Items;
            cmbUnit.ValueMember = "ShortName";
            cmbUnit.DisplayMember = "FullName";

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
            await SetComboboxes();
            txtDFrom.CustomFormat = " ";
            txtDTo.CustomFormat = " ";
            if (mode == 1)
            {
                txtDFrom.Value = DateTime.Today;
            }
            txtAmount.Text = _this.Amount.ToString();
            if(_this.ValidFrom != null)
            {
                txtDFrom.Value = _this.ValidFrom.Value;
            }
            if (_this.ValidTo != null)
            {
                txtDTo.Value = _this.ValidTo.Value;
            }
            Looper.Hide();
        }

        private async void Save(object sender, EventArgs e)
        {
            try
            {
                Looper.Show(this);
                _this.PartId =cmbPart.GetSelectedValue<Part>();
                _this.PlaceId = (int)cmbPlace.SelectedValue;
                _this.Unit = cmbUnit.SelectedValue.ToString();
                _this.ValidFrom = txtDFrom.Value;
                if(txtDTo.Text == " ")
                {
                    _this.ValidTo = null;
                }
                else
                {
                    _this.ValidTo = txtDTo.Value;
                }
                float amount;
                bool convertable = float.TryParse(txtAmount.Text, out amount);
                if (convertable)
                {
                    _this.Amount = amount;
                    if (mode == 1)
                    {
                        _this.CreatedBy = RuntimeSettings.UserId;
                        _this.CreatedOn = DateTime.Now;
                        if (await _this.Add())
                        {
                            mode = 2;
                            this.Text = "Szczegóły pozycji w Bomie";
                        }

                    }
                    else if (mode == 2)
                    {
                        _this.Edit();
                    }
                }
                else
                {
                    MessageBox.Show("Wartość w polu Ilość musi być liczbą!");
                }
                
            }catch(Exception ex)
            {

            }
            finally
            {
                Looper.Hide();
            }
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
                        cmbPlace.SelectedValue = placeId;
                    }
                }
            }
            
        }

        private void txtDFrom_ValueChanged(object sender, EventArgs e)
        {
            txtDFrom.CustomFormat = "yyyy-MM-dd";
            txtDFrom.Format = DateTimePickerFormat.Custom;
        }

        private void txtDTo_ValueChanged(object sender, EventArgs e)
        {
            txtDTo.CustomFormat = "yyyy-MM-dd";
            txtDTo.Format = DateTimePickerFormat.Custom;
        }
    }
}

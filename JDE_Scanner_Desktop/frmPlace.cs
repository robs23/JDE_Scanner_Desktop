using JDE_Scanner_Desktop.Models;
using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop
{
    public partial class frmPlace : Form
    {
        int mode; //1-add, 2-edit, 3-view
        Place _this;
        AreasKeeper Areas = new AreasKeeper();
        SetsKeeper Sets = new SetsKeeper();
        frmLooper Looper;

        public frmPlace(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            lblCreated.Visible = false;
            this.Text = "Nowy zasób";
            _this = new Place();
        }

        public frmPlace(Place Place, Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły zasobu";
            _this = Place;
            txtNumber1.Text = _this.Number1;
            txtNumber2.Text = _this.Number2;
            txtDescription.Text = _this.Description;
            txtName.Text = _this.Name;
            txtPriority.Text = _this.Priority;
            if(_this.CreatedOn != null && _this.CreatedBy != 0)
            {
                lblCreated.Text = "Utworzone w dniu " + _this.CreatedOn + " przez " + _this.CreatedByName;
                lblCreated.Visible = true;
            }
            if(_this.PlaceToken != null)
            {
                GenerateQrCode(_this.PlaceToken);
            }
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            Looper.Show(this);
            await Sets.Refresh();
            await Areas.Refresh();
            Looper.Hide();
            cmbArea.DataSource = Areas.Items;
            cmbSet.DataSource = Sets.Items;
            cmbArea.DisplayMember = "Name";
            cmbArea.ValueMember = "AreaId";
            cmbSet.DisplayMember = "Name";
            cmbSet.ValueMember = "SetId";
            cmbArea.SelectedIndex = cmbArea.FindStringExact(_this.AreaName);
            cmbSet.SelectedIndex = cmbSet.FindStringExact(_this.SetName);
        }

        private async void Save(object sender, EventArgs e)
        {
            _this.Name = txtName.Text;
            _this.Number1 = txtNumber1.Text;
            _this.Number2 = txtNumber2.Text;
            _this.Description = txtDescription.Text;
            _this.Priority = txtPriority.Text;
            if (cmbArea.SelectedItem != null)
            {
                _this.AreaId = Convert.ToInt32(cmbArea.SelectedValue.ToString());
            }
            if(cmbSet.SelectedItem != null)
            {
                _this.SetId = Convert.ToInt32(cmbSet.SelectedValue.ToString());
            }

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
                        this.Text = "Szczegóły zasobu";
                        GenerateQrCode(_this.PlaceToken);
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

        private void BringCombos()
        {

        }

        private void GenerateQrCode(string qrStr)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrStr, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrImage = qrCode.GetGraphic(5);
            pbQrCode.Image = qrImage;
        }
    }
}

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
            await Sets.Refresh();
            await Areas.Refresh();
            cmbArea.DataSource = Areas.Items;
            cmbSet.DataSource = Sets.Items;
            cmbArea.DisplayMember = "Name";
            cmbArea.ValueMember = "AreaId";
            cmbSet.DisplayMember = "Name";
            cmbSet.ValueMember = "SetId";
            cmbArea.SelectedIndex = cmbArea.FindStringExact(_this.AreaName);
            cmbSet.SelectedIndex = cmbSet.FindStringExact(_this.SetName);
        }

        private void Save(object sender, EventArgs e)
        {
            _this.Name = txtName.Text;
            _this.Number1 = txtNumber1.Text;
            _this.Number2 = txtNumber2.Text;
            if (cmbArea.SelectedItem != null)
            {
                _this.AreaId = Convert.ToInt32(cmbArea.SelectedValue.ToString());
            }
            if(cmbSet.SelectedItem != null)
            {
                _this.SetId = Convert.ToInt32(cmbSet.SelectedValue.ToString());
            }
            _this.PlaceToken = Utilities.uniqueToken();
            if (_this.IsValid)
            {
                if (mode == 1)
                {
                    _this.CreatedBy = 1;
                    _this.CreatedOn = DateTime.Now;

                    Add();
                }
                else if (mode == 2)
                {

                    Edit();
                }
            }
            else
            {
                MessageBox.Show("Pola Obszar i Instalacja są wymagane!");
            }
        }

        private void BringCombos()
        {

        }

        private async void Add()
        {
            using (var client = new HttpClient())
            {
                string url = "http://jde_api.robs23.webserwer.pl/CreatePlace?token=" + RuntimeSettings.TenantToken;
                var serializedProduct = JsonConvert.SerializeObject(_this);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(new Uri(url), content);
                //if (result.IsSuccessStatusCode)
                //{
                    MessageBox.Show("Tworzenie zasobu zakończone powodzeniem!");
                //}
                //else
                //{
                //    MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia użytkownika. Wiadomość: " + result.ReasonPhrase);
                //}
            }
        }

        private async void Edit()
        {
            using (var client = new HttpClient())
            {
                string url = "http://jde_api.robs23.webserwer.pl/EditPlace?token=" + RuntimeSettings.TenantToken + "&id=";
                var serializedProduct = JsonConvert.SerializeObject(_this);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(String.Format("{0}{1}", new Uri(url), _this.PlaceId), content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Edycja zasobu zakończona powodzeniem!");
                }
                else
                {
                    MessageBox.Show("Serwer zwrócił błąd przy próbie edycji użytkownika. Wiadomość: " + result.ReasonPhrase);
                }
            }
            
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

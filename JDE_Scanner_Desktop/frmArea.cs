using JDE_Scanner_Desktop.Models;
using Newtonsoft.Json;
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
    public partial class frmArea : Form
    {
        int mode; //1-add, 2-edit, 3-view
        Area _this;

        public frmArea(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            lblCreated.Visible = false;
            this.Text = "Nowy obszar";
            _this = new Area();
        }

        public frmArea(Area Item, Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły obszaru";
            _this = Item;
            txtName.Text = _this.Name;
            txtDescription.Text = _this.Description;
            if(_this.CreatedOn != null && _this.CreatedBy != 0)
            {
                lblCreated.Text = "Utworzone w dniu " + _this.CreatedOn + " przez " + _this.CreatedByName;
                lblCreated.Visible = true;
            }
        }

        private void FormLoaded(object sender, EventArgs e)
        {

        }

        private void Save(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                _this.CreatedBy = 1;
                _this.CreatedOn = DateTime.Now;
                _this.Name = txtName.Text;
                _this.Description = txtDescription.Text;
 
                Add();
            }else if(mode == 2)
            {
                _this.Name = txtName.Text;
                _this.Description = txtDescription.Text;

                Edit();
            }
        }

        private async void Add()
        {
            using (var client = new HttpClient())
            {
                string url = "http://jde_api.robs23.webserwer.pl/CreateArea?token=" + RuntimeSettings.TenantToken;
                var serializedProduct = JsonConvert.SerializeObject(_this);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(new Uri(url), content);
                //if (result.IsSuccessStatusCode)
                //{
                    MessageBox.Show("Tworzenie obszaru zakończone powodzeniem!");
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
                string url = "http://jde_api.robs23.webserwer.pl/EditArea?token=" + RuntimeSettings.TenantToken + "&id=";
                var serializedProduct = JsonConvert.SerializeObject(_this);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(String.Format("{0}{1}", new Uri(url), _this.AreaId), content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Edycja obszaru zakończona powodzeniem!");
                }
                else
                {
                    MessageBox.Show("Serwer zwrócił błąd przy próbie edycji obszaru. Wiadomość: " + result.ReasonPhrase);
                }
            }
            
        }
    }
}

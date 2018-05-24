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
    public partial class frmUser : Form
    {
        int mode; //1-add, 2-edit, 3-view
        User ThisUser;

        public frmUser(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            lblCreated.Visible = false;
            this.Text = "Nowy użytkownik";
            ThisUser = new User();
        }

        public frmUser(User User, Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły użytkownika";
            ThisUser = User;
            txtName.Text = ThisUser.Name;
            txtSurname.Text = ThisUser.Surname;
            txtPassword.Text = ThisUser.Password;
            if (ThisUser.IsMechanic)
            {
                cmbMechanic.SelectedIndex = cmbMechanic.FindStringExact("Tak");
            }
            else
            {
                cmbMechanic.SelectedIndex = cmbMechanic.FindStringExact("Nie");
            }
            if(ThisUser.CreatedOn != null && ThisUser.CreatedBy != 0)
            {
                lblCreated.Text = "Utworzone w dniu " + ThisUser.CreatedOn + " przez " + ThisUser.CreatedByName;
                lblCreated.Visible = true;
            }
        }

        private void FormLoaded(object sender, EventArgs e)
        {

        }

        private void SaveUser(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                ThisUser.CreatedBy = 1;
                ThisUser.CreatedOn = DateTime.Now;
                ThisUser.Name = txtName.Text;
                ThisUser.Surname = txtSurname.Text;
                ThisUser.Password = txtPassword.Text;
                
                if (cmbMechanic.GetItemText(cmbMechanic.SelectedItem) == "Tak")
                {
                    ThisUser.IsMechanic = true;
                }
                else
                {
                    ThisUser.IsMechanic = false;
                }
                AddUser();
            }else if(mode == 2)
            {
                ThisUser.Name = txtName.Text;
                ThisUser.Surname = txtSurname.Text;
                ThisUser.Password = txtPassword.Text;

                if (cmbMechanic.GetItemText(cmbMechanic.SelectedItem) == "Tak")
                {
                    ThisUser.IsMechanic = true;
                }
                else
                {
                    ThisUser.IsMechanic = false;
                }
                EditUser();
            }
        }

        private async void AddUser()
        {
            using (var client = new HttpClient())
            {
                string url = "http://jde_api.robs23.webserwer.pl/CreateUser?token=" + RuntimeSettings.TenantToken;
                var serializedProduct = JsonConvert.SerializeObject(ThisUser);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(new Uri(url), content);
                //if (result.IsSuccessStatusCode)
                //{
                    MessageBox.Show("Tworzenie użytkownika zakończone powodzeniem!");
                //}
                //else
                //{
                //    MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia użytkownika. Wiadomość: " + result.ReasonPhrase);
                //}
            }
        }

        private async void EditUser()
        {
            using (var client = new HttpClient())
            {
                string url = "http://jde_api.robs23.webserwer.pl/EditUser?token=" + RuntimeSettings.TenantToken + "&id=";
                var serializedProduct = JsonConvert.SerializeObject(ThisUser);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(String.Format("{0}{1}", new Uri(url),ThisUser.UserId), content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Edycja użytkownika zakończona powodzeniem!");
                }
                else
                {
                    MessageBox.Show("Serwer zwrócił błąd przy próbie edycji użytkownika. Wiadomość: " + result.ReasonPhrase);
                }
            }
            
        }
    }
}

using JDE_Scanner_Desktop.Models;
using JDE_Scanner_Desktop.Static;
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
        frmLooper Looper;

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
            txtMesLogin.Text = ThisUser.MesLogin;
            txtToken.Text = $"[UID={User.UserId};PASS={User.Password}]";
            cboxArchived.CheckState = ThisUser.IsArchived.ToCheckboxState();
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
            Looper = new frmLooper(this);
        }

        private async void SaveUser(object sender, EventArgs e)
        {
            try
            {
                Looper.Show(this);
                if (mode == 1)
                {
                    ThisUser.CreatedBy = RuntimeSettings.UserId;
                    ThisUser.CreatedOn = DateTime.Now;
                    ThisUser.Name = txtName.Text;
                    ThisUser.Surname = txtSurname.Text;
                    ThisUser.Password = txtPassword.Text;
                    ThisUser.MesLogin = txtMesLogin.Text;
                    ThisUser.IsArchived = cboxArchived.CheckState.CheckboxStateToNullableBool();
                    if (cmbMechanic.GetItemText(cmbMechanic.SelectedItem) == "Tak")
                    {
                        ThisUser.IsMechanic = true;
                    }
                    else
                    {
                        ThisUser.IsMechanic = false;
                    }
                    if (await ThisUser.Add())
                    {
                        mode = 2;
                        txtToken.Text = $"[UID={ThisUser.UserId};PASS={ThisUser.Password}]";
                        this.Text = "Szczegóły użytkownika";
                    }
                }
                else if (mode == 2)
                {
                    ThisUser.Name = txtName.Text;
                    ThisUser.Surname = txtSurname.Text;
                    ThisUser.Password = txtPassword.Text;
                    ThisUser.MesLogin = txtMesLogin.Text;
                    ThisUser.IsArchived = cboxArchived.CheckState.CheckboxStateToNullableBool();
                    if (cmbMechanic.GetItemText(cmbMechanic.SelectedItem) == "Tak")
                    {
                        ThisUser.IsMechanic = true;
                    }
                    else
                    {
                        ThisUser.IsMechanic = false;
                    }
                    ThisUser.Edit();           
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

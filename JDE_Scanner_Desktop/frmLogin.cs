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
    public partial class frmLogin : Form
    {
        UsersKeeper Keeper = new UsersKeeper();

        public frmLogin(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
        }

        private async void formLoaded(object sender, EventArgs e)
        {
            frmLooper Looper = new frmLooper(this);
            Looper.Show(this);
            await Keeper.Refresh();
            cmbUsers.DataSource = Keeper.Items;
            cmbUsers.DisplayMember = "Surname";
            cmbUsers.ValueMember = "UserId";
            txtPassword.Text = "Hasło";
            txtPassword.ForeColor = Color.Gray;
            Looper.Hide();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Hasło")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Hasło";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0';
            }
        }

        private void Login(object sender, EventArgs e)
        {
            if (txtPassword.ForeColor == Color.Black && cmbUsers.SelectedItem != null)
            {
                int UserId = Convert.ToInt32(cmbUsers.SelectedValue.ToString());
                if(Keeper.Items.Where(u=>u.UserId==UserId && u.Password == txtPassword.Text).Any())
                {
                    //login and password OK
                    RuntimeSettings.UserId = UserId;
                    User _this = Keeper.Items.Where(u => u.UserId == UserId).FirstOrDefault();
                    _this.Login();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Podano błędne hasło!");
                    txtPassword.Text = "Hasło";
                    txtPassword.ForeColor = Color.Gray;
                }

            }
            else
            {
                MessageBox.Show("Nie wybrano użytkownika lub nie podano hasła! Najpierw wybierz użytkownika i podaj hasło.");
            }

        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void tlpMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

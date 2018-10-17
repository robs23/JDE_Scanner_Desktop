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
    public partial class frmActionType : Form
    {
        int mode; //1-add, 2-edit, 3-view
        ActionType _this;
        frmLooper Looper;

        public frmActionType(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            lblCreated.Visible = false;
            this.Text = "Nowy typ zgłoszenia";
            _this = new ActionType();
            cmbMesSync.DataSource = new List<bool> { false, true };
            cmbShowInPlanning.DataSource = new List<bool> { false,true };
        }

        public frmActionType(ActionType Item, Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły typu zgłoszenia";
            _this = Item;
            txtName.Text = _this.Name;
            txtDescription.Text = _this.Description;
            if(_this.CreatedOn != null && _this.CreatedBy != 0)
            {
                lblCreated.Text = "Utworzone w dniu " + _this.CreatedOn + " przez " + _this.CreatedByName;
                lblCreated.Visible = true;
            }
            cmbMesSync.DataSource = new List<bool> { false, true };
            cmbShowInPlanning.DataSource = new List<bool> { false, true };
            cmbMesSync.SelectedIndex = cmbMesSync.FindStringExact(_this.MesSync.ToString());
            cmbShowInPlanning.SelectedIndex = cmbShowInPlanning.FindStringExact(_this.ShowInPlanning.ToString());
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
        }

        private async void Save(object sender, EventArgs e)
        {
            try
            {
                if (mode == 1)
                {
                    _this.CreatedBy = 1;
                    _this.CreatedOn = DateTime.Now;
                    _this.Name = txtName.Text;
                    _this.Description = txtDescription.Text;
                    _this.ShowInPlanning = bool.Parse(cmbShowInPlanning.Text);
                    _this.MesSync = bool.Parse(cmbMesSync.Text);
                    if (await _this.Add())
                    {
                        mode = 2;
                        this.Text = "Szczegóły typu zgłoszenia";
                    }
                }
                else if (mode == 2)
                {
                    _this.Name = txtName.Text;
                    _this.Description = txtDescription.Text;
                    _this.ShowInPlanning = bool.Parse(cmbShowInPlanning.Text);
                    _this.MesSync = bool.Parse(cmbMesSync.Text);
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

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
            
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            cmbMesSync.DataSource = new List<bool> { false, true };
            cmbShowInPlanning.DataSource = new List<bool> { false, true };
            cmbAllowDuplicates.DataSource = new List<bool> { true, false };
            cmbRequireInitialDiagnosis.DataSource = new List<bool> { false, true };
            cmbQrToStart.DataSource = new List<bool> { false, true };
            cmbQrToFinish.DataSource = new List<bool> { false,true };
            cmbClosePrevious.DataSource = new List<bool> { false, true };

            if (mode == 2)
            {
                cmbMesSync.SelectedIndex = cmbMesSync.FindStringExact(_this.MesSync.ToString());
                cmbShowInPlanning.SelectedIndex = cmbShowInPlanning.FindStringExact(_this.ShowInPlanning.ToString());
                cmbRequireInitialDiagnosis.SelectedIndex = cmbRequireInitialDiagnosis.FindStringExact(_this.RequireInitialDiagnosis.ToString());
                cmbAllowDuplicates.SelectedIndex = cmbAllowDuplicates.FindStringExact(_this.AllowDuplicates.ToString());
                cmbQrToStart.SelectedIndex = cmbQrToStart.FindStringExact(_this.RequireQrToStart.ToString());
                cmbQrToFinish.SelectedIndex = cmbQrToFinish.FindStringExact(_this.RequireQrToFinish.ToString());
                cmbClosePrevious.SelectedIndex = cmbClosePrevious.FindStringExact(_this.ClosePreviousInSamePlace.ToString());
            }
            
        }

        private async void Save(object sender, EventArgs e)
        {
            try
            {
                _this.Name = txtName.Text;
                _this.Description = txtDescription.Text;
                if (cmbShowInPlanning.SelectedItem != null)
                {
                    _this.ShowInPlanning = bool.Parse(cmbShowInPlanning.Text);
                }
                if (cmbMesSync.SelectedItem != null)
                {
                    _this.MesSync = bool.Parse(cmbMesSync.Text);
                }
                if (cmbRequireInitialDiagnosis.SelectedItem != null)
                {
                    _this.RequireInitialDiagnosis = bool.Parse(cmbRequireInitialDiagnosis.Text);
                }
                if (cmbAllowDuplicates.SelectedItem != null)
                {
                    _this.AllowDuplicates = bool.Parse(cmbAllowDuplicates.Text);
                }
                if (cmbQrToStart.SelectedItem != null)
                {
                    _this.RequireQrToStart = bool.Parse(cmbQrToStart.Text);
                }
                if (cmbQrToFinish.SelectedItem != null)
                {
                    _this.RequireQrToFinish = bool.Parse(cmbQrToFinish.Text);
                }
                if (cmbClosePrevious.SelectedItem != null)
                {
                    _this.ClosePreviousInSamePlace = bool.Parse(cmbClosePrevious.Text);
                }
                if (mode == 1)
                {
                    _this.CreatedBy = RuntimeSettings.UserId;
                    _this.CreatedOn = DateTime.Now;
                    
                    if (await _this.Add())
                    {
                        mode = 2;
                        this.Text = "Szczegóły typu zgłoszenia";
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

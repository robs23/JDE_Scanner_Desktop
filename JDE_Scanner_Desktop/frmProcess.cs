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
    public partial class frmProcess : Form
    {
        int mode; //1-add, 2-edit, 3-view
        Process _this;
        PlacesKeeper Places = new PlacesKeeper();
        UsersKeeper StartingUsers = new UsersKeeper();
        UsersKeeper FinishingUsers = new UsersKeeper();
        ActionTypesKeeper ActionTypes = new ActionTypesKeeper();
        frmLooper Looper;

        public frmProcess(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            lblCreated.Visible = false;
            this.Text = "Nowe zgłoszenie";
            _this = new Process();
            DatesChange();
        }

        public frmProcess(Process Process, Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły zgłoszenia";
            _this = Process;
            DatesChange();
            txtDescription.Text = _this.Description;
            if(_this.CreatedOn != null && _this.CreatedBy != 0)
            {
                lblCreated.Text = "Utworzone w dniu " + _this.CreatedOn + " przez " + _this.CreatedByName;
                lblCreated.Visible = true;
            }
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            Looper.Show(this);
            await Places.Refresh();
            await StartingUsers.Refresh();
            FinishingUsers.Items = new List<User>(StartingUsers.Items); 
            await ActionTypes.Refresh();
            cmbActionType.DataSource = ActionTypes.Items;
            cmbStartedBy.DataSource = StartingUsers.Items;
            cmbFinishedBy.DataSource = FinishingUsers.Items;
            cmbPlace.DataSource = Places.Items;
            cmbStartedBy.DisplayMember = "FullName";
            cmbStartedBy.ValueMember = "UserId";
            cmbFinishedBy.DisplayMember = "FullName";
            cmbFinishedBy.ValueMember = "UserId";
            cmbActionType.DisplayMember = "Name";
            cmbActionType.ValueMember = "ActionTypeId";
            cmbPlace.DisplayMember = "Name";
            cmbPlace.ValueMember = "PlaceId";
            cmbActionType.SelectedIndex = cmbActionType.FindStringExact(_this.ActionTypeName);
            cmbPlace.SelectedIndex = cmbPlace.FindStringExact(_this.PlaceName);
            cmbStartedBy.SelectedIndex = cmbStartedBy.FindStringExact(_this.StartedByName);
            cmbFinishedBy.SelectedIndex = cmbFinishedBy.FindStringExact(_this.FinishedByName);
            cmbStatus.SelectedIndex = cmbStatus.FindStringExact(_this.Status);
            if (_this.StartedOn != null)
            {
                txtStartedOn.Value = (DateTime)_this.StartedOn;
            }
            if (_this.FinishedOn != null)
            {
                txtFinishedOn.Value = (DateTime)_this.FinishedOn;
            }
            txtDescription.Text = _this.Description;
            txtOutput.Text = _this.Output;
            Looper.Hide();
        }

        private void Save(object sender, EventArgs e)
        {
            _this.Description = txtDescription.Text;
            _this.Output = txtOutput.Text;
            if(txtStartedOn.Text == " ")
            {
                _this.StartedOn = null;
            }
            else
            {
                _this.StartedOn = txtStartedOn.Value;
            }
            if (txtFinishedOn.Text == " ")
            {
                _this.FinishedOn = null;
            }
            else
            {
                _this.FinishedOn = txtFinishedOn.Value;
            }
            if (cmbPlace.SelectedItem != null)
            {
                _this.PlaceId = Convert.ToInt32(cmbPlace.SelectedValue.ToString());
            }
            if(cmbActionType.SelectedItem != null)
            {
                _this.ActionTypeId = Convert.ToInt32(cmbActionType.SelectedValue.ToString());
            }
            if(cmbStatus.SelectedItem != null)
            {
                _this.Status = cmbStatus.SelectedItem.ToString();
            }
            if(cmbStartedBy.SelectedItem != null)
            {
                _this.StartedBy = Convert.ToInt32(cmbStartedBy.SelectedValue.ToString());
            }
            if(cmbFinishedBy.SelectedItem != null)
            {
                _this.FinishedBy = Convert.ToInt32(cmbFinishedBy.SelectedValue.ToString());
            }

            try
            {
                Looper.Show(this);
                if (mode == 1)
                {
                    _this.CreatedBy = RuntimeSettings.UserId;
                    _this.CreatedOn = DateTime.Now;
                    _this.Add();
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

        private void txtStartedOn_ValueChanged(object sender, EventArgs e)
        {
            txtStartedOn.CustomFormat = "yyyy-MM-dd";
            txtStartedOn.Format = DateTimePickerFormat.Custom;
        }

        private void btnStartedOnClear_Click(object sender, EventArgs e)
        {
            txtStartedOn.CustomFormat = " ";
            txtStartedOn.Format = DateTimePickerFormat.Custom;
        }

        private void btnFinishedOnClear_Click(object sender, EventArgs e)
        {
            txtFinishedOn.CustomFormat = " ";
            txtFinishedOn.Format = DateTimePickerFormat.Custom;
        }

        private void txtFinishedOn_ValueChanged(object sender, EventArgs e)
        {
            txtFinishedOn.CustomFormat = "yyyy-MM-dd";
            txtFinishedOn.Format = DateTimePickerFormat.Custom;
        }

        private void DatesChange()
        {
            if (_this.StartedOn == null)
            {
                txtStartedOn.CustomFormat = " ";
                txtStartedOn.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                txtStartedOn.CustomFormat = "yyyy-MM-dd";
                txtStartedOn.Format = DateTimePickerFormat.Custom;
            }
            if (_this.FinishedOn == null)
            {
                txtFinishedOn.CustomFormat = " ";
                txtFinishedOn.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                txtFinishedOn.CustomFormat = "yyyy-MM-dd";
                txtFinishedOn.Format = DateTimePickerFormat.Custom;
            }
        }
    }
}

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
        UsersKeeper AssignableUsers = new UsersKeeper();
        List<User> AssignedUsers = null;
        ActionTypesKeeper ActionTypes = new ActionTypesKeeper();
        ProcessAssignKeeper ProcessAssigns = new ProcessAssignKeeper();
        frmLooper Looper;
        public bool ForceRefresh = false;

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
            cmbStatus.Enabled = false;
            cmbStartedBy.Enabled = false;
            cmbFinishedBy.Enabled = false;
            txtFinishedOn.Enabled = false;
            txtStartedOn.Enabled = false;
            lblMesId.Visible = false;
            txtMesId.Visible = false;
            lblDescription.Text = "Opis";
            txtDescription.Text = _this.Description;
            txtRepairActions.Visible = false;
            txtInitialDiagnosis.Visible = false;
            lblRepairActions.Visible = false;
            lblInitialDiagnosis.Visible = false;
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
            
            if (_this.CreatedOn != null && _this.CreatedBy != 0)
            {
                lblCreated.Text = "Utworzone w dniu " + _this.CreatedOn + " przez " + _this.CreatedByName;
                lblCreated.Visible = true;
            }
            txtOutput.Text = _this.Output;
        }

        private bool IsMesSyncSelected()
        {
            int sel = 0;
            bool val = false;

            if(cmbActionType.ValueMember != "")
            {
                if (cmbActionType.SelectedItem != null)
                {
                    sel = (int)cmbActionType.SelectedValue;

                    if (ActionTypes.Items.Where(i => i.ActionTypeId == sel).Any())
                    {
                        if (ActionTypes.Items.Where(i => i.ActionTypeId == sel).FirstOrDefault().MesSync==true)
                        {
                            val = true;
                        }
                    }
                }
                
            }
            
            return val;
        }

        private bool IsShowInPlanningSelected()
        {
            int sel = 0;
            bool val = false;

            if (cmbActionType.ValueMember != "")
            {
                if (cmbActionType.SelectedItem != null)
                {
                    sel = (int)cmbActionType.SelectedValue;

                    if (ActionTypes.Items.Where(i => i.ActionTypeId == sel).Any())
                    {
                        if (ActionTypes.Items.Where(i => i.ActionTypeId == sel).FirstOrDefault().ShowInPlanning == true)
                        {
                            val = true;
                        }
                    }
                }

            }

            return val;
        }

        private bool IsInitialDiagnosisRequiredSelected()
        {
            int sel = 0;
            bool val = false;

            if (cmbActionType.ValueMember != "")
            {
                if (cmbActionType.SelectedItem != null)
                {
                    sel = (int)cmbActionType.SelectedValue;

                    if (ActionTypes.Items.Where(i => i.ActionTypeId == sel).Any())
                    {
                        if (ActionTypes.Items.Where(i => i.ActionTypeId == sel).FirstOrDefault().RequireInitialDiagnosis == true)
                        {
                            val = true;
                        }
                    }
                }

            }

            return val;
        }

        private void ChangeLook()
        {
            if (!string.IsNullOrEmpty(_this.MesId))
            {
                cmbActionType.Enabled = false;
            }
            if(IsMesSyncSelected())
            {
                lblMesId.Visible = true;
                txtMesId.Visible = true;
                txtMesId.Text = _this.MesId;
                lblDescription.Text = "Powód";
                txtDescription.Text = _this.Reason;
            }
            else
            {
                lblMesId.Visible = false;
                txtMesId.Visible = false;
                lblDescription.Text = "Opis";
                txtDescription.Text = _this.Description;
            }
            if (IsInitialDiagnosisRequiredSelected())
            {
                txtInitialDiagnosis.Visible = true;
                txtRepairActions.Visible = true;
                lblDescription.Text = "Powód";
                txtDescription.Text = _this.Reason;
                txtInitialDiagnosis.Text = _this.InitialDiagnosis;
                txtRepairActions.Text = _this.RepairActions;
                txtOutput.Enabled = false;
            }
            else
            {
                txtRepairActions.Visible = false;
                txtInitialDiagnosis.Visible = false;
                lblRepairActions.Visible = false;
                lblInitialDiagnosis.Visible = false;
                lblDescription.Text = "Opis";
                txtDescription.Text = _this.Description;
            }
            if (IsShowInPlanningSelected())
            {
                lblAssignedCaption.Visible = true;
                lblAssignedUsers.Visible = true;
                btnEditAssignedList.Visible = true;
            }
            else
            {
                lblAssignedCaption.Visible = false;
                lblAssignedUsers.Visible = false;
                btnEditAssignedList.Visible = false;
            }
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            Looper.Show(this);
            await Places.Refresh(null,'a');
            await StartingUsers.Refresh();
            FinishingUsers.Items = new List<User>(StartingUsers.Items);
            AssignableUsers.Items = new List<User>(StartingUsers.Items);
            await ActionTypes.Refresh();
            if (mode == 1)
            {
                cmbActionType.DataSource = ActionTypes.Items.Where(i => i.ShowInPlanning == true).ToList();
                txtPlannedStart.Enabled = true;
                txtPlannedFinish.Enabled = true;
                txtPlannedStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 0, 0);
                txtPlannedFinish.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 0, 0);
            }
            else
            {
                cmbActionType.DataSource = ActionTypes.Items;
                if (_this.PlannedStart == null)
                {
                    txtPlannedStart.CustomFormat = " ";
                    txtPlannedFinish.CustomFormat = " ";
                    txtPlannedStart.Enabled = false;
                    txtPlannedFinish.Enabled = false;
                }
                else
                {
                    txtPlannedStart.Value = (DateTime)_this.PlannedStart;
                    if(_this.PlannedFinish != null)
                    {
                        txtPlannedFinish.Value = (DateTime)_this.PlannedFinish;
                    }
                }
                if(_this.Status == "Planowany")
                {
                    txtPlannedStart.Enabled = true;
                    txtPlannedFinish.Enabled = true;
                }
                else
                {
                    txtPlannedStart.Enabled = false;
                    txtPlannedFinish.Enabled = false;
                }
                
            }
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
            _this.Handlings = new HandlingsKeeper();
            _this.Logs = new LogsKeeper();
            _this.ProcessActions = new ProcessActionsKeeper();
            if (_this.StartedOn != null)
            {
                LoadHandlings();
                LoadHistory();
                LoadProcessAssigns();
                //AssignedUsers = _this.
                txtStartedOn.Value = (DateTime)_this.StartedOn;
            }
            if (_this.FinishedOn != null)
            {
                txtFinishedOn.Value = (DateTime)_this.FinishedOn;
            }
            LoadActions();
            ChangeLook();
            Looper.Hide();
        }

        private async void LoadProcessAssigns()
        {
            if(_this.ProcessId > 0)
            {
                await ProcessAssigns.Refresh($"ProcessId={_this.ProcessId}");
                if (ProcessAssigns.Items.Any())
                {
                    foreach(ProcessAssign pa in ProcessAssigns.Items)
                    {
                        AssignedUsers.Add(new User { UserId=pa.UserId, Name=pa.UserName})
                    }
                }
            }
            
        }

        private async Task<bool> LoadHandlings()
        {
            await _this.Handlings.GetByProcessId(_this.ProcessId);
            if (_this.Handlings.Items.Any())
            {
                lvHandlings.Columns.Add("ID");
                lvHandlings.Columns.Add("Użytkownik");
                lvHandlings.Columns.Add("Status");
                lvHandlings.Columns.Add("Rozpoczęcie");
                lvHandlings.Columns.Add("Zakończenie");
                lvHandlings.Columns.Add("Długotrwałość [min]");
                lvHandlings.Columns.Add("Rezultat");
                foreach (Handling h in _this.Handlings.Items)
                {
                    string[] row =
                    {
                        h.HandlingId.ToString(),
                        h.UserName,
                        h.Status,
                        h.StartedOn.ToString(),
                        h.FinishedOn.ToString(),
                        h.Length.ToString(),
                        h.Output
                    };
                    ListViewItem item = new ListViewItem(row);
                    lvHandlings.Items.Add(item);
                }
                for (int i = 0; i < lvHandlings.Columns.Count; i++)
                {
                    //adjust column's widht to the content
                    lvHandlings.Columns[i].Width = -2;
                }
                lvHandlings.GridLines = true;
                return true;
            }
            else
            {
                lvHandlings.View = View.List;
                lvHandlings.Items.Add(new ListViewItem("Brak danych"));
                return false;
            }
        }

        private async Task<bool> LoadActions()
        {
            await _this.ProcessActions.GetByProcessId(_this.ProcessId);
            if (_this.ProcessActions.Items.Any())
            {
                dgvActions.DataSource = _this.ProcessActions.Items;
                //dgvActions.Columns["ProcessId"].Visible = false;
                dgvActions.Columns["PlannedStart"].Visible = false;
                dgvActions.Columns["PlannedFinish"].Visible = false;
                dgvActions.Columns["PlaceName"].Visible = false;
                AttributeEvaluator evaluator = new AttributeEvaluator(new ProcessAction());
                List<string> cols = evaluator.PropertiesByValueBool(true, typeof(MergableAttribute), "Mergable");
                DgvMerger merger = new DgvMerger(dgvActions, cols);
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> LoadHistory()
        {
            await _this.Logs.GetProcessHistory(_this.ProcessId);
            if (_this.Logs.Items.Any())
            {
                lvHistory.Columns.Add("ID logu");
                lvHistory.Columns.Add("Czas");
                lvHistory.Columns.Add("Użytkownik");
                lvHistory.Columns.Add("Opis");
                foreach (Log l in _this.Logs.Items)
                {
                    string[] row =
                    {
                        l.LogId.ToString(),
                        l.TimeStamp.ToString(),
                        l.UserName,
                        l.Description
                    };
                    ListViewItem item = new ListViewItem(row);
                    lvHistory.Items.Add(item);
                }
                for (int i = 0; i < lvHistory.Columns.Count; i++)
                {
                    //adjust column's widht to the content
                    lvHistory.Columns[i].Width = -2;
                }
                lvHistory.GridLines = true;
                return true;
            }
            else
            {
                lvHandlings.View = View.List;
                lvHandlings.Items.Add(new ListViewItem("Brak danych"));
                return false;
            }
        }

        private async void Save(object sender, EventArgs e)
        {
            ForceRefresh = true;
            _this.Output = txtOutput.Text;
            _this.InitialDiagnosis = txtInitialDiagnosis.Text;
            _this.RepairActions = txtRepairActions.Text;
            if(IsMesSyncSelected())
            {
                _this.MesId = txtMesId.Text;
                _this.Reason = txtDescription.Text;
            }
            else
            {
                _this.Description = txtDescription.Text;
            }
                    
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
            if(txtPlannedStart.Text == " ")
            {
                _this.PlannedStart = null;
            }
            else
            {
                _this.PlannedStart = txtPlannedStart.Value;
            }
            if (txtPlannedFinish.Text == " ")
            {
                _this.PlannedFinish = null;
            }
            else
            {
                _this.PlannedFinish = txtPlannedFinish.Value;
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
                    if (await _this.Add())
                    {
                        mode = 2;
                        this.Text = "Szczegóły zgłoszenia";
                    }
                }
                else if (mode == 2)
                {
                    await _this.Edit();
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
            txtStartedOn.CustomFormat = "yyyy-MM-dd HH:mm:ss tt";
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
            txtFinishedOn.CustomFormat = "yyyy-MM-dd HH:mm:ss tt";
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
                txtStartedOn.CustomFormat = "yyyy-MM-dd HH:mm:ss tt";
                txtStartedOn.Format = DateTimePickerFormat.Custom;
            }
            if (_this.FinishedOn == null)
            {
                txtFinishedOn.CustomFormat = " ";
                txtFinishedOn.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                txtFinishedOn.CustomFormat = "yyyy-MM-dd HH:mm:ss tt";
                txtFinishedOn.Format = DateTimePickerFormat.Custom;
            }
        }

        private void cmbActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLook();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnEditAssignedList_Click(object sender, EventArgs e)
        {
            List<Tuple<int, string, bool>> Users = new List<Tuple<int, string, bool>>();

            frmOptionPicker frmOptionPicker = new frmOptionPicker();
        }
    }
}

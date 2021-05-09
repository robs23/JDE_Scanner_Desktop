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
using System.Linq.Dynamic;
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
        List<User> AssignedUsers = new List<User>();
        ActionTypesKeeper ActionTypes = new ActionTypesKeeper();
        ProcessAssignKeeper ProcessAssigns = new ProcessAssignKeeper();
        frmLooper Looper;
        AssignedUsersHandler assignedUsersHandler;
        BackgroundWorker BW = new BackgroundWorker();
        FileKeeper files;

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
            assignedUsersHandler = new AssignedUsersHandler(this);
            files = new FileKeeper(this);
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
            assignedUsersHandler = new AssignedUsersHandler(this);
            assignedUsersHandler.ProcessId = Process.ProcessId;
            files = new FileKeeper(this,null,null,Process.ProcessId);
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

        private bool IsQrToStartSelected()
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
                        if (ActionTypes.Items.Where(i => i.ActionTypeId == sel).FirstOrDefault().RequireQrToStart == true)
                        {
                            val = true;
                        }
                    }
                }

            }

            return val;
        }

        private bool IsQrToFinishSelected()
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
                        if (ActionTypes.Items.Where(i => i.ActionTypeId == sel).FirstOrDefault().RequireQrToFinish == true)
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
                lblInitialDiagnosis.Visible = true;
                lblRepairActions.Visible = true;
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
                lblInitialDiagnosis.Visible = false;
                lblRepairActions.Visible = false;
                txtInitialDiagnosis.Visible = false;
                lblRepairActions.Visible = false;
                lblInitialDiagnosis.Visible = false;
                lblDescription.Text = "Opis";
                txtDescription.Text = _this.Description;
            }
            if (IsShowInPlanningSelected())
            {
                lblAssignedUsers.Visible = true;
                btnEditAssignedList.Visible = true;
            }
            else
            {
                lblAssignedUsers.Visible = false;
                btnEditAssignedList.Visible = false;
            }
            if(_this.Status == "Planowany")
            {
                btnChangeState.Text = "Rozpocznij";
                btnChangeState.BackColor = Color.Green;
                btnChangeState.Enabled = true;
            }else if(_this.Status == "Rozpoczęty" || _this.Status == "Wstrzymany")
            {
                btnChangeState.Text = "Zakończ";
                btnChangeState.BackColor = Color.Red;
                btnChangeState.Enabled = true;
                if(dgvActions.Columns.Count > 0)
                {
                    dgvActions.Columns[1].ReadOnly = false;
                }
                
            }
            else if(_this.Status == "Zakończony" || _this.Status == "Zrealizowany")
            {
                btnChangeState.Text = "Zakończony";
                btnChangeState.BackColor = Color.DarkGray;
                btnChangeState.Enabled = false;
            }
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            Looper.Show(this);
            var PlaceRefreshTask = Task.Run(() => Places.Refresh(null, 'a'));
            var StartingUsersRefreshTask = Task.Run(() => StartingUsers.Refresh(null, 'a'));
            await Task.WhenAll(PlaceRefreshTask, StartingUsersRefreshTask);
            FinishingUsers.Items = new List<User>(StartingUsers.Items);
            AssignableUsers.Items = new List<User>(StartingUsers.Items);
            _this.Handlings = new HandlingsKeeper();
            _this.Logs = new LogsKeeper();
            _this.PartUsages = new PartUsageKeeper();
            _this.ProcessActions = new ProcessActionsKeeper();
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
                txtComment.Text = _this.Comment;
                LoadHistory();
                var loadActionsTask = Task.Run(() => LoadActions());
                var loadProcessAssingsTask = Task.Run(() => assignedUsersHandler.LoadProcessAssigns());
                var loadUsedPartsTask = Task.Run(() => LoadParts());

                await Task.WhenAll(loadActionsTask, loadProcessAssingsTask, loadUsedPartsTask);
                lblAssignedUsers.Text = assignedUsersHandler.AssignedUserNames;

            }
            cmbStartedBy.DataSource = StartingUsers.Items;
            cmbFinishedBy.DataSource = FinishingUsers.Items;
            new AutoCompleteBehavior<Place>(this.cmbPlace, Places.Items);
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
                LoadHandlings();

                txtStartedOn.Value = (DateTime)_this.StartedOn;
            }
            if (_this.FinishedOn != null)
            {
                txtFinishedOn.Value = (DateTime)_this.FinishedOn;
            }
            
            ChangeLook();
            files.Initialize();
            Looper.Hide();
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
                dgvActions.NullableBoolCheckbox(); //make bool? column a checkbox column 
                foreach(DataGridViewColumn col in dgvActions.Columns)
                {
                    col.ReadOnly = true;    
                }
                
                
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> LoadParts()
        {
            await _this.PartUsages.GetByProcessId(_this.ProcessId);
            if (_this.PartUsages.Items.Any())
            {
                dgvUsedParts.DataSource = _this.PartUsages.Items;
                //dgvActions.Columns["ProcessId"].Visible = false;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private async Task<bool> LoadHistory()
        {
            lvHistory.View = View.List;
            lvHistory.Items.Add(new ListViewItem("Wczytywanie.."));
            if (_this.Logs != null)
            {
                await _this.Logs.GetProcessHistory(_this.ProcessId);
                lvHistory.Items[0].Remove();
                if (_this.Logs.Items.Any())
                {
                    lvHistory.View = View.Details;
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
            }
            lvHistory.View = View.List;
            lvHistory.Items.Add(new ListViewItem("Brak danych"));
            return false;

        }

        private async void SaveCommand(object sender, EventArgs e)
        {
            string res = await Save();
            if(res != "OK")
            {
                MessageBox.Show($"Coś poszło nie tak.. Szczegóły: {res}", "Niepowodzenie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private async Task<string> Save()
        {
            ForceRefresh = true;
            _this.Output = txtOutput.Text;
            _this.InitialDiagnosis = txtInitialDiagnosis.Text;
            _this.RepairActions = txtRepairActions.Text;
            _this.Comment = txtComment.Text;
            string _Result = "OK";

            if (IsMesSyncSelected())
            {
                _this.MesId = txtMesId.Text;
                _this.Reason = txtDescription.Text;
            }
            else
            {
                _this.Description = txtDescription.Text;
            }

            if (txtStartedOn.Text == " ")
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
            if (txtPlannedStart.Text == " ")
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
                _this.PlaceId = (int)cmbPlace.GetSelectedValue<Place>();
            }
            if (cmbActionType.SelectedItem != null)
            {
                _this.ActionTypeId = Convert.ToInt32(cmbActionType.SelectedValue.ToString());
            }
            if (cmbStatus.SelectedItem != null)
            {
                _this.Status = cmbStatus.SelectedItem.ToString();
            }
            if (cmbStartedBy.SelectedItem != null)
            {
                _this.StartedBy = Convert.ToInt32(cmbStartedBy.SelectedValue.ToString());
            }
            if (cmbFinishedBy.SelectedItem != null)
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
                        if (assignedUsersHandler.AssignedUsers.Any())
                        {
                            _Result = await _this.AssignUsers(assignedUsersHandler.AssignedUsers);
                        }

                        mode = 2;
                        this.Text = "Szczegóły zgłoszenia";
                    }
                    else
                    {
                        _Result = "Błąd podczas tworzenia nowego zgłoszenia..";
                    }
                }
                else if (mode == 2)
                {
                    if (await _this.Edit())
                    {
                        if (assignedUsersHandler.AssignedUsers.Any())
                        {

                           _Result = await _this.AssignUsers(assignedUsersHandler.AssignedUsers);
                        }
                    }
                    else
                    {
                        _Result = "Błąd podczas edycji zgłoszenia..";
                    }
                    

                }
                if(_Result == "OK")
                {
                    _Result = await files.Save($"ProcessId={_this.ProcessId}");
                }
                
                if (_Result != "OK")
                {
                    _Result = $"Wystąpiły problemy podczas zapisywania plików. Szczegóły: {_Result}";
                }
            }
            catch (Exception ex)
            {
                _Result = ex.ToString();
            }
            finally
            {
                Looper.Hide();
            }
            ChangeLook();

            return _Result;
        }

        private async Task<string> SaveActions(int handlingId)
        {
            string _Res = "OK";

            foreach(DataGridViewRow row in dgvActions.Rows)
            {
                var processActionId = (int)row.Cells["ProcessActionId"].Value;
                var isChecked = row.Cells["IsChecked"].Value;
                if ((bool)isChecked == true)
                {
                    ProcessAction pa = _this.ProcessActions.Items.FirstOrDefault(i => i.ProcessActionId == processActionId);
                    if (pa!= null)
                    {
                        pa.IsChecked = true;
                        pa.HandlingId = handlingId;
                        await pa.Edit();
                    }
                }
            }
            return _Res;
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


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnEditAssignedList_Click(object sender, EventArgs e)
        {
            assignedUsersHandler.AssignableUsers = new List<User>(StartingUsers.Items);
            assignedUsersHandler.ShowDialog();
            lblAssignedUsers.Text = assignedUsersHandler.AssignedUserNames;
        }

        private void cmbActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLook();
        }

        private void btnAttachments_Click(object sender, EventArgs e)
        {
            files.ShowFiles();
        }

        private async void btnChangeState_Click(object sender, EventArgs e)
        {

            if(_this.Status == "Rozpoczęty")
            {
                await End();
            }else if(_this.Status == "Planowany")
            {
                await Start();
            }

        }

        private async Task End()
        {
            string _Res = "OK";

            try
            {
                _Res = await Validate(true);

                if (_Res == "OK")
                {
                    // Taking care of handling
                    HandlingsKeeper hk = new HandlingsKeeper();
                    await hk.Refresh($"UserId={RuntimeSettings.UserId} and ProcessId={_this.ProcessId}");
                    Handling h;
                    if (hk.Items.Any(i => i.Status == "Rozpoczęty"))
                    {
                        //User has a handling that is started, let's use it
                        h = hk.Items.FirstOrDefault(i => i.Status == "Rozpoczęty");
                        h.PlaceId = _this.PlaceId;
                        h.Status = "Zakończony";
                        h.ActionTypeId = _this.ActionTypeId;
                        h.FinishedOn = DateTime.Now;
                        h.Output = "Obsługa utworzona na komputerze";
                        _Res = await h.Edit();
                    }
                    else
                    {
                        h = new Handling();
                        h.StartedOn = DateTime.Now;
                        h.UserId = RuntimeSettings.UserId;
                        h.TenantId = RuntimeSettings.TenantId;
                        h.ProcessId = _this.ProcessId;
                        h.PlaceId = _this.PlaceId;
                        h.Status = "Zakończony";
                        h.FinishedOn = DateTime.Now;
                        h.ActionTypeId = _this.ActionTypeId;
                        h.Output = "Obsługa utworzona na komputerze";
                        if (!await h.Add())
                        {
                            _Res = "Wystąpił problem przy tworzeniu obsługi tego zgłoszenia dla bieżącego użytkownika";
                        }
                    }
                    if(_Res == "OK")
                    {
                        _Res = await SaveActions(h.HandlingId);
                        if(_Res == "OK")
                        {
                            cmbFinishedBy.SelectedValue = RuntimeSettings.UserId;
                            txtFinishedOn.Value = DateTime.Now;
                            cmbStatus.SelectedIndex = cmbStatus.FindStringExact("Zakończony");
                            _Res = await Save();
                        }
                        
                    }

                }
                if (_Res != "OK")
                {
                    MessageBox.Show($"Napotkano błąd przy próbie zakończenia zgłoszenia. Szczegóły: {_Res}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Napotkano błąd przy próbie rozpoczęcia zgłoszenia. Szczegóły: {_Res}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Start()
        {
            string _Res = "OK";

            try
            {
                _Res = await Validate();

                if (_Res == "OK")
                {
                    cmbStartedBy.SelectedValue = RuntimeSettings.UserId;
                    txtStartedOn.Value = DateTime.Now;
                    cmbStatus.SelectedIndex = cmbStatus.FindStringExact("Rozpoczęty");
                    _Res = await Save();

                    if(ActionTypes.Items.Any(at => at.ActionTypeId == _this.ActionTypeId))
                    {
                        if (ActionTypes.Items.FirstOrDefault(at => at.ActionTypeId == _this.ActionTypeId).ClosePreviousInSamePlace == true)
                        {
                            Task.Run(() => _this.CompleteAllProcessesOfTheTypeInThePlace("Zamknięte ponieważ nowsze zgłoszenie tego typu zostało rozpoczęte"));
                        }
                    }

                    // Taking care of handling
                    Handling h = new Handling();
                    h.StartedOn = DateTime.Now;
                    h.UserId = RuntimeSettings.UserId;
                    h.TenantId = RuntimeSettings.TenantId;
                    h.Status = "Rozpoczęty";
                    h.ProcessId = _this.ProcessId;
                    h.PlaceId = _this.PlaceId;
                    h.ActionTypeId = _this.ActionTypeId;
                    if(!await h.Add())
                    {
                        _Res = "Wystąpił problem przy tworzeniu obsługi tego zgłoszenia dla bieżącego użytkownika";
                    }

                }
                if (_Res != "OK")
                {
                    MessageBox.Show($"Napotkano błąd przy próbie rozpoczęcia zgłoszenia. Szczegóły: {_Res}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Napotkano błąd przy próbie rozpoczęcia zgłoszenia. Szczegóły: {_Res}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string> Validate(bool EndValidation = false)
        {
            string _res = "OK";

            if (EndValidation)
            {
                if (this.IsQrToFinishSelected())
                {
                    _res = "Zgłoszenie może być zakończone jedynie na telefonie, ponieważ wymagane jest zeskanowanie kodu QR maszyny.. ";
                }
            }
            else
            {
                if (this.IsQrToStartSelected())
                {
                    _res = "Zgłoszenie może być rozpoczęte jedynie na telefonie, ponieważ wymagane jest zeskanowanie kodu QR maszyny.. ";
                }
            }

            return _res;
        }
    }
}

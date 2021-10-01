using JDE_Scanner_Desktop.Models;
using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Timer = System.Timers.Timer;
using System.Timers;

namespace JDE_Scanner_Desktop
{
    public partial class frmStarter : Form
    {
        BackgroundWorker filesSync;
        FileKeeper files;
        Timer filesSyncTimer;
        Form OverviewForm;
        bool IsInitialized = false;

        public frmStarter()
        {
            InitializeComponent();
            try
            {
                RuntimeSettings.GetPageSize();
                OverviewForm = new frmOverview();
                OverviewForm.TopLevel = false;
                OverviewForm.FormBorderStyle = FormBorderStyle.None;
                OverviewForm.Dock = DockStyle.Fill;
                pnlOverview.Controls.Add(OverviewForm);
                pnlOverview.Tag = OverviewForm;
                OverviewForm.BringToFront();
                OverviewForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(RuntimeSettings.ConnectionUnavailableMessage, "Brak połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
        }

        private void koniecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uzytkownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmUsers FrmUsers = new frmUsers(this);
            FrmUsers.Show(this);
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmUser FrmUser = new frmUser(this);
            FrmUser.Show(this);
        }

        private void nowyToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmActionType FrmActionType = new frmActionType(this);
            FrmActionType.Show(this);
        }

        private void typuZleceńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmActionTypes FrmActionTypes = new frmActionTypes(this);
            FrmActionTypes.Show(this);
        }

        private void noweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmProcess FrmProcess = new frmProcess(this);
            FrmProcess.Show(this);
        }

        private void zleceniaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmProcesses FrmProcesses = new frmProcesses(this);
            FrmProcesses.Show(this);
        }

        private async void formLoaded(object sender, EventArgs e)
        {
            frmLogin FrmLogin = new frmLogin(this);
            FrmLogin.ShowDialog(this);
            files = new FileKeeper(mainForm: this, uploadKeeper: true);
            await files.Initialize();
            RuntimeSettings.UploadKeeper = files;
            filesSyncTimer = new Timer(60000); //run it everyminute
            filesSyncTimer.Elapsed += Timer_Elapsed;
            filesSync = new BackgroundWorker();
            filesSync.DoWork += (obj, ea) => SyncFiles();
            filesSyncTimer.Start();
        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!filesSync.IsBusy)
                filesSync.RunWorkerAsync();
        }

        public async Task SyncFiles()
        {
            await files.RestoreUploadQueue();
            await files.Upload();   
        }

        private async void frmStarter_Shown(object sender, EventArgs e)
        {
            if (RuntimeSettings.UserId == 0)
            {
                this.Close();
            }
            else
            {
                this.Text = "JDE Scan v." + System.Windows.Forms.Application.ProductVersion;
                if(IsInitialized == false)
                {
                    this.WindowState = FormWindowState.Maximized;
                    IsInitialized = true;
                }
                
#if (DEBUG == false)
                ReleaseEntry release = null;
                string path = string.Empty;
                if (Directory.Exists(Static.Secrets.SquirrelAbsoluteUpdatePath))
                {
                    path = Static.Secrets.SquirrelAbsoluteUpdatePath;
                }
                else if (Directory.Exists(Static.Secrets.SquirrelUpdatePath))
                {
                    path = Static.Secrets.SquirrelUpdatePath;
                }
                if (!string.IsNullOrWhiteSpace(path))
                {
                    using (var mgr = new UpdateManager(path))
                    {
                        //SquirrelAwareApp.HandleEvents(
                        //onInitialInstall: v =>
                        //{
                        //    mgr.CreateShortcutForThisExe();
                        //    mgr.CreateRunAtWindowsStartupRegistry();
                        //},
                        //onAppUninstall: v =>
                        //{
                        //    mgr.RemoveShortcutForThisExe();
                        //    mgr.RemoveRunAtWindowsStartupRegistry();
                        //});
                        release = await mgr.UpdateApp();
                    }
                    if (release != null)
                    {
                        MessageBox.Show("Aplikacja została zaktualizowana do nowszej wersji. Naciśnij OK aby zrestartować aplikację", "Aktualizacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //force app restart
                        UpdateManager.RestartApp();
                    }
                }
#endif
            }
        }

        private void historiaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmLogs FrmLogs = new frmLogs(this);
            FrmLogs.Show(this);
        }

        private void zgłoszeniaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmProcesses FrmProcesses = new frmProcesses(this);
            FrmProcesses.Show(this);
        }

        private void noweToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmProcess FrmProcess = new frmProcess(this);
            FrmProcess.Show(this);
        }

        private void obsługaZgłoszeńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmHandlings FrmHandlings = new frmHandlings(this);
            FrmHandlings.Show(this);
        }

        private void zasobyXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmPlacesY FrmPlacesY = new frmPlacesY(this);
            FrmPlacesY.Show(this);
        }

        private void nowyToolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmActionType FrmActionType = new frmActionType(this);
            FrmActionType.Show(this);
        }

        private void wszystkieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmActionTypes FrmActionTypes = new frmActionTypes(this);
            FrmActionTypes.Show(this);
        }

        private void nowyToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmPlace FrmPlace = new frmPlace(this);
            FrmPlace.Show(this);
        }

        private void wszystkieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmPlaces FrmPlaces = new frmPlaces(this);
            FrmPlaces.Show(this);
        }

        private void nowaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmSet FrmSet = new frmSet(this);
            FrmSet.Show(this);
        }

        private void wszystkieToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmSets FrmSets = new frmSets(this);
            FrmSets.Show(this);
        }

        private void nowyToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmArea FrmArea = new frmArea(this);
            FrmArea.Show(this);
        }

        private void wszystkieToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmAreas FrmAreas = new frmAreas(this);
            FrmAreas.Show(this);
        }

        private void wszystkieToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmCompanyTypes FrmCompanyTypes = new frmCompanyTypes(this);
            FrmCompanyTypes.Show(this);
        }

        private void nowyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmCompanyType FrmCompanyType = new frmCompanyType(this);
            FrmCompanyType.Show(this);
        }

        private void wszystkieToolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmCompanies FrmCompanies = new frmCompanies(this);
            FrmCompanies.Show(this);
        }

        private void nowaToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            //new company
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmCompany FrmCompany = new frmCompany(this);
            FrmCompany.Show(this);
        }

        private void wszystkieToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmParts FrmParts = new frmParts(this);
            FrmParts.Show(this);
        }

        private void wszystkieToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmBoms FrmBoms = new frmBoms(this);
            FrmBoms.Show(this);
        }

        private void nowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmPart FrmPart = new frmPart(this);
            FrmPart.Show(this);
        }

        private void KonserwacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmProcesses FrmProcesses = new frmProcesses(this,typeId:2);
            FrmProcesses.Show(this);
        }

        private void CzynnosciKonserwacyjneToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmProcessActions FrmProcessActions = new frmProcessActions(this);
            FrmProcessActions.Show(this);
        }

        private void wszystkieToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmPartUsages FrmPartUsages = new frmPartUsages(this);
            FrmPartUsages.Show(this);   
        }

        private void nowyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmComponent FrmComponent = new frmComponent(this);
            FrmComponent.Show(this);
        }

        private void wszystkieToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmComponents FrmComponents = new frmComponents(this);
            FrmComponents.Show(this);
        }

        private void masoweDodawanieKomponentówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmAddComponents FrmAddComponents = new frmAddComponents(this);
            FrmAddComponents.Show(this);
        }

        private async void kolejkaPlikówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await files.RestoreUploadQueue();
            files.ShowFiles();
        }

        private void frmStarter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (files.Items.Any(i => i.IsUploaded == false))
            {
                var res = MessageBox.Show($@"Niektóre pliki, które dodałeś, nie zostały jeszcze zsynchronizowane. Jeśli teraz zamkniesz program, pozostałe pliki zostaną przesłane na serwer przy ponownym uruchomieniu programu. Do tego czasu pliki te będą niedostępne dla pozostałych użytkowników.{Environment.NewLine}{Environment.NewLine}Czy napewno chcesz zamknąć program?",
                                            "Synchronizacja w toku", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(res == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void smarowaniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProcesses FrmProcesses = new frmProcesses(this, typeId: 24);
            FrmProcesses.Show(this);
        }

        private void regałyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmStorageBins FrmStorageBins = new frmStorageBins(this);
            FrmStorageBins.Show(this);
        }

        private void nowyRegałToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmStorageBin FrmStorageBin = new frmStorageBin(this);
            FrmStorageBin.Show(this);
        }

        private void noweToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmOrder Frm = new frmOrder(this);
            Frm.Show(this);
        }

        private void nowyToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmAbandonReason Frm = new frmAbandonReason(this);
            Frm.Show(this);
        }

        private void wszystkieToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmAbandonReasons Frm = new frmAbandonReasons(this);
            Frm.Show(this);
        }

        private void masoweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmAddAbandonReasons Frm = new frmAddAbandonReasons(this);
            Frm.Show(this);
        }

        private void wszystkieToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (!RuntimeSettings.CurrentUser.IsAuthorized())
                return;
            frmOrders Frm = new frmOrders(this);
            Frm.Show(this);
        }
    }
}

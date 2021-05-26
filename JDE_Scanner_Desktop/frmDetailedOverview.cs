using FontAwesome.Sharp;
using JDE_Scanner_Desktop.CustomControls;
using JDE_Scanner_Desktop.Models;
using JDE_Scanner_Desktop.Static;
using NuGet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JDE_Scanner_Desktop.Static.Enums;

namespace JDE_Scanner_Desktop
{
    public partial class frmDetailedOverview : Form
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public FileKeeper ImageInfoKeeper { get; set; }
        public ProcessesKeeper ProcessKeeper { get; set; }
        public ProcessActionsKeeper ProcessActionKeeper { get; set; }
        public List<ImageInfo> ImageInfos { get; set; }
        public List<dynamic> ProcessStats { get; set; }
        public List<dynamic> ProcessActionStats { get; set; }
        public ProcessActionStatsDivisionType DivisionType { get; set; }

        public frmDetailedOverview(DateTime dateFrom, DateTime dateTo, ProcessActionStatsDivisionType divisionType)
        {
            InitializeComponent();
            ImageInfoKeeper = new FileKeeper(this);
            ProcessKeeper = new ProcessesKeeper();
            ProcessActionKeeper = new ProcessActionsKeeper();
            DateFrom = dateFrom;
            DateTo = dateTo;
            DivisionType = divisionType;
        }

        public async Task LoadRecentImages()
        {  
            ImageInfos = await ImageInfoKeeper.GetImageInfos(DateFrom, DateTo);
        }
        public async Task LoadProcessResults()
        {
            ProcessStats = await ProcessKeeper.GetProcessStats(DateFrom, DateTo);
        }

        public async Task LoadProcessActions()
        {
            if(DivisionType == ProcessActionStatsDivisionType.Daily)
            {
                try
                {
                    List<Task<List<dynamic>>> tasks = new List<Task<List<dynamic>>>();
                    ActionTypesKeeper atk = new ActionTypesKeeper();
                    await atk.Refresh();
                    int year = DateTime.Now.Year;
                    int week = DateTime.Now.IsoWeekOfYear();

                    foreach (var at in atk.Items)
                    {
                        if (at.ActionsApplicable == true)
                        {
                            //let's get its stats
                            Task<List<dynamic>> getAtStats = Task.Run(() => ProcessActionKeeper.GetProcessActionStats(year, week, ProcessActionStatsDivisionType.Daily, at.ActionTypeId));
                            tasks.Add(getAtStats);
                        }
                    }
                    if (tasks.Any())
                    {
                        var results = await Task.WhenAll(tasks);
                        List<dynamic> ints = new List<dynamic>();
                        foreach (var r in results)
                        {
                            ints.Add(r.FirstOrDefault());
                        }
                    }
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Wystąpił problem przy pobieraniu statystyk wykonania czynności w listach kontrolnych", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async Task DisplayProcessResutls()
        {
            pnlProcesses.Controls.Clear();
            if (ProcessStats.Any())
            {
                foreach(var item in ProcessStats)
                {
                    if (item.ShowOnDashboard == true)
                    {
                        IconChar icon = IconChar.None;
                        string n = item.Name;
                        bool existent = RuntimeSettings.ProcessIcons.TryGetValue(n, out icon);


                        ThreeRowsColumn card = new ThreeRowsColumn();
                        card.Name = item.Name;
                        card.Icon = icon;
                        card.L1Text = item.Count.ToString();
                        card.L2Text = item.Result.ToString();
                        card.L3Text = item.PercentOfAll.ToString("0.00");
                        card.Dock = DockStyle.Left;
                        pnlProcesses.Controls.Add(card);
                    }
                }
            }

            ThreeRowsColumn Headlines = new ThreeRowsColumn();
            Headlines.Dock = DockStyle.Left;
            pnlProcesses.Controls.Add(Headlines);
        }

        private async Task DisplayRecentImages()
        {
            pnlImages.Controls.Clear();
            foreach (var i in ImageInfos)
            {
                ImageInfoControl item = new ImageInfoControl(this);
                item.thisItem = i;
                pnlImages.Controls.Add(item);
            }
        }

        private async void frmDetailedOverview_Load(object sender, EventArgs e)
        {
            Task loadImagesTask = Task.Run(() => LoadRecentImages());
            Task loadResults = Task.Run(() => LoadProcessResults());
            Task loadProcessActions = Task.Run(() => LoadProcessActions());

            await Task.WhenAll(loadImagesTask, loadResults, loadProcessActions);

            DisplayRecentImages();
            DisplayProcessResutls();
            DisplayProcessActions();
        }

        private async Task DisplayProcessActions()
        {
            
        }

        private void chartProgress_Click(object sender, EventArgs e)
        {

        }
    }
}

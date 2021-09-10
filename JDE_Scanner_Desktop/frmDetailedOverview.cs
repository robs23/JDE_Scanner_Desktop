using FontAwesome.Sharp;
using JDE_Scanner_Desktop.CustomControls;
using JDE_Scanner_Desktop.Models;
using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json.Linq;
using NuGet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
        ActionTypesKeeper ActionTypes = new ActionTypesKeeper();
        public ProcessActionStatsDivisionType DivisionType { get; set; }

        List<List<dynamic>> chartSeries = new List<List<dynamic>>();

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
            try
            {
                List<Task<List<dynamic>>> tasks = new List<Task<List<dynamic>>>();
                    
                await ActionTypes.Refresh();
                int year = DateTime.Now.Year;
                int week = DateTime.Now.IsoWeekOfYear();

                foreach (var at in ActionTypes.Items)
                {
                    if (at.ActionsApplicable == true)
                    {
                        //let's get its stats
                        Task<List<dynamic>> getAtStats = Task.Run(() => ProcessActionKeeper.GetProcessActionStats(year, week, DivisionType, at.ActionTypeId));
                        tasks.Add(getAtStats);
                    }
                }
                if (tasks.Any())
                {
                    var results = await Task.WhenAll(tasks);
                        

                    foreach (var r in results)
                    {
                        chartSeries.Add(r);
                    }
                    //string s = chartSeries.FirstOrDefault().FirstOrDefault().Weekday;
                }
                    
            }
            catch (Exception ex)
            {

                MessageBox.Show("Wystąpił problem przy pobieraniu statystyk wykonania czynności w listach kontrolnych", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        card.Action = new Action<int, string>(OpenProcesses);
                        card.ActionTypeId = item.ActionTypeId;
                        card.DateFrom = DateFrom;
                        card.DateTo = DateTo;
                        card.Dock = DockStyle.Left;
                        pnlProcesses.Controls.Add(card);
                    }
                }
            }

            ThreeRowsColumn Headlines = new ThreeRowsColumn();
            Headlines.Dock = DockStyle.Left;
            pnlProcesses.Controls.Add(Headlines);
        }

        public void OpenProcesses(int typeId, string parameters)
        {
            frmProcesses FrmProcesses = new frmProcesses(this, typeId, parameters);
            FrmProcesses.Show();
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

            try
            {
                await Task.WhenAll(loadImagesTask, loadResults, loadProcessActions);

                DisplayRecentImages();
                DisplayProcessResutls();
                DisplayProcessActions();
            }
            catch (Exception)
            {
            }
        }

        private async Task DisplayProcessActions()
        {
            chartProgress.Series.Clear();

            if (chartSeries.Any())
            {
                List<CustomLabel> Labels = new List<CustomLabel>();
                chartProgress.ChartAreas[0].AxisY.Title = "Wykonanie [%]";
                chartProgress.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
                chartProgress.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                chartProgress.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
                chartProgress.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
                //chartProgress.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 14, FontStyle.Bold);
               
                foreach (var s in chartSeries)
                {
                    if (s.Any())
                    {
                        if(DivisionType == ProcessActionStatsDivisionType.Weekly || DivisionType == ProcessActionStatsDivisionType.Monthly)
                        {
                            s.Reverse();
                            chartProgress.ChartAreas[0].AxisY.Minimum = 50;
                        }
                        int atId = Convert.ToInt32(s.FirstOrDefault().Type);
                        string sName = ActionTypes.Items.FirstOrDefault(i => i.ActionTypeId == atId).Name;
                        if (!string.IsNullOrEmpty(sName))
                        {
                            chartProgress.Series.Add(sName);
                            if(DivisionType == ProcessActionStatsDivisionType.Monthly)
                            {
                                chartProgress.Series[sName].XValueType = ChartValueType.Date;
                            }
                            else
                            {
                                chartProgress.Series[sName].XValueType = ChartValueType.String;
                            }
                            
                            chartProgress.Series[sName].ChartType = SeriesChartType.Column;
                            chartProgress.Series[sName].IsValueShownAsLabel = true;
                            foreach (var p in s)
                            {
                                double percent = Math.Round(Convert.ToDouble(p.Done), 1);
                                if (DivisionType == ProcessActionStatsDivisionType.Daily)
                                {
                                    DateTime date = p.Date;
                                    string label = p.Weekday;
                                    int i = chartProgress.Series[sName].Points.AddXY(date, percent);
                                    chartProgress.ChartAreas[0].AxisX.CustomLabels.Add(date.AddHours(-12).ToOADate(), date.AddHours(12).ToOADate(), label);
                                }
                                else if(DivisionType == ProcessActionStatsDivisionType.Weekly)
                                {
                                    int i = chartProgress.Series[sName].Points.AddXY((int)p.Week, percent);
                                }else if (DivisionType == ProcessActionStatsDivisionType.Monthly)
                                {
                                    int month = Convert.ToInt32(p.Month);
                                    DateTime firstDate = p.FirstDate;
                                    string label = firstDate.ToString("MMMM", CultureInfo.GetCultureInfo("pl-PL"));
                                    int i = chartProgress.Series[sName].Points.AddXY(firstDate, percent);
                                    chartProgress.ChartAreas[0].AxisX.CustomLabels.Add(firstDate.AddDays(-15).ToOADate(), firstDate.AddDays(15).ToOADate(), label);
                                }

                            }
                        }
                        //chartProgress.Series[sName].Points[1].Color = Color.Red; 
                    }
                }
            }
        }

        private void chartProgress_Click(object sender, EventArgs e)
        {

        }
    }
}

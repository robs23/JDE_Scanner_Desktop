using FontAwesome.Sharp;
using JDE_Scanner_Desktop.CustomControls;
using JDE_Scanner_Desktop.Models;
using NuGet;
using Oracle.ManagedDataAccess.Types;
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
    public partial class frmDetailedOverview : Form
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public FileKeeper ImageInfoKeeper { get; set; }
        public List<ImageInfo> ImageInfos { get; set; }

        public frmDetailedOverview()
        {
            InitializeComponent();
            ImageInfoKeeper = new FileKeeper(this);
        }

        public frmDetailedOverview(DateTime dateFrom, DateTime dateTo)
        {
            InitializeComponent();
            ImageInfoKeeper = new FileKeeper(this);
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        public async Task LoadRecentImages()
        {  
            ImageInfos = await ImageInfoKeeper.GetImageInfos(DateFrom, DateTo);
        }
        public async Task LoadProcessResults()
        {
            await Task.Delay(100);
        }

        public async Task DisplayProcessResutls()
        {
            pnlProcesses.Controls.Clear();
            ThreeRowsColumn DefectCards = new ThreeRowsColumn(name: "Karty defektów", icon: IconChar.Viruses, l1Text: "10", l2Text: "150", l2Color: Color.Green);
            DefectCards.Dock = DockStyle.Left;
            pnlProcesses.Controls.Add(DefectCards);
            ThreeRowsColumn Smearings = new ThreeRowsColumn(name: "Smarowania", icon: IconChar.OilCan, l1Text: "10", l2Text: "150", l2Color: Color.Green);
            Smearings.Dock = DockStyle.Left;
            pnlProcesses.Controls.Add(Smearings);
            ThreeRowsColumn Maintenance = new ThreeRowsColumn(name: "Konserwacje", icon: IconChar.Tasks, l1Text: "10", l2Text: "150", l2Color: Color.Green);
            Maintenance.Dock = DockStyle.Left;
            pnlProcesses.Controls.Add(Maintenance);
            ThreeRowsColumn Breakdowns = new ThreeRowsColumn(name: "Awarie", icon: IconChar.ExclamationTriangle, l1Text: "3", l2Text: "290", l2Color: Color.Red);
            Breakdowns.Dock = DockStyle.Left;
            pnlProcesses.Controls.Add(Breakdowns);
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
            await Task.WhenAll(loadImagesTask, loadResults);
            DisplayRecentImages();
            DisplayProcessResutls();
        }
    }
}

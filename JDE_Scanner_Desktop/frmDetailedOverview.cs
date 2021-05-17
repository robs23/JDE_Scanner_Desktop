using JDE_Scanner_Desktop.CustomControls;
using JDE_Scanner_Desktop.Models;
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
            pnlImages.Controls.Clear();
            List<ImageInfoControl> ImageInfoControls = new List<ImageInfoControl>();    

            List<ImageInfo> Items = await ImageInfoKeeper.GetImageInfos(DateFrom, DateTo);

            
            foreach(var i in Items)
            {
                ImageInfoControl item = new ImageInfoControl(this);
                item.thisItem = i;
                ImageInfoControls.Add(item);
                pnlImages.Controls.Add(item);
            }
            
        }

        private async void frmDetailedOverview_Load(object sender, EventArgs e)
        {
            await LoadRecentImages();
        }
    }
}

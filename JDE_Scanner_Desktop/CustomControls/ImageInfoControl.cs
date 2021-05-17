using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using JDE_Scanner_Desktop.Models;
using NuGet;
using JDE_Scanner_Desktop.Static;

namespace JDE_Scanner_Desktop.CustomControls
{
    public partial class ImageInfoControl : UserControl
    {
        public Form ParentForm { get; set; }
        public ImageInfo _thisItem;
        public ImageInfo thisItem
        {
            get { return _thisItem; }
            set
            {
                _thisItem = value;
                pbImage.ImageLocation = $"{Secrets.ApiAddress}{RuntimeSettings.ThumbnailsPath}{thisItem.LinkName}";
                lblTitle.Text = thisItem.Description;
                lblDetails.Text = $"Dodane przez {thisItem.CreatedByName}, {thisItem.CreatedOn.Value.ToString("dd.MM.yyyy HH:mm")}";
            }
        }

        public ImageInfoControl(Form parent)
        {
            InitializeComponent();
            ParentForm = parent;
        }

        public async Task OpenImage()
        {
            System.Diagnostics.Process.Start($"{Secrets.ApiAddress}{RuntimeSettings.FilesPath}{thisItem.LinkName}");
        }

        public async Task GoToAssign()
        {
            if(thisItem.ProcessId != null)
            {
                var processKeeper = new ProcessesKeeper();
                await processKeeper.GetByProcessId((int)thisItem.ProcessId);
                frmProcess FrmProcess = new frmProcess(processKeeper.Items.FirstOrDefault(), ParentForm);
                FrmProcess.Show();
            }else if(thisItem.PlaceId != null)
            {
                var placeKeeper = new PlacesKeeper();
                await placeKeeper.Refresh(query: $"PlaceId={thisItem.PlaceId}");
                frmPlace FrmPlace = new frmPlace(placeKeeper.Items.FirstOrDefault(), ParentForm);
                FrmPlace.Show();
            }
            else if (thisItem.PartId != null)
            {
                var partKeeper = new PartKeeper();
                await partKeeper.Refresh(query: $"PartId={thisItem.PartId}");
                frmPart FrmPart = new frmPart(partKeeper.Items.FirstOrDefault(), ParentForm);
                FrmPart.Show();
            }
        }

        private void ImageInfoControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(217, 229, 242);
        }

        private void ImageInfoControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 255, 255);
        }

        private async void pnlData_Click(object sender, EventArgs e)
        {
            await GoToAssign();
        }

        private async void pbImage_Click(object sender, EventArgs e)
        {
            await OpenImage();
        }

        private async void lblTitle_Click(object sender, EventArgs e)
        {
            await GoToAssign();
        }

        private async void lblDetails_Click(object sender, EventArgs e)
        {
            await GoToAssign();
        }

        private async void ImageInfoControl_Click(object sender, EventArgs e)
        {
            await GoToAssign();
        }
    }
}

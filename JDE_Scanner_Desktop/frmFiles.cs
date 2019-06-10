using JDE_Scanner_Desktop.Models;
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
    public partial class frmFiles : Form
    {
        FileKeeper files;

        public frmFiles(FileKeeper fls, Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            files = fls;
        }

        private async void LoadImages()
        {
            if (files.Items.Any())
            {
                if (lvImages.Items.Count > 0)
                {
                    lvImages.Clear();
                }
                lvImages.View = View.LargeIcon;
                lvImages.LargeImageList = iList;
                foreach (Models.File f in files.Items)
                {
                    iList.Images.Add(f.Link, Image.FromFile(f.Link));
                    lvImages.Items.Add(new ListViewItem { ImageKey = f.Link });
                }

                //lvImages.Refresh();
            }
            else
            {
                lvImages.Clear();
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            files.LoadFromDisk();
            LoadImages();
        }

        private void frmFiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void frmFiles_Load(object sender, EventArgs e)
        {
            LoadImages();
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if(lvImages.SelectedItems.Count > 0)
            {
                for (int i = lvImages.SelectedItems.Count - 1; i >= 0; i--)
                {
                    files.Items.RemoveAt(lvImages.SelectedItems[i].Index);
                }

                LoadImages();
            }
        }
    }
}

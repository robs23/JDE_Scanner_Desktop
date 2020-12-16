using JDE_Scanner_Desktop.Models;
using JDE_Scanner_Desktop.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
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
                    //load placeholder
                    iList.Images.Add(f.Name, f.ThumbnailPlaceholder);
                    lvImages.Items.Add(new ListViewItem { ImageKey = f.Name, Text= f.Name });
                }
                LoadPreviews();
                //lvImages.Refresh();
            }
            else
            {
                lvImages.Clear();
            }
        }

        public async Task LoadPreviews()
        {
            for (int i = 0; i < lvImages.Items.Count; i++)
            {
                string name = lvImages.Items[i].Text;
                File f = files.Items.FirstOrDefault(x => x.Name == name);
                if (f != null)
                {
                    if (f.IsImage)
                    {
                        Image img = await f.GetPreview();
                        if (img != null)
                        {
                            for (int n = 0; n < iList.Images.Count; n++)
                            {
                                iList.Images[iList.Images.IndexOfKey(name)] = img;
                            }
                            iList.Images[i] = img;
                        }
                    }
                }
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

        private void lvImages_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < lvImages.Items.Count; i++)
            {
                var rectangle = lvImages.GetItemRect(i);
                if (rectangle.Contains(e.Location))
                {
                    if (files.Items.Any(x => x.Name == lvImages.Items[i].Text))
                    {
                        files.Items.Where(x => x.Name == lvImages.Items[i].Text).FirstOrDefault().Open();
                    }
                }
            }
        }
    }
}

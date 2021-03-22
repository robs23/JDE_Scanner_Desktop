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
                    lvImages.Items.Add(new ListViewItem { ImageKey = f.Name, Text= f.Name, Tag=f.Token });
                }
                Task.Run(()=> LoadPreviews());
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
                string name = "";
                Invoke(new System.Action(() =>
                {
                    //Updating UI from other thread, that this method is working on
                    name = lvImages.Items[i].Text;
                }));
                
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
                                Invoke(new System.Action(() => { iList.Images[iList.Images.IndexOfKey(name)] = img; }));
                                
                            }
                            Invoke(new System.Action(() => { iList.Images[i] = img; }));
                        }
                    }
                }
            }
            Invoke(new System.Action(() => { lvImages.Refresh(); }));
        }

        public async void LoadItems()
        {
            if ((string)cmbView.SelectedValue == "Miniatury")
            {
                LoadImages();
            }
            else
            {
                LoadDetails();
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            files.LoadFromDisk();
            LoadItems();
        }

        private void frmFiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void frmFiles_Load(object sender, EventArgs e)
        {
            if (files.UploadKeeper)
            {
                btnAddFile.Visible = false;
                btnDeleteFile.Visible = true;
                btnUpload.Visible = false;
            }
            else
            {
                btnAddFile.Visible = true;
                btnDeleteFile.Visible = true;
                btnUpload.Visible = false;
            }
            string[] cmbItems = { "Miniatury", "Szczegóły"};
            this.cmbView.DataSource = cmbItems;
            LoadItems();
            
        }

        private void LoadDetails()
        {
            lvImages.Columns.Add("ID", 30);
            lvImages.Columns.Add("Nazwa",100);
            lvImages.Columns.Add("Typ", 50);
            lvImages.Columns.Add("Utworzono", 80);
            lvImages.Columns.Add("Ścieżka", 150);
            lvImages.Columns.Add("Wysłano", 50);
            lvImages.Columns.Add("Rozmiar", 50);

            if (files.Items.Any())
            {
                if (lvImages.Items.Count > 0)
                {
                    lvImages.Items.Clear();
                }
                
                foreach (Models.File f in files.Items)
                {
                    ListViewItem i = new ListViewItem(new string[] { f.FileId.ToString(), f.Name, f.Type, f.CreatedOn.ToString(), f.Link, f.IsUploaded.ToString(), f.SizeInMB.ToString() });
                    i.Tag = f.Token;
                    lvImages.Items.Add(i);
                }
            }
            else
            {
                lvImages.Clear();
            }
            lvImages.View = View.Details;
        }

        private async void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if(lvImages.SelectedItems.Count > 0)
            {
                for (int i = lvImages.SelectedItems.Count - 1; i >= 0; i--)
                {
                    files.RemovedItems.Add(files.Items.Where(x => x.Token == (string)lvImages.SelectedItems[i].Tag).FirstOrDefault()) ;
                    files.Items.RemoveAt(lvImages.SelectedItems[i].Index);
                }
                if (files.UploadKeeper)
                {
                    bool res = await files.RemoveAll();
                    if (!res)
                    {
                        MessageBox.Show("Usuwanie jednego lub więcej plików zakończyło się niepowodzeniem..", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                LoadItems();
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
                        files.OpenFile(files.Items.Where(x => x.Name == lvImages.Items[i].Text).FirstOrDefault());
                    }
                }
            }
        }

        private void cmbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cmbView.SelectedValue == "Miniatury")
            {
                LoadImages();
            }
            else
            {
                LoadDetails();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            files.Upload();
        }
    }
}

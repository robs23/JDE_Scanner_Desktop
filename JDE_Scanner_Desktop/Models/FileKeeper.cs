using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class FileKeeper : Keeper<File>
    {
        protected override string ObjectName => "File";

        protected override string PluralizedObjectName => "Files";
        public Form MainForm { get; set; }
        public Form FileForm { get; set; }
        public OpenFileDialog OpenFileDialog;

        public FileKeeper(Form mainForm) : base()
        {
            MainForm = mainForm;
        }

        public async void LoadFromDisk()
        {
            OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Wybierz plik(i)";
            OpenFileDialog.Multiselect = true;
            OpenFileDialog.Filter = "Obrazy (*.JPG;*.GIF,*.PNG)|*.JPG;*.GIF;*.PNG";

            if (OpenFileDialog.ShowDialog()== DialogResult.OK)
            {
                foreach (String file in OpenFileDialog.FileNames)
                {
                    try
                    {
                        string name = new FileInfo(file).Name;
                        File nFile = new File();
                        nFile.Link = file;
                        nFile.Name = name;
                        Items.Add(nFile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            } 
        }

        public async void DownloadFromCloud(bool? min = false)
        {
            if (this.Items.Any())
            {
                foreach(File f in this.Items)
                {

                }
            }
        }

        public async void ShowFiles()
        {
            FileForm = new frmFiles(this, MainForm);
            FileForm.Show(MainForm);
        }
    }
}

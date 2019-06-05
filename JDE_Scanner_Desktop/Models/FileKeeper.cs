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

        public OpenFileDialog OpenFileDialog;

        public void LoadFromDisk()
        {
            OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Wybierz plik(i)";
            OpenFileDialog.Multiselect = true;
            OpenFileDialog.Filter = "Obrazy (*.JPG;*.GIF,*.PNG)|*.JPG;*.GIF;*.PNG|Wszystkie pliki (*.*)|*.*";

            if (OpenFileDialog.ShowDialog()== DialogResult.OK)
            {
                foreach (String file in OpenFileDialog.FileNames)
                {
                    try
                    {
                        File nFile = new File { Link = file, Name=Static.Utilities.GetFileName(file) };
                        Items.Add(nFile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            } 
        }
    }
}

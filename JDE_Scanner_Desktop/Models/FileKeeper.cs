using JDE_Scanner_Desktop.Static;
using SQLite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
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

        public List<File> RemovedItems { get; set; }

        public FileKeeper(Form mainForm) : base()
        {
            MainForm = mainForm;
            RemovedItems = new List<File>();
        }

        public async void LoadFromDisk(bool multiselect = true)
        {
            OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Wybierz plik(i)";
            OpenFileDialog.Multiselect = multiselect;
            OpenFileDialog.Filter = "Obrazy (*.JPG;*.GIF,*.PNG)|*.JPG;*.GIF;*.PNG";

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in OpenFileDialog.FileNames)
                {
                    try
                    {
                        string name = new FileInfo(file).Name;
                        File nFile = new File();
                        nFile.Link = file;
                        nFile.Name = name;
                        nFile.Type = name.Split('.').Last();
                        if (!multiselect)
                            Items.Clear();
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
                foreach (File f in this.Items)
                {

                }
            }
        }

        public async void ShowFiles()
        {
            FileForm = new frmFiles(this, MainForm);
            FileForm.Show(MainForm);
        }

        public void OpenFile(int id)
        {
            System.Diagnostics.Process.Start(Items[id].Link);
        }

        public async Task<Image> GetImage(string name, bool min, bool save = false)
        {
            bool success = false;
            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + $"GetAttachment?token=" + Secrets.TenantToken + "&name=" + name + "&min=" + min;
                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        System.Net.Http.HttpContent content = response.Content;
                        var stream = Bitmap.FromStream(await response.Content.ReadAsStreamAsync());

                        if (save)
                        {
                            FileStream fileStream = null;
                            try
                            {
                                string path = Path.Combine(RuntimeSettings.LocalFilesPath, name);
                                fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                                await content.CopyToAsync(fileStream).ContinueWith(
                                    (copyTask) =>
                                    {
                                        fileStream.Close();
                                    });
                                success = true;
                            }
                            catch
                            {

                                if (fileStream != null)
                                {
                                    fileStream.Close();
                                }

                                throw;
                            }
                        }

                        return stream;

                    }
                    return null;
                }
            }
        }

        public async Task<bool> GetAttachment(string name, bool min)
        {
            bool success = false;
            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + $"GetAttachment?token=" + Secrets.TenantToken + "&name=" + name + "&min=" + min;
                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        System.Net.Http.HttpContent content = response.Content;

                        FileStream fileStream = null;
                        try
                        {
                            string path = Path.Combine(RuntimeSettings.LocalFilesPath, name);
                            fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                            await content.CopyToAsync(fileStream).ContinueWith(
                                (copyTask) =>
                                {
                                    fileStream.Close();
                                });
                            success = true;
                        }
                        catch
                        {

                            if (fileStream != null)
                            {
                                fileStream.Close();
                            }

                            throw;
                        }

                    }
                    return success;
                }
            }

        }

        public async Task<bool> AddAll(string args)
        {
            bool res = true;

            List<Task<bool>> tasks = new List<Task<bool>>();
            foreach (var i in Items.Where(f=>f.FileId==0))
            {
                tasks.Add(i.Add(args));
            }

            IEnumerable<bool> results = await Task.WhenAll<bool>(tasks);
            if (results.Any(r => r == false))
            {
                res = false;
            }
            return res;
        }

        public async Task<bool> RemoveAll()
        {
            List<int> rItems = new List<int>();

            if (RemovedItems.Any())
            {
                foreach (File f in RemovedItems)
                {
                    if (f.FileId > 0)
                    {
                        //make sure its saved first
                        rItems.Add(f.FileId);
                    }
                }
                await Remove(rItems);
            }
            return true;
        }

        public async Task AddToUploadQueue()
        {
            var db = new SQLiteConnection(RuntimeSettings.LocalDbPath);
            db.CreateTable<File>();
            if (Items.Any())
            {
                db.InsertAll(Items);
            }

        }

        public async Task RestoreUploadQueue()
        {
            var db = new SQLiteConnection(RuntimeSettings.LocalDbPath);
            Items = new List<File>(db.Table<File>());
        }

        public async Task Upload()
        {
            if (Items.Any())
            {
                foreach (File f in Items)
                {
                    var res = await f.Upload();
                    if (res == "OK")
                    {
                        f.IsUploaded = true;
                    }
                    else
                    {
                        f.IsUploaded = false;
                    }
                }
                await DeleteUploaded();
            }
        }

        public async Task DeleteUploaded()
        {
            var db = new SQLiteConnection(RuntimeSettings.LocalDbPath);

            foreach (File f in Items.Where(i => i.IsUploaded == true))
            {
                db.Delete<File>(f.FileId);
                Items.Remove(f);
            }
            db.Close();
        }
    }
}

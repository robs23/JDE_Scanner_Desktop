﻿using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
        public int? PartId { get; set; }
        public int? PlaceId { get; set; }
        public int? ProcessId { get; set; }
        public bool UploadKeeper { get; set; }
        public OpenFileDialog OpenFileDialog;

        public List<File> RemovedItems { get; set; }

        public FileKeeper(Form mainForm, int? partId = null, int? placeId = null, int? processId = null, bool uploadKeeper = false) : base()
        {
            if(mainForm != null)
            {
                MainForm = mainForm;
            }
                
            RemovedItems = new List<File>();
            PartId = partId;
            PlaceId = placeId;
            ProcessId = processId;
            UploadKeeper = uploadKeeper;
        }

        public async Task Initialize()
        {
            string args = null;
            if (UploadKeeper)
            {
                //it's uploadKeeper. Show all files that wait for upload in local Db
                RestoreUploadQueue();
            }
            else if(PartId != null || PlaceId != null || ProcessId != null)
            {
                if (PartId != null)
                {
                    args = $"PartId={PartId}";
                }
                else if (PlaceId != null)
                {
                    args = $"PlaceId={PlaceId}";
                }
                else if (ProcessId != null)
                {
                    args = $"ProcessId={ProcessId}";
                }
                //Bring from the cloud Db
                await this.Refresh(args);
            }
        }

        public async void LoadFromDisk(bool multiselect = true)
        { 
            OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Wybierz plik(i)";
            OpenFileDialog.Multiselect = multiselect;
            OpenFileDialog.Filter = "Obrazy (*.JPG;*.GIF,*.PNG), Filmy (*.MP4), Dokumenty (*.PDF, *.DOC, *.XLS)|*.JPG;*.GIF;*.PNG;*.MP4;*.PDF;*.DOC;*.DOCX;*.XLS;*.XLSX;*.XLSM";

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in OpenFileDialog.FileNames)
                {
                    try
                    {
                        string name = new FileInfo(file).Name;
                        long size = new FileInfo(file).Length;
                        File nFile = new File();
                        nFile.Link = file;
                        nFile.Name = name;
                        nFile.Type = name.Split('.').Last();
                        nFile.CreatedOn = DateTime.Now;
                        nFile.Size = size;
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

        public async void DownloadFromCloud()
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

        public async void OpenFile(File file)
        {
            if (file.IsUploaded == true)
            {
                //download it first

                if (!file.IsImage && !file.IsVideo)
                {
                    bool success = await GetAttachment($"{file.Token}.{file.Type}", false);
                    if (success)
                    {
                        string path = Path.Combine(RuntimeSettings.LocalFilesPath, $"{file.Token}.{file.Type}");
                        System.Diagnostics.Process.Start(path);
                    }
                    else
                    {
                        MessageBox.Show("Pobieranie pliku z serwera zakończyło się niepowodzeniem..", "Niepowodzenie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //Prefer streaming for media files
                    if(file.Token != null && file.Type != null)
                    {
                        System.Diagnostics.Process.Start($"{Secrets.ApiAddress}Files/{file.Token}.{file.Type}");
                    }
                    else
                    {
                        if(file.Token == null)
                        {
                            System.Diagnostics.Process.Start($"{Secrets.ApiAddress}Files/{file.Name}");
                        }
                        else
                        {
                            string t = System.IO.Path.GetExtension(file.Name);
                            System.Diagnostics.Process.Start($"{Secrets.ApiAddress}Files/{file.Token}{t}");
                        }
                        
                    }
                    
                }
            }
            else
            {
                if (System.IO.File.Exists(file.Link))
                {
                    System.Diagnostics.Process.Start(file.Link);
                }
                else
                {
                    MessageBox.Show($"Ten plik nie został jeszcze zsynchronizowany i na razie znajduje się tylko na urządzeniu, z którego pochodzi. Spróbuj ponownie później lub skontaktuj się z {file.CreatedByName}, który przesłał ten plik", "Plik niedostępny", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }

            
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
                await RemoveFromLocal(rItems);
                await Remove(rItems);
            }
            return true;
        }


        public async Task<string> AddToUploadQueue()
        {
            string res = "OK";

            if (!System.IO.File.Exists(Path.Combine(RuntimeSettings.LocalDbPath, "JDE_Scan.db3")))
            {
                CreateLocalDb();
            }

            string connectionString = $@"Data Source={Path.Combine(RuntimeSettings.LocalDbPath, "JDE_Scan.db3")};Version=3";
            using (var con = new SQLiteConnection(connectionString))
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                string iSql;

                foreach(File f in Items.Where(i=>i.IsUploaded == false))
                {
                    //Make sure the file exists in the location
                    //it can be someone else's file
                    if (System.IO.File.Exists(f.Link))
                    {
                        if (!ExistInUploadQueue(f.Token))
                        {
                            try
                            {
                                iSql = $"INSERT INTO Files (FileId, Name, Link, Token, IsUploaded, Type, Size, CreatedBy, CreatedOn) VALUES ({f.FileId}, '{f.Name}', '{f.Link}', '{f.Token}', {f.IsUploaded}, '{f.Type}', {f.Size}, {f.CreatedBy}, '{f.CreatedOn}')";
                                SQLiteCommand command = new SQLiteCommand(iSql, con);
                                command.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                res = $"Błąd podczas dodawania plików do kolejki. Szczegóły: {ex.ToString()}";
                                break;
                            }
                        } 
                    }
                    

                    
                }
                return res;
            }
        }

        public void CreateLocalDb()
        {
            SQLiteConnection.CreateFile(Path.Combine(RuntimeSettings.LocalDbPath, "JDE_Scan.db3"));
            string connectionString = $@"Data Source={Path.Combine(RuntimeSettings.LocalDbPath, "JDE_Scan.db3")};Version=3";
            using (var con = new SQLiteConnection(connectionString))
            {
                try
                {
                    if(con.State != System.Data.ConnectionState.Open)
                    {
                        con.Open();
                    }
                    string sql = "create table Files (FileId int, Name varchar(50), Link varchar(150), Token varchar(50) UNIQUE, IsUploaded int, Type varchar(10), Size int, CreatedBy int, CreatedOn varchar(20))";
                    SQLiteCommand command = new SQLiteCommand(sql, con);
                    command.ExecuteNonQuery();
                }catch(Exception ex)
                {

                }
                    
            }
        }

        public async Task RestoreUploadQueue()
        {
            if (!System.IO.File.Exists(Path.Combine(RuntimeSettings.LocalDbPath, "JDE_Scan.db3")))
            {
                CreateLocalDb();
            }


            string connectionString = $@"Data Source={Path.Combine(RuntimeSettings.LocalDbPath, "JDE_Scan.db3")};Version=3";
            using (var con = new SQLiteConnection(connectionString))
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                string sql = "SELECT * FROM Files";

                SQLiteCommand command = new SQLiteCommand(sql, con);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!Items.Any(i => i.Token == reader.GetString(reader.GetOrdinal("Token"))))
                        {
                            File f = new File();
                            f.FileId = reader.GetInt32(reader.GetOrdinal("FileId"));
                            f.Type = reader.GetString(reader.GetOrdinal("Type"));
                            f.Token = reader.GetString(reader.GetOrdinal("Token"));
                            f.Size = reader.GetInt64(reader.GetOrdinal("Size"));
                            f.Link = reader.GetString(reader.GetOrdinal("Link"));
                            f.Name = reader.GetString(reader.GetOrdinal("Name"));
                            f.CreatedOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn"));
                            f.CreatedBy = reader.GetInt32(reader.GetOrdinal("CreatedBy"));
                            f.IsUploaded = reader.GetBoolean(reader.GetOrdinal("IsUploaded"));
                            this.Items.Add(f);
                        }
                    }
                }
                
            }
        }

        public bool ExistInUploadQueue(string token = null, int? id = null)
        {
            bool res = false;

            string connectionString = $@"Data Source={Path.Combine(RuntimeSettings.LocalDbPath, "JDE_Scan.db3")};Version=3";
            using (var con = new SQLiteConnection(connectionString))
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                string sql = string.Empty;
                if (token != null)
                {
                    sql = $"SELECT * FROM Files WHERE Token='{token}'";
                }
                else
                {
                    if (id != null)
                    {
                        sql = $"SELECT * FROM Files WHERE FileId={id}";
                    }
                }

                if(sql != null)
                {
                    SQLiteCommand command = new SQLiteCommand(sql, con);
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        res = true;
                    }
                }
                

            }
            return res;
        }

        public async Task Upload()
        {
            if (Items.Any())
            {
                foreach (File f in Items.Where(i=>i.IsUploaded == false))
                {
                    var res = await f.Upload();
                    if (res == "OK")
                    {
                        f.IsUploaded = true;
                        SetUploaded(f.Token);
                    }
                    else
                    {
                        f.IsUploaded = false;
                    }
                }
                await DeleteUploaded();
            }
        }

        private void SetUploaded(string token)
        {
            string connectionString = $@"Data Source={Path.Combine(RuntimeSettings.LocalDbPath, "JDE_Scan.db3")};Version=3";
            using (var con = new SQLiteConnection(connectionString))
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                string iSql;

                try
                {
                    iSql = $"UPDATE Files SET IsUploaded=1 WHERE Token='{token}'";
                    SQLiteCommand command = new SQLiteCommand(iSql, con);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task DeleteUploaded()
        {
            if (!System.IO.File.Exists(Path.Combine(RuntimeSettings.LocalDbPath, "JDE_Scan.db3")))
            {
                CreateLocalDb();
            }

            string connectionString = $@"Data Source={Path.Combine(RuntimeSettings.LocalDbPath, "JDE_Scan.db3")};Version=3";
            using (var con = new SQLiteConnection(connectionString))
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                string dSql;
                string dList = "";

                foreach (File f in Items.Where(i => i.IsUploaded == true))
                {
                    dList += $"{f.FileId},";   
                }
                if (!string.IsNullOrEmpty(dList))
                {
                    dList = dList.Substring(0, dList.Length - 1);
                    dSql = $"DELETE FROM Files WHERE FileId IN ({dList})";
                    SQLiteCommand command = new SQLiteCommand(dSql, con);
                    command.ExecuteNonQuery();
                    Items.RemoveAll(i => i.IsUploaded == true);
                }
            }
        }

        public async Task<List<ImageInfo>> GetImageInfos(DateTime dateFrom, DateTime dateTo, string query = null, char type = 'p', string parameters = null)
        {
            List<ImageInfo> ImageInfos = new List<ImageInfo>();

            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + $"GetImages?token={Secrets.TenantToken}&dateFrom={dateFrom.ToString("yyyy-MM-dd HH:mm:ss")}&dateTo={dateTo.ToString("yyyy-MM-dd HH:mm:ss")}";
                if (type == 'p')
                {
                    url += "&page=1";
                }
                if (query != null)
                {
                    QueryString = query;
                    url += "&query=" + query;
                    if (this.FilterString != null)
                    {
                        url += "AND " + this.FilterString;
                    }
                }
                else
                {

                    url += "&query=" + this.FilterString;
                }
                if (parameters != null)
                {
                    url += "&" + parameters;
                }
                this.Parameters = parameters;

                if (this.PageSize != null)
                {
                    url += $"&pageSize={this.PageSize}";
                }

                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            var userJsonString = await response.Content.ReadAsStringAsync();
                            ImageInfos = JsonConvert.DeserializeObject<ImageInfo[]>(userJsonString).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Wystąpił błąd podczas deserializacji odpowiedzi z serwera. Szczegóły: {ex.ToString()}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            return ImageInfos;
        }

        public async Task RemoveFromLocal(List<int> ids)
        {
            if (!System.IO.File.Exists(Path.Combine(RuntimeSettings.LocalDbPath, "JDE_Scan.db3")))
            {
                CreateLocalDb();
            }

            string connectionString = $@"Data Source={Path.Combine(RuntimeSettings.LocalDbPath, "JDE_Scan.db3")};Version=3";
            using (var con = new SQLiteConnection(connectionString))
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                string dSql;
                string dList = "";

                foreach (int id in ids)
                {
                    //if (ExistInUploadQueue(null, id))
                    //{
                    dList += $"{id},";
                    //}
                }
                if (!string.IsNullOrEmpty(dList))
                {
                    dList = dList.Substring(0, dList.Length - 1);
                    dSql = $"DELETE FROM Files WHERE FileId IN ({dList})";
                    SQLiteCommand command = new SQLiteCommand(dSql, con);
                    command.ExecuteNonQuery();
                }
            }
        }

        public async Task<string> Save(string IdString)
        {
            //IdString = e.g. PartId=1
            string result = "OK";

            List<Task<bool>> tasks = new List<Task<bool>>();
            tasks.Add(this.AddAll(IdString));
            tasks.Add(this.RemoveAll());

            var res = await Task.WhenAll<bool>(tasks);



            if (res.Any(r => r == false))
            {
                result = "Zapis jednego lub więcej plików zakończył sie niepowodzeniem!";
            }
            else
            {
                string _res = await this.AddToUploadQueue();
                if (_res != "OK")
                {
                    //something went wrong
                    result = _res;
                }
                else
                {
                    if (RuntimeSettings.UploadKeeper != null)
                        RuntimeSettings.UploadKeeper.RestoreUploadQueue();
                }
            } 

            return result;
        }
    }
}

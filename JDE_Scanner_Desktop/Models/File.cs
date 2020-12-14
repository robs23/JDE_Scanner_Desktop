using JDE_Scanner_Desktop.Classes;
using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    [Table("Files")]
    public class File : Entity<File>
    {
        [DisplayName("ID")]
        public int FileId { get; set; }

        public override int Id
        {
            set => value = FileId;
            get => FileId;
        }

        [DisplayName("Nazwa")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        [DisplayName("Token")]
        public string Token { get; set; }
        [DisplayName("Przesłany")]
        public bool? IsUploaded { get; set; } = false;
        public bool? IsSaved { get; set; } = false;

        public async Task<bool> Add(int? PartId = null, int? PlaceId = null, int? ProcessId = null)
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    string url = Secrets.ApiAddress + $"CreateFile?token=" + Secrets.TenantToken + $"&fileJson={serializedProduct}" + "&UserId=" + RuntimeSettings.UserId + $"&PartId={PartId}&PlaceId={PlaceId}&ProcessId={ProcessId}";
                    MultipartFormDataContent content = new MultipartFormDataContent();
                    //var body = new StringContent(serializedProduct, Encoding.UTF8, "application/json");

                    try
                    {
                        using (var fileStream = System.IO.File.OpenRead(Link))
                        {
                            var fileInfo = new FileInfo(Link);
                            StreamContent fcontent = new StreamContent(fileStream);
                            fcontent.Headers.Add("Content-Type", "application/octet-stream");
                            fcontent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + fileInfo.Name + "\"");
                            content.Add(fcontent, "file", fileInfo.Name);
                            var result = await client.PostAsync(new Uri(url), content);
                            if (result.IsSuccessStatusCode)
                            {
                                var rString = await result.Content.ReadAsStringAsync();
                                AddedItem = rString;
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia rekordu. Wiadomość: " + result.ReasonPhrase);
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        //public async Task Download(bool? min = false)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        string url = Secrets.ApiAddress + $"GetFile?token=" + Secrets.TenantToken + "&id=" + this.FileId;
        //        using (var response = await client.GetAsync(new Uri(url)))
        //        {
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var userJsonString = await response.Content.ReadAsStringAsync();
        //                var vItems = JsonConvert.DeserializeObject<T[]>(userJsonString).ToList();
        //                Items.AddRange(vItems);
        //                return true;
        //            }
        //        }
        //    }
        //}

        public async Task<string> Upload()
        {
            string _Result = "OK";
            MultipartFormDataContent content = new MultipartFormDataContent();

            using (var client = new HttpClient())
            {
                var serializedProduct = JsonConvert.SerializeObject(this);
                string url = Secrets.ApiAddress + $"UploadFile?token=" + Secrets.TenantToken + $"&fileToken={this.Token}";

                try
                {
                    using (var fileStream = System.IO.File.OpenRead(Link))
                    {
                        var fileInfo = new FileInfo(Link);
                        StreamContent fcontent = new StreamContent(fileStream);
                        fcontent.Headers.Add("Content-Type", "application/octet-stream");
                        fcontent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + fileInfo.Name + "\"");
                        content.Add(fcontent, "file", fileInfo.Name);
                        var result = await client.PostAsync(new Uri(url), content);
                        if (result.IsSuccessStatusCode)
                        {
                            this.IsUploaded = true;
                        }
                        else
                        {
                            _Result = "Serwer zwrócił błąd przy próbie utworzenia rekordu. Wiadomość: " + result.ReasonPhrase;
                            this.IsUploaded = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _Result = ex.ToString();
                }
                return _Result;
            }
        }
    }
}

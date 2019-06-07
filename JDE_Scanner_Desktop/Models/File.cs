using JDE_Scanner_Desktop.Classes;
using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
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
    public class File : Entity<File>
    {
        [DisplayName("ID")]
        public int FileId { get; set; }

        public override int Id {
            set => value = FileId;
            get => FileId;
        }
        
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        [DisplayName("Token")]
        public string Token { get; set; }

        public override async Task<bool> Add()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    string url = Secrets.ApiAddress + $"CreateFile?token=" + Secrets.TenantToken + $"&fileJson={serializedProduct}" + "&UserId=" + RuntimeSettings.UserId;
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
                    catch(Exception ex)
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
    }
}

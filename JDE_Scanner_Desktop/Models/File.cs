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
                    var fileStream = System.IO.File.Open(Link, FileMode.Open);
                    var fileInfo = new FileInfo(Link);
                    MultipartFormDataContent fContent = new MultipartFormDataContent();
                    fContent.Headers.Add("filePath", Link);
                    string url = Secrets.ApiAddress + $"CreateFile?token=" + Secrets.TenantToken + "&UserId=" + RuntimeSettings.UserId;
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
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
            else
            {
                return false;
            }
        }
    }
}

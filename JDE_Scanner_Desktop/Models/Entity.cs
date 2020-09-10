using JDE_Scanner_Desktop.Classes;
using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public abstract class Entity<T>
    {
        [Browsable(false)]
        public abstract int Id { get; set; }
        [Browsable(false)]
        public int CreatedBy { get; set; }
        [DisplayName("Utworzył")]
        public string CreatedByName { get; set; }
        [DisplayName("Data utworzenia")]
        public DateTime CreatedOn { get; set; }
        [Browsable(false)]
        public int? LmBy { get; set; }
        [DisplayName("Zmodyfikował")]
        public string LmByName { get; set; }
        [DisplayName("Data modyfikacji")]
        public DateTime? LmOn { get; set; }
        [Browsable(false)]
        public int TenantId { get; set; }
        [Browsable(false)]
        public string TenantName { get; set; }
        [DisplayName("Archiwalny")]
        public bool? IsArchived { get; set; }
        [Browsable(false)]
        public string AddedItem { get; set; }

        public virtual async Task<bool> Add()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    string url = Secrets.ApiAddress + $"Create{typeof(T).Name}?token=" + Secrets.TenantToken + "&UserId=" + RuntimeSettings.UserId;
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

        public virtual async Task<bool> Add(string attachmentPath)
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                { 
                    var serializedProduct = JsonConvert.SerializeObject(this, new JsonSerializerSettings { DateFormatString = "yyyy-MM-ddTHH:mm:ss.fff" });
                    string url = Secrets.ApiAddress + $"Create{typeof(T).Name}?token=" + Secrets.TenantToken + $"&{typeof(T).Name}Json={serializedProduct}" + "&UserId=" + RuntimeSettings.UserId;
                    MultipartFormDataContent content = new MultipartFormDataContent();
                    //var body = new StringContent(serializedProduct, Encoding.UTF8, "application/json");

                    try
                    {
                        using (var fileStream = System.IO.File.OpenRead(attachmentPath))
                        {
                            var fileInfo = new FileInfo(attachmentPath);
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

        public async void Edit()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    string url = Secrets.ApiAddress + $"Edit{typeof(T).Name}?token=" + Secrets.TenantToken + "&id={0}&UserId={1}";
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync(String.Format(url, this.Id, RuntimeSettings.UserId), content);
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Edycja zakończona powodzeniem!");
                    }
                    else
                    {
                        MessageBox.Show("Serwer zwrócił błąd przy próbie edycji. Wiadomość: " + result.ReasonPhrase);
                    }
                }
            }

        }

        public async void Edit(string attachmentPath)
        {
            if (string.IsNullOrEmpty(attachmentPath))
            {
                Edit();
            }
            else
            {
                ModelValidator validator = new ModelValidator();
                if (validator.Validate(this))
                {
                    using (var client = new HttpClient())
                    {
                        var serializedProduct = JsonConvert.SerializeObject(this, new JsonSerializerSettings { DateFormatString = "yyyy-MM-ddTHH:mm:ss.fff" });
                        string url = Secrets.ApiAddress + $"Edit{typeof(T).Name}?token=" + Secrets.TenantToken + $"&id={this.Id}&UserId={RuntimeSettings.UserId}" + $"&{typeof(T).Name}Json={serializedProduct}";
                        MultipartFormDataContent content = new MultipartFormDataContent();
                        try
                        {
                            using (var fileStream = System.IO.File.OpenRead(attachmentPath))
                            {
                                var fileInfo = new FileInfo(attachmentPath);
                                StreamContent fcontent = new StreamContent(fileStream);
                                fcontent.Headers.Add("Content-Type", "application/octet-stream");
                                fcontent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + fileInfo.Name + "\"");
                                content.Add(fcontent, "file", fileInfo.Name);
                                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                                var result = await client.PutAsync(url, content);
                                if (result.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Edycja zakończona powodzeniem!");
                                }
                                else
                                {
                                    MessageBox.Show("Serwer zwrócił błąd przy próbie edycji. Wiadomość: " + result.ReasonPhrase);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Problem z wysyłką żądania do serwera. Wiadomość: " + ex.Message + ". " + ex.InnerException.Message, "Błąd żądania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            

        }
    }
}

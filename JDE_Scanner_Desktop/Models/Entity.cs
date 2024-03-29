﻿using JDE_Scanner_Desktop.Classes;
using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        [Browsable(false)]
        public bool IsSaved { get; set; } = false;

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

        public virtual async Task<bool> Add(string args)
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    string url = Secrets.ApiAddress + $"Create{typeof(T).Name}?token=" + Secrets.TenantToken + "&UserId=" + RuntimeSettings.UserId;
                    if (!string.IsNullOrEmpty(args))
                    {
                        url += $"&{args}";
                    }
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(new Uri(url), content);
                    if (result.IsSuccessStatusCode)
                    {
                        var rString = await result.Content.ReadAsStringAsync();
                        IsSaved = true;
                        AddedItem = rString;
                        return true;
                    }
                    else
                    {
                        IsSaved = false;
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



        public virtual async Task<bool> Add(string attachmentPath, string args)
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
                            fcontent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
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
                                MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia rekordu. Wiadomość: " + result.ReasonPhrase, "Nieudane żądanie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Błąd. Stack trace={ex.ToString()}","Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<string> Edit(bool DeleteImage = false)
        {
            ModelValidator validator = new ModelValidator();
            string _Res = "OK";

            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    
                    string url = Secrets.ApiAddress + $"Edit{typeof(T).Name}?token=" + Secrets.TenantToken + "&id={0}&UserId={1}";
                    if (DeleteImage)
                    {
                        url += "&DeleteImage=1";
                    }
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync(String.Format(url, this.Id, RuntimeSettings.UserId), content);
                    if (!result.IsSuccessStatusCode)
                    {
                        _Res = ("Serwer zwrócił błąd przy próbie edycji. Wiadomość: " + result.ReasonPhrase);
                    }
                }

            }
            return _Res;
        }

        public async Task<string> Edit(string attachmentPath)
        {
            string _Res = "OK";

            if (string.IsNullOrEmpty(attachmentPath))
            {
                _Res = await Edit();
            }
            else
            {
                HttpResponseMessage result;
                ModelValidator validator = new ModelValidator();
                if (validator.Validate(this))
                {
                    using (var client = new HttpClient())
                    {
                        var serializedProduct = JsonConvert.SerializeObject(this, new JsonSerializerSettings { DateFormatString = "yyyy-MM-ddTHH:mm:ss.fff" });
                        string url = Secrets.ApiAddress + $"Edit{typeof(T).Name}?token=" + Secrets.TenantToken + $"&id={this.Id}&UserId={RuntimeSettings.UserId}" + $"&{typeof(T).Name}Json={Uri.EscapeDataString(serializedProduct)}";
                        MultipartFormDataContent content = new MultipartFormDataContent();
                        try
                        {
                            using (var fileStream = System.IO.File.OpenRead(attachmentPath))
                            {
                                var fileInfo = new FileInfo(attachmentPath);
                                StreamContent fcontent = new StreamContent(fileStream);
                                fcontent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                                fcontent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + fileInfo.Name + "\"");
                                content.Add(fcontent, "file", fileInfo.Name);
                                result = await client.PutAsync(url, content);
                                if (!result.IsSuccessStatusCode)
                                {
                                    _Res = "Serwer zwrócił błąd przy próbie edycji. Wiadomość: " + result.ReasonPhrase;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Problem z wysyłką żądania do serwera. Wiadomość: " + ex.ToString(), "Błąd żądania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _Res = "Problem z wysyłką żądania do serwera. Wiadomość: " + ex.ToString();
                        }
                    }
                }
            }
            return _Res;

        }
    }
}

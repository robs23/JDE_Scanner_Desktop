﻿using JDE_Scanner_Desktop.Classes;
using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using MimeTypes;

namespace JDE_Scanner_Desktop.Models
{
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
        [DisplayName("Typ")]
        public string Type { get; set; }
        [DisplayName("Rozmiar")]
        public long Size { get; set; }
        public double SizeInMB
        {
            get
            {
                return (double)Size / 1048576;
            }
        }

        public bool IsImage
        {
            get
            {
                string[] imageFormats = { "png", "jpg", "jpeg", "gif" };
                bool res = false;
                
                if (!string.IsNullOrEmpty(Type))
                {
                    if (imageFormats.Contains(Type.ToLower().Trim()))
                    {
                        res = true;
                    }
                }else if (!string.IsNullOrEmpty(Name))
                {
                    if (imageFormats.Contains(Name.Split('.').Last().ToLower().Trim()))
                    {
                        res = true;
                    }
                }
                return res;
            }
        }

        public bool IsVideo
        {
            get
            {
                string[] videoFormats = { "mp4", "avi" };
                bool res = false;

                if (!string.IsNullOrEmpty(Type))
                {
                    if (videoFormats.Contains(Type.ToLower().Trim()))
                    {
                        res = true;
                    }
                }
                else if (!string.IsNullOrEmpty(Name))
                {
                    if (videoFormats.Contains(Name.Split('.').Last().ToLower().Trim()))
                    {
                        res = true;
                    }
                }
                return res;
            }
        }

        public Image ThumbnailPlaceholder
        {
            get
            {
                Image res = new Bitmap(JDE_Scanner_Desktop.Properties.Resources.icon_unknown);
                string[] excels = { "xls", "xlsx", "xlsm" };
                string[] words = { "doc", "docx", "docm" };
                string[] videos = { "mp4", "avi" };

                if (IsImage)
                {
                    //if (IsUploaded==true)
                    //{
                    //    //prefer online thumb
                    //    //first load placeholder local img
                    //    //to be replaced wtih downloaded file
                    //    res = new Bitmap(JDE_Scanner_Desktop.Properties.Resources.Image_icon_64);
                    //}
                    //else
                    //{
                    //    //get from disk
                    //    res = Image.FromFile(Link);
                    //}
                    res = new Bitmap(JDE_Scanner_Desktop.Properties.Resources.Image_icon_64);
                }
                else
                {
                    if (excels.Contains(Type.ToLower().Trim()))
                    {
                        res = new Bitmap(JDE_Scanner_Desktop.Properties.Resources.icon_excel);
                    }
                    if (words.Contains(Type.ToLower().Trim()))
                    {
                        res = new Bitmap(JDE_Scanner_Desktop.Properties.Resources.icon_word);
                    }
                    if (videos.Contains(Type.ToLower().Trim()))
                    {
                        res = new Bitmap(JDE_Scanner_Desktop.Properties.Resources.icon_video);
                    }
                    if(Type.ToLower().Trim() == "pdf")
                    {
                        res = new Bitmap(JDE_Scanner_Desktop.Properties.Resources.icon_pdf);
                    }
                }
                return res;
            }
        }

        public async Task<Image> GetPreview()
        {
            Image res = null;
            if (IsUploaded==true)
            {
                //try to get online thumb
                if (this.Token != null && this.Type != null)
                {
                    res = await new FileKeeper(null).GetImage($"{this.Token}.{this.Type}", true);
                }
                else
                {
                    if (this.Token == null)
                    {
                        res = await new FileKeeper(null).GetImage($"{this.Name}", true);
                    }
                    else
                    {
                        string t = System.IO.Path.GetExtension(this.Name);
                        res = await new FileKeeper(null).GetImage($"{this.Token}{t}", true);
                    }
                }
                    
            }
            else
            {
                res = Image.FromFile(Link);
                res = res.Resize(50, 50);
            }
            return res;
        }


        public async override Task<bool> Add(string args = null)
        {
            bool x;
            if (args == null)
            {
                x = await base.Add();
            }
            else
            {
                x = await base.Add(args);
            }

            if (x)
            {
                try
                {
                    File _this = JsonConvert.DeserializeObject<File>(AddedItem);
                    this.FileId = _this.FileId;
                    this.Token = _this.Token;
                    this.TenantId = _this.TenantId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> Upload()
        {
            string _Result = "OK";
            MultipartFormDataContent content = new MultipartFormDataContent();

            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + $"UploadFile?token=" + Secrets.TenantToken + $"&fileToken={this.Token}";

                try
                {
                    using (var fileStream = System.IO.File.OpenRead(Link))
                    {
                        var fileInfo = new FileInfo(Link);
                        StreamContent fcontent = new StreamContent(fileStream); 
                        fcontent.Headers.ContentType = new MediaTypeHeaderValue(MimeTypeMap.GetMimeType(fileInfo.Extension));
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

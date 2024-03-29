﻿using FontAwesome.Sharp;
using JDE_Scanner_Desktop.Models;
using JDE_Scanner_Desktop.Static;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop
{
    public static class RuntimeSettings
    {
        public static int TenantId { get; set; }
        
        public static int UserId { get; set; }

        public static User CurrentUser { get; set; }

        public static int PageSize { get; set; }

        public async static void GetPageSize()
        {
            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "PageSize";
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(new Uri(url)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var reply = response.Content.ReadAsStringAsync();
                            PageSize = Convert.ToInt32(reply.Result);
                        }
                        else
                        {
                            PageSize = 200;
                        }
                    }
                }
                catch (Exception)
                {
                    PageSize = 200;
                }
            }
        }

        public static string ThumbnailsPath { get { return "Files/Thumbnails/"; } }
        public static string FilesPath { get { return "Files/"; } }

        public static string LocalFilesPath {
            get {
                CreateLocalFilesFolders();
                return Path.Combine(LocalFilesPathRoot, "JDE_Scan", "Files") ;
            }
        }

        public static string LocalDbPath
        {
            get 
            {
                CreateLocalFilesFolders();
                return Path.Combine(LocalFilesPathRoot, "JDE_Scan", "Upload"); 
            }
        }

        public static string LocalFilesPathRoot
        {
            get
            {
                //return C:\Users\<User_name>\AppData\Local\Temp\
                return Path.GetTempPath();
            }
        }

        public static void CreateLocalFilesFolders()
        {
            if (!Directory.Exists(Path.Combine(LocalFilesPathRoot, "JDE_Scan")))
                Directory.CreateDirectory(Path.Combine(LocalFilesPathRoot, "JDE_Scan"));
            if (!Directory.Exists(Path.Combine(LocalFilesPathRoot, "JDE_Scan", "Files")))
                Directory.CreateDirectory(Path.Combine(LocalFilesPathRoot, "JDE_Scan", "Files"));
            if (!Directory.Exists(Path.Combine(LocalFilesPathRoot, "JDE_Scan", "Files", "Thumbnails")))
                Directory.CreateDirectory(Path.Combine(LocalFilesPathRoot, "JDE_Scan", "Files", "Thumbnails"));
            if (!Directory.Exists(Path.Combine(LocalFilesPathRoot, "JDE_Scan", "Upload")))
                Directory.CreateDirectory(Path.Combine(LocalFilesPathRoot, "JDE_Scan", "Upload"));
        }

        public static FileKeeper UploadKeeper { get; set; }

        public static Dictionary<string, IconChar> ProcessIcons = new Dictionary<string, IconChar>()
        {
            {"Awaria", IconChar.ExclamationTriangle },
            {"Konserwacja", IconChar.Tasks },
            {"Smarowanie", IconChar.OilCan },
            {"Karta Defektu", IconChar.Paperclip },
            {"Usterka", IconChar.Tools },
            {"Regulacja", IconChar.SlidersH },
        };
        public static Dictionary<string, Color> ProcessColors = new Dictionary<string, Color>()
        {
            {"Awaria", Color.OrangeRed },
            {"Konserwacja", Color.FromArgb(65,140,240) },
            {"Smarowanie", Color.MediumPurple }, //Color.FromArgb(252,180,65) },
            {"Karta Defektu", Color.LightGreen },
            {"Usterka", Color.DarkOrange },
            {"Pozostałe", Color.LightGray },
            {"Regulacja", Color.Gold }
        };


        public static string ConnectionUnavailableMessage { get; set; } = "Nie można połączyć się z serwerem, prawdopodobnie utraciłeś połączenie z internetem. Jeśli łaczysz się zdalnie, upewnij się że jesteś zalogowany do korporacyjnego VPNa";

        public static PartKeeper PartBackup { get; set; }
    }
}

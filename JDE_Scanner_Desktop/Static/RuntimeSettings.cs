﻿using JDE_Scanner_Desktop.Models;
using JDE_Scanner_Desktop.Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop
{
    public static class RuntimeSettings
    {
        public static int TenantId { get; set; }
        
        public static int UserId { get; set; }

        public static int PageSize { get; set; }

        public async static void GetPageSize()
        {
            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "PageSize";
                using (HttpResponseMessage response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var reply = response.Content.ReadAsStringAsync();
                        PageSize =  Convert.ToInt32(reply.Result);
                    }
                    else
                    {
                        PageSize =  200;
                    }
                }
            }
        }

        public static string LocalFilesPath {
            get {
                CreateLocalFilesFolders();
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JDE_Scan", "Files") ;
            }
        }

        public static void CreateLocalFilesFolders()
        {
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JDE_Scan")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JDE_Scan"));
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JDE_Scan", "Files")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JDE_Scan", "Files"));
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JDE_Scan", "Files", "Thumbnails")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JDE_Scan", "Files", "Thumbnails"));
        }
    }
}

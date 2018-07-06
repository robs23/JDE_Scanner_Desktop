using JDE_Scanner_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop
{
    public static class RuntimeSettings
    {
        public static int TenantId { get; set; }
        public static string TenantToken
        {
            get
            {
                return "zyjp7h38DE205BpjzLqWw";
            }
        }
        public static string ApiAddress
        {
            get
            {
                return "http://jde_api.robs23.webserwer.pl/";
            }
        }

        public static int UserId { get; set; }

        public static int PageSize { get; set; }

        public async static void GetPageSize()
        {
            using (var client = new HttpClient())
            {
                string url = RuntimeSettings.ApiAddress + "PageSize";
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
    }
}

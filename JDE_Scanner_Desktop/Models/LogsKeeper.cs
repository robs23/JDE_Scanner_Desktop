using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class LogsKeeper : Keeper<Log>
    {
        protected override string ObjectName => "Log";

        protected override string PluralizedObjectName => "Logs";

        public async Task GetProcessHistory(int ProcessId)
        {
            if (Items.Any())
            {
                Items.Clear();
            }

            using (var client = new HttpClient())
            {

                string url = Secrets.ApiAddress + "GetProcessHistory?token=" + Secrets.TenantToken + $"&id={ProcessId}";


                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var userJsonString = await response.Content.ReadAsStringAsync();
                        Items = JsonConvert.DeserializeObject<Log[]>(userJsonString).ToList();
                    }
                }
            }
        }

    }
}

using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class HandlingsKeeper : Keeper<Handling>
    {

        protected override string ObjectName => "Handling";

        protected override string PluralizedObjectName => "Handlings";

        

        public async Task GetByProcessId(int ProcessId)
        {
            if (Items.Any())
            {
                Items.Clear();
            }

            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + string.Format("GetHandlings?token={0}&query=ProcessId={1}", Secrets.TenantToken, ProcessId);
                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var userJsonString = await response.Content.ReadAsStringAsync();
                        Items = JsonConvert.DeserializeObject<Handling[]>(userJsonString).ToList();
                    }
                }
            }
        }
    }
}

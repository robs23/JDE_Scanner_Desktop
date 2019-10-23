using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class ProcessActionsKeeper : Keeper<ProcessAction>
    {
        protected override string ObjectName => "ProcessAction";

        protected override string PluralizedObjectName => "ProcessActions";

        public async Task GetByProcessId(int ProcessId)
        {
            if (Items.Any())
            {
                Items.Clear();
            }

            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + $"Get{PluralizedObjectName}?token={Secrets.TenantToken}&query=ProcessId={ProcessId}";
                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var userJsonString = await response.Content.ReadAsStringAsync();
                        Items = JsonConvert.DeserializeObject<ProcessAction[]>(userJsonString).ToList();
                    }
                }
            }
        }
    }
}

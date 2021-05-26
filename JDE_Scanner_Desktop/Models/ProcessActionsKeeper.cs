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
    public class ProcessActionsKeeper : Keeper<ProcessAction>
    {
        protected override string ObjectName => "ProcessAction";

        protected override string PluralizedObjectName => "ProcessActions";

        public async Task<List<dynamic>> GetProcessActionStats(int year, int week, Enums.ProcessActionStatsDivisionType divisionType, int actionTypeId)
        {
            List<dynamic> Stats = new List<dynamic>();

            string url = string.Empty;
            if(divisionType == Enums.ProcessActionStatsDivisionType.Daily)
            {
                url = Secrets.ApiAddress + $"GetDoneActionsDaily?token={Secrets.TenantToken}&year={year}&week={week}&actionTypeId={actionTypeId}&cumulative=true";
            }

            if (!string.IsNullOrEmpty(url))
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(new Uri(url)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            try
                            {
                                var userJsonString = await response.Content.ReadAsStringAsync();
                                Stats = JsonConvert.DeserializeObject<dynamic[]>(userJsonString).ToList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Wystąpił błąd podczas deserializacji odpowiedzi z serwera. Szczegóły: {ex.ToString()}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }

            return Stats;
        }

    }
}

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
    public class ProcessesKeeper : Keeper<Process>
    {

        protected override string ObjectName => "Process";

        protected override string PluralizedObjectName => "Processes";


        public void Finish(List<int> ids)
        {
            DialogResult result = MessageBox.Show("Czy jesteś pewien, że chcesz zamknąć " + ids.Count.ToString() + " zaznaczone zgłoszenia?", "Potwierdź zamknięcie zgłoszeń", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                foreach (int id in ids)
                {
                    _Finish(id);
                }
            }
        }

        private async void _Finish(int id)
        {
            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "CompleteProcess?token=" + Secrets.TenantToken + "&id={0}&UserId={1}";
                var result = await client.PutAsync(String.Format(url, id, RuntimeSettings.UserId),null);
                if (!result.IsSuccessStatusCode)
                {
                    MessageBox.Show(String.Format("Serwer zwrócił błąd przy próbie usunięcia zgłoszenia {0}. Wiadomość: " + result.ReasonPhrase, id));
                }
            }
        }

        public async Task ReassignUsers(List<int> ids, List<User> Users)
        {
            //it reassignes users to multiple process

            DialogResult result = MessageBox.Show("Czy jesteś pewien, że chcesz zmienić przypisanie obsługujących w " + ids.Count.ToString() + " zaznaczonych zgłoszeniach?", "Potwierdź zmianę przypisanych obsługujących", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                List<Process> Processes = new List<Process>();
                foreach(int id in ids)
                {
                    Processes.Add(new Process() { ProcessId = id });
                }

                List<Task<string>> ListsOfTasks = new List<Task<string>>();

                foreach (Process p in Processes)
                {
                    ListsOfTasks.Add(p.AssignUsers(Users));
                }

                string response = "";
                IEnumerable<string> res = await Task.WhenAll<string>(ListsOfTasks);
                if (res.Any())
                {
                    foreach (string r in res)
                    {
                        if (!string.IsNullOrEmpty(r))
                        {
                            response += r + "\r";
                        }
                    }
                    if (response.Length > 0)
                    {
                        MessageBox.Show(response);
                    }
                }
            }
        }

        public async Task AddComment(List<int> ids, string comment)
        {
            //it adds comment to multiple process

            List<Process> Processes = new List<Process>();
            foreach (int id in ids)
            {
                Processes.Add(new Process() { ProcessId = id });
            }

            List<Task<string>> ListsOfTasks = new List<Task<string>>();

            foreach (Process p in Processes)
            {
                ListsOfTasks.Add(p.AddComment(comment));
            }

            string response = "";
            IEnumerable<string> res = await Task.WhenAll<string>(ListsOfTasks);
            if (res.Any())
            {
                foreach (string r in res)
                {
                    if (!string.IsNullOrEmpty(r))
                    {
                        response += r + "\r";
                    }
                }
                if (response.Length > 0)
                {
                    MessageBox.Show(response);
                }
            }
        }

        public async Task<dynamic> GetProcessStats(DateTime dateFrom, DateTime dateTo)
        {
            List<dynamic> Stats = new List<dynamic>();

            string url = Secrets.ApiAddress + $"GetProcessStats?token={Secrets.TenantToken}&dateFrom={dateFrom}&dateTo={dateTo}";

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

            return Stats;
        }
        
    }
}
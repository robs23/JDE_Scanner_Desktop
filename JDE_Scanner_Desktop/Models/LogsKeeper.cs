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
    public class LogsKeeper : IKeptable
    {
        public List<Log> Items { get; set; }
        public string FilterString { get; set; } = null;

        public LogsKeeper()
        {
            Items = new List<Log>();
        }

        public void Remove(List<int> ids)
        {
            DialogResult result = MessageBox.Show("Czy jesteś pewien, że chcesz usunąć " + ids.Count.ToString() + " zaznaczone wiersze?", "Potwierdź usunięcie", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                foreach(int id in ids)
                {
                    _Remomve(id);
                }
            }
        }

        private async void _Remomve(int id)
        {
            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "DeleteLog?token=" + Secrets.TenantToken + "&id=";
                var result = await client.DeleteAsync(String.Format("{0}{1}", new Uri(url), id));
                if (!result.IsSuccessStatusCode)
                {
                    MessageBox.Show(String.Format("Serwer zwrócił błąd przy próbie usunięcia logu {0}. Wiadomość: " + result.ReasonPhrase,id));
                }
            }
        }

        public async Task Refresh()
        {
            if (Items.Any())
            {
                Items.Clear();
            }

            using (var client = new HttpClient())
            {

                string url = Secrets.ApiAddress + "GetLogs?token=" + Secrets.TenantToken + "&page=" + 1;
                if (!string.IsNullOrEmpty(FilterString))
                {
                    url += "&query=" + FilterString;
                }
                
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

        public async Task<bool> GetMore(int page)
        {

            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "GetLogs?token=" + Secrets.TenantToken + "&page=" + page;
                if (!string.IsNullOrEmpty(FilterString))
                {
                    url += "&query=" + FilterString;
                }

                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var userJsonString = await response.Content.ReadAsStringAsync();
                        var vItems = JsonConvert.DeserializeObject<Log[]>(userJsonString).ToList();
                        Items.AddRange(vItems);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

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

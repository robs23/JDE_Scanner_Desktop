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
    public class LogsKeeper
    {
        public List<Log> Items { get; set; }

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
                string url = RuntimeSettings.ApiAddress + "DeleteLog?token=" + RuntimeSettings.TenantToken + "&id=";
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
                string url = RuntimeSettings.ApiAddress + "GetLogs?token=" + RuntimeSettings.TenantToken;
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

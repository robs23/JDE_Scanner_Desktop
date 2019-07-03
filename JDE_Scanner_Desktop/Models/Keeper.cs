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
    public interface IKeptable
    {
        string FilterString { get; set; }
    }

    public abstract class Keeper<T> : IKeptable
    {
        public List<T> Items { get; set; } 
        protected abstract string ObjectName { get;}
        protected abstract string PluralizedObjectName { get;}

        public string FilterString { get; set; } = null;

        public Keeper()
        {
            Items = new List<T>();
        }

        

        public async Task Remove(List<int> ids)
        {
            DialogResult result = MessageBox.Show("Czy jesteś pewien, że chcesz usunąć " + ids.Count.ToString() + " zaznaczone wiersze?", "Potwierdź usunięcie", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                List<Task<string>> ListsOfTasks = new List<Task<string>>();

                foreach (int id in ids)
                {
                    ListsOfTasks.Add(_Remomve(id)); 
                }

                string response = "";
                IEnumerable<string> res = await Task.WhenAll<string>(ListsOfTasks);
                if (res.Any())
                {
                    foreach(string r in res)
                    {
                        if (!string.IsNullOrEmpty(r))
                        {
                            response += r + "\r";
                        }
                    }
                    if(response.Length > 0)
                    {
                        MessageBox.Show(response);
                    }
                }
            }
        }

        private async Task<string> _Remomve(int id)
        {
            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + $"Delete{ObjectName}?token=" + Secrets.TenantToken + "&id={0}&UserId={1}";
                var result = await client.DeleteAsync(String.Format(url, id, RuntimeSettings.UserId));
                if (!result.IsSuccessStatusCode)
                {
                    return String.Format("Serwer zwrócił błąd przy próbie usunięcia pozycji {0}. Wiadomość: " + result.ReasonPhrase, id);
                }
                return null;
            }
        }

        public async Task Refresh(string query = null, char type='p')
        {
            if (Items.Any())
            {
                Items.Clear();
            }

            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + $"Get{PluralizedObjectName}?token=" + Secrets.TenantToken;
                if (type == 'p')
                {
                    url += "&page=1";
                }
                if (query != null)
                {
                    url += "&query=" + query;
                    if (this.FilterString != null)
                    {
                        url += "AND " + this.FilterString;
                    }
                }
                else
                {
                    url += "&query=" + this.FilterString;
                }

                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var userJsonString = await response.Content.ReadAsStringAsync();
                        Items = JsonConvert.DeserializeObject<T[]>(userJsonString).ToList();
                    }
                }
            }
        }

        public async Task<bool> GetMore(int page)
        {

            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + $"Get{PluralizedObjectName}?token=" + Secrets.TenantToken + "&page=" + page;
                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var userJsonString = await response.Content.ReadAsStringAsync();
                        var vItems = JsonConvert.DeserializeObject<T[]>(userJsonString).ToList();
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
    }
}

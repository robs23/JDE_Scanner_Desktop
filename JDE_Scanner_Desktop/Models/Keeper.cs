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
        string QueryString { get; set; }
    }

    public interface IArchivable
    {
        string ArchiveString { get; set; }
    }

    public abstract class Keeper<T> : IKeptable
    {
        public List<T> Items { get; set; } 
        protected abstract string ObjectName { get;}
        protected abstract string PluralizedObjectName { get;}

        protected virtual string ArchiveString { get; set; } = null;

        public string FilterString { get; set; } = null;
        public string QueryString { get; set; } = null;
        public string Parameters { get; set; }

        public int? PageSize { get; set; }

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

        public async Task Archive(List<int> ids)
        {
            DialogResult result = MessageBox.Show("Czy jesteś pewien, że chcesz zarchiwizować " + ids.Count.ToString() + " zaznaczone wiersze?", "Potwierdź archiwizacje", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                List<Task<string>> ListsOfTasks = new List<Task<string>>();

                foreach (int id in ids)
                {
                    ListsOfTasks.Add(_Archive(id));
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

        private async Task<string> _Archive(int id)
        {
            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + $"Archive{ObjectName}?token=" + Secrets.TenantToken + "&id={0}&UserId={1}";
                var result = await client.GetAsync(String.Format(url, id, RuntimeSettings.UserId));
                if (!result.IsSuccessStatusCode)
                {
                    return String.Format("Serwer zwrócił błąd przy próbie usunięcia pozycji {0}. Wiadomość: " + result.ReasonPhrase, id);
                }
                return null;
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

        public async Task Refresh(string query = null, char type='p', string parameters=null)
        {
            if (this.ArchiveString!=null)
            {
                if (!this.QueryString.ContainsNullSafe("IsArchived") && !this.FilterString.ContainsNullSafe("IsArchived") && !query.ContainsNullSafe("IsArchived"))
                {
                    if (!string.IsNullOrEmpty(this.FilterString))
                    {
                        FilterString += " AND " + ArchiveString;
                    }
                    else
                    {
                        FilterString = ArchiveString;
                    }
                } 
            }
            
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
                    QueryString = query;
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
                if (parameters != null)
                {
                    url += "&" + parameters;
                }
                this.Parameters = parameters;

                if (this.PageSize != null)
                {
                    url += $"&pageSize={this.PageSize}";
                }

                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            var userJsonString = await response.Content.ReadAsStringAsync();
                            Items = JsonConvert.DeserializeObject<T[]>(userJsonString).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Wystąpił błąd podczas deserializacji odpowiedzi z serwera. Szczegóły: {ex.ToString()}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        }
                    }
                }
            }
        }

        

        public async Task<bool> GetMore(int page)
        {

            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + $"Get{PluralizedObjectName}?token=" + Secrets.TenantToken + "&page=" + page;
                if (QueryString != null)
                {
                    url += "&query=" + QueryString;
                    if (this.FilterString != null)
                    {
                        url += "AND " + this.FilterString;
                    }
                }
                else
                {
                    url += "&query=" + this.FilterString;
                }
                if (this.Parameters != null)
                {
                    url += "&" + this.Parameters;
                }
                if (this.PageSize != null)
                {
                    url += $"&pageSize={this.PageSize}";
                }
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
                        Items = JsonConvert.DeserializeObject<T[]>(userJsonString).ToList();
                    }
                }
            }
        }


        public virtual async Task<string> AddAll(List<Entity<T>> items = null, string args=null)
        {
            string res = "OK";

            List<Task<bool>> tasks = new List<Task<bool>>();

            if(items != null)
            {
                foreach (var i in items)
                {
                    tasks.Add(i.Add(args));
                }
            }
            else
            {
                foreach(var i in Items)
                {
                    tasks.Add((i as Entity<T>).Add(args));
                }
            }
            

            IEnumerable<bool> results = await Task.WhenAll<bool>(tasks);
            if (results.Any(r => r == false))
            {
                res = "Wystąpił błąd podczas zapisywania niektórych pozycji..";
            }
            return res;
        }

        public virtual async Task<string> EditAll(List<Entity<T>> items = null, string args=null)
        {
            string res = "OK";

            List<Task<string>> tasks = new List<Task<string>>();

            if (items != null)
            {
                foreach (var i in items)
                {
                    tasks.Add(i.Edit());
                }
            }
            else
            {
                foreach (var i in Items)
                {
                    tasks.Add((i as Entity<T>).Edit());
                }
            }

            IEnumerable<string> results = await Task.WhenAll<string>(tasks);
            if (results.Any(r => r != "OK"))
            {
                res = "Wystąpił błąd podczas zapisywania niektórych pozycji..";
            }
            return res;
        }
    }
}

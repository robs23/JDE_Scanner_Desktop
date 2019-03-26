﻿using JDE_Scanner_Desktop.Static;
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
    public class ProcessesKeeper
    {
        public List<Process> Items { get; set; }

        public ProcessesKeeper()
        {
            Items = new List<Process>();
        }

        public void Remove(List<int> ids)
        {
            DialogResult result = MessageBox.Show("Czy jesteś pewien, że chcesz usunąć " + ids.Count.ToString() + " zaznaczone wiersze?", "Potwierdź usunięcie", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                foreach (int id in ids)
                {
                    _Remomve(id);
                }
            }
        }

        private async void _Remomve(int id)
        {
            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "DeleteProcess?token=" + Secrets.TenantToken + "&id={0}&UserId={1}";
                var result = await client.DeleteAsync(String.Format(url, id, RuntimeSettings.UserId));
                if (!result.IsSuccessStatusCode)
                {
                    MessageBox.Show(String.Format("Serwer zwrócił błąd przy próbie usunięcia zgłoszenia {0}. Wiadomość: " + result.ReasonPhrase, id));
                }
            }
        }

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

        public async Task Refresh()
        {
            if (Items.Any())
            {
                Items.Clear();
            }

            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "GetProcesses?token=" + Secrets.TenantToken + "&page=1";
                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var userJsonString = await response.Content.ReadAsStringAsync();
                        Items = JsonConvert.DeserializeObject<Process[]>(userJsonString).ToList();
                    }
                }
            }
        }

        public async Task<bool> GetMore(int page)
        {

            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "GetProcesses?token=" + Secrets.TenantToken + "&page=" + page;
                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var userJsonString = await response.Content.ReadAsStringAsync();
                        var vItems = JsonConvert.DeserializeObject<Process[]>(userJsonString).ToList();
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
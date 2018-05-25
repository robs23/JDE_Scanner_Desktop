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
    public class Set
    {
        public int SetId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int TenantId { get; set; }
        public string TenantName { get; set; }

        public async void Add()
        {
            using (var client = new HttpClient())
            {
                string url = RuntimeSettings.ApiAddress + "CreateSet?token=" + RuntimeSettings.TenantToken;
                var serializedProduct = JsonConvert.SerializeObject(this);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(new Uri(url), content);
                //if (result.IsSuccessStatusCode)
                //{
                MessageBox.Show("Tworzenie instalacji zakończone powodzeniem!");
                //}
                //else
                //{
                //    MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia użytkownika. Wiadomość: " + result.ReasonPhrase);
                //}
            }
        }

        public async void Edit()
        {
            using (var client = new HttpClient())
            {
                string url = RuntimeSettings.ApiAddress + "EditSet?token=" + RuntimeSettings.TenantToken + "&id=";
                var serializedProduct = JsonConvert.SerializeObject(this);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(String.Format("{0}{1}", new Uri(url), this.SetId), content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Edycja instalacji zakończona powodzeniem!");
                }
                else
                {
                    MessageBox.Show("Serwer zwrócił błąd przy próbie edycji obszaru. Wiadomość: " + result.ReasonPhrase);
                }
            }

        }
    }
}

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
    public class User
    {
        public int UserId { get; set; }
        public int TenantId { get; set; }
        public string TenantName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public bool IsMechanic { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastLoggedOn { get; set; }
        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }

        public async void Add()
        {
            using (var client = new HttpClient())
            {
                string url = RuntimeSettings.ApiAddress + "CreateUser?token=" + RuntimeSettings.TenantToken;
                var serializedProduct = JsonConvert.SerializeObject(this);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(new Uri(url), content);
                //if (result.IsSuccessStatusCode)
                //{
                MessageBox.Show("Tworzenie użytkownika zakończone powodzeniem!");
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
                string url = RuntimeSettings.ApiAddress + "EditUser?token=" + RuntimeSettings.TenantToken + "&id=";
                var serializedProduct = JsonConvert.SerializeObject(this);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(String.Format("{0}{1}", new Uri(url), this.UserId), content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Edycja użytkownika zakończona powodzeniem!");
                }
                else
                {
                    MessageBox.Show("Serwer zwrócił błąd przy próbie edycji użytkownika. Wiadomość: " + result.ReasonPhrase);
                }
            }

        }
    }
}

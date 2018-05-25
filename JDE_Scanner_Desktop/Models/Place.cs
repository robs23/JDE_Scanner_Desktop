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
    public class Place
    {
        public int PlaceId { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int SetId { get; set; }
        public string SetName { get; set; }
        public string Priority { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public int TenantId { get; set; }
        public string TenantName { get; set; }
        public string PlaceToken { get; set; }
        public bool IsValid {
            get
            {
                if(AreaId==0 || SetId == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            } }

        public async void Add()
        {
            using (var client = new HttpClient())
            {
                string url = RuntimeSettings.ApiAddress + "CreatePlace?token=" + RuntimeSettings.TenantToken;
                var serializedProduct = JsonConvert.SerializeObject(this);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(new Uri(url), content);
                //if (result.IsSuccessStatusCode)
                //{
                MessageBox.Show("Tworzenie zasobu zakończone powodzeniem!");
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
                string url = RuntimeSettings.ApiAddress + "EditPlace?token=" + RuntimeSettings.TenantToken + "&id=";
                var serializedProduct = JsonConvert.SerializeObject(this);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(String.Format("{0}{1}", new Uri(url), this.PlaceId), content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Edycja zasobu zakończona powodzeniem!");
                }
                else
                {
                    MessageBox.Show("Serwer zwrócił błąd przy próbie edycji użytkownika. Wiadomość: " + result.ReasonPhrase);
                }
            }

        }
    }
}



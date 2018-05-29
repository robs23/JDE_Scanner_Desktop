using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using JDE_Scanner_Desktop.Classes;

namespace JDE_Scanner_Desktop.Models
{
    public class Place
    {
        [DisplayName("ID")]
        public int PlaceId { get; set; }
        [DisplayName("Numer")]
        public string Number1 { get; set; }
        [Browsable(false)]
        public string Number2 { get; set; }
        [DisplayName("Nazwa")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Pole nazwa nie może być puste!")]
        public string Name { get; set; }
        [Browsable(false)]
        public string Description { get; set; }
        [Browsable(false)]
        [Range(1, int.MaxValue, ErrorMessage = "Wybierz obszar z rozwijanej listy!")]
        public int AreaId { get; set; }
        [DisplayName("Obszar")]
        public string AreaName { get; set; }
        [Browsable(false)]
        [Range(1,int.MaxValue, ErrorMessage ="Wybierz instalacje z rozwijanej listy!")]
        public int SetId { get; set; }
        [DisplayName("Instalacja")]
        public string SetName { get; set; }
        [DisplayName("Priorytet")]
        public string Priority { get; set; }
        [DisplayName("Data utworzenia")]
        public DateTime? CreatedOn { get; set; }
        [Browsable(false)]
        public int CreatedBy { get; set; }
        [DisplayName("Utworzył")]
        public string CreatedByName { get; set; }
        [Browsable(false)]
        public int TenantId { get; set; }
        [Browsable(false)]
        public string TenantName { get; set; }
        [Browsable(false)]
        public string PlaceToken { get; set; }
        [Browsable(false)]

        public async void Add()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
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
        }

        public async void Edit()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
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
}



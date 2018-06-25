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
    public class ActionType
    {
        [DisplayName("ID")]
        public int ActionTypeId { get; set; }
        [DisplayName("Nazwa")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Pole nazwa nie może być puste!")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Data utworzenia")]
        public DateTime CreatedOn { get; set; }
        [Browsable(false)]
        public int CreatedBy { get; set; }
        [DisplayName("Utworzył")]
        public string CreatedByName { get; set; }
        [Browsable(false)]
        public int TenantId { get; set; }
        [Browsable(false)]
        public string TenantName { get; set; }

        public async void Add()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    string url = RuntimeSettings.ApiAddress + "CreateActionType?token=" + RuntimeSettings.TenantToken + "&UserId=" + RuntimeSettings.UserId;
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(new Uri(url), content);
                    if (result.IsSuccessStatusCode)
                    {
                        var rString = await result.Content.ReadAsStringAsync();
                        ActionType _this = JsonConvert.DeserializeObject<ActionType>(rString);
                        this.ActionTypeId = _this.ActionTypeId;
                        MessageBox.Show("Tworzenie typu zlecenia zakończone powodzeniem!");
                    }
                    else
                    {
                        MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia typu zlecenia. Wiadomość: " + result.ReasonPhrase);
                    }
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
                    string url = RuntimeSettings.ApiAddress + "EditActionType?token=" + RuntimeSettings.TenantToken + "&id={0}&UserId={1}";
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync(String.Format(url, this.ActionTypeId, RuntimeSettings.UserId), content);
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Edycja typu zlecenia zakończona powodzeniem!");
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

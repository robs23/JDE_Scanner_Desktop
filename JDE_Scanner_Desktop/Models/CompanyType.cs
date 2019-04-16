using JDE_Scanner_Desktop.Classes;
using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class CompanyType
    {
        [DisplayName("ID")]
        public int CompanyTypeId { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [Browsable(false)]
        public Nullable<int> CreatedBy { get; set; }
        [DisplayName("Data utworzenia")]
        public Nullable<System.DateTime> CreatedOn { get; set; }
        [Browsable(false)]
        public Nullable<int> TenantId { get; set; }
        [Browsable(false)]
        public string TenantName { get; set; }
        [DisplayName("Utworzył")]
        public string CreatedByName { get; set; }
        [DisplayName("Zmodyfikował")]
        public string LmByName { get; set; }
        [Browsable(false)]
        public Nullable<int> LmBy { get; set; }
        [DisplayName("Data modyfikacji")]
        public Nullable<System.DateTime> LmOn { get; set; }

        public async Task<bool> Add()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    string url = Secrets.ApiAddress + "CreateCompanyType?token=" + Secrets.TenantToken + "&UserId=" + RuntimeSettings.UserId;
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(new Uri(url), content);
                    if (result.IsSuccessStatusCode)
                    {
                        var rString = await result.Content.ReadAsStringAsync();
                        CompanyType _this = JsonConvert.DeserializeObject<CompanyType>(rString);
                        this.CompanyTypeId = _this.CompanyTypeId;
                        MessageBox.Show("Tworzenie typu firmy zakończone powodzeniem!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia typu firmy. Wiadomość: " + result.ReasonPhrase);
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public async void Edit()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    string url = Secrets.ApiAddress + "EditCompanyType?token=" + Secrets.TenantToken + "&id={0}&UserId={1}";
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync(String.Format(url, this.CompanyTypeId, RuntimeSettings.UserId), content);
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Edycja typu firmy zakończona powodzeniem!");
                    }
                    else
                    {
                        MessageBox.Show("Serwer zwrócił błąd przy próbie edycji typu firmy. Wiadomość: " + result.ReasonPhrase);
                    }
                }
            }

        }
    }
}

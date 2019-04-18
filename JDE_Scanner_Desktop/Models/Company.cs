using JDE_Scanner_Desktop.Classes;
using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class Company : Entity<Company>
    {
        [DisplayName("ID")]
        public int CompanyId { get; set; }
        public override int Id { set => value = CompanyId; get => CompanyId; }
        [DisplayName("Nazwa")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nazwa nie może być puste!")]
        public string Name { get; set; }
        [DisplayName("Typ")]
        public string CompanyTypeName { get; set; }
        [DisplayName("Ulica")]
        public string Street { get; set; }
        [DisplayName("Ulica2")]
        public string Street2 { get; set; }
        [DisplayName("Numer budynku")]
        public string BuildingNo { get; set; }
        [DisplayName("Numer lokalu")]
        public string LocalNo { get; set; }
        [DisplayName("Kod")]
        public string ZipCode { get; set; }
        [DisplayName("Miasto")]
        public string City { get; set; }
        [DisplayName("Kraj")]
        public string Country { get; set; }
        [Browsable(false)]
        public int TypeId { get; set; }
        //[DisplayName("ID")]
        //public int CompanyId { get; set; }
        //[DisplayName("Nazwa")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Pole nazwa nie może być puste!")]
        //public string Name { get; set; }
        //[DisplayName("Typ")]
        //public string CompanyTypeName { get; set; }
        //[DisplayName("Ulica")]
        //public string Street { get; set; }
        //[DisplayName("Ulica2")]
        //public string Street2 { get; set; }
        //[DisplayName("Numer budynku")]
        //public string BuildingNo { get; set; }
        //[DisplayName("Numer lokalu")]
        //public string LocalNo { get; set; }
        //[DisplayName("Kod")]
        //public string ZipCode { get; set; }
        //[DisplayName("Miasto")]
        //public string City { get; set; }
        //[DisplayName("Kraj")]
        //public string Country { get; set; }
        //[Browsable(false)]
        //public int TypeId { get; set; }
        //[Browsable(false)]
        //public int CreatedBy { get; set; }
        //[DisplayName("Utworzył")]
        //public string CreatedByName { get; set; }
        //[DisplayName("Data utworzenia")]
        //public DateTime CreatedOn { get; set; }
        //[Browsable(false)]
        //public int? LmBy { get; set; }
        //[DisplayName("Zmodyfikował")]
        //public string LmByName { get; set; }
        //[DisplayName("Data modyfikacji")]
        //public DateTime? LmOn { get; set; }
        //[Browsable(false)]
        //public int TenantId { get; set; }
        //[Browsable(false)]
        //public string TenantName { get; set; }

        //public async Task<bool> Add()
        //{
        //    ModelValidator validator = new ModelValidator();
        //    if (validator.Validate(this))
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            string url = Secrets.ApiAddress + "CreateCompany?token=" + Secrets.TenantToken + "&UserId=" + RuntimeSettings.UserId;
        //            var serializedProduct = JsonConvert.SerializeObject(this);
        //            var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
        //            var result = await client.PostAsync(new Uri(url), content);
        //            if (result.IsSuccessStatusCode)
        //            {
        //                var rString = await result.Content.ReadAsStringAsync();
        //                Company _this = JsonConvert.DeserializeObject<Company>(rString);
        //                this.CompanyId = _this.CompanyId;
        //                MessageBox.Show("Tworzenie firmy zakończone powodzeniem!");
        //                return true;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia firmy. Wiadomość: " + result.ReasonPhrase);
        //                return false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public async void Edit()
        //{
        //    ModelValidator validator = new ModelValidator();
        //    if (validator.Validate(this))
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            string url = Secrets.ApiAddress + "EditCompany?token=" + Secrets.TenantToken + "&id={0}&UserId={1}";
        //            var serializedProduct = JsonConvert.SerializeObject(this);
        //            var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
        //            var result = await client.PutAsync(String.Format(url, this.CompanyId, RuntimeSettings.UserId), content);
        //            if (result.IsSuccessStatusCode)
        //            {
        //                MessageBox.Show("Edycja firmy zakończona powodzeniem!");
        //            }
        //            else
        //            {
        //                MessageBox.Show("Serwer zwrócił błąd przy próbie edycji firmy. Wiadomość: " + result.ReasonPhrase);
        //            }
        //        }
        //    }

        //}
    }
}

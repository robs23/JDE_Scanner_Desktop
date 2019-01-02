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
    public class Handling
    {
        [Browsable(false)]
        public int HandlingId { get; set; }
        [DisplayName("ID zgłoszenia")]
        public int ProcessId { get; set; }
        [Browsable(false)]
        public int UserId { get; set; }
        [DisplayName("Użytkownik")]
        public string UserName { get; set; }
        [Browsable(false)]
        public int PlaceId { get; set; }
        [DisplayName("Zasób")]
        public string PlaceName { get; set; }
        [Browsable(false)]
        public int SetId { get; set; }
        [Browsable(false)]
        [DisplayName("Instalacja")]
        public string SetName { get; set; }
        [Browsable(false)]
        public int AreaId { get; set; }
        [Browsable(false)]
        [DisplayName("Obszar")]
        public string AreaName { get; set; }
        [DisplayName("Data rozpoczęcia")]
        public DateTime? StartedOn { get; set; }
        [DisplayName("Data zakończenia")]
        public DateTime? FinishedOn { get; set; }
        [Browsable(false)]
        public bool IsActive { get; set; }
        [Browsable(false)]
        public bool IsFrozen { get; set; }
        [Browsable(false)]
        public bool IsCompleted { get; set; }
        [DisplayName("Rezultat")]
        public string Output { get; set; }
        [Browsable(false)]
        public int TenantId { get; set; }
        [Browsable(false)]
        public string TenantName { get; set; }
        [Browsable(false)]
        public int ActionTypeId { get; set; }
        [DisplayName("Typ zlecenia")]
        public string ActionTypeName { get; set; }
        [DisplayName("Długość [min]")]
        public int Length { get; set; }
        [DisplayName("Status")]
        public string Status
        {
            get
            {
                if (IsCompleted)
                {
                    return "Zakończony";
                }
                else if (IsFrozen && !(IsCompleted))
                {
                    return "Wstrzymany";
                }
                else if (IsActive)
                {
                    return "Rozpoczęty";
                }
                else
                {
                    return "Nierozpoczęty";
                }
            }
            set
            {
                if (value == "Zakończony")
                {
                    IsCompleted = true;
                    IsFrozen = false;
                    IsActive = false;
                }
                else if (value == "Wstrzymany")
                {
                    IsCompleted = false;
                    IsFrozen = true;
                    IsActive = false;
                }
                else if (value == "Rozpoczęty")
                {
                    IsCompleted = false;
                    IsFrozen = false;
                    IsActive = true;
                }
                else
                {
                    IsCompleted = false;
                    IsFrozen = false;
                    IsActive = false;
                }
            }
        }

        public async Task<bool> Add()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    string url = Secrets.ApiAddress + "CreateHandling?token=" + Secrets.TenantToken + "&UserId=" + RuntimeSettings.UserId;
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(new Uri(url), content);
                    if (result.IsSuccessStatusCode)
                    {
                        var rString = await result.Content.ReadAsStringAsync();
                        Handling _this = JsonConvert.DeserializeObject<Handling>(rString);
                        this.HandlingId = _this.HandlingId;
                        MessageBox.Show("Tworzenie obsługi zakończone powodzeniem!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia obsługi. Wiadomość: " + result.ReasonPhrase);
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
                    string url = Secrets.ApiAddress + "EditHandling?token=" + Secrets.TenantToken + "&id={0}&UserId={1}";
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync(String.Format(url, this.HandlingId, RuntimeSettings.UserId), content);
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Edycja obsługi zakończona powodzeniem!");
                    }
                    else
                    {
                        MessageBox.Show("Serwer zwrócił błąd przy próbie edycji obsługi. Wiadomość: " + result.ReasonPhrase);
                    }
                }
            }
        }
    }
}

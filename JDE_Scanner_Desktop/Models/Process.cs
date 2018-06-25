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
    public class Process
    {
        [DisplayName("ID")]
        public int ProcessId { get; set; }
        [DisplayName("Opis")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Pole opis nie może być puste!")]
        public string Description { get; set; }
        [DisplayName("Data rozpoczęcia")]
        public DateTime? StartedOn { get; set; }
        [Browsable(false)]
        public int? StartedBy { get; set; }
        [DisplayName("Rozpoczął")]
        public string StartedByName { get; set; }
        [DisplayName("Data zakończenia")]
        public DateTime? FinishedOn { get; set; }
        [Browsable(false)]
        public int? FinishedBy { get; set; }
        [DisplayName("Zakończył")]
        public string FinishedByName { get; set; }
        [Browsable(false)]
        [Range(1,int.MaxValue,ErrorMessage ="Wybierz typ zlecenia z rozwijanej listy!")]
        public int ActionTypeId { get; set; }
        [DisplayName("Typ zlecenia")]
        public string ActionTypeName { get; set; }
        [Browsable(false)]
        public bool IsActive { get; set; }
        [Browsable(false)]
        public bool IsFrozen { get; set; }
        [Browsable(false)]
        public bool IsCompleted { get; set; }
        [Browsable(false)]
        public bool IsSuccessfull { get; set; }
        [Browsable(false)]
        [Range(1,int.MaxValue, ErrorMessage = "Wybierz zasób z rozwijanej listy!")]
        public int PlaceId { get; set; }
        [DisplayName("Zasób")]
        public string PlaceName { get; set; }
        [DisplayName("Rezultat")]
        public string Output { get; set; }
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
        [DisplayName("Status")]
        public string Status { get
            {
                if (IsSuccessfull)
                {
                    return "Zrealizowany";
                }
                else if (IsCompleted)
                {
                    return "Zakończony";
                } else if (IsFrozen && !(IsSuccessfull || IsCompleted))
                {
                    return "Wstrzymany";
                } else if (IsActive)
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
                if(value == "Zrealizowany")
                {
                    IsSuccessfull = true;
                    IsCompleted = false;
                    IsActive = false;
                    IsFrozen = false;
                }else if(value == "Zakończony")
                {
                    IsSuccessfull = false;
                    IsCompleted = true;
                    IsFrozen = false;
                    IsActive = false;
                }else if(value == "Wstrzymany")
                {
                    IsSuccessfull = false;
                    IsCompleted = false;
                    IsFrozen = true;
                    IsActive = false;
                }else if(value == "Rozpoczęty")
                {
                    IsSuccessfull = false;
                    IsCompleted = false;
                    IsFrozen = false;
                    IsActive = true;
                }
                else
                {
                    IsSuccessfull = false;
                    IsCompleted = false;
                    IsFrozen = false;
                    IsActive = false;
                }
            }
            }

        public async void Add()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    string url = RuntimeSettings.ApiAddress + "CreateProcess?token=" + RuntimeSettings.TenantToken + "&UserId=" + RuntimeSettings.UserId;
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(new Uri(url), content);
                    if (result.IsSuccessStatusCode)
                    {
                        var rString = await result.Content.ReadAsStringAsync();
                        Process _this = JsonConvert.DeserializeObject<Process>(rString);
                        this.ProcessId = _this.ProcessId;
                        MessageBox.Show("Tworzenie zlecenia zakończone powodzeniem!");
                    }
                    else
                    {
                        MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia zlecenia. Wiadomość: " + result.ReasonPhrase);
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
                    string url = RuntimeSettings.ApiAddress + "EditProcess?token=" + RuntimeSettings.TenantToken + "&id={0}&UserId={1}";
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync(String.Format(url, this.ProcessId, RuntimeSettings.UserId), content);
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Edycja zlecenia zakończona powodzeniem!");
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

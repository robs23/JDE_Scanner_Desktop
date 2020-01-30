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
using JDE_Scanner_Desktop.Static;

namespace JDE_Scanner_Desktop.Models
{
    public class Process
    {
        [DisplayName("ID")]
        public int ProcessId { get; set; }
        [Browsable(false)]
        public string Description { get; set; }
        [DisplayName("Planowane rozpoczęcie")]
        public DateTime? PlannedStart { get; set; }
        [DisplayName("Planowane zakończenie")]
        public DateTime? PlannedFinish { get; set; }
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
        [DisplayName("Status")]
        public string Status
        {
            get
            {
                if (IsSuccessfull)
                {
                    return "Zrealizowany";
                }
                else if (IsCompleted)
                {
                    return "Zakończony";
                }
                else if (IsFrozen && !(IsSuccessfull || IsCompleted))
                {
                    return "Wstrzymany";
                }
                else if (IsActive)
                {
                    return "Rozpoczęty";
                }
                else
                {
                    return "Planowany";
                }
            }
            set
            {
                if (value == "Zrealizowany")
                {
                    IsSuccessfull = true;
                    IsCompleted = false;
                    IsActive = false;
                    IsFrozen = false;
                }
                else if (value == "Zakończony")
                {
                    IsSuccessfull = false;
                    IsCompleted = true;
                    IsFrozen = false;
                    IsActive = false;
                }
                else if (value == "Wstrzymany")
                {
                    IsSuccessfull = false;
                    IsCompleted = false;
                    IsFrozen = true;
                    IsActive = false;
                }
                else if (value == "Rozpoczęty")
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
        [DisplayName("Długość [min]")]
        public int? Length { get; set; }
        [DisplayName("Obsługujący")]
        public string HandlingStatus
        {
            get
            {
                return OpenHandlings + " z " + AllHandlings;
            }
        }
        [DisplayName("Rezultat")]
        public string Output { get; set; }
        [DisplayName("MES ID")]
        public string MesId { get; set; }
        [DisplayName("Wstępne rozpoznanie")]
        public string InitialDiagnosis { get; set; }
        [DisplayName("Czynności naprawcze")]
        public string RepairActions { get; set; }
        [Browsable(false)]
        public string Reason { get; set; }
        [Browsable(false)]
        public DateTime? MesDate { get; set; }
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
        [DisplayName("Ostatni status")]
        public ProcessStatus? LastStatus { get; set; }
        [Browsable(false)]
        public int? LastStatusBy { get; set; }
        [Browsable(false)]
        public DateTime? LastStatusOn { get; set; }
        [Browsable(false)]
        public int? OpenHandlings { get; set; }
        [Browsable(false)]
        public int? AllHandlings { get; set; }
        [Browsable(false)]
        public HandlingsKeeper Handlings { get; set; }
        [Browsable(false)]
        public LogsKeeper Logs { get; set; }
        [DisplayName("Przypisani obsługujący")]
        public string AssignedUserNames { get; set; }
        [Browsable(false)]
        public ProcessActionsKeeper ProcessActions { get; set; }
        [DisplayName("Procent wykonania")]
        public float FinishRate { get; set; }


        public async Task<bool> Add()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    string url = Secrets.ApiAddress + "CreateProcess?token=" + Secrets.TenantToken + "&UserId=" + RuntimeSettings.UserId;
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(new Uri(url), content);
                    if (result.IsSuccessStatusCode)
                    {
                        var rString = await result.Content.ReadAsStringAsync();
                        Process _this = JsonConvert.DeserializeObject<Process>(rString);
                        this.ProcessId = _this.ProcessId;
                        MessageBox.Show("Tworzenie zlecenia zakończone powodzeniem!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia zlecenia. Wiadomość: " + result.ReasonPhrase);
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Edit()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                
                if (this.AdditionalValidation())
                {
                    using (var client = new HttpClient())
                    {
                        string url = Secrets.ApiAddress + "EditProcess?token=" + Secrets.TenantToken + "&id={0}&UserId={1}&UseServerDates=false";
                        var serializedProduct = JsonConvert.SerializeObject(this);
                        var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                        var result = await client.PutAsync(String.Format(url, this.ProcessId, RuntimeSettings.UserId), content);
                        if (result.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Edycja zlecenia zakończona powodzeniem!");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Serwer zwrócił błąd przy próbie edycji użytkownika. Wiadomość: " + result.ReasonPhrase);
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<string> AssignUsers(List<User> Users)
        {
            //it reassignes users to single process

            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "AssignUsers?token=" + Secrets.TenantToken + "&ProcessId={0}&UserId={1}";
                var serializedProduct = JsonConvert.SerializeObject(Users);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(String.Format(url, this.ProcessId, RuntimeSettings.UserId), content);
                if (!result.IsSuccessStatusCode)
                {
                    if(result.StatusCode== System.Net.HttpStatusCode.BadRequest)
                    {
                        return String.Format("Przypisanie użytkowników nie ma zastosowania do zgłoszenia {0}. Wiadomość: " + result.ReasonPhrase, this.ProcessId);
                    }
                    return String.Format("Serwer zwrócił błąd przy próbie zmiany przypisanych użytkowników do zgłoszenia {0}. Wiadomość: " + result.ReasonPhrase, this.ProcessId);
                }
                else
                {
                    return null;
                }
            }
        }

        private bool AdditionalValidation()
        {
            bool _isOk = true;
            if ((this.IsActive || this.IsFrozen || this.IsCompleted || this.IsSuccessfull) && (this.StartedOn == null || this.StartedBy == null))
            {
                MessageBox.Show("Pole Data rozpoczęcia i Rozpoczęcie przez nie mogą być puste! Uzupełnij dane!");
                _isOk = false;
            }
            else if ((this.IsCompleted || this.IsSuccessfull) && (this.FinishedOn == null || this.FinishedBy == null))
            {
                MessageBox.Show("Pole Data zakończenia i Zakończenie przez nie mogą być puste! Uzupełnij dane!");
                _isOk = false;
            }
            else if (this.StartedOn != null && this.StartedBy == null)
            {
                MessageBox.Show("Wybierz z listy rozwijanej użytkownika, który rozpoczął zgłoszenie!");
                _isOk = false;
            }
            else if (this.StartedOn == null && this.StartedBy != null)
            {
                MessageBox.Show("Podaj datę rozpoczęcia zgłoszenia!");
                _isOk = false;
            }
            else if (this.FinishedOn != null && this.FinishedBy == null)
            {
                MessageBox.Show("Wybierz z listy rozwijanej użytkownika, który zakończył zgłoszenie!");
                _isOk = false;
            }
            else if (this.FinishedOn == null && this.FinishedBy != null)
            {
                MessageBox.Show("Podaj datę zakończenia zgłoszenia!");
                _isOk = false;
            }
            else if ((this.FinishedOn != null && this.FinishedBy != null) && !this.IsCompleted)
            {
                //Close it
                this.IsCompleted = true;
            }
            else if ((this.StartedOn != null && this.StartedBy != null) && !(this.IsActive || this.IsFrozen || this.IsCompleted || this.IsSuccessfull))
            {
                //Start it
                this.IsActive = true;
            }
            return _isOk;
        }

        
    }

    public enum ProcessStatus
    {
        Brak,
        Planowany,
        Rozpoczęty,
        Wstrzymany,
        Wznowiony,
        Zakończony
    }
}

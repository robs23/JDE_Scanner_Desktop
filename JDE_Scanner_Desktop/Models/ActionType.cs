﻿using Newtonsoft.Json;
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
        [DisplayName("Wymaga wstępnej diagnozy")]
        public bool? RequireInitialDiagnosis { get; set; }
        [DisplayName("Pokaż w planowaniu")]
        public bool? ShowInPlanning { get; set; }
        [DisplayName("Synchronizacja z MES")]
        public bool? MesSync { get; set; }
        [DisplayName("Zezwalaj na duplikaty")]
        public bool? AllowDuplicates { get; set; }
        [DisplayName("Wymagaj skanowania QR by rozpocząć")]
        public bool? RequireQrToStart { get; set; }
        [DisplayName("Wymagaj skanowania QR by zakończyć")]
        public bool? RequireQrToFinish { get; set; }
        [DisplayName("Zamknij poprzednie zgłoszenia")]
        public bool? ClosePreviousInSamePlace { get; set; }
        [DisplayName("Konsumpcja części")]
        public bool? PartsApplicable { get; set; }
        [DisplayName("Zawiera czynności")]
        public bool? ActionsApplicable { get; set; }
        [DisplayName("Wymaga przypisania użytkownika")]
        public bool? RequireUsersAssignment { get; set; }
        [DisplayName("Pokaż na pulpicie")]
        public bool? ShowOnDashboard { get; set; }
        [DisplayName("Proponuj pozostawienie otwartego zgłoszenia")]
        public bool? Leaveable { get; set; }



        public async Task<bool> Add()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    string url = Secrets.ApiAddress + "CreateActionType?token=" + Secrets.TenantToken + "&UserId=" + RuntimeSettings.UserId;
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(new Uri(url), content);
                    if (result.IsSuccessStatusCode)
                    {
                        var rString = await result.Content.ReadAsStringAsync();
                        ActionType _this = JsonConvert.DeserializeObject<ActionType>(rString);
                        this.ActionTypeId = _this.ActionTypeId;
                        MessageBox.Show("Tworzenie typu zlecenia zakończone powodzeniem!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia typu zlecenia. Wiadomość: " + result.ReasonPhrase);
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
                    string url = Secrets.ApiAddress + "EditActionType?token=" + Secrets.TenantToken + "&id={0}&UserId={1}";
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

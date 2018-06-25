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
    public class User
    {
        [DisplayName("ID")]
        public int UserId { get; set; }
        [Browsable(false)]
        public int TenantId { get; set; }
        [Browsable(false)]
        public string TenantName { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Pole imię nie może być puste!")]
        [DisplayName("Imię")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Pole nazwisko nie może być puste!")]
        [DisplayName("Nazwisko")]
        public string Surname { get; set; }
        [Browsable(false)]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Pole hasło nie może być puste!")]
        [StringLength(20,MinimumLength =4, ErrorMessage = "Hasło musi mieć od 4 do 20 znaków!")]
        public string Password { get; set; }
        [DisplayName("Mechanik?")]
        public bool IsMechanic { get; set; }
        [DisplayName("Data utworzenia")]
        public DateTime? CreatedOn { get; set; }
        [Browsable(false)]
        public int CreatedBy { get; set; }
        [DisplayName("Utworzył")]
        public string CreatedByName { get; set; }
        [DisplayName("Ostatnie logowanie")]
        public DateTime? LastLoggedOn { get; set; }
        [Browsable(false)]
        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }

        public async void Add()
        {
            ModelValidator validator = new ModelValidator();
            if (validator.Validate(this))
            {
                using (var client = new HttpClient())
                {
                    string url = RuntimeSettings.ApiAddress + "CreateUser?token=" + RuntimeSettings.TenantToken + "&UserId="+RuntimeSettings.UserId;
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(new Uri(url), content);
                    if (result.IsSuccessStatusCode)
                    {
                        var rString = await result.Content.ReadAsStringAsync();
                        User _this = JsonConvert.DeserializeObject<User>(rString);
                        this.UserId = _this.UserId;
                        MessageBox.Show("Tworzenie użytkownika zakończone powodzeniem!");
                    }
                    else
                    {
                        MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia użytkownika. Wiadomość: " + result.ReasonPhrase);
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
                    string url = RuntimeSettings.ApiAddress + "EditUser?token=" + RuntimeSettings.TenantToken + "&id={0}&UserId={1}";
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync(String.Format(url, this.UserId, RuntimeSettings.UserId), content);
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

            public async void Login()
            {
                using (var client = new HttpClient())
                {
                    string url = RuntimeSettings.ApiAddress + "LogIn?token=" + RuntimeSettings.TenantToken + "&id=";
                    var serializedProduct = JsonConvert.SerializeObject(this);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync(String.Format("{0}{1}", new Uri(url), this.UserId), content);
                }
            }
    }
}

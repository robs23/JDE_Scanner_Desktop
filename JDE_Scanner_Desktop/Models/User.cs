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
    public class User :Entity<User>
    {
        [DisplayName("ID")]
        public int UserId { get; set; }
        public override int Id
        {
            set => value = UserId;
            get => UserId;
        }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Pole imię nie może być puste!")]
        [DisplayName("Imię")]
        [Browsable(false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Pole nazwisko nie może być puste!")]
        [DisplayName("Nazwisko")]
        [Browsable(false)]
        public string Surname { get; set; }
        [DisplayName("Imię i nazwisko")]
        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }
        [Browsable(false)]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Pole hasło nie może być puste!")]
        [StringLength(20,MinimumLength =4, ErrorMessage = "Hasło musi mieć od 4 do 20 znaków!")]
        public string Password { get; set; }
        [DisplayName("Mechanik?")]
        public bool IsMechanic { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole Login MES nie może być puste!")]
        [DisplayName("Login MES")]
        public string MesLogin { get; set; }
        [DisplayName("Ostatnie logowanie")]
        public DateTime? LastLoggedOn { get; set; }

        public async override Task<bool> Add()
        {
            bool x;
            x = await base.Add();

            if (x)
            {
                try
                {
                    User _this = JsonConvert.DeserializeObject<User>(AddedItem);
                    this.UserId = _this.UserId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Tworzenie nowego rekordu zakończone powodzeniem!");
                return true;
            }
            else
            {
                return false;
            }
        }


        public async void Login()
        {
            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "LogIn?token=" + Secrets.TenantToken + "&id=";
                var serializedProduct = JsonConvert.SerializeObject(this);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(String.Format("{0}{1}", new Uri(url), this.UserId), content);
            }
        }
    }
}

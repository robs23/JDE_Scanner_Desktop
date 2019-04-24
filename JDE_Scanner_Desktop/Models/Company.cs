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
        public override int Id {
            set => value = CompanyId;
            get => CompanyId;
        }
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

        public async override Task<bool> Add()
        {
            bool x = await base.Add();
            if (x)
            {
                try
                {
                    Company _this = JsonConvert.DeserializeObject<Company>(AddedItem);
                    this.CompanyId = _this.CompanyId;
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
    }
}

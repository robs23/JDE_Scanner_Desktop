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
    public class Place : Entity<Place>
    {
        [DisplayName("ID")]
        public int PlaceId { get; set; }
        public override int Id
        {
            set => value = PlaceId;
            get => PlaceId;
        }
        [DisplayName("Numer")]
        public string Number1 { get; set; }
        [Browsable(false)]
        public string Number2 { get; set; }
        [DisplayName("Nazwa")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Pole nazwa nie może być puste!")]
        public string Name { get; set; }
        [Browsable(false)]
        public string Description { get; set; }
        [Browsable(false)]
        [Range(1, int.MaxValue, ErrorMessage = "Wybierz obszar z rozwijanej listy!")]
        public int AreaId { get; set; }
        [DisplayName("Obszar")]
        public string AreaName { get; set; }
        [Browsable(false)]
        [Range(1, int.MaxValue, ErrorMessage = "Wybierz instalacje z rozwijanej listy!")]
        public int SetId { get; set; }
        [DisplayName("Instalacja")]
        public string SetName { get; set; }
        [DisplayName("Priorytet")]
        public string Priority { get; set; }
        
        [DisplayName("Token")]
        public string PlaceToken { get; set; }
        [DisplayName("Zdjęcie")]
        public string Image { get; set; }

        public async override Task<bool> Add(string attachmentPath = null)
        {
            bool x;
            if (attachmentPath == null)
            {
                x = await base.Add();
            }
            else
            {
                x = await base.Add(attachmentPath);
            }

            if (x)
            {
                try
                {
                    Place _this = JsonConvert.DeserializeObject<Place>(AddedItem);
                    this.PlaceId = _this.PlaceId;
                    this.PlaceToken = _this.PlaceToken;
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



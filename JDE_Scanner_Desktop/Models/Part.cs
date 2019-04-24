using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class Part : Entity<Part>
    {
        [DisplayName("ID")]
        public int PartId { get; set; }
        public override int Id
        {
            set => value = PartId;
            get => PartId;
        }
        [DisplayName("Nazwa")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nazwa nie może być puste!")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Kod EAN")]
        public string EAN { get; set; }
        [Browsable(false)]
        public Nullable<int> ProducerId { get; set; }
        [DisplayName("Producent")]
        public string ProducerName { get; set; }
        [DisplayName("Kod producenta")]
        public string ProducentsCode { get; set; }
        [Browsable(false)]
        public Nullable<int> SupplierId { get; set; }
        [DisplayName("Dostawca")]
        public string SupplierName { get; set; }
        [DisplayName("Symbol")]
        public string Symbol { get; set; }
        [DisplayName("Przeznaczenie")]
        public string Destination { get; set; }
        [DisplayName("Zastosowanie")]
        public string Appliance { get; set; }
        [DisplayName("Używana do")]
        public string UsedOn { get; set; }
        [DisplayName("Token")]
        public string Token { get; set; }

        public async override Task<bool> Add()
        {
            bool x = await base.Add();
            if (x)
            {
                try
                {
                    Part _this = JsonConvert.DeserializeObject<Part>(AddedItem);
                    this.PartId = _this.PartId;
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
    
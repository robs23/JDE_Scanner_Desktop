using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class PartPrice : Entity<PartPrice>
    {
        [DisplayName("ID")]
        public int PartPriceId { get; set; }
        public override int Id
        {
            set => value = PartPriceId;
            get => PartPriceId;
        }
        [DisplayName("Ważna od")]
        public DateTime? ValidFrom { get; set; }
        [Browsable(false)]
        public int? PartId { get; set; }
        [DisplayName("Część")]
        public string Name { get; set; }
        [DisplayName("Cena")]
        public decimal Price { get; set; }
        [DisplayName("Waluta")]
        public string Currency { get; set; }
        

        public async override Task<bool> Add()
        {
            bool x = await base.Add();

            if (x)
            {
                try
                {
                    PartPrice _this = JsonConvert.DeserializeObject<PartPrice>(AddedItem);
                    this.PartPriceId = _this.PartPriceId;
                    this.TenantId = _this.TenantId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

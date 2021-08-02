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
    public class AbandonReason : Entity<AbandonReason>
    {
        [DisplayName("ID")]
        public int AbandonReasonId { get; set; }
        public override int Id
        {
            set => value = AbandonReasonId;
            get => AbandonReasonId;
        }

        [DisplayName("Nazwa")]
        public string Name { get; set; }


        public async override Task<bool> Add()
        {
            bool x = await base.Add();

            if (x)
            {
                try
                {
                    PartPrice _this = JsonConvert.DeserializeObject<PartPrice>(AddedItem);
                    this.AbandonReasonId = _this.PartPriceId;
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

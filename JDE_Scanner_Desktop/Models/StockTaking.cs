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
    public class StockTaking : Entity<StockTaking>
    {
        [DisplayName("ID")]
        public int StockTakingId { get; set; }
        public override int Id
        {
            set => value = StockTakingId;
            get => StockTakingId;
        }

        [DisplayName("ID części")]
        public int? PartId { get; set; }
        [DisplayName("Część")]
        public string Name { get; set; }
        [DisplayName("Ilość sztuk")]
        public int? Amount { get; set; }
        [Browsable(false)]
        public int? StorageBinId { get; set; }
        [DisplayName("Regał")]
        public string StorageBinNumber { get; set; }

        public async override Task<bool> Add()
        {
            bool x = await base.Add();

            if (x)
            {
                try
                {
                    StockTaking _this = JsonConvert.DeserializeObject<StockTaking>(AddedItem);
                    this.StockTakingId = _this.StockTakingId;
                    this.TenantId = _this.TenantId;
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

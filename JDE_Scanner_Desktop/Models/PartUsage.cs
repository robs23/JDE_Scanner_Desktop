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
    public class PartUsage : Entity<PartUsage>
    {
        [DisplayName("ID")]
        public int PartUsageId { get; set; }
        public override int Id
        {
            set => value = PartUsageId;
            get => PartUsageId;
        }
        [DisplayName("ID zgłoszenia")]
        public int? ProcessId { get; set; }
        [Browsable(false)]
        public int? PlaceId { get; set; }
        [DisplayName("Zasób")]
        public string PlaceName { get; set; }
        [DisplayName("Ilość")]
        public float Amount { get; set; } = 0;
        [Browsable(false)]
        public int PartId { get; set; }
        [DisplayName("Część")]
        public string Name { get; set; }
        [Browsable(false)]
        public int? ProducerId { get; set; }
        [DisplayName("Producent")]
        public string ProducerName { get; set; }
        [DisplayName("Symbol")]
        public string Symbol { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [Browsable(false)]
        public int? StorageBinId { get; set; }
        [DisplayName("Regał")]
        public string StorageBinNumber { get; set; }
        [DisplayName("Pozostało [szt]")]
        public string Comment { get; set; }

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
                    PartUsage _this = JsonConvert.DeserializeObject<PartUsage>(AddedItem);
                    this.PartUsageId = _this.PartUsageId;
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

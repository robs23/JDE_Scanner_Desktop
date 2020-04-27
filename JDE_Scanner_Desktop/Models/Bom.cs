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
    public class Bom : Entity<Bom>
    {
        [Browsable(false)]
        public override int Id
        {
            set => value = BomId;
            get => BomId;
        }
        [DisplayName("ID")]
        public int BomId { get; set; }
        [Browsable(false)]
        public Nullable<int> PartId { get; set; }
        [DisplayName("Część")]
        public string PartName { get; set; }
        [Browsable(false)]
        public Nullable<int> PlaceId { get; set; }
        [DisplayName("Zasób")]
        public string PlaceName { get; set; }
        [DisplayName("Ilość")]
        public Nullable<double> Amount { get; set; }
        [DisplayName("Jednostka")]
        public string Unit { get; set; }
        [DisplayName("Ważne od")]
        public Nullable<System.DateTime> ValidFrom { get; set; }
        [DisplayName("Ważne do")]
        public Nullable<System.DateTime> ValidTo { get; set; }

        public async override Task<bool> Add()
        {
            bool x = await base.Add();
            if (x)
            {
                try
                {
                    Bom _this = JsonConvert.DeserializeObject<Bom>(AddedItem);
                    this.BomId = _this.BomId;
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

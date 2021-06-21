using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

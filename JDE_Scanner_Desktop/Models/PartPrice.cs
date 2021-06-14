using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [DisplayName("ID części")]
        public int? PartId { get; set; }
        [DisplayName("Część")]
        public string Name { get; set; }
        [DisplayName("Cena")]
        public decimal Price { get; set; }
        [DisplayName("Waluta")]
        public string Currency { get; set; }
        [DisplayName("Ważna od")]
        public DateTime? ValidFrom { get; set; }
    }
}

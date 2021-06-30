using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class OrderItem : Entity<OrderItem>
    {
        [DisplayName("ID")]
        public int OrderItemId { get; set; }
        public override int Id
        {
            set => value = OrderItemId;
            get => OrderItemId;
        }
        [DisplayName("ID zamówienia")]
        public int? OrderId { get; set; }
        [DisplayName("Numer zamówienia")]
        public int? OrderNo { get; set; }
        [Browsable(false)]
        public int? PartId { get; set; }
        [DisplayName("Część")]
        public string PartName { get; set; }
        [DisplayName("Symbol")]
        public string PartSymbol { get; set; }
        [Browsable(false)]
        public string EAN { get; set; }
        [DisplayName("Ilość")]
        public double? Amount { get; set; }
        [DisplayName("Jednostka")]
        public string Unit { get; set; }
        [DisplayName("Koszt")]
        public double? Price { get; set; }
        [DisplayName("Waluta")]
        public string Currency { get; set; }

    }
}

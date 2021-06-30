using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class Order : Entity<Order>
    {
        [DisplayName("ID")]
        public int OrderId { get; set; }
        public override int Id
        {
            set => value = OrderId;
            get => OrderId;
        }
        [DisplayName("Numer")]
        public string OrderNo { get; set; }
        [DisplayName("Numer u dostawcy")]
        public string SuppliersOrderNo { get; set; }
        [DisplayName("Planowana dostawa")]
        public DateTime? DeliveryOn { get; set; }
        [Browsable(false)]
        public int? SupplierId { get; set; }
        [DisplayName("Dostawca")]
        public string SupplierName { get; set; }

        public OrderItemKeeper ItemKeeper { get; set; }

        public Order()
        {
            ItemKeeper = new OrderItemKeeper();
        }
    }
}

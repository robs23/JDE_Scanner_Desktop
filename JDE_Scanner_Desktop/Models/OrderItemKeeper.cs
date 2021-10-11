using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class OrderItemKeeper : Keeper<OrderItem>
    {
        protected override string ObjectName => "OrderItem";

        protected override string PluralizedObjectName => "OrderItems";
        protected override string ArchiveString { get; set; } = null;
    }
}

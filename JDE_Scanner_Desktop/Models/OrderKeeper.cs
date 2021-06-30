using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class OrderKeeper : Keeper<Order>
    {
        protected override string ObjectName => "Order";

        protected override string PluralizedObjectName => "Orders";
    }
}

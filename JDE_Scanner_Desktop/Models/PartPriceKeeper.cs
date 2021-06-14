using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class PartPriceKeeper : Keeper<PartPrice>
    {
        protected override string ObjectName => "PartPrice";

        protected override string PluralizedObjectName => "PartPrices";
    }
}

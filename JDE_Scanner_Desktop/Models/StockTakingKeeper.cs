using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class StockTakingKeeper : Keeper<StockTaking>
    {
        protected override string ObjectName => "StockTaking";

        protected override string PluralizedObjectName => "StockTakings";
    }
}

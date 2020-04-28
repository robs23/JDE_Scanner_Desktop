using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class PartUsageKeeper : Keeper<PartUsage>
    {
        protected override string ObjectName => "PartUsage";

        protected override string PluralizedObjectName => "PartUsages";

    }
}

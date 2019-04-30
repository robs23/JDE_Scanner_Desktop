using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class BomKeeper : Keeper<Bom>
    {
        protected override string ObjectName => "Bom";

        protected override string PluralizedObjectName => "Boms";
    }
}

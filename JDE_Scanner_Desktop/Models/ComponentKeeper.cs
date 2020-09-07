using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class ComponentKeeper : Keeper<Component>
    {
        protected override string ObjectName => "Component";

        protected override string PluralizedObjectName => "Components";
    }
}

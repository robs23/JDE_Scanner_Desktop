using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class ActionKeeper : Keeper<Action>
    {
        protected override string ObjectName => "Action";

        protected override string PluralizedObjectName => "Actions";
    }
}

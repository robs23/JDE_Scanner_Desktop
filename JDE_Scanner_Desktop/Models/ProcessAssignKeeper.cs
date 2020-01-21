using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class ProcessAssignKeeper : Keeper<ProcessAssign>
    {
        protected override string ObjectName => "ProcessAssign";

        protected override string PluralizedObjectName => "ProcessAssigns";
    }
}

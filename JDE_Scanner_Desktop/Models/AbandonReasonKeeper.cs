using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class AbandonReasonKeeper : Keeper<AbandonReason>
    {
        protected override string ObjectName => "AbandonReason";

        protected override string PluralizedObjectName => "AbandonReasons";
        protected override string ArchiveString { get; set; } = "IsArchived<>True";
    }
}

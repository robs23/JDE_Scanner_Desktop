using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class SetsKeeper : Keeper<Set>
    {
        protected override string ObjectName => "Set";

        protected override string PluralizedObjectName => "Sets";
    }
}

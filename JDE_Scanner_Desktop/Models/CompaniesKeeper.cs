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
    public class CompaniesKeeper : Keeper<Company>
    {
        protected override string ObjectName => "Company";

        protected override string PluralizedObjectName => "Companies";

    }
}

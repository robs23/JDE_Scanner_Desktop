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
    public class UsersKeeper : Keeper<User>
    {
        protected override string ObjectName => "User";

        protected override string PluralizedObjectName => "Users";

        protected override string ArchiveString { get; set; } = "IsArchived<>True";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Static
{
    static class Utilities
    {
        public static string uniqueToken()
        {
            string token;
            Guid g = Guid.NewGuid();
            token = Convert.ToBase64String(g.ToByteArray());
            token = token.Replace("=", "");
            token = token.Replace("+", "");
            token = token.Replace("/", "");
            token = token.Replace("\\", "");
            return token;
        }
    }
}

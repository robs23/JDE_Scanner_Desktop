using JDE_Scanner_Desktop.Models;
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

        public static string EnumString(Enum Tenum, int i)
        {
            string str = "";
            if (Tenum.GetType() == typeof(ProcessStatus))
            {
                //statuses of process
                switch (i)
                {
                    case 0:
                        str = "Brak";
                        break;
                    case 1:
                        str = "Planowany";
                        break;
                    case 2:
                        str = "Rozpoczęty";
                        break;
                    case 3:
                        str = "Wstrzymany";
                        break;
                    case 4:
                        str = "Wznowiony";
                        break;
                    case 5:
                        str = "Zakończony";
                        break;
                }

            }
            
            return str;
        }
    }
}

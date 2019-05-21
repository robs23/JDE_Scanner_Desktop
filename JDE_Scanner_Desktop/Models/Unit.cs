using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class Unit
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string FullName { get
            {
                return LongName + " (" + ShortName + ")";
            } }
    }
}

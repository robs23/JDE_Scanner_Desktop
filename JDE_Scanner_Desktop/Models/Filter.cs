using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class Filter
    {
        public List<FilterColumn> Columns { get; set; }
        public bool IsOn { get; set; }

        public Filter()
        {
            Columns = new List<FilterColumn>();
        }
    }
}

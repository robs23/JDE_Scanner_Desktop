using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class FilterColumn
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public List<FilterRow> Items { get; set; }

        public FilterColumn()
        {
            Items = new List<FilterRow>();
        }
    }
}

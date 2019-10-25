using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Classes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MergableAttribute : Attribute
    {
        public MergableAttribute()
        {
            Mergable = false;
        }

        public MergableAttribute(bool value)
        {
            Mergable = value;
        }

        public bool Mergable { get; set; } = false;
    }
}

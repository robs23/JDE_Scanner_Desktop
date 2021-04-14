using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Classes
{
    [AttributeUsage(AttributeTargets.Property)]
    class EditableAttribute: Attribute
    {
        public EditableAttribute()
        {
            Editable = false;
        }

        public EditableAttribute(bool value)
        {
            Editable = value;
        }

        public bool Editable { get; set; } = false;
    }
}

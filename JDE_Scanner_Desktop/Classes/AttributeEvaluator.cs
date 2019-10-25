using JDE_Scanner_Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Classes
{
    public class AttributeEvaluator
    {
        public bool Evaluate(object instance, string propertyName)
        {
            AttributeCollection attributes = TypeDescriptor.GetProperties(instance)[propertyName].Attributes;
            foreach (var a in attributes)
            {
                if (a.GetType() == typeof(MergableAttribute))
                {
                    return ((MergableAttribute)a).Mergable; //<-- how to cast a to appopriate type?
                }
            }
            return false;
        }
    }
}

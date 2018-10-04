using System;
using System.Collections;
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
        public FilterColumnType Type { get; set; }
        public List<FilterRow> Items { get; set; }
        public object Selected { get; set; }
        public FilterColumnOptionType OptionType { get; set; }
        public Filter Filter { get; set; }

        public FilterColumn(object val, Filter filter, string name = null)
        {
            Filter = filter;
            if (name == null)
            {
                Name = (string)val;
                Text = (string)val;
            }
            else
            {
                Name = name;
                Text = name;
            }

            if (IsList(val))
            {
                Items = new List<FilterRow>();
                Items = (List<FilterRow>)val;
                Type = FilterColumnType.List;
            }
            else
            {
                Items = null;
                Type = FilterColumnType.Value;
            }
            Filter.Columns.Add(this);
        }

        private bool IsList(object o)
        {
            if (o == null) return false;
            return o is IList &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }
    }

    public enum FilterColumnType
    {
        Value,
        List
    }
    public enum FilterColumnOptionType
    {
        Contain,
        DoesntContain,
        SmallerOrEqual,
        Smaller,
        Equal,
        Greater,
        GreaterOrEqual
    }
}

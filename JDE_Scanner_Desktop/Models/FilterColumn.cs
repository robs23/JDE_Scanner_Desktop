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
        public int Ordinal { get; set; } //place on the list of filter columns
        public FilterColumnType Type { get; set; }
        public FilterColumnValueType ValueType { get; set; }
        public List<FilterRow> Items { get; set; }
        public object Value { get; set; }
        public object Selected { get; set; }
        public Filter Filter { get; set; }

        public FilterColumn(object val, Filter filter, FilterColumnValueType valueType, int ordinal, string name = null)
        {
            Filter = filter;
            Ordinal = ordinal;
            if (name == null)
            {
                Name = (string)val;
                Text = (string)val;
            }
            else
            {
                Name = val.ToString();
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
                ValueType = valueType;
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

    public enum FilterColumnValueType
    {
        Text,
        Number,
        Date,
        Boolean
    }
}

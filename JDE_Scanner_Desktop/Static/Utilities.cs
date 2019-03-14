using JDE_Scanner_Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name,
                    Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}

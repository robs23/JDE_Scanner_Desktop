using JDE_Scanner_Desktop.Models;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Static
{
    static class Utilities
    {

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

        public static string FilterStringconverter(string filter)
        {
            string newColFilter = "";

            // get rid of all the parenthesis 
            filter = filter.Replace("(", "").Replace(")", "");

            // now split the string on the 'and' (each grid column)
            var colFilterList = filter.Split(new string[] { "AND" }, StringSplitOptions.None);

            string andOperator = "";

            foreach (var colFilter in colFilterList)
            {
                newColFilter += andOperator;

                // split string on the 'in'
                var temp1 = colFilter.Trim().Split(new string[] { "IN" }, StringSplitOptions.None);

                // get string between square brackets
                var colName = temp1[0].Split('[', ']')[1].Trim();

                // prepare beginning of linq statement
                newColFilter += string.Format("({0} != null AND (", colName);

                string orOperator = "";

                var filterValsList = temp1[1].Split(',');

                foreach (var filterVal in filterValsList)
                {
                    // remove any single quotes before testing if filter is a num or not
                    var cleanFilterVal = filterVal.Replace("'", "").Trim();

                    double tempNum = 0;
                    if (Double.TryParse(cleanFilterVal, out tempNum))
                        newColFilter += string.Format("{0} {1} = {2}", orOperator, colName, cleanFilterVal.Trim());
                    else
                        newColFilter += string.Format("{0} {1}.Contains('{2}')", orOperator, colName, cleanFilterVal.Trim());

                    orOperator = " OR ";
                }

                newColFilter += "))";

                andOperator = " AND ";
            }

            // replace all single quotes with double quotes
            return newColFilter.Replace("'", "\"");
        }

        public static Bitmap GetQR(string toCode, int size)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(toCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrImage = qrCode.GetGraphic(size);
            return qrImage;
        }

        public static string GetFileName(string path)
        {
        }

    }
}

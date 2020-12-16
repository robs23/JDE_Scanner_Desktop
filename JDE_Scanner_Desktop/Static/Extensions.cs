using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic;
using System.Drawing;
using SQLite;
using System.Collections;

namespace JDE_Scanner_Desktop.Static
{
    static class Extensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        public static int? GetSelectedValue<T>(this ComboBox combobox)
        {
            if(combobox.SelectedItem == null)
            {
                return null;
            }
            else
            {
                return (int)typeof(T).GetProperty(combobox.ValueMember).GetValue(combobox.SelectedItem);
            }
            
        }

        public static void SetSelectedValue<T>(this ComboBox combobox, int? selectedValue)
        {
            if(selectedValue != null)
            {
                combobox.SelectedItem = combobox.Items.Cast<T>().Where(combobox.ValueMember + $"={selectedValue}").FirstOrDefault();
            }
        }

        public static CheckState ToCheckboxState(this bool booleanValue)
        {
            return booleanValue.ToCheckboxState();
        }

        public static CheckState ToCheckboxState(this bool? booleanValue)
        {
            return booleanValue.HasValue ?
                   (booleanValue == true ? CheckState.Checked : CheckState.Unchecked) :
                   CheckState.Indeterminate;
        }

        public static bool? CheckboxStateToNullableBool(this CheckState checkState)
        {
            if(checkState == CheckState.Checked)
            {
                return true;
            }else if(checkState == CheckState.Unchecked)
            {
                return false;
            }
            else
            {
                return null;
            }
        }

        public static bool ContainsNullSafe(this string str, string search)
        {
            bool res = false;
            if (str != null)
            {
                return str.Contains(search);
            }
            return res;
        }

        public static Image Resize(this Image iImg, int width, int height)
        {
            Image res;
            Bitmap bmp = new Bitmap(width, height); //canvas where the new image will be drawn/resized
            Graphics graph = Graphics.FromImage(bmp); //used to draw/resize the new image

            graph.DrawImage(iImg, new Rectangle(0, 0, width, height)); //resize new image to proper size

            return bmp;
        }

        static public int InsertOrReplaceAll(this SQLiteConnection connection, IEnumerable objects, bool runInTransaction = true)
        {
            var c = 0;
            if (objects == null)
                return c;

            if (runInTransaction)
            {
                connection.RunInTransaction(() =>
                {
                    foreach (var r in objects)
                    {
                        c += connection.Insert(r, "OR REPLACE", Orm.GetType(r));
                    }
                });
            }
            else
            {
                foreach (var r in objects)
                {
                    c += connection.Insert(r, "OR REPLACE", Orm.GetType(r));
                }
            }

            return c;
        }
    }
}

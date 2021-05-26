using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic;
using System.Drawing;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Globalization;

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

        public static void NullableBoolCheckbox(this DataGridView g)
        {
            //allows nullable bool column to be displayed as normal 3 state checkbox
            //otherwise the column is converted to text
            g.Columns.Cast<DataGridViewColumn>()
                .Where(x => x.ValueType == typeof(bool?))
                .ToList().ForEach(x =>
                {
                    var index = x.Index;
                    g.Columns.RemoveAt(index);
                    var c = new DataGridViewCheckBoxColumn();
                    c.ValueType = x.ValueType;
                    c.ThreeState = false;
                    c.DataPropertyName = x.DataPropertyName;
                    c.HeaderText = x.HeaderText;
                    c.Name = x.Name;
                    g.Columns.Insert(index, c);
                });
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

        private delegate void SetPropertyThreadSafeDelegate<TResult>(
    Control @this,
    Expression<Func<TResult>> property,
    TResult value);

        public static void SetPropertyThreadSafe<TResult>(
            this Control @this,
            Expression<Func<TResult>> property,
            TResult value)
        {
            var propertyInfo = (property.Body as MemberExpression).Member
                as PropertyInfo;

            if (propertyInfo == null ||
                !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) ||
                @this.GetType().GetProperty(
                    propertyInfo.Name,
                    propertyInfo.PropertyType) == null)
            {
                throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
            }

            if (@this.InvokeRequired)
            {
                @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>
                (SetPropertyThreadSafe),
                new object[] { @this, property, value });
            }
            else
            {
                @this.GetType().InvokeMember(
                    propertyInfo.Name,
                    BindingFlags.SetProperty,
                    null,
                    @this,
                    new object[] { value });
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }

        public static void ShowInPanel(this Form form, Panel panel)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel.Controls.Add(form);
            panel.Tag = form;
            form.BringToFront();
            form.Show();
        }

        public static DateTime StartOfWeek(this DateTime dt)
        {
            DayOfWeek startOfWeek = DayOfWeek.Monday;
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            DateTime mon = dt.AddDays(-1 * diff).Date;
            return mon.AddHours(-2);
        }

        public static int IsoWeekOfYear(this DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
        }
    }
}

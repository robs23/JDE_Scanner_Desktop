using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop
{
    public partial class frmOptionPicker : Form
    {
        List<Tuple<int, string, bool>> Items;
        public List<Tuple<int, string, bool>> ReturnItems { get; set; } = new List<Tuple<int, string, bool>>();
        public int MinCount { get; set; } = 1;

        public frmOptionPicker(Form parent, List<Tuple<int, string, bool>> items )
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(Cursor.Position.X-this.Width, Cursor.Position.Y);
            Items = new List<Tuple<int, string, bool>>();
            Items = items;
        }

        private void frmOptionPicker_Load(object sender, EventArgs e)
        {
            if (clbItems.Items.Count > 0)
            {
                clbItems.Items.Clear();
            }

            foreach(var i in Items)
            {
                clbItems.Items.Add(i.Item2, i.Item3);
            }
        }

        private void frmOptionPicker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clbItems.CheckedItems.Count >= MinCount)
            {
                foreach (var i in Items)
                {
                    //set initiallly response to no checked items
                    ReturnItems.Add(new Tuple<int, string, bool>(i.Item1, i.Item2, false));
                }

                foreach (var i in clbItems.CheckedItems)
                {
                    var OldTuple = ReturnItems.Find(t => t.Item2 == (string)i);
                    var tuple = new Tuple<int, string, bool>(OldTuple.Item1, OldTuple.Item2, true);
                    ReturnItems.Remove(OldTuple);
                    ReturnItems.Add(tuple);
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show($"Przynajmniej {MinCount} pozycji musi być zaznaczonych..","Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
    }
}

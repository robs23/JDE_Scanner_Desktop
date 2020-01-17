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
        List<Tuple<int, string, bool>> ReturnItems { get; set; }

        public frmOptionPicker(Form parent, List<Tuple<int, string, bool>> items )
        {
            InitializeComponent();
            Items = new List<Tuple<int, string, bool>>();
            Items = items;
        }

        private void frmOptionPicker_Load(object sender, EventArgs e)
        {
            foreach(var i in Items)
            {
                clbItems.Items.Add(i.Item2, i.Item3);
            }
        }

        private void frmOptionPicker_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(var i in Items)
            {
                //set initiallly response to no checked items
                ReturnItems.Add(new Tuple<int, string, bool>(i.Item1, i.Item2, false));
            }

            foreach(var i in clbItems.CheckedItems)
            {
                var tuple = ReturnItems.Find(t => t.Item2 == (string)i);
                tuple = new Tuple<int, string, bool>(tuple.Item1, tuple.Item2, true);

            }
            this.DialogResult = DialogResult.OK;
        }
    }
}

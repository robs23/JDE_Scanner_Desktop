using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.CustomControls
{
    public class DBDataGridView : DataGridView
    {
        public new bool DoubleBuffered
        {
            get { return base.DoubleBuffered; }
            set { base.DoubleBuffered = value; }
        }

        public DBDataGridView()
        {
            DoubleBuffered = true;
        }
    }
}

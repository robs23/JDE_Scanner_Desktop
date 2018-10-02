using JDE_Scanner_Desktop.Models;
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
    public partial class frmFilter : Form
    {
        Filter _this;

        public frmFilter(Form parent, Filter Filter)
        {
            InitializeComponent();
            _this = Filter;
        }

        private void frmFilter_Load(object sender, EventArgs e)
        {
            if(_this != null && _this.Columns.Any())
            {
                tlpItems.RowStyles.Clear();
                int counter = 0;

                foreach(FilterColumn col in _this.Columns)
                {
                    int rowIndex = 0;
                    if (counter > 0)
                    {
                        rowIndex = AddTableRow();
                    }
                    

                    Label nLabel = new Label();
                    nLabel.Text = col.Name;
                    tlpItems.Controls.Add(nLabel, 0, rowIndex);
                    nLabel.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                    ComboBox nCombo = new ComboBox();
                    nCombo.Name = col.Name;
                    nCombo.DataSource = col.Items;
                    nCombo.ValueMember = "ValueMember";
                    nCombo.DisplayMember = "DisplayMember";
                    tlpItems.Controls.Add(nCombo, 1, rowIndex);
                    nCombo.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                    nCombo.SelectionLength = 0;
                    counter++;
                }
            }
        }

        private int AddTableRow()
        {
            int index = tlpItems.RowCount++;
            RowStyle style = new RowStyle(SizeType.Absolute, 30F);
            tlpItems.RowStyles.Add(style);
            return index;
        }
    }
}

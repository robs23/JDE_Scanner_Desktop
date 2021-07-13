using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.CustomControls
{
    public class SpecKeysDataGridView : DataGridView
    {
        public new bool DoubleBuffered
        {
            get { return base.DoubleBuffered; }
            set { base.DoubleBuffered = value; }
        }

        public Action TabAction { get; set; }
        public Func<bool> GetFocusAction { get; set; }
        public Func<bool> HideFinderAction { get; set; }

        public SpecKeysDataGridView()
        {
            DoubleBuffered = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                Control c = Control.FromHandle(msg.HWnd);
                DataGridViewTextBoxEditingControl tb;
                DataGridView dgv = null;
                try
                {
                    if(c.GetType() == typeof(DataGridViewTextBoxEditingControl))
                    {
                        tb = (DataGridViewTextBoxEditingControl)c;
                        dgv = tb.EditingControlDataGridView;
                    }else if(c.GetType() == typeof(DataGridView))
                    {
                        dgv = (DataGridView)c;
                    }

                    if (dgv != null)
                    {
                        if (dgv.Columns[dgv.CurrentCell.ColumnIndex].Name == "PartId")
                        {
                            //Handle only PartId column. Otherwise behave normally e.g. go to next cell
                            TabAction();
                        }
                    }

                }catch(Exception ex)
                {

                }

                
            }else if (keyData == Keys.Down)
            {
                bool canEnter = GetFocusAction();
                if (canEnter)
                {
                    return true;
                }
            }else if(keyData == Keys.Escape)
            {
                bool wasShown = HideFinderAction();
                if (wasShown)
                {
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

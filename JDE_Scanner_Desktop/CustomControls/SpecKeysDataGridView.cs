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
        public List<string> TabListeningColumns { get; set; }
        public Action EnterAction { get; set; }
        public List<string> EnterListeningColumns { get; set; }
        public Func<bool> KeyDownAction { get; set; }
        public List<string> KeyDownListeningColumns { get; set; }
        public Func<bool> EscapeAction { get; set; }
        public List<string> EscapeListeningColumns { get; set; }

        public SpecKeysDataGridView()
        {
            DoubleBuffered = true;
        }

        private bool IsCurrentColumnListening(Message msg, List<string> columns)
        {
            if (columns == null) 
            {
                //if none columns were specified, all columns are listening
                return true;
            }
            else{
                Control c = Control.FromHandle(msg.HWnd);
                DataGridViewTextBoxEditingControl tb;
                DataGridView dgv = null;
                try
                {
                    if (c.GetType() == typeof(DataGridViewTextBoxEditingControl))
                    {
                        tb = (DataGridViewTextBoxEditingControl)c;
                        dgv = tb.EditingControlDataGridView;
                    }
                    else if (c.GetType() == typeof(DataGridView))
                    {
                        dgv = (DataGridView)c;
                    }

                    if (dgv != null)
                    {
                        if (columns.Contains(dgv.Columns[dgv.CurrentCell.ColumnIndex].Name))
                        {
                            //Handle only PartId column. Otherwise behave normally e.g. go to next cell
                            TabAction();
                        }
                    }

                }
                catch (Exception ex)
                {

                }
                return false;
            }
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab && TabAction !=null)
            {
                if(IsCurrentColumnListening(msg, TabListeningColumns))
                {
                    TabAction();
                }

            }
            else if (keyData == Keys.Enter && EnterAction != null)
            {
                if (IsCurrentColumnListening(msg, EnterListeningColumns))
                {
                    EnterAction();
                }
            }
            else if (keyData == Keys.Down && KeyDownAction != null)
            {
                if (IsCurrentColumnListening(msg, KeyDownListeningColumns))
                {
                    bool canEnter = KeyDownAction(); // e.g. move focus to other control
                    if (canEnter)
                    {
                        return true;
                    } 
                }
            }else if(keyData == Keys.Escape && EscapeAction != null)
            {
                if (IsCurrentColumnListening(msg, EscapeListeningColumns))
                {
                    bool wasShown = EscapeAction(); // e.g. hide control
                    if (wasShown)
                    {
                        return true;
                    } 
                }
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

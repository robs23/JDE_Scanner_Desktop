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
    public partial class rrComboBox : ComboBox
    {
        public rrComboBox()
        {
            
            AutoCompleteMode = AutoCompleteMode.Suggest;
        }
        protected override void OnTextChanged(EventArgs e)
        {
            try
            {
                if (DesignMode || !string.IsNullOrEmpty(Text) || !Visible) return;

                ResetCompletionList();
            }
            finally
            {
                base.OnTextChanged(e);
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            try
            {
                if (DesignMode) return;
                if (e.KeyChar == '\r' || e.KeyChar == '\n')
                {
                    e.Handled = true;
                    if (SelectedIndex == -1 && Items.Count > 0 && Items[0].ToString().ToLowerInvariant().StartsWith(Text.ToLowerInvariant()))
                    {
                        Text = Items[0].ToString();
                    }
                    DroppedDown = false;
                    return; //0
                }

                BeginInvoke(new Action(ReevaluateCompletionList)); //1
            }
            finally
            {
                base.OnKeyPress(e);
            }
        }
        //0 Guardclose when detecting any enter keypresses to avoid a glitch which was selecting an item by means of down arrow key followed by enter to wipe out the text within
        //1 Its crucial that we use begininvoke because we need the changes to sink into the textfield  Omitting begininvoke would cause the searchterm to lag behind by one character  That is the last character that got typed in

        private void ResetCompletionList()
        {
            _previousSearchterm = null;
            try
            {
                SuspendLayout();

                var originalList = (object[])Tag;
                if (originalList == null)
                {
                    Tag = originalList = Items.Cast<object>().ToArray();
                }

                if (Items.Count == originalList.Length) return;

                while (Items.Count > 0)
                {
                    Items.RemoveAt(0);
                }

                Items.AddRange(originalList);
            }
            finally
            {
                ResumeLayout(performLayout: true);
            }
        }

        private string _previousSearchterm;
        private void ReevaluateCompletionList()
        {
            var currentSearchterm = Text.ToLowerInvariant();
            if (currentSearchterm == _previousSearchterm) return; //optimization

            _previousSearchterm = currentSearchterm;
            try
            {
                SuspendLayout();

                var originalList = (object[])Tag;
                if (originalList == null)
                {
                    Tag = originalList = Items.Cast<object>().ToArray(); //0
                }

                var newList = (object[])null;
                if (string.IsNullOrEmpty(currentSearchterm))
                {
                    if (Items.Count == originalList.Length) return;

                    newList = originalList;
                }
                else
                {
                    newList = originalList.Where(x => x.ToString().ToLowerInvariant().Contains(currentSearchterm)).ToArray();
                }

                try
                {
                    while (Items.Count > 0) //1
                    {
                        Items.RemoveAt(0);
                    }
                }
                catch
                {
                    try
                    {
                        Items.Clear();
                    }
                    catch
                    {
                    }
                }


                Items.AddRange(newList.ToArray()); //2
            }
            finally
            {
                if (currentSearchterm.Length >= 2 && !DroppedDown)
                {
                    DroppedDown = true; //3
                    Cursor.Current = Cursors.Default; //4
                    Text = currentSearchterm; //5
                    Select(currentSearchterm.Length, 0);
                }

                ResumeLayout(performLayout: true);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}

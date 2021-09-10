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
        IKeptable Keeper;

        public string FilterString
        {
            get
            {
                string res = "";
                string option = "";

                foreach (FilterColumn col in _this.Columns)
                {
                    ComboBox cmb = (ComboBox)this.Controls.Find($"cmbOptions{col.Ordinal}", true).FirstOrDefault();
                    Control val = this.Controls.Find(col.Name, true).FirstOrDefault();

                    if (col.Ordinal > 0)
                    {
                        if(col.ValueType == FilterColumnValueType.Boolean)
                        {
                            if(((CheckBox)val).CheckState != CheckState.Indeterminate)
                            {
                                if (res.Length > 0) { res += " AND "; }
                            }
                        }
                        else
                        {
                            if((!string.IsNullOrEmpty(val.Text) && val.Text != " ") || (cmb.SelectedItem.ToString() == "Jest puste" || cmb.SelectedItem.ToString() == "Nie jest puste"))
                            {
                                if (res.Length > 0) { res += " AND "; }
                            }
                        }
                        
                    }
                    if (col.ValueType == FilterColumnValueType.Number)
                    {
                        val = (TextBox)this.Controls.Find(col.Name, true).FirstOrDefault();
                        if (!string.IsNullOrEmpty(val.Text))
                        {
                            if (cmb.SelectedIndex == 0)
                            {
                                option = "<=";
                            }
                            else if (cmb.SelectedIndex == 1)
                            {
                                option = "<";
                            }
                            else if (cmb.SelectedIndex == 2)
                            {
                                option = "=";
                            }
                            else if (cmb.SelectedIndex == 3)
                            {
                                option = "<>";
                            }
                            else if (cmb.SelectedIndex == 4)
                            {
                                option = ">";
                            }
                            else if (cmb.SelectedIndex == 5)
                            {
                                option = ">=";
                            }
                            res += $"{col.Name}{option}{val.Text}";
                        }
                        if (cmb.SelectedIndex == 6)
                        {
                            //Is null
                            res += $"{col.Name} = null";
                        }
                        else if (cmb.SelectedIndex == 7)
                        {
                            //Is NOT null
                            res += $"{col.Name} <> null";
                        }
                    }
                    else if (col.ValueType == FilterColumnValueType.Date)
                    {
                        val = (DateTimePicker)this.Controls.Find(col.Name, true).FirstOrDefault();
                        if (val.Text != " ")
                        {
                            if (cmb.SelectedIndex == 0)
                            {
                                option = "=";
                                res += $"{col.Name}.Value.Year=={((DateTimePicker)val).Value.Year} AND {col.Name}.Value.Month=={((DateTimePicker)val).Value.Month} AND {col.Name}.Value.Day=={((DateTimePicker)val).Value.Day}";
                            }
                            else if (cmb.SelectedIndex == 1)
                            {
                                option = "<";
                                res += $"{col.Name}{option}DateTime({((DateTimePicker)val).Value.Year},{((DateTimePicker)val).Value.Month},{((DateTimePicker)val).Value.Day})";
                            }
                            else if (cmb.SelectedIndex == 2)
                            {
                                option = ">";
                                res += $"{col.Name}{option}DateTime({((DateTimePicker)val).Value.Year},{((DateTimePicker)val).Value.Month},{((DateTimePicker)val).Value.Day})";
                            }
                        }
                        if (cmb.SelectedIndex == 3)
                        {
                            //Is null
                            res += $"{col.Name} = null";
                        }
                        else if (cmb.SelectedIndex == 4)
                        {
                            //Is NOT null
                            res += $"{col.Name} <> null";
                        }
                    }
                    else if (col.ValueType == FilterColumnValueType.Text)
                    {
                        val = (TextBox)this.Controls.Find(col.Name, true).FirstOrDefault();
                        if (!string.IsNullOrEmpty(val.Text))
                        {
                            if (cmb.SelectedIndex == 0)
                            {
                                res += $"{col.Name}.ToLower().Contains(\"{val.Text}\")";
                                
                            }
                            else if (cmb.SelectedIndex == 1)
                            {
                                res += $"!{col.Name}.ToLower().Contains(\"{val.Text}\")";
                            }
                            else if (cmb.SelectedIndex == 2)
                            {
                                res += $"{col.Name}=\"{val.Text}\"";
                            }
                            else if (cmb.SelectedIndex == 3)
                            {
                                res += $"{col.Name}<>\"{val.Text}\"";
                            }
                        }
                        if (cmb.SelectedIndex == 4)
                        {
                            //Is null
                            res += $"({col.Name} = null OR {col.Name} = \"\")";
                        }
                        else if (cmb.SelectedIndex == 5)
                        {
                            //Is NOT null
                            res += $"({col.Name} <> null AND {col.Name} <> \"\")";
                        }
                    }
                    else if (col.ValueType == FilterColumnValueType.Boolean)
                    {
                        var val2 = (CheckBox)val;
                        if (val2.CheckState != CheckState.Indeterminate)
                        {
                            if(val2.CheckState == CheckState.Checked)
                            {
                                res += $"{col.Name}=true";
                            }
                            else
                            {
                                res += $"{col.Name}<>true";
                            }
                        }
                    }

                }
                return res;
            }
        }


        public frmFilter(Form parent, Filter Filter)
        {
            InitializeComponent();
            _this = Filter;
        }

        public frmFilter(Filter Filter)
        {
            InitializeComponent();
            _this = Filter;
        }


        public frmFilter(Form parent, DataGridView dg, IKeptable keeper)
        {
            InitializeComponent();
            //Let's create filter columns based on given data grid view
            _this = new Filter();
            Keeper = keeper;
            int i = 0;

            foreach(DataGridViewColumn col in dg.Columns)
            {
                FilterColumnValueType cType;
                if (col.ValueType == typeof(int) || col.ValueType == typeof(float) || col.ValueType == typeof(Nullable<int>) || col.ValueType == typeof(Nullable<float>) || col.ValueType == typeof(decimal) || col.ValueType == typeof(Nullable<decimal>))
                {
                    cType = FilterColumnValueType.Number;
                }
                else if (col.ValueType == typeof(DateTime) || col.ValueType == typeof(Nullable<DateTime>))
                {
                    cType = FilterColumnValueType.Date;
                }else if (col.ValueType == typeof(Boolean) || col.ValueType == typeof(Nullable<Boolean>))
                {
                    cType = FilterColumnValueType.Boolean;
                }else
                {
                    cType = FilterColumnValueType.Text;
                }
                FilterColumn nCol = new FilterColumn(col.Name, _this, cType, i, col.HeaderText);
                i++;
            }

            if (_this != null && _this.Columns.Any())
            {
                tlpItems.RowStyles.Clear();
                int counter = 0;

                foreach (FilterColumn col in _this.Columns)
                {
                    int rowIndex = 0;
                    if (counter > 0)
                    {
                        rowIndex = AddTableRow();
                    }


                    Label nLabel = new Label();
                    nLabel.Text = col.Text;
                    tlpItems.Controls.Add(nLabel, 0, rowIndex);
                    nLabel.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                    List<string> Options = new List<string>();

                    ComboBox nComb = new ComboBox();
                    nComb.Name = "RangeCombo" + counter;

                    if (col.Type == FilterColumnType.List)
                    {
                        Options.Add("Zawiera");
                        Options.Add("Nie zawiera");
                        ComboBox nCombo = new ComboBox();
                        nCombo.Name = col.Name;
                        nCombo.DataSource = col.Items;
                        nCombo.ValueMember = "ValueMember";
                        nCombo.DisplayMember = "DisplayMember";
                        nCombo.SelectedIndexChanged += new EventHandler(nCombobox_SelectedIndexChanged);
                        tlpItems.Controls.Add(nCombo, 2, rowIndex);
                        nCombo.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                        nCombo.SelectionLength = 0;
                    }
                    else
                    {
                        if (col.ValueType == FilterColumnValueType.Date)
                        {
                            DateTimePicker nDTPicker = new DateTimePicker();
                            nDTPicker.Name = col.Name;
                            nDTPicker.CustomFormat = " ";
                            nDTPicker.ValueChanged += new EventHandler(nDTPicker_ValueChanged);
                            nDTPicker.Format = DateTimePickerFormat.Custom;
                            tlpItems.Controls.Add(nDTPicker, 2, rowIndex);
                            nDTPicker.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                            Options.Add("Jest równe");
                            Options.Add("Wcześniej niż");
                            Options.Add("Później niż");
                            Options.Add("Jest puste");
                            Options.Add("Nie jest puste");
                        }else if(col.ValueType == FilterColumnValueType.Boolean)
                        {
                            CheckBox nCheckBox = new CheckBox();
                            nCheckBox.CheckState = CheckState.Indeterminate;
                            nCheckBox.Name = col.Name;
                            tlpItems.Controls.Add(nCheckBox, 1, rowIndex);
                        }
                        else
                        {
                            TextBox nText = new TextBox();
                            nText.Name = col.Name;
                            tlpItems.Controls.Add(nText, 2, rowIndex);
                            nText.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                            if (col.ValueType == FilterColumnValueType.Text)
                            {
                                Options.Add("Zawiera");
                                Options.Add("Nie zawiera");
                                Options.Add("Jest równe");
                                Options.Add("Jest różne od");
                                Options.Add("Jest puste");
                                Options.Add("Nie jest puste");
                            }
                            else if (col.ValueType == FilterColumnValueType.Boolean)
                            {
                                Options.Add("Jest równe");
                                Options.Add("Jest różne od");
                            }
                            else{
                                Options.Add("Mniejsze lub równe niż");
                                Options.Add("Mniejsze niż");
                                Options.Add("Jest równe");
                                Options.Add("Jest różne od");
                                Options.Add("Większe niż");
                                Options.Add("Większe lub równe niż");
                                Options.Add("Jest puste");
                                Options.Add("Nie jest puste");
                            }
                        }
                    }
                    if (Options.Any())
                    {
                        nComb.DataSource = Options;
                        nComb.Name = "cmbOptions" + col.Ordinal;
                        nComb.SelectedIndexChanged += new EventHandler(nCombobox_SelectedIndexChanged);
                        tlpItems.Controls.Add(nComb, 1, rowIndex);
                        nComb.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                        nComb.SelectionLength = 0;
                    }
                    
                    counter++;
                }
            }
        }

        private void frmFilter_Load(object sender, EventArgs e)
        {
            
        }

        private void nDTPicker_ValueChanged(object sender, EventArgs e)
        {
            ((DateTimePicker)sender).CustomFormat = "yyyy-MM-dd";
        }

        private void nCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Name = ((ComboBox)sender).Name;
            string[] StringSeparators = new string[] { "cmbOptions" };
            var NameArray = Name.Split(StringSeparators, StringSplitOptions.None);
            bool ControlEnabler = true;
            var val = ((ComboBox)sender).SelectedItem.ToString();
            if(val == "Jest puste" || val == "Nie jest puste")
            {
                ControlEnabler = false;
            }

            if (NameArray.Length > 1)
            {
                var Index = Convert.ToInt32(NameArray[1]);
                Control ctrl = tlpItems.GetControlFromPosition(2, Index);
                if(ctrl != null)
                {
                    if (ctrl.Enabled != ControlEnabler)
                    {
                        ctrl.Enabled = ControlEnabler;
                    }
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            Keeper.FilterString = this.FilterString;
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Keeper.FilterString = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

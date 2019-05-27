﻿using JDE_Scanner_Desktop.Models;
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
        public string FilterString
        {
            get
            {
                string res = "";
                string option = "";

                foreach (FilterColumn col in _this.Columns)
                {
                    if (col.Ordinal > 0)
                    {
                        res += " AND ";
                    }
                    if (col.ValueType == FilterColumnValueType.Number)
                    {
                        ComboBox cmb = (ComboBox)this.Controls.Find($"cmbOptions{col.Ordinal}",true).FirstOrDefault();
                        TextBox val = (TextBox)this.Controls.Find(col.Name, true).FirstOrDefault();

                        if (cmb.SelectedValue == "Mniejsze lub równe niż")
                        {
                            option = "<=";
                        }else if (cmb.SelectedValue == "Mniejsze niż")
                        {
                            option = "<";
                        }
                        else if (cmb.SelectedValue == "Jest równe")
                        {
                            option = "=";
                        }
                        else if (cmb.SelectedValue == "Jest różne od")
                        {
                            option = "<>";
                        }
                        else if (cmb.SelectedValue == "Większe niż")
                        {
                            option = ">=";
                        }else if (cmb.SelectedValue == "Większe lub równe niż")
                        {
                            option = ">=";
                        }

                        res += $"{col.Name}{option}{val.Text}";
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

        public frmFilter(Form parent, DataGridView dg)
        {
            InitializeComponent();
            //Let's create filter columns based on given data grid view
            _this = new Filter();
            int i = 0;

            foreach(DataGridViewColumn col in dg.Columns)
            {
                FilterColumnValueType cType;
                if(col.ValueType==typeof(int) || col.ValueType == typeof(float))
                {
                    cType = FilterColumnValueType.Number;
                }else if (col.ValueType == typeof(DateTime))
                {
                    cType = FilterColumnValueType.Date;
                }
                else
                {
                    cType = FilterColumnValueType.Text;
                }
                FilterColumn nCol = new FilterColumn(col.Name, _this, cType, i, col.HeaderText);
                i++;
            }
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
                        tlpItems.Controls.Add(nCombo, 2, rowIndex);
                        nCombo.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                        nCombo.SelectionLength = 0;
                    }
                    else
                    {
                        if(col.ValueType == FilterColumnValueType.Date)
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
                        }
                        else
                        {
                            TextBox nText = new TextBox();
                            nText.Name = col.Name;
                            tlpItems.Controls.Add(nText, 2, rowIndex);
                            nText.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                            if(col.ValueType== FilterColumnValueType.Text)
                            {
                                Options.Add("Jest równe");
                                Options.Add("Jest różne od");
                                Options.Add("Zawiera");
                                Options.Add("Nie zawiera");
                            }
                            else
                            {
                                Options.Add("Mniejsze lub równe niż");
                                Options.Add("Mniejsze niż");
                                Options.Add("Jest równe");
                                Options.Add("Jest różne od");
                                Options.Add("Większe niż");
                                Options.Add("Większe lub równe niż");
                            }
                        }
                        
                        
                    }
                    nComb.DataSource = Options;
                    nComb.Name = "cmbOptions" + col.Ordinal;
                    tlpItems.Controls.Add(nComb, 1, rowIndex);
                    nComb.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                    nComb.SelectionLength = 0;
                    counter++;
                }
            }
        }

        private void nDTPicker_ValueChanged(object sender, EventArgs e)
        {
            ((DateTimePicker)sender).CustomFormat = "yyyy-MM-dd HH:mm";
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
            MessageBox.Show(this.FilterString);
        }
    }
}

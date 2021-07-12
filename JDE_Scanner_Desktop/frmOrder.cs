using JDE_Scanner_Desktop.Classes;
using JDE_Scanner_Desktop.CustomControls;
using JDE_Scanner_Desktop.Models;
using JDE_Scanner_Desktop.Static;
using MoreLinq.Experimental;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Menu;
using File = JDE_Scanner_Desktop.Models.File;

namespace JDE_Scanner_Desktop
{
    public partial class frmOrder : Form
    {
        int mode; //1-add, 2-edit, 3-view
        Order _this;
        frmLooper Looper;
        ContextMenu buttonContextMenu;
        CompaniesKeeper SupplierKeeper;
        BindingSource source = new BindingSource();
        PartFinder Finder;
        Point CurrentRowPoint;
        public bool IsLoading { get; set; } = false;

        public frmOrder(Form parent)
        {
            Init(parent);
            mode = 1;
            _this = new Order();
            StyleAsNew();
        }

        public frmOrder(Order Item, Form parent)
        {
            Init(parent);
            mode = 2;
            _this = Item;
            
        }

        private void Init(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            SupplierKeeper = new CompaniesKeeper();
        }

        private void StyleAsNew()
        {
            this.lblCreated.Visible = false;
            cboxArchived.CheckState = CheckState.Indeterminate;
            this.Text = "Nowe zamówienie";
        }

        private void StyleAsExistent()
        {
            this.Text = "Szczegóły zamówienia";
            if (_this.DeliveryOn == null)
            {
                txtDeliveryDate.CustomFormat = "";
            }
            if (_this.CreatedOn != null && _this.CreatedBy != 0)
            {
                lblCreated.Text = "Utworzone w dniu " + _this.CreatedOn + " przez " + _this.CreatedByName;
                lblCreated.Visible = true;
            }
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            Looper.Show(this);
            IsLoading = true;
            Finder = new PartFinder(dgvItems);
            var LoadParts = Task.Run(() => Finder.Init());
            List<Task> LoadingTasks = new List<Task>();
            LoadingTasks.Add(Task.Run(() => SupplierKeeper.Refresh("TypeId=2")));
            LoadingTasks.Add(Task.Run(() => _this.ItemKeeper.Refresh($"OrderId={_this.OrderId}")));
            await Task.WhenAll(LoadingTasks);
            new AutoCompleteBehavior<Company>(this.cmbSupplier, SupplierKeeper.Items);
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "CompanyId";
            source.DataSource = _this.ItemKeeper.Items;
            dgvItems.DataSource = source;
            var Columns = new List<string>() { "PartId", "PartName", "PartSymbol", "Amount", "Unit", "Price", "Currency" };
            dgvItems.AdjustColumnVisibility(Columns);
            dgvItems.TabAction = () => Finder.TabPressed();
            this.Controls.Add(Finder);
            

            if (mode > 1)
            {
                BindFromObject();
            }
            else
            {

            }
            IsLoading = false; 
            Looper.Hide();
        }

        private void BindFromObject()
        {
            txtNumber.Text = _this.OrderNo;
            txtSupplierOrderNo.Text = _this.SuppliersOrderNo;
            cboxArchived.CheckState = _this.IsArchived.ToCheckboxState();
            cmbSupplier.SelectedIndex = cmbSupplier.FindStringExact(_this.SupplierName);
            if(_this.DeliveryOn != null)
            {
                txtDeliveryDate.Value = _this.DeliveryOn.Value;
            }
        }

        private void BindToObject()
        {
            _this.OrderNo = txtNumber.Text;
            _this.SuppliersOrderNo = txtSupplierOrderNo.Text;
            _this.IsArchived = cboxArchived.CheckState.CheckboxStateToNullableBool();
            if (cmbSupplier.SelectedItem != null)
            {
                _this.SupplierId = (int)cmbSupplier.GetSelectedValue<Company>();
            }
            if (txtDeliveryDate.Value != null)
            {
                _this.DeliveryOn = txtDeliveryDate.Value;
            }
        }
        

        private async void Save(object sender, EventArgs e)
        {
            BindToObject();
            try
            {
                Looper.Show(this);
                string res = string.Empty;

                if (mode == 1)
                {
                    _this.CreatedBy = RuntimeSettings.UserId;
                    _this.CreatedOn = DateTime.Now;
                    
                    if(await _this.Add())
                    {
                        mode = 2;
                        this.Text = "Szczegóły zamówienia";
                    }
                    
                }
                else if (mode == 2)
                {

                    res = await _this.Edit();
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd podczas zapisywania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Looper.Hide();
            }
                
        }

        private void dgvItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(e.ColumnIndex == dgvItems.Columns["Price"].Index)
            {
                dgvItems.Rows[e.RowIndex].ErrorText = "";
                double newValue;
                if (!dgvItems.Rows[e.RowIndex].IsNewRow)
                {
                    if(!double.TryParse(e.FormattedValue.ToString(), out newValue) && e.FormattedValue!=string.Empty)
                    {
                        e.Cancel = true;
                        string errMsg = "Pole Koszt wymaga podania wartości liczbowych!";
                        dgvItems.Rows[e.RowIndex].ErrorText = errMsg;
                        MessageBox.Show(errMsg, "Nieprawidłowy format danych", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }else if(e.ColumnIndex == dgvItems.Columns["Amount"].Index)
            {
                dgvItems.Rows[e.RowIndex].ErrorText = "";
                double newValue;
                if (!dgvItems.Rows[e.RowIndex].IsNewRow)
                {
                    if (!double.TryParse(e.FormattedValue.ToString(), out newValue) && e.FormattedValue != string.Empty)
                    {
                        e.Cancel = true;
                        string errMsg = "Pole Ilość wymaga podania wartości liczbowych!";
                        dgvItems.Rows[e.RowIndex].ErrorText = errMsg;
                        MessageBox.Show(errMsg, "Nieprawidłowy format danych", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            else if (e.ColumnIndex == dgvItems.Columns["PartId"].Index)
            {
                dgvItems.Rows[e.RowIndex].ErrorText = "";
                int newValue;
                if (!dgvItems.Rows[e.RowIndex].IsNewRow)
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out newValue) && e.FormattedValue != string.Empty)
                    {
                        e.Cancel = true;
                        string errMsg = "Pole ID części wymaga podania wartości liczbowych!";
                        dgvItems.Rows[e.RowIndex].ErrorText = errMsg;
                        MessageBox.Show(errMsg, "Nieprawidłowy format danych", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            else if (e.ColumnIndex == dgvItems.Columns["Unit"].Index)
            {
                dgvItems.Rows[e.RowIndex].ErrorText = "";
                List<string> values = Enum.GetNames(typeof(Enums.PartUnit)).ToList();

                int newValue;
                if (!dgvItems.Rows[e.RowIndex].IsNewRow)
                {
                    if (!values.Contains(e.FormattedValue.ToString()) && e.FormattedValue != string.Empty)
                    {
                        e.Cancel = true;
                        string errMsg = $"Pole Jednostka zawiera nieprawidłową wartość. Prawidłowe wartości to: {string.Join(",", values)}";
                        dgvItems.Rows[e.RowIndex].ErrorText = errMsg;
                        MessageBox.Show(errMsg, "Nieprawidłowy wartość", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        private AutoCompleteStringCollection CreateAutoCompleteList(string colName)
        {
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();

            if(colName == "Unit")
            {
                foreach (var i in Enum.GetValues(typeof(Enums.PartUnit)))
                {
                    col.Add(i.ToString());
                }
            }else if(colName == "Currency")
            {
                foreach (var i in Enum.GetValues(typeof(Enums.Currency)))
                {
                    col.Add(i.ToString());
                }
            }
            return col;
            
        }

        private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string headerText = dgvItems.Columns[dgvItems.CurrentCell.ColumnIndex].HeaderText;
            if(headerText == "Jednostka")
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.Suggest;
                    tb.AutoCompleteCustomSource = CreateAutoCompleteList("Unit");
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }else if (headerText == "Waluta")
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.Suggest;
                    tb.AutoCompleteCustomSource = CreateAutoCompleteList("Currency");
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else if (headerText == "ID części")
            {
                TextBox tb = e.Control as TextBox;
                tb.TextChanged += new EventHandler(PartIdTextChanged);
                tb.KeyPress += new KeyPressEventHandler(PartIdKeyPressed);
            }
            else
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.None;
                }
            }
        }

        private async void PartIdTextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (!string.IsNullOrEmpty(tb.Text))
            {
                //HandleTab(tb);
                if (tb.Text.Length > 1)
                {
                    await Finder.Find(tb.Text);
                    await Finder.Show(CurrentRowPoint);
                }
            }
            else
            {
                //HandleTab(tb);
            }
            
        }

        private void PartIdKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n' || e.KeyChar == '\t')
            {
                MessageBox.Show("TERAZ");
            }
        }

        //private void HandleTab(TextBox tb)
        //{
        //    if (tb.Text == null)
        //    {
        //        tb.PreviewKeyDown += (sender, e) =>
        //        {
        //            if (e.KeyData == Keys.Tab)
        //            {
        //                e.IsInputKey = true;
        //            }
        //        };
        //    }
        //    else
        //    {
        //        tb.PreviewKeyDown += (sender, e) =>
        //        {
        //            if (e.KeyData == Keys.Tab)
        //            {
        //                e.IsInputKey = false;
        //            }
        //        };
        //    }

        //}

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvItems.Columns[e.ColumnIndex].Name;
            if(colName == "PartId")
            {
                int rowHeight = dgvItems.Rows[e.RowIndex].Height;
                Rectangle Cell = dgvItems.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Cell.X += dgvItems.Left;
                Cell.Y += dgvItems.Top + rowHeight;
                CurrentRowPoint = PointToScreen(new Point(Cell.X, Cell.Y + dgvItems.Top));
            }

        }
    }
}

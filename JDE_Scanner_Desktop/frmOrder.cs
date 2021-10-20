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
            StyleAsExistent();
            
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
            
            List<Task> LoadingTasks = new List<Task>();
            LoadingTasks.Add(Task.Run(() => SupplierKeeper.Refresh("TypeId=2")));
            LoadingTasks.Add(Task.Run(() => _this.ItemKeeper.Refresh($"OrderId={_this.OrderId}")));
            await Task.WhenAll(LoadingTasks);
            SetPartFinder();
            new AutoCompleteBehavior<Company>(this.cmbSupplier, SupplierKeeper.Items);
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "CompanyId";
            source.DataSource = _this.ItemKeeper.Items;
            dgvItems.DataSource = source;
            AdjustColumns();
            StyleEditable(_this.IsArchived);
            StyleItemsArchived();
            dgvItems.TabAction = () => Finder.TabPressed();
            dgvItems.TabListeningColumns = new List<string>() { "PartId" };
            dgvItems.EnterAction = () => Finder.EnterPressed();
            dgvItems.EnterListeningColumns = new List<string>() { "PartId" };
            dgvItems.KeyDownAction = () => Finder.GetFocus();
            dgvItems.EscapeAction = () => Finder.Hide();

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

        private void StyleEditable(bool? val)
        {
            bool _val = val ?? false;

            dgvItems.AllowUserToAddRows = !_val;
            dgvItems.AllowUserToDeleteRows = !_val;
            btnArchiveItem.Enabled = !_val;
            btnSave.Enabled = !_val;
        }

        private void AdjustColumns()
        {
            var Columns = new List<string>() {"PartId", "PartName", "Symbol", "Amount", "Unit", "Delivered", "Price", "Currency", "IsArchived" };
            dgvItems.AdjustColumnVisibility(Columns);
            dgvItems.Columns["PartName"].ReadOnly = true;
            dgvItems.Columns["PartName"].MinimumWidth = 150;
            dgvItems.Columns["PartName"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvItems.Columns["IsArchived"].ReadOnly = true;
            dgvItems.Columns["IsArchived"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvItems.Columns["Delivered"].ReadOnly = true;
            dgvItems.Columns["Delivered"].DefaultCellStyle.BackColor = Color.LightGray;

        }

        private void StyleItemsArchived()
        {
            foreach(DataGridViewRow item in dgvItems.Rows)
            {
                if (item.Cells["IsArchived"].Value != null)
                {
                    if (item.Cells["IsArchived"].Value.ToString() == true.ToString())
                    {
                        foreach (DataGridViewCell cell in item.Cells)
                        {
                            cell.ReadOnly = true;
                            cell.Style.BackColor = Color.LightGray;
                        }
                    } 
                }
            }
        }

        private async Task SetPartFinder()
        {
            Finder = new PartFinder(dgvItems);
            List<string> columns = new List<string>() {"PartId", "Name", "ProducerName", "Symbol", "SupplierName", "CreatedOn" };
            Finder.AdjustColumns(columns);
            this.Controls.Add(Finder);
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
            _this.AddMissingOrderIds();

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
                        string r = await _this.ItemKeeper.AddAll();
                        if (r == "OK")
                        {
                            mode = 2;
                            this.Text = "Szczegóły zamówienia";
                        }
                        else
                        {
                            MessageBox.Show($"Upps.. Coś poszło nie tak.. Szczegóły: {r}", "Bład zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                    
                }
                else if (mode == 2)
                {
                    res = await _this.Edit();
                    if(res == "OK")
                    {
                        res = await _this.ItemKeeper.EditAll();
                        if(res == "OK")
                        {
                            MessageBox.Show("Zapis zakończony powodzeniem!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    
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
            if (cboxShowFinder.Checked)
            {
                TextBox tb = (TextBox)sender;

                if (!string.IsNullOrEmpty(tb.Text))
                {
                    if (dgvItems.Columns[dgvItems.CurrentCell.ColumnIndex].Name == "PartId")
                    {
                        if (tb.Text.Length > 1)
                        {
                            if (await Finder.Find(tb.Text))
                            {
                                List<string> columns = new List<string>() { "PartId", "Name", "ProducerName", "Symbol", "SupplierName", "CreatedOn" };
                                Finder.AdjustColumns(columns);
                                await Finder.Show(CurrentRowPoint);
                            }
                            else
                            {
                                Finder.Hide();
                            }
                        }
                    }
                } 
            }
        }

        private void dgvItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (cboxShowFinder.Checked)
            {
                string colName = dgvItems.Columns[e.ColumnIndex].Name;
                if (colName == "PartId" && e.RowIndex >= 0)
                {
                    int rowHeight = dgvItems.Rows[e.RowIndex].Height;
                    Rectangle Cell = dgvItems.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    Cell.X += dgvItems.Left;
                    Cell.Y += dgvItems.Top;
                    CurrentRowPoint = PointToScreen(new Point(Cell.X, Cell.Y + dgvItems.Top));
                }
            }
        }

        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(IsLoading == false) //avoid triggering when data initally loads on form loading
            {
                string colName = dgvItems.Columns[e.ColumnIndex].Name;
                if (colName == "PartId" && e.RowIndex >= 0)
                {
                    if(dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        PopulateRow(e.RowIndex);
                    }
                    else
                    {
                        ClearRow(e.RowIndex);
                    }
                }
            }
        }

        private void PopulateRow(int rowNumber)
        {
            int partId; 
            if(int.TryParse(dgvItems.Rows[rowNumber].Cells[dgvItems.Columns["PartId"].Index].Value.ToString(), out partId))
            {
                Part CurrentPart = RuntimeSettings.PartBackup.Items.FirstOrDefault(i => i.PartId == partId);
                if(CurrentPart != null)
                {
                    dgvItems.Rows[rowNumber].Cells[dgvItems.Columns["PartName"].Index].Value = CurrentPart.Name;
                    dgvItems.Rows[rowNumber].Cells[dgvItems.Columns["Unit"].Index].Value = Enum.GetValues(typeof(Enums.PartUnit)).GetValue(0).ToString();
                    if (CurrentPart.Price != null)
                    {
                        dgvItems.Rows[rowNumber].Cells[dgvItems.Columns["Price"].Index].Value = CurrentPart.Price;
                        dgvItems.Rows[rowNumber].Cells[dgvItems.Columns["Currency"].Index].Value = CurrentPart.Currency;
                    }
                    else
                    {
                        dgvItems.Rows[rowNumber].Cells[dgvItems.Columns["Price"].Index].Value = null;
                        dgvItems.Rows[rowNumber].Cells[dgvItems.Columns["Currency"].Index].Value = null;
                    }
                }
                
            }
        }

        private void ClearRow(int rowNumber)
        {
            dgvItems.Rows[rowNumber].Cells[dgvItems.Columns["PartName"].Index].Value = null;
            dgvItems.Rows[rowNumber].Cells[dgvItems.Columns["Unit"].Index].Value = null;
            dgvItems.Rows[rowNumber].Cells[dgvItems.Columns["Price"].Index].Value = null;
            dgvItems.Rows[rowNumber].Cells[dgvItems.Columns["Currency"].Index].Value = null;
        }

        private async void btnArchiveItem_Click(object sender, EventArgs e)
        {
            if (RuntimeSettings.CurrentUser.IsAuthorized(Enums.Authorizations.ARCHIVE_ORDER_ITEM))
            {
                if(dgvItems.SelectedRows.Count > 0)
                {
                    List<int> SelectedRows = new List<int>();
                    for (int i = dgvItems.SelectedRows.Count - 1; i >= 0; i--)
                    {
                        if((int)dgvItems.SelectedRows[i].Cells[0].Value > 0)
                        {
                            SelectedRows.Add((int)dgvItems.SelectedRows[i].Cells[0].Value);
                        }
                        else
                        {
                            dgvItems.Rows.Remove(dgvItems.SelectedRows[i]);
                        }
                        
                    }
                    if (SelectedRows.Any())
                    {
                        await _this.ItemKeeper.Archive(SelectedRows);
                        _this.SetArchived(SelectedRows);
                        StyleItemsArchived();
                    }
                }
                else
                {
                    MessageBox.Show("Żaden wiersz nie jest zaznaczony. Zaznacz wiersze, które chcesz usunąć klikając po ich lewej stronie", "Brak zaznaczenia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cboxShowFinder_CheckedChanged(object sender, EventArgs e)
        {
            dgvItems.AreSpecKeysEnabled = cboxShowFinder.Checked;
        }
    }
}

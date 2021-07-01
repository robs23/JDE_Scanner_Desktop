using JDE_Scanner_Desktop.Classes;
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
            List<Task> LoadingTasks = new List<Task>();
            LoadingTasks.Add(Task.Run(() => SupplierKeeper.Refresh("TypeId=2")));
            LoadingTasks.Add(Task.Run(() => _this.ItemKeeper.Refresh($"OrderId={_this.OrderId}")));
            await Task.WhenAll(LoadingTasks);
            new AutoCompleteBehavior<Company>(this.cmbSupplier, SupplierKeeper.Items);
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "CompanyId";
            source.DataSource = _this.ItemKeeper.Items;
            dgvItems.DataSource = source;

            if (mode > 1)
            {
                BindFromObject();
            }
            else
            {

            }
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

    }
}

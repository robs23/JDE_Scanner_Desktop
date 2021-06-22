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
    public partial class frmStorageBin : Form
    {
        int mode; //1-add, 2-edit, 3-view
        StorageBin _this;
        frmLooper Looper;
        ContextMenu buttonContextMenu;

        public frmStorageBin(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            lblCreated.Visible = false;
            cboxArchived.CheckState = CheckState.Indeterminate;
            this.Text = "Nowy regał magazynowy";
            _this = new StorageBin();
        }

        public frmStorageBin(StorageBin Item, Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły regału magazynowego";
            _this = Item;
            txtNumber.Text = _this.Number;
            txtName.Text = _this.Name;
            cboxArchived.CheckState  = _this.IsArchived.ToCheckboxState();
            if(_this.CreatedOn != null && _this.CreatedBy != 0)
            {
                lblCreated.Text = "Utworzone w dniu " + _this.CreatedOn + " przez " + _this.CreatedByName;
                lblCreated.Visible = true;
            }
            if (_this.Token != null)
            {
                GenerateQrCode(_this.Token);
            }
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            Looper.Show(this);
            if (mode > 1)
            {

            }
            else
            {

            }
            Looper.Hide();
        }
        

        private async void Save(object sender, EventArgs e)
        {
            _this.Number = txtNumber.Text;
            _this.Name = txtName.Text;
            _this.IsArchived = cboxArchived.CheckState.CheckboxStateToNullableBool();
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
                        this.Text = "Szczegóły regału magazynowego";
                        GenerateQrCode(_this.Token);
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


        private void GenerateQrCode(string qrStr)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrStr, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrImage = qrCode.GetGraphic(2);
            pbQrCode.Image = qrImage;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //print
            StorageBinKeeper keeper = new StorageBinKeeper();
            keeper.Items.Add(_this);
            List<int> lInt = new List<int>();
            lInt.Add(_this.StorageBinId);
            keeper.PrintQR(lInt);
        }


        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            if(_this.StorageBinId > 0)
            {
                //frmGetPartData StockForm = new frmGetPartData(Enums.PartDataFormType.Stock, _this.PartId);
                //StockForm.Show(this);
            }
            else
            {
                MessageBox.Show("Aby zinwentaryzować zapas, należy najpierw zapisać regał. Kliknij ikonę dyskietki by zapisać regał.", "Regał nie został jeszcze utworzony", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

    }
}

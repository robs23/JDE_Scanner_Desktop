using JDE_Scanner_Desktop.Models;
using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop
{
    public partial class frmPart : Form
    {
        int mode; //1-add, 2-edit, 3-view
        Part _this;
        frmLooper Looper;
        CompaniesKeeper producers;
        CompaniesKeeper suppliers;

        public frmPart(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            lblCreated.Visible = false;
            this.Text = "Nowa część";
            _this = new Part();
        }

        public frmPart(Part Item, Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły części";
            _this = Item;
            txtName.Text = _this.Name;
            txtDescription.Text = _this.Description;
            txtEAN.Text = _this.EAN;
            txtProducersCode.Text = _this.ProducentsCode;
            txtSymbol.Text = _this.Symbol;
            txtAppliance.Text = _this.Appliance;
            txtDestination.Text = _this.Destination;
            txtUsedOn.Text = _this.UsedOn;
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

        private async void SetComboboxes()
        {
            //int sId;
            //int pId;
            //if (cmbProducer.SelectedItem != null)
            //{
            //    pId = (int)cmbProducer.SelectedValue;
            //}
            //if(cmbSupplier.SelectedItem != null)
            //{
            //    sId = (int)cmbSupplier.SelectedValue;
            //}
            await producers.Refresh("TypeId=2");
            await suppliers.Refresh("TypeId=1");
            cmbProducer.DataSource = producers.Items;
            cmbProducer.DisplayMember = "Name";
            cmbProducer.ValueMember = "CompanyId";
            cmbSupplier.DataSource = suppliers.Items;
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "CompanyId";
            if (mode != 1)
            {
                cmbProducer.SelectedIndex = cmbProducer.FindStringExact(_this.ProducerName);
                cmbSupplier.SelectedIndex = cmbSupplier.FindStringExact(_this.SupplierName);
            }
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            Looper.Show(this);
            producers = new CompaniesKeeper();
            suppliers = new CompaniesKeeper();
            SetComboboxes();
            Looper.Hide();
        }

        private async void Save(object sender, EventArgs e)
        {
            _this.Name = txtName.Text;
            _this.Description = txtDescription.Text;
            _this.EAN = txtEAN.Text;
            _this.ProducentsCode = txtProducersCode.Text;
            _this.Symbol = txtSymbol.Text;
            _this.Destination = txtDestination.Text;
            _this.Appliance = txtAppliance.Text;
            _this.UsedOn = txtUsedOn.Text;
            _this.ProducerId = Convert.ToInt32(cmbProducer.SelectedValue.ToString());
            _this.SupplierId = Convert.ToInt32(cmbSupplier.SelectedValue.ToString());
            try
            {
                Looper.Show(this);
                if (mode == 1)
                {
                    _this.CreatedBy = RuntimeSettings.UserId;
                    _this.CreatedOn = DateTime.Now;
                    if(await _this.Add())
                    {
                        mode = 2;
                        this.Text = "Szczegóły części";
                        GenerateQrCode(_this.Token);
                    }
                    
                }
                else if (mode == 2)
                {
                    _this.Edit();
                }
            }catch(Exception ex)
            {

            }
            finally
            {
                Looper.Hide();
            }
                
        }

        private void AddCompany(object sender, EventArgs e)
        {
            frmCompany Item = new frmCompany(this);
            Item.FormClosed += Company_FormClosed;
            Item.Show(this);
        }

        private void Company_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetComboboxes();
        }

        private void EditProducer(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cmbProducer.SelectedValue);

            Company item = new Company();
            item = producers.Items.Where(u => u.CompanyId == id).FirstOrDefault();
            frmCompany ItemForm = new frmCompany(item, this);
            ItemForm.FormClosed += Company_FormClosed;
            ItemForm.Show();
        }

        private void EditSupplier(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cmbSupplier.SelectedValue);

            Company item = new Company();
            item = suppliers.Items.Where(u => u.CompanyId == id).FirstOrDefault();
            frmCompany ItemForm = new frmCompany(item, this);
            ItemForm.FormClosed += Company_FormClosed;
            ItemForm.Show();
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
            printQrCode();
        }

        private void printQrCode()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                doc.DefaultPageSettings.Landscape = false;
                doc.Print();
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = Utilities.GetQR(_this.Token, 3);
            e.Graphics.DrawImage(bm, 30, 10);
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            RectangleF rectF = new RectangleF(10, 130, 150, 50);//part's name
            RectangleF rectFB = new RectangleF(15, 170, 150, 50);//part's code
            e.Graphics.DrawString(_this.Name, new Font("Tahoma", 8), Brushes.Black, rectF);
            e.Graphics.DrawString(_this.Identifier, new Font("Tahoma", 9, FontStyle.Bold), Brushes.Black, rectFB);
            e.Graphics.Flush();
            bm.Dispose();
        }
    }
}

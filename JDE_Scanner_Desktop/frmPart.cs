﻿using JDE_Scanner_Desktop.Classes;
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
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Menu;

namespace JDE_Scanner_Desktop
{
    public partial class frmPart : Form
    {
        int mode; //1-add, 2-edit, 3-view
        Part _this;
        frmLooper Looper;
        CompaniesKeeper producers;
        CompaniesKeeper suppliers;
        BomKeeper boms = new BomKeeper();
        FileKeeper files;
        FileKeeper img;
        ContextMenu buttonContextMenu;

        public frmPart(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            lblCreated.Visible = false;
            cboxArchived.CheckState = CheckState.Indeterminate;
            this.Text = "Nowa część";
            _this = new Part();
            files = new FileKeeper(this);
            img = new FileKeeper(this);
        }

        public frmPart(Part Item, Form parent)
        {
            InitializeComponent();
            img = new FileKeeper(this);
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły części";
            _this = Item;
            files = new FileKeeper(this);
            txtName.Text = _this.Name;
            txtDescription.Text = _this.Description;
            txtEAN.Text = _this.EAN;
            txtProducersCode.Text = _this.ProducentsCode;
            txtSymbol.Text = _this.Symbol;
            txtAppliance.Text = _this.Appliance;
            txtDestination.Text = _this.Destination;
            txtUsedOn.Text = _this.UsedOn;
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

        private async Task SetComboboxes()
        {
            await producers.Refresh("TypeId=1",'a');
            await suppliers.Refresh("TypeId=2",'a');

            new AutoCompleteBehavior<Company>(cmbProducer, producers.Items);
            cmbProducer.DisplayMember = "Name";
            cmbProducer.ValueMember = "CompanyId";
            new AutoCompleteBehavior<Company>(cmbSupplier, suppliers.Items);
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
            InitiailizeButtonContextMenu();
            if (mode > 1)
            {
                GetBoms();
                GetImage();
            }
            else
            {
                btnAdd.Enabled = false;
                btnRemove.Enabled = false;
            }
            Looper.Hide();
        }

        private async void GetBoms()
        {
            await boms.Refresh($"PartId={_this.PartId}");
            dgvBoms.DataSource = boms.Items;

        }

        private async void GetImage()
        {
            if (!string.IsNullOrEmpty(_this.Image))
            {
                pbImage.Image = await img.GetImage(_this.Image, false,true);
                pbImage.SizeMode = PictureBoxSizeMode.Zoom;
                img.Items.Add(new Models.File { Name = _this.Image, IsUploaded = true, Link = Path.Combine(RuntimeSettings.LocalFilesPath, _this.Image) });
            }
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
            _this.IsArchived = cboxArchived.CheckState.CheckboxStateToNullableBool();
            _this.ProducerId = cmbProducer.GetSelectedValue<Company>();
            _this.SupplierId = cmbSupplier.GetSelectedValue<Company>();
            string photoPath = null;
            if (img.Items.Any())
            {
                photoPath = img.Items[0].Link;
            }
            try
            {
                Looper.Show(this);
                if (mode == 1)
                {
                    _this.CreatedBy = RuntimeSettings.UserId;
                    _this.CreatedOn = DateTime.Now;
                    
                    if(await _this.Add(photoPath))
                    {
                        if (files.Items.Where(i => i.IsUploaded == false).Any())
                        {
                            //there are some files not uploaded to cloud
                            foreach (Models.File f in files.Items.Where(i => i.IsUploaded == false))
                            {
                                if (await f.Add(_this.PartId))
                                {
                                    f.IsUploaded = true;
                                }
                            }
                        }
                        mode = 2;
                        this.Text = "Szczegóły części";
                        GenerateQrCode(_this.Token);
                        btnAdd.Enabled = true;
                        btnRemove.Enabled = true;
                    }
                    
                }
                else if (mode == 2)
                {
                    _this.Edit(photoPath);
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

        private async void Company_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetComboboxes();
        }

        private void EditProducer(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cmbProducer.GetSelectedValue<Company>());

            Company item = new Company();
            item = producers.Items.Where(u => u.CompanyId == id).FirstOrDefault();
            frmCompany ItemForm = new frmCompany(item, this);
            ItemForm.FormClosed += Company_FormClosed;
            ItemForm.Show();
        }

        private void EditSupplier(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cmbSupplier.GetSelectedValue<Company>());

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
            PartKeeper partKeeper = new PartKeeper();
            partKeeper.Items.Add(_this);
            List<int> lInt = new List<int>();
            lInt.Add(_this.PartId);
            partKeeper.PrintQR(lInt);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBomItem form = new frmBomItem(this,_this.PartId,null);
            form.Show(this);
        }

        private void btnRefreshBoms_Click(object sender, EventArgs e)
        {
            GetBoms();
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvBoms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Żaden wiersz nie jest zaznaczony. Aby usunąć wybrane wiersze, najpierw zaznacz je kliknięciem po ich lewej stronie.");
            }
            else
            {
                Looper.Show(this);
                List<int> SelectedRows = new List<int>();
                for (int i = 0; i < dgvBoms.SelectedRows.Count; i++)
                {
                    SelectedRows.Add((int)dgvBoms.SelectedRows[i].Cells[0].Value);
                }
                await boms.Remove(SelectedRows);
                Looper.Hide();
                GetBoms();
            }
        }

        private void dgvBoms_DoubleClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvBoms.Rows[dgvBoms.CurrentCell.RowIndex].Cells[0].Value);
            Bom item = new Bom();
            item = boms.Items.Where(i => i.BomId == id).FirstOrDefault();
            frmBomItem form = new frmBomItem(item,this);
            form.Show(this);
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            //files.ShowFiles();
        }

        private void pbImage_DoubleClick(object sender, EventArgs e)
        {
            LoadImg();
        }

        private void LoadImg()
        {
            //Let's add  new image
            
            img.LoadFromDisk(false);
            if (img.Items.Any())
            {
                pbImage.Image = Image.FromFile(img.Items[0].Link);
                pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        public void InitiailizeButtonContextMenu()
        {
            buttonContextMenu = new ContextMenu();
            MenuItem miChange = new MenuItem("Zmień zdjęcie");
            miChange.Click += ChangeImage;
            MenuItem miDelete = new MenuItem("Usuń zdjęcie");
            miDelete.Click += DeleteImage;

            MenuItemCollection collection = new MenuItemCollection(buttonContextMenu);
            collection.Add(miChange);
            collection.Add(miDelete);
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            if(((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (img.Items.Any())
                {
                    img.OpenFile(0);
                }
                else
                {
                    LoadImg();
                }
            }
            else
            {
                Control cont = (Control)sender;
                buttonContextMenu.Show(cont, new Point(cont.Location.X+30, cont.Location.Y+30));
            }
            
        }

        public void ChangeImage(object sender, EventArgs e)
        {
            LoadImg();
        }

        public void DeleteImage(object sender, EventArgs e)
        {
            img.Items.Clear();
            pbImage.Image = pbImage.InitialImage;
        }
    }
}

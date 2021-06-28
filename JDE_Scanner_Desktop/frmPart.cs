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
    public partial class frmPart : Form
    {
        int mode; //1-add, 2-edit, 3-view
        Part _this;
        frmLooper Looper;
        CompaniesKeeper producers;
        CompaniesKeeper suppliers;
        BomKeeper boms = new BomKeeper();
        PartUsageKeeper usedParts = new PartUsageKeeper();
        FileKeeper files;
        FileKeeper img;
        PartPriceKeeper PriceKeeper;
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
            PriceKeeper = new PartPriceKeeper();
        }

        public frmPart(Part Item, Form parent)
        {
            InitializeComponent();
            img = new FileKeeper(this);
            PriceKeeper = new PartPriceKeeper();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły części";
            _this = Item;
            files = new FileKeeper(this, Item.PartId);
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
                EnableButtons();
                List<Task> tasks = new List<Task>()
                {
                    Task.Run(() => GetBoms()),
                    Task.Run(() => GetImage()),
                    Task.Run(() => GetUsedParts()),
                    Task.Run(() => GetPrices())
                };
                await Task.WhenAll(tasks);
            }

            files.Initialize();
            Looper.Hide();
        }

        private async Task GetBoms()
        {
            await boms.Refresh($"PartId={_this.PartId}");
            dgvBoms.DataSource = boms.Items;

        }

        private async Task GetUsedParts()
        {
            await usedParts.Refresh($"PartId={_this.PartId}");
            dgvPlaces.DataSource = usedParts.Items;
        }
       

        private async Task GetImage()
        {
            if (!string.IsNullOrEmpty(_this.Image))
            {
                pbImage.ImageLocation = $"{Secrets.ApiAddress}{RuntimeSettings.ThumbnailsPath}/{_this.Image}";
                pbImage.SizeMode = PictureBoxSizeMode.Zoom;
                img.Items.Add(new Models.File { Name = _this.Image, IsUploaded = true, Link = Path.Combine(RuntimeSettings.LocalFilesPath, _this.Image) });
            }
        }

        private async Task GetPrices()
        {
            await PriceKeeper.Refresh($"PartId={_this.PartId}");
            dgvPrices.DataSource = PriceKeeper.Items;
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
                if(img.Items[0].IsUploaded != true)
                {
                    photoPath = img.Items[0].Link;
                }
            }
            try
            {
                Looper.Show(this);
                string res = string.Empty;

                if (mode == 1)
                {
                    _this.CreatedBy = RuntimeSettings.UserId;
                    _this.CreatedOn = DateTime.Now;
                    
                    if(await _this.Add(photoPath))
                    {
                        mode = 2;
                        this.Text = "Szczegóły części";
                        GenerateQrCode(_this.Token);
                        EnableButtons();
                    }
                    
                }
                else if (mode == 2)
                {

                    res = await _this.Edit(photoPath);
                    
                }
                res = await files.Save($"PartId={_this.PartId}");
                if (res != "OK")
                {
                    MessageBox.Show($"Wystąpiły problemy podczas zapisywania plików. Szczegóły: {res}", "Problemy", buttons: MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void EnableButtons()
        {
            btnAdd.Enabled = true;
            btnRemove.Enabled = true;
            btnUpdatePrice.Enabled = true;
            btnUpdateStock.Enabled = true;
            btnPriceDelete.Enabled = true;
            btnRefreshBoms.Enabled = true;
            btnPriceRefresh.Enabled = true;
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
            files.ShowFiles();
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
                    img.OpenFile(img.Items.FirstOrDefault());
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

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            if(_this.PartId > 0)
            {
                frmGetPartData StockForm = new frmGetPartData(Enums.PartDataFormType.Stock, _this.PartId);
                StockForm.Show(this);
            }
            else
            {
                MessageBox.Show("Aby zinwentaryzować zapas, należy najpierw zapisać część. Kliknij ikonę dyskietki by zapisać część.", "Część nie została jeszcze utworzona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            if (_this.PartId > 0)
            {
                frmGetPartData PriceForm = new frmGetPartData(Enums.PartDataFormType.Price, _this.PartId);
                PriceForm.Show(this);
            }
            else
            {
                MessageBox.Show("Aby zaktualizować cenę, należy najpierw zapisać część. Kliknij ikonę dyskietki by zapisać część.", "Część nie została jeszcze utworzona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private async void btnPriceRefresh_Click(object sender, EventArgs e)
        {
            if(mode > 1)
            {
                await GetPrices();
            }
        }

        private async void btnPriceDelete_Click(object sender, EventArgs e)
        {
            if (dgvPrices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Żaden wiersz nie jest zaznaczony. Aby usunąć wybrane wiersze, najpierw zaznacz je kliknięciem po ich lewej stronie.");
            }
            else
            {
                List<int> SelectedRows = new List<int>();
                for (int i = 0; i < dgvPrices.SelectedRows.Count; i++)
                {
                    SelectedRows.Add((int)dgvPrices.SelectedRows[i].Cells[0].Value);
                }
                await PriceKeeper.Remove(SelectedRows);
                await GetPrices();
            }
        }
    }
}

using JDE_Scanner_Desktop.Models;
using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop
{
    public partial class frmCompany : Form
    {
        int mode; //1-add, 2-edit, 3-view
        Company _this;
        frmLooper Looper;

        public frmCompany(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            lblCreated.Visible = false;
            this.Text = "Nowa firma";
            _this = new Company();
        }

        public frmCompany(Company Company, Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły firmy";
            _this = Company;
            txtName.Text = _this.Name;
            txtStreet.Text = _this.Street;
            txtStreet2.Text = _this.Street2;
            txtBuildingNo.Text = _this.BuildingNo;
            txtZipCode.Text = _this.ZipCode;
            txtCity.Text = _this.City;
            txtCountry.Text = _this.Country;
            if(_this.CreatedOn != null && _this.CreatedBy != 0)
            {
                lblCreated.Text = "Utworzone w dniu " + _this.CreatedOn + " przez " + _this.CreatedByName;
                lblCreated.Visible = true;
            }
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            Looper.Show(this);
            Looper.Hide();
        }

        private async void Save(object sender, EventArgs e)
        {
            _this.Name = txtName.Text;
            _this.Street = txtStreet.Text;
            _this.Street2 = txtStreet2.Text;
            _this.BuildingNo = txtBuildingNo.Text;
            _this.ZipCode = txtZipCode.Text;
            _this.City = txtCity.Text;
            _this.Country = txtCountry.Text;

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
                        this.Text = "Szczegóły firmy";
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
    }
}

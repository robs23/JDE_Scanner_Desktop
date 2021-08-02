using JDE_Scanner_Desktop.Classes;
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
    public partial class frmAbandonReason : Form
    {
        int mode; //1-add, 2-edit, 3-view
        AbandonReason _this;
        frmLooper Looper;

        public frmAbandonReason(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            lblCreated.Visible = false;
            cboxArchived.CheckState = CheckState.Indeterminate;
            this.Text = "Nowy powód niewykonania";
            _this = new AbandonReason();
        }

        public frmAbandonReason(AbandonReason Item, Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły powodu niewykonania";
            _this = Item;
            txtName.Text = _this.Name;
            cboxArchived.CheckState  = _this.IsArchived.ToCheckboxState();
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
                        this.Text = "Szczegóły powodu niewykonania";
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

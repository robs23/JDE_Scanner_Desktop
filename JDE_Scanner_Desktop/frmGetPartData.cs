using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JDE_Scanner_Desktop.Static.Enums;

namespace JDE_Scanner_Desktop
{
    public partial class frmGetPartData : Form
    {
        PartDataFormType Type;
        public decimal Value { get; set; }
        public string Unit { get; set; }
        public DateTime Date { get; set; }
        public frmGetPartData(PartDataFormType type)
        {
            InitializeComponent();
            Type = type;
            this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGetPartData_Load(object sender, EventArgs e)
        {
            if(Type == PartDataFormType.Price)
            {
                StyleAsPriceForm();
            }
            else
            {
                StyleAsStockForm();
            }
        }

        private void StyleAsPriceForm()
        {
            lblValue.Text = "Cena";
            lblUnit.Text = "Waluta";
            lblDate.Text = "Ważna od";
            cmbUnit.DataSource = Enum.GetValues(typeof(Currency));
            txtDate.Value = DateTime.Now;
        }

        private void StyleAsStockForm()
        {
            lblValue.Text = "Zapas";
            lblUnit.Text = "Jednostka";
            lblDate.Text = "Data inwentaryzacji";
            cmbUnit.DataSource = Enum.GetValues(typeof(PartUnit));
            txtDate.Value = DateTime.Now;
        }
    }
}

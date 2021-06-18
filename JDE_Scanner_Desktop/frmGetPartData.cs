using JDE_Scanner_Desktop.Models;
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
        public PartPrice Price { get; set; }
        public StockTaking Stock { get; set; }
        public int PartId { get; set; }
        public frmLooper Looper { get; set; }

        public frmGetPartData(PartDataFormType type, int partId)
        {
            InitializeComponent();
            Type = type;
            PartId = partId;
            this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGetPartData_Load(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            if(Type == PartDataFormType.Price)
            {
                StyleAsPriceForm();
                CreatePrice();
            }
            else
            {
                StyleAsStockForm();
                CreateStock();
            }
        }

        private void CreatePrice()
        {
            Price = new PartPrice()
            {
                PartId = PartId,
                CreatedOn = DateTime.Now,
                CreatedBy = RuntimeSettings.CurrentUser.UserId,
                TenantId = RuntimeSettings.TenantId
            };
        }

        private void CreateStock()
        {
            Stock = new StockTaking()
            {
                PartId = PartId,
                CreatedOn = DateTime.Now,
                CreatedBy = RuntimeSettings.CurrentUser.UserId,
                TenantId = RuntimeSettings.TenantId
            };
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

        private async void btnOK_Click(object sender, EventArgs e)
        {
            string res = Validate();
            if(res == "OK")
            {
                try
                {
                    Looper.Show();
                    //Save
                    if (Type == PartDataFormType.Price)
                    {
                        Price.Price = decimal.Parse(txtValue.Text);
                        Price.Currency = cmbUnit.SelectedItem.ToString();
                        Price.ValidFrom = txtDate.Value;
                        await SavePrice();
                    }
                    else
                    {
                        Stock.Amount = int.Parse(txtValue.Text);
                        Stock.CreatedOn = txtDate.Value;
                        await SaveStock();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Napotkano błąd. Szczegóły: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
                finally
                {
                    Looper.Hide();
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show(res, "Dane zawierają błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SaveStock()
        {
            if (await Stock.Add())
            {
                MessageBox.Show($"Inwentaryzacja została zapisana i zapas zaktualizowany", "Powodzenie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Serwer zwrócił błąd, inwentaryzacja nie została zapisana..", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SavePrice()
        {
            if (await Price.Add())
            {
                MessageBox.Show($"Zaktualizowano cenę. Nowa cena będzie obowiązywać od {Price.ValidFrom}.", "Powodzenie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Serwer zwrócił błąd podczas aktualizacji ceny, cena nie została zaktualizowana..", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Validate()
        {
            string res = "OK";
            if (string.IsNullOrEmpty(txtValue.Text))
            {
                res = "Wszystkie pola muszą być wypełnione by kontynuować!";
            }
            else if(Type == PartDataFormType.Price && !decimal.TryParse(txtValue.Text, out decimal price))
            {
                res = "Wpisanej ceny nie udało się przetworzyć na liczbę. Upewnij się, że wpisana cena ma poprawny format liczbowy!";
            }
            else if (Type == PartDataFormType.Stock && !int.TryParse(txtValue.Text, out int stock))
            {
                res = "Wpisanego zapasu nie udało się przetworzyć na liczbę. Upewnij się, że wpisany zapas ma format liczbowy!";
            }
            return res;
        }


    }
}

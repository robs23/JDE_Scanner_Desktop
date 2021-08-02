using JDE_Scanner_Desktop.Classes;
using JDE_Scanner_Desktop.Models;
using JDE_Scanner_Desktop.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Component = JDE_Scanner_Desktop.Models.Component;

namespace JDE_Scanner_Desktop
{
    public partial class frmAddAbandonReasons : Form
    {
        int mode;
        frmLooper Looper;
        public frmAddAbandonReasons(Form parent, int? placeId = null)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 1;
            this.Text = "Masowe dodawanie powodów niewykonania";
        }

        private async void frmAddComponents_Load(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string[] items;
            items = txtComponents.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            List<Task<bool>> tasks = new List<Task<bool>>();
            if(items.Length > 0)
            {
                foreach (string s in items)
                {
                    AbandonReason c = new AbandonReason();
                    c.CreatedBy = RuntimeSettings.UserId;
                    c.CreatedOn = DateTime.Now;
                    c.Name = s;
                    tasks.Add(c.Add());
                }

                string response = "";
                IEnumerable<bool> res = await Task.WhenAll<bool>(tasks);
                if (res.Where(r => r == false).Any())
                {
                    MessageBox.Show($"Nie udało się dodać {res.Count(r => r == false)} powodów. Dodano {res.Count(r => r)} powodów.", "Niepełne powodzenie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Dodawanie {res.Count(r => r)} powodów zakończone powodzeniem.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("W polu tekstowym wpisz nowe powody niewykonania. Jeden powód w jednej linii!", "Nie podano komponentów", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

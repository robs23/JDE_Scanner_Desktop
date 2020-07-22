using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop
{
    public partial class frmInputBox : Form
    {
        public string Response { get; set; }
        public frmInputBox(Form parent, string question, string title=null, string defaultAnswer = null)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X/2, this.Owner.Location.Y/2);
            lblQuestion.Text = question;
            if (title != null)
            {
                this.Text = title;
            }
            if(defaultAnswer != null)
            {
                Response = defaultAnswer;
                txtInput.Text = defaultAnswer;
            }
            this.DialogResult = DialogResult.Cancel; // let's default to cancel
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Response = txtInput.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

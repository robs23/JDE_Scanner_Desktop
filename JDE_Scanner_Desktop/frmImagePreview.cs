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

namespace JDE_Scanner_Desktop
{
    public partial class frmImagePreview : Form
    {
        FileKeeper files;

        public frmImagePreview()
        {
            InitializeComponent();
            files = new FileKeeper(this);
        }

        public async void Load(string name, bool min)
        {
            pbPic.Image = await files.GetAttachment(name, min);
            pbPic.SizeMode = PictureBoxSizeMode.Zoom;
            this.Left = Cursor.Position.X + 30;
            this.Top = Cursor.Position.Y + 30;
            this.Show();
        }
    }
}

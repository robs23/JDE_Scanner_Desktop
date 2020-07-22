using DiffMatchPatch;
using JDE_Scanner_Desktop.Models;
using JsonDiffPatchDotNet;
using JsonDiffPatchDotNet.Formatters.JsonPatch;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class frmLog : Form
    {
        int mode; //1-add, 2-edit, 3-view
        Log _this;
        frmLooper Looper;

        public frmLog(Log Item, Form parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Location = new Point(this.Owner.Location.X + 20, this.Owner.Location.Y + 20);
            mode = 2;
            this.Text = "Szczegóły logu";
            _this = Item;
            txtTimeStamp.Text = _this.TimeStamp.ToString();
            txtUserName.Text = _this.UserName;
            txtDescription.Text = _this.Description;
            txtOldValue.Text = _this.OldValue;
            txtNewValue.Text = _this.NewValue;
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            Looper = new frmLooper(this);
            if(!string.IsNullOrEmpty(_this.NewValue) && !string.IsNullOrEmpty(_this.OldValue))
            {
                var jdp = new JsonDiffPatch();
                JToken diffResult = jdp.Diff(_this.OldValue, _this.NewValue);
                txtDiff.Text = diffResult.ToString(Formatting.Indented).Replace("\\r\\n", "");
            }
        }
    }
}

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
    public partial class frmStarter : Form
    {
        public frmStarter()
        {
            InitializeComponent();
        }

        private void koniecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uzytkownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers FrmUsers = new frmUsers(this);
            FrmUsers.Show(this);
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser FrmUser = new frmUser(this);
            FrmUser.Show(this);
        }

        private void zasobyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPlaces FrmPlaces = new frmPlaces(this);
            FrmPlaces.Show(this);
        }

        private void nowyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPlace FrmPlace = new frmPlace(this);
            FrmPlace.Show(this);
        }

        private void instalacjeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSets FrmSets = new frmSets(this);
            FrmSets.Show(this);
        }

        private void nowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSet FrmSet = new frmSet(this);
            FrmSet.Show(this);
        }

        private void obszaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAreas FrmAreas = new frmAreas(this);
            FrmAreas.Show(this);
        }

        private void nowyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmArea FrmArea = new frmArea(this);
            FrmArea.Show(this);
        }

        private void nowyToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmActionType FrmActionType = new frmActionType(this);
            FrmActionType.Show(this);
        }

        private void typuZleceńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmActionTypes FrmActionTypes = new frmActionTypes(this);
            FrmActionTypes.Show(this);
        }

        private void noweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProcess FrmProcess = new frmProcess(this);
            FrmProcess.Show(this);
        }

        private void zleceniaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProcesses FrmProcesses = new frmProcesses(this);
            FrmProcesses.Show(this);
        }
    }
}

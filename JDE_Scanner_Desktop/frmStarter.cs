﻿using JDE_Scanner_Desktop.Models;
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
            RuntimeSettings.GetPageSize();
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

        private void formLoaded(object sender, EventArgs e)
        {
            frmLogin FrmLogin = new frmLogin(this);
            FrmLogin.ShowDialog(this);
        }

        private void frmStarter_Shown(object sender, EventArgs e)
        {
            if (RuntimeSettings.UserId == 0)
            {
                this.Close();
            }
        }

        private void historiaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLogs FrmLogs = new frmLogs(this);
            FrmLogs.Show(this);
        }

        private void zgłoszeniaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProcesses FrmProcesses = new frmProcesses(this);
            FrmProcesses.Show(this);
        }

        private void noweToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProcess FrmProcess = new frmProcess(this);
            FrmProcess.Show(this);
        }

        private void obsługaZgłoszeńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHandlings FrmHandlings = new frmHandlings(this);
            FrmHandlings.Show(this);
        }

        private void zasobyXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlacesY FrmPlacesY = new frmPlacesY(this);
            FrmPlacesY.Show(this);
        }

        private void nowyToolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            frmActionType FrmActionType = new frmActionType(this);
            FrmActionType.Show(this);
        }

        private void wszystkieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmActionTypes FrmActionTypes = new frmActionTypes(this);
            FrmActionTypes.Show(this);
        }

        private void nowyToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmPlace FrmPlace = new frmPlace(this);
            FrmPlace.Show(this);
        }

        private void wszystkieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPlaces FrmPlaces = new frmPlaces(this);
            FrmPlaces.Show(this);
        }

        private void nowaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSet FrmSet = new frmSet(this);
            FrmSet.Show(this);
        }

        private void wszystkieToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmSets FrmSets = new frmSets(this);
            FrmSets.Show(this);
        }

        private void nowyToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmArea FrmArea = new frmArea(this);
            FrmArea.Show(this);
        }

        private void wszystkieToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmAreas FrmAreas = new frmAreas(this);
            FrmAreas.Show(this);
        }

        private void wszystkieToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmCompanies FrmCompanies = new frmCompanies(this);
            FrmCompanies.Show(this);
        }

        private async void nowaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //new company

            bKeeper keeper = new bKeeper(typeof(Area), "Areas");
            await keeper.Refresh();
            MessageBox.Show(keeper.Items.Count.ToString());
        }
    }
}

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
using static JDE_Scanner_Desktop.Static.Enums;

namespace JDE_Scanner_Desktop
{
    public partial class frmStockTaking : Form
    {
        public StockTakingType Type { get; set; }
        public Part Part { get; set; } = null;
        public StorageBin StorageBin { get; set; } = null;
        public PartKeeper PartKeeper { get; set; }
        public StorageBinKeeper StorageBinKeeper { get; set; }
        public StockTakingKeeper StockTakingKeeper { get; set; }
        public frmStockTaking(Part part)
        {
            InitializeComponent();
            Type = StockTakingType.ByPart;
            Part = part;
            Init();
        }
        public frmStockTaking(StorageBin storageBin)
        {
            InitializeComponent();
            Type = StockTakingType.ByStorageBin;
            StorageBin = storageBin;
            Init();
        }

        private void Init()
        {
            PartKeeper = new PartKeeper();
            StorageBinKeeper = new StorageBinKeeper();
            StockTakingKeeper = new StockTakingKeeper();
        }

        private async Task LoadAllData()
        {
            List<Task> tasks = new List<Task>();
            Task partsLoad = Task.Run(() => PartKeeper.Refresh());
            Task storagesLoad = Task.Run(() => StorageBinKeeper.Refresh());
            tasks.Add(partsLoad);
            tasks.Add(storagesLoad);
            if(StorageBin != null)
            {
                tasks.Add(Task.Run(() => StockTakingKeeper.Refresh()));
            }
            await Task.WhenAll(tasks);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


        }

        private async void frmStockTaking_Load(object sender, EventArgs e)
        {
            
        }
    }
}

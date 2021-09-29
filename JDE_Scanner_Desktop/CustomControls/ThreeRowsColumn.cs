using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace JDE_Scanner_Desktop.CustomControls
{
    public partial class ThreeRowsColumn : UserControl
    {
        private string _Name;
        private IconChar _Icon;
        private Color _NameColor;
        private string _L1Text;
        private Color _L1Color;
        private string _L2Text;
        private Color _L2Color;
        private string _L3Text;
        private Color _L3Color;
        private Action<int?, string> _Action;
        private int? _ActionTypeId;
        private DateTime? _DateFrom;
        private DateTime? _DateTo;
        private Color _barColor;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                btnProcess.Text = value;
            }
        }
        public IconChar Icon
        {
            get { return _Icon; }
            set
            {
                _Icon = value;
                btnProcess.IconChar = value;
            }
        }
        public Color NameColor
        {
            get { return _NameColor; }
            set 
            { 
                _NameColor = value;
                btnProcess.ForeColor = value;
                btnProcess.IconColor = value;
            }
        }
        public string L1Text
        {
            get { return _L1Text; }
            set
            {
                _L1Text = value;
                label1.Text = value;
            }
        }
        public Color L1Color
        {
            get { return _L1Color; }
            set
            {
                _L1Color = value;
                label1.ForeColor = value;
            }
        }

        public Color BarColor
        {
            get { return _barColor; }
            set
            {
                _barColor = value;
            }
        }

        public string L2Text
        {
            get { return _L2Text; }
            set
            {
                _L2Text = value;
                label2.Text = value;
            }
        }
        public Color L2Color
        {
            get { return _L2Color; }
            set
            {
                _L2Color = value;
                label2.ForeColor = value;
            }
        }
        public string L3Text
        {
            get { return _L3Text; }
            set
            {
                _L3Text = value;
                label3.Text = value;
            }
        }
        public Color L3Color
        {
            get { return _L3Color; }
            set
            {
                _L3Color = value;
                label3.ForeColor = value;
            }
        }

        public Action<int?, string> Action
        {
            get { return _Action; }
            set
            {
                _Action = value;
            }
        }

        public int? ActionTypeId
        {
            get { return _ActionTypeId; }
            set { _ActionTypeId = value; }
        }
        
        public DateTime? DateFrom
        {
            get { return _DateFrom; }
            set { _DateFrom = value; }
        }

        public DateTime? DateTo
        {
            get { return _DateTo; }
            set { _DateTo = value; }
        }


        public ThreeRowsColumn(string name = null, IconChar icon = IconChar.None, Color? nameColor = null, string l1Text = null, Color? l1Color = null,
                                string l2Text = null, Color? l2Color = null, string l3Text = null, Color? l3Color = null, Action<int?, string> action=null, int? actionTypeId = null, DateTime? dateFrom=null, DateTime? dateTo=null, Color? barColor = null)
        {
            InitializeComponent();
            Name = name ?? "Rodzaj";
            Icon = icon;
            NameColor = nameColor ?? Color.Black;
            L1Text = l1Text ?? "Ilość [szt.]";
            L1Color = l1Color ?? Color.Black;
            L2Text = l2Text ?? "Czas [min]";
            L2Color = l2Color ?? Color.Black;
            L3Text = l3Text ?? "Razem [%]";
            L3Color = l3Color ?? Color.Black;
            BarColor = barColor ?? Color.Transparent;
            Action = action;
            ActionTypeId = actionTypeId;
            DateFrom = dateFrom;
            DateTo = dateTo;
            
        }

        private void DrawBar(Color barColor)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(barColor);
            SolidBrush sb = new SolidBrush(barColor);
            int x = (btnProcess.Left + (btnProcess.Width / 2))-10;
            int y = btnProcess.Top + btnProcess.Height -10;
            int width = 20;
            int height = 20;
            g.DrawRectangle(p, x, y, width, height);
            g.FillRectangle(sb, x, y, width, height);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string parameters = string.Empty;
            parameters += $@"StartedOn > DateTime({DateFrom.Value.Year},{DateFrom.Value.Month},{DateFrom.Value.Day},{DateFrom.Value.Hour},{DateFrom.Value.Minute},{DateFrom.Value.Second}) 
                            AND StartedOn < DateTime({DateTo.Value.Year},{DateTo.Value.Month},{DateTo.Value.Day},{DateTo.Value.Hour},{DateTo.Value.Minute},{DateTo.Value.Second})";
            Action((int)ActionTypeId, parameters);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if(BarColor != Color.Transparent)
            {
                DrawBar(BarColor);
            }
            
        }
    }
}

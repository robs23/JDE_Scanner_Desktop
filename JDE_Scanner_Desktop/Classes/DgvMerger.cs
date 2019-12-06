using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Classes
{
    public class DgvMerger
    {
        public DataGridView dgv { get; set; }
        public List<string> Columns { get; set; }
        public List<int> ColumnNumbers
        {
            get
            {
                List<int> cNumbers = new List<int>();
                var columnList = dgv.Columns.Cast<DataGridViewColumn>().ToList();
                foreach (var col in Columns)
                {
                    int index = columnList.FindIndex(c => c.Name == col);
                    if(index >= 0)
                    {
                        cNumbers.Add(index);
                    }
                }
                return cNumbers;
            }
        }

        public DgvMerger(DataGridView _dgv, List<string> Cols)
        {
            dgv = _dgv;
            Columns = Cols;
            dgv.CellFormatting += dgv_CellFormatting;
            dgv.CellPainting += dgv_CellPainting;
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgv[column, row];
            DataGridViewCell cell2 = dgv[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (ColumnNumbers.Any(i => i == e.ColumnIndex))
            {
                if (e.RowIndex == 0)
                    return;
                if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }

        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (ColumnNumbers.Any(i=>i==e.ColumnIndex))
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                if (e.RowIndex < 1 || e.ColumnIndex < 0)
                    return;
                if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
                {
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    e.AdvancedBorderStyle.Top = dgv.AdvancedCellBorderStyle.Top;
                }
            }

        }
    }
}

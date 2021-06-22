using JDE_Scanner_Desktop.Static;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class StorageBinKeeper : Keeper<StorageBin>
    {
        protected override string ObjectName => "StorageBin";

        protected override string PluralizedObjectName => "StorageBins";

        protected override string ArchiveString { get; set; } = "IsArchived<>True";

        private int?[] ToPrint { get; set; } = new int?[2];

        public void PrintQR(List<int> ids)
        {
            int[] aId = ids.ToArray();

            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            int i = 0;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                doc.DefaultPageSettings.Landscape = false;
                doc.DefaultPageSettings.PaperSize = new PaperSize("Etykieta", 400, 200);
                doc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                doc.OriginAtMargins = false;
                pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                //doc.DefaultPageSettings.PaperSource = pd.PrinterSettings.DefaultPageSettings.PaperSource;
                //string printerName = pd.PrinterSettings.PrinterName;
                if (ids.Count > 1)
                {
                    ToPrint[0] = aId[0];
                    ToPrint[1] = aId[1];
                    i = 2;
                }
                else
                {
                    ToPrint[0] = aId[0];
                    ToPrint[1] = null;
                    i = 1;
                }
                doc.Print();
                for (int x = i; x < aId.Length; x += 2)
                {
                    ToPrint[0] = aId[x];
                    if (aId.Length - (x + 1) > 0)
                    {
                        //there's code for second half
                        ToPrint[1] = aId[x + 1];
                    }
                    else
                    {
                        //2nd half to be empty
                        ToPrint[1] = null;
                    }
                    doc.Print();
                }
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int A = (int)ToPrint[0];

            Bitmap bm = Utilities.GetQR("<StorageBin>" + Items.Where(i => i.StorageBinId == A).FirstOrDefault().Token, 4);
            e.Graphics.DrawImage(bm, 30, 10);
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            RectangleF rectFA = new RectangleF(20, 130, 150, 50);//number
            RectangleF rectFA2 = new RectangleF(25, 170, 150, 50);//name
            e.Graphics.DrawString(Items.Where(i => i.StorageBinId == A).FirstOrDefault().Number, new Font("Tahoma", 8), Brushes.Black, rectFA);
            e.Graphics.DrawString(Items.Where(i => i.StorageBinId == A).FirstOrDefault().Name, new Font("Tahoma", 9, FontStyle.Bold), Brushes.Black, rectFA2);
            if (ToPrint[1] != null)
            {
                int B = (int)ToPrint[1];
                Bitmap bmB = Utilities.GetQR("<StorageBin>" + Items.Where(i => i.StorageBinId == B).FirstOrDefault().Token, 4);
                e.Graphics.DrawImage(bmB, 230, 10);
                RectangleF rectFB = new RectangleF(220, 130, 150, 50);//number
                RectangleF rectFB2 = new RectangleF(225, 170, 150, 50);//name
                e.Graphics.DrawString(Items.Where(i => i.StorageBinId == B).FirstOrDefault().Number, new Font("Tahoma", 8), Brushes.Black, rectFB);
                e.Graphics.DrawString(Items.Where(i => i.StorageBinId == B).FirstOrDefault().Name, new Font("Tahoma", 9, FontStyle.Bold), Brushes.Black, rectFB2);
                bmB.Dispose();
            }

            e.Graphics.Flush();
            bm.Dispose();
        }
    }
}

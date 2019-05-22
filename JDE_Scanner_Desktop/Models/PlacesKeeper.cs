using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class PlacesKeeper
    {
        public List<Place> Items { get; set; }

        public PlacesKeeper()
        {
            Items = new List<Place>();
        }

        public void Remove(List<int> ids)
        {
            DialogResult result = MessageBox.Show("Czy jesteś pewien, że chcesz usunąć " + ids.Count.ToString() + " zaznaczone wiersze?", "Potwierdź usunięcie", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                foreach(int id in ids)
                {
                    _Remomve(id);
                }
            }
        }

        private async void _Remomve(int id)
        {
            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "DeletePlace?token=" + Secrets.TenantToken + "&id={0}&UserId={1}";
                var result = await client.DeleteAsync(String.Format(url, id, RuntimeSettings.UserId));
                if (!result.IsSuccessStatusCode)
                {
                    MessageBox.Show(String.Format("Serwer zwrócił błąd przy próbie usunięcia użytkownika {0}. Wiadomość: " + result.ReasonPhrase,id));
                }
            }
        }

        public async Task Refresh(string query = null, char type='p')
        {
            if (Items.Any())
            {
                Items.Clear();
            }

            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "GetPlaces?token=" + Secrets.TenantToken;
                if (type=='p')
                {
                     url += "&page=1";
                }

                
                if(query != null)
                {
                    url += "&query=" + query;
                }
                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var userJsonString = await response.Content.ReadAsStringAsync();
                        Items = JsonConvert.DeserializeObject<Place[]>(userJsonString).ToList();
                    }
                }
            }
        }

        public async Task<bool> GetMore(int page)
        {

            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "GetPlaces?token=" + Secrets.TenantToken + "&page=" + page;
                using (var response = await client.GetAsync(new Uri(url)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var userJsonString = await response.Content.ReadAsStringAsync();
                        var vItems = JsonConvert.DeserializeObject<Place[]>(userJsonString).ToList();
                        Items.AddRange(vItems);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

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

            Bitmap bm = Utilities.GetQR(Items.Where(i => i.PlaceId == A).FirstOrDefault().PlaceToken, 3);
            e.Graphics.DrawImage(bm, 30, 10);
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            RectangleF rectFA = new RectangleF(20, 130, 150, 50);//place's name
            e.Graphics.DrawString(Items.Where(i => i.PlaceId == A).FirstOrDefault().Name, new Font("Tahoma", 8, FontStyle.Bold), Brushes.Black, rectFA);
            if (ToPrint[1] != null)
            {
                int B = (int)ToPrint[1];
                Bitmap bmB = Utilities.GetQR(Items.Where(i => i.PlaceId == B).FirstOrDefault().PlaceToken, 3);
                e.Graphics.DrawImage(bmB, 230, 10);
                RectangleF rectFB = new RectangleF(220, 130, 150, 50);//place's name
                e.Graphics.DrawString(Items.Where(i => i.PlaceId == B).FirstOrDefault().Name, new Font("Tahoma", 8, FontStyle.Bold), Brushes.Black, rectFB);
                bmB.Dispose();
            }

            e.Graphics.Flush();
            bm.Dispose();
        }
    }
}

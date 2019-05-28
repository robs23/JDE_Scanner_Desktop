using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class ProcessesKeeper : Keeper<Process>
    {

        protected override string ObjectName => "Process";

        protected override string PluralizedObjectName => "Processes";


        public void Finish(List<int> ids)
        {
            DialogResult result = MessageBox.Show("Czy jesteś pewien, że chcesz zamknąć " + ids.Count.ToString() + " zaznaczone zgłoszenia?", "Potwierdź zamknięcie zgłoszeń", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                foreach (int id in ids)
                {
                    _Finish(id);
                }
            }
        }

        private async void _Finish(int id)
        {
            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + "CompleteProcess?token=" + Secrets.TenantToken + "&id={0}&UserId={1}";
                var result = await client.PutAsync(String.Format(url, id, RuntimeSettings.UserId),null);
                if (!result.IsSuccessStatusCode)
                {
                    MessageBox.Show(String.Format("Serwer zwrócił błąd przy próbie usunięcia zgłoszenia {0}. Wiadomość: " + result.ReasonPhrase, id));
                }
            }
        }
    }
}
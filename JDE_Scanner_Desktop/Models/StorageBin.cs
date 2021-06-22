using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class StorageBin : Entity<StorageBin>
    {
        public override int Id
        {
            set => value = StorageBinId;
            get => StorageBinId;
        }
        [DisplayName("ID")]
        public int StorageBinId { get; set; }
        [DisplayName("Numer")]
        public string Number { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Token")]
        public string Token { get; set; }

        public async override Task<bool> Add()
        {
            bool x = await base.Add();

            if (x)
            {
                try
                {
                    StorageBin _this = JsonConvert.DeserializeObject<StorageBin>(AddedItem);
                    this.StorageBinId = _this.StorageBinId;
                    this.Token = _this.Token;
                    this.TenantId = _this.TenantId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Tworzenie nowego rekordu zakończone powodzeniem!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

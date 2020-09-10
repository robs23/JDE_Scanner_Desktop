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
    public class Component : Entity<Component>
    {
        [DisplayName("ID")]
        public int ComponentId { get; set; }
        public override int Id
        {
            set => value = ComponentId;
            get => ComponentId;
        }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [Browsable(false)]
        public int? PlaceId { get; set; }
        [DisplayName("Zasób")]
        public string PlaceName { get; set; }

        public async override Task<bool> Add(string attachmentPath = null)
        {
            bool x;
            if (attachmentPath == null)
            {
                x = await base.Add();
            }
            else
            {
                x = await base.Add(attachmentPath);
            }

            if (x)
            {
                try
                {
                    Component _this = JsonConvert.DeserializeObject<Component>(AddedItem);
                    this.ComponentId = _this.ComponentId;
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

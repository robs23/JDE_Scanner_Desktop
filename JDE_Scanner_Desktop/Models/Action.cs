using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class Action : Entity<Action>
    {
        [Browsable(false)]
        public override int Id
        {
            set => value = ActionId;
            get => ActionId;
        }
        [DisplayName("ID")]
        public int ActionId { get; set; }
        [DisplayName("Nazwa")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nazwa nie może być puste!")]
        public string Name { get; set; }
        [DisplayName("Założony czas")]
        public Nullable<int> GivenTime { get; set; }
        [DisplayName("Typ")]
        public string Type { get; set; }

        public async override Task<bool> Add()
        {
            bool x = await base.Add();
            if (x)
            {
                try
                {
                    Action _this = JsonConvert.DeserializeObject<Action>(AddedItem);
                    this.ActionId = _this.ActionId;
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

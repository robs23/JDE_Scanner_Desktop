using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    class UnitKeeper
    {
        public List<Unit> Items { get; set; }

        public UnitKeeper()
        {
            Items = new List<Unit>();
            Items.Add(new Unit { ShortName="pc", LongName="Sztuka" });
            Items.Add(new Unit { ShortName = "kg", LongName = "Kilogram" });
            Items.Add(new Unit { ShortName = "box", LongName = "Karton" });
            Items.Add(new Unit { ShortName = "pal", LongName = "Paleta" });
            Items.Add(new Unit { ShortName = "m", LongName = "Metr" });
            Items.Add(new Unit { ShortName = "m2", LongName = "Metr kwadrat" });
            Items.Add(new Unit { ShortName = "m3", LongName = "Metr sześcienny" });
        }
    }
}

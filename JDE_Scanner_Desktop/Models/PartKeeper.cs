using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    class PartKeeper : Keeper<Part>
    {
        protected override string ObjectName => "Part";

        protected override string PluralizedObjectName => "Parts";

        public void PrintQR(List<int> ids)
        {
            int[] aId = ids.ToArray();
            int i = 1;
            do
            {
                if (i % 2 == 0)
                {
                    //we're on the LEFT side of the label
                }
                else
                {
                    //we're on teh RIGHT side of the label
                }
                i += 1;
            } while (i <= int.MaxValue);
        }
    }
}

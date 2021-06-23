using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Static
{
    public static class Enums
    {
        public enum ProcessActionStatsDivisionType
        {
            Daily,
            Weekly,
            Monthly
        }

        public enum Currency
        {
            PLN,
            EUR
        }

        public enum PartUnit
        {
            sztuki
        }

        public enum PartDataFormType
        {
            Price,
            Stock
        }

        public enum StockTakingType
        {
            ByPart,
            ByStorageBin
        }
    }
}

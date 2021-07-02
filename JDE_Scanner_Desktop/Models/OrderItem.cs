using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JDE_Scanner_Desktop.Static;
using static JDE_Scanner_Desktop.Static.Enums;

namespace JDE_Scanner_Desktop.Models
{
    public class OrderItem : Entity<OrderItem>
    {
        [DisplayName("ID")]
        public int OrderItemId { get; set; }
        public override int Id
        {
            set => value = OrderItemId;
            get => OrderItemId;
        }
        [DisplayName("ID zamówienia")]
        public int? OrderId { get; set; }
        [DisplayName("Numer zamówienia")]
        public string OrderNo { get; set; }
        [DisplayName("ID części")]
        public int? PartId { get; set; }
        [DisplayName("Nazwa części")]
        public string PartName { get; set; }
        [DisplayName("Symbol")]
        public string PartSymbol { get; set; }
        [Browsable(false)]
        public string EAN { get; set; }
        [DisplayName("Ilość")]
        public double? Amount { get; set; }
        [DisplayName("Jednostka")]
        public string Unit { get; set; }
        //public PartUnit? PartUnit
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Unit))
        //        {
        //            if(Enum.IsDefined(typeof(PartUnit), Unit))
        //            {
        //                return (PartUnit)Enum.Parse(typeof(PartUnit), Unit);
        //            }
        //            else
        //            {
        //                return (PartUnit)1;
        //            }
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    set
        //    {
        //        Unit = value.ToString();
        //    }
        //}
        [DisplayName("Koszt")]
        public double? Price { get; set; }
        [DisplayName("Waluta")]
        public string Currency { get; set; }

    }
}

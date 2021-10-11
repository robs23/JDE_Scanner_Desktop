using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
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
        [DisplayName("Dostarczono")]
        public double? Delivered { get; set; }

        [DisplayName("Koszt jednostkowy")]
        public decimal? Price { get; set; }
        [DisplayName("Waluta")]
        public string Currency { get; set; }

        public async override Task<bool> Add(string args = null)
        {
            bool x = await base.Add(args);
            if (x)
            {
                try
                {
                    OrderItem _this = JsonConvert.DeserializeObject<OrderItem>(AddedItem);
                    this.OrderItemId = _this.OrderItemId;
                    this.CreatedOn = _this.CreatedOn;
                    this.CreatedBy = _this.CreatedBy;
                    this.TenantId = _this.TenantId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

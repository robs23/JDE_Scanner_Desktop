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
    public class Order : Entity<Order>
    {
        [DisplayName("ID")]
        public int OrderId { get; set; }
        public override int Id
        {
            set => value = OrderId;
            get => OrderId;
        }
        [DisplayName("Numer")]
        public string OrderNo { get; set; }
        [DisplayName("Numer u dostawcy")]
        public string SuppliersOrderNo { get; set; }
        [DisplayName("Planowana dostawa")]
        public DateTime? DeliveryOn { get; set; }
        [Browsable(false)]
        public int? SupplierId { get; set; }
        [DisplayName("Dostawca")]
        public string SupplierName { get; set; }
        [Browsable(false)]
        public OrderItemKeeper ItemKeeper { get; set; }

        public Order()
        {
            ItemKeeper = new OrderItemKeeper();
        }

        public async override Task<bool> Add()
        {
            bool x = await base.Add();
            if (x)
            {
                try
                {
                    Order _this = JsonConvert.DeserializeObject<Order>(AddedItem);
                    this.OrderId = _this.OrderId;
                    this.TenantId = _this.TenantId;
                    AddMissingOrderIds();
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

        public void AddMissingOrderIds()
        {
            //pass OrderId from parent Order to child OrderItems before saving
            if(this.OrderId != 0)
            {
                foreach (var i in ItemKeeper.Items.Where(n => n.OrderId == 0 || n.OrderId == null))
                {
                    i.OrderId = this.OrderId;
                }
            }
        }

        public void SetArchived(List<int> ids)
        {
            foreach(var id in ids)
            {
                var orderItem = ItemKeeper.Items.Where(i => i.OrderItemId == id).FirstOrDefault();
                if(orderItem != null)
                {
                    orderItem.IsArchived = true;
                }
            }
        }
    }
}

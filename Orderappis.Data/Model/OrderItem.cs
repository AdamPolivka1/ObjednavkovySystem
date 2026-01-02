using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderis.Data.Model
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public string Note { get; set; }

        public OrderItem() { }

        public OrderItem(int orderItemId, int orderId, int productId, int qty, string note)
        {
            OrderItemId = orderItemId;
            OrderId = orderId;
            ProductId = productId;
            Qty = qty;
            Note = note;
        }
    }
}
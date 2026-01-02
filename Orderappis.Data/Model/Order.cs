using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderis.Data.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int? PaymentId { get; set; }
        public int CustomerAccountId { get; set; }
        public int? DeliveryId { get; set; }
        public decimal TotalPriceCZK { get; set; }
        public int Status { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Order() { }
        
        public Order(int orderId,
            int paymentId,
            int customerAccountId,
            int deliveryId,
            decimal totalPriceCZK,
            int status,
            DateTime orderedAt,
            DateTime updatedAt)
        {
            OrderId = orderId;
            PaymentId = paymentId;
            CustomerAccountId = customerAccountId;
            DeliveryId = deliveryId;
            TotalPriceCZK = totalPriceCZK;
            Status = status;
            OrderedAt = orderedAt;
            UpdatedAt = updatedAt;
        }

        public Order(int orderId,
            int customerAccountId,
            decimal totalPriceCZK,
            int status,
            DateTime orderedAt,
            DateTime updatedAt)
        {
            OrderId = orderId;
            CustomerAccountId = customerAccountId;
            TotalPriceCZK = totalPriceCZK;
            Status = status;
            OrderedAt = orderedAt;
            UpdatedAt = updatedAt;
        }

    }
}

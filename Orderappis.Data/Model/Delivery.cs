using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderis.Data.Model
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int DeliveryType { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public int Status { get; set; }
        public decimal PriceCZK { get; set; }
        public string Note { get; set; }

        public Delivery() {}

        public Delivery(int aDeliveryId,
            int aDeliveryType,
            DateTime aDeliveryDate,
            string aDeliveryAddress,
            int aStatus,
            decimal aPriceCZK,
            string aNote) {
            DeliveryId = aDeliveryId;
            DeliveryType = aDeliveryType;
            DeliveryDate = aDeliveryDate;
            DeliveryAddress = aDeliveryAddress;
            Status = aStatus;
            PriceCZK = aPriceCZK;
            Note = aNote;
        }
    }
}

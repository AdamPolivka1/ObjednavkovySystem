using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderappis.Data.Model
{
    public class DeliveryTypes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DeliveryTypes(int aDeliveryTypeId, string aDeliveryTypeName)
        {
            Id = aDeliveryTypeId;
            Name = aDeliveryTypeName;
        }
    }
}
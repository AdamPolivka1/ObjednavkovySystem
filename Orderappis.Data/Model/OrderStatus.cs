using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderappis.Data.Model
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public OrderStatus(int aId, string aName)
        {
            Id = aId;
            Name = aName;
        }
    }
}

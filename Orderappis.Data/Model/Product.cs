using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderis.Data.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public int AvailableQty { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceCzk { get; set; }

        public Product() { }

        public Product(int productId,
            int productCategoryId,
            int availableQty,
            string code,
            string name,
            string description,
            decimal price)
        {
            ProductId = productId;
            ProductCategoryId = productCategoryId;
            AvailableQty = availableQty;
            Code = code;
            Name = name;
            Description = description;
            PriceCzk = price;
        }


    }
}

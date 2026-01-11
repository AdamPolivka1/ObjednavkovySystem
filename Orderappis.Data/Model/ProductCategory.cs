using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderis.Data.Model
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Descr { get; set; }

        //public ProductCategory() { }

        public ProductCategory(int productCategoryId,
            string categoryName,
            string descr)
        {
            ProductCategoryId = productCategoryId;
            CategoryName = categoryName;
            Descr = descr;
        }
    }
}

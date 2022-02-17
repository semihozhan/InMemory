using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Add.Models
{
    public class ProductDetailList
    {
        public List<ProductDetail> productDetails { get; set; }

        public ProductDetailList()
        {
                productDetails = new List<ProductDetail>();
        
        }
        
    }
}

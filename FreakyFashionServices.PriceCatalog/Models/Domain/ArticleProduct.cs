using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.PriceCatalog.Models.Domain
{
    public class ArticleProduct
    {
        public string ArticleNumber { get; set; }
        public int Price { get; set; }

        public ArticleProduct()
        {

        }
        public ArticleProduct(string articleNumber, int price)
        {
            ArticleNumber = articleNumber;
            Price = price;
        }
    }
}

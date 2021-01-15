using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Models.Domain
{
    class Cart
    {
        public string CartId { get; set; }
        public IList<CartContent> CartContents { get; set; }
    }
}

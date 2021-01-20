using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Models.Domain
{
    public class CartContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}

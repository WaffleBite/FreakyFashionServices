using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Models.DTO
{
    public class CartDto
    {
        public string CartId { get; set; }
        public IEnumerable<CartContentDto> CartContents { get; set; }
    }
}

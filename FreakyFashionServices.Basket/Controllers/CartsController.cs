using FreakyFashionServices.Basket.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartsController : ControllerBase
    {
        //private static readonly List<Cart> Carts = new List<Cart>
        //{
        //    new Cart
        //    {
        //        CartId = "555",
        //        CartContents = new List<CartContent>
        //        {
        //            new CartContent
        //            {
        //                Id = 1,
        //                Name = "Basic White T-shirt",
        //                Description = "A basic white t-shirt",
        //                UnitPrice = 300,
        //                Quantity = 23
        //            },
        //            new CartContent
        //            {
        //                Id = 2,
        //                Name = "Basic Black T-shirt",
        //                Description = "A basic black t-shirt",
        //                UnitPrice = 300,
        //                Quantity = 17
        //            },
        //        }
        //    }
        //};

        private readonly IDistributedCache cache;
        public CartsController(IDistributedCache cache)
        {
            this.cache = cache;
        }

        [HttpGet("{cartId}")]
        public async Task<string> Get(string cartId)
        {
            var cacheKey = cartId;
            var existingCart = cache.GetString(cacheKey);
            if (!string.IsNullOrEmpty(existingCart))
            {
                return existingCart;
            }
            else
            {
                return "Nothing in cart.";
            }
        }

        // PUT /carts/{id}
        [HttpPut("{cartId}")]
        public async Task<IActionResult> AddCartContents(string cartId, CartDto cartDto)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
            options.SlidingExpiration = TimeSpan.FromSeconds(60);

            var serializedData = JsonSerializer.Serialize(cartDto);

            await cache.SetStringAsync(
                cartDto.CartId,
                serializedData,
                options);

            return Ok();
        }
    }
}
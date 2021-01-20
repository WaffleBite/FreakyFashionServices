using FreakyFashionServices.Catalog.Models;
using FreakyFashionServices.Catalog.Models.Domain;
using FreakyFashionServices.Catalog.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FreakyFashionServices.Catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET api/products
        [HttpGet]
        public ActionResult<List<Product>> GetProductItems()
        {

            return _context.Products.ToList();
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductItems()
        //{
        //    var products = from x in _context.Products
        //                   select new ProductDto()
        //                   {
        //                       Id = x.Id,
        //                       ArticleNumber = x.ArticleNumber,
        //                       Name = x.Name,
        //                       Description = x.Description,
        //                       AvailableStock = x.AvailableStock
        //                   };
        //    return await products.ToListAsync();
        //}

        // GET api/products/1
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(int id)
        {
            var foundProduct = _context.Products.FirstOrDefault(x => x.Id == id);

            if (foundProduct is null)
            {
                return NotFound();
            }

            var dto = new ProductDto
            {
                Id = foundProduct.Id,
                Name = foundProduct.Name,
                Description = foundProduct.Description,
                Price = foundProduct.Price,
                AvailableStock = foundProduct.AvailableStock
            };

            return dto;
        }
    }
}

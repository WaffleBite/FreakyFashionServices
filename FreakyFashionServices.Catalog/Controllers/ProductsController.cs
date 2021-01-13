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
        public ApplicationDbContext _context { get; }

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProductItems()
        {
            return _context.Products;
        }

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

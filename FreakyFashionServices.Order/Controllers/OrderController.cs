using FreakyFashionServices.Order.Models;
using FreakyFashionServices.Order.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// Order/{customerId}
        [HttpPost("{customerId}")]
        public async Task<ActionResult> AddCartContents(int customerId, Customer customer)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("http://localhost:56233/carts/" + customerId).Result;
            var cartDto = response.Content.ReadAsStringAsync().Result;

            var dto = new Customer
            (
                customerId: customer.CustomerId,
                firstName: customer.FirstName,
                lastName: customer.LastName
            );

            _context.Orders.Add(dto);
            await _context.SaveChangesAsync();

            return Ok(dto.Id);
        }
    }
}

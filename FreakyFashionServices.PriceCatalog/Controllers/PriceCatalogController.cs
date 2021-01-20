using FreakyFashionServices.PriceCatalog.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreakyFashionServices.PriceCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceCatalogController : ControllerBase
    {
        // GET /ProductPriceCatalog?products=ABC123,BCA321,AAA123
        [HttpGet]
        public IEnumerable<ArticleProduct> Get(string articleNumbers)
        {

            var products = articleNumbers.Split(',').ToList();

            List<ArticleProduct> articles = new List<ArticleProduct>();
            Random rnd = new Random();

            foreach(var item in products)
            {
                articles.Add(new ArticleProduct()
                {
                    ArticleNumber = item,
                    Price = rnd.Next(29, 999)
                });
            }

            //foreach (var item in Products)
            //{
            //    var rng = new Random();
            //    item.Price = rng.Next();
            //}

            return articles;
        }
    }
}

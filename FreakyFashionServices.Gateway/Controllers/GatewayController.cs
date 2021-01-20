﻿using FreakyFashionServices.Basket.Models.DTO;
using FreakyFashionServices.Gateway.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;

        public GatewayController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            // get products

            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44361/api/Products");

            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            var serializedProduct = await response.Content.ReadAsStringAsync();

            var productDto = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ProductDto>>(serializedProduct, serializeOptions);

            var articleNumbers = "";

            foreach (var product in productDto)
            {
                if (String.IsNullOrEmpty(articleNumbers))
                    articleNumbers += product.ArticleNumber;
                else
                    articleNumbers += "," + product.ArticleNumber;
            }

            // get price

            request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:51325/PriceCatalog" + "?articleNumbers=" + articleNumbers);

            request.Headers.Add("Accept", "application/json");

            response = await client.SendAsync(request);

            var serializedPrice = await response.Content.ReadAsStringAsync();

            var priceDto = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<PriceDto>>(serializedPrice, serializeOptions);

            foreach (var item in priceDto)
            {
                var product = productDto.FirstOrDefault(x => x.ArticleNumber == item.ArticleNumber);
                product.Price = item.Price;
            }

            return productDto;
        }

        // PUT /carts/{cartId}
        [HttpPut("{cartId}")]
        public async Task<IActionResult> AddToCart(string cartId, CartDto cartDto)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "http://localhost:56233/carts/" + cartId);

            request.Headers.Add("Accept", "application/json");

            var json = JsonConvert.SerializeObject(cartDto);

            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var client = clientFactory.CreateClient();
            await client.SendAsync(request);

            return NoContent();  // 204 No Content
        }

        // POST /order
        [HttpPost]
        public async Task<IActionResult> AddOrder(int customerId, OrderDto order)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:52489/order/" + customerId);

            request.Headers.Add("Accept", "application/json");

            var serialisedOrder = System.Text.Json.JsonSerializer.Serialize(order);

            request.Content = new StringContent(serialisedOrder, Encoding.UTF8, "application/json");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            var orderId = await response.Content.ReadAsStringAsync();

            return Ok(orderId);
        }
    }
}

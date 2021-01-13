﻿namespace FreakyFashionServices.Catalog.Models.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableStock { get; set; }

        public Product()
        {

        }

        public Product(int id, string name, string description, decimal price, int availableStock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            AvailableStock = availableStock;
        }
    }
}

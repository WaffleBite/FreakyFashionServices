namespace FreakyFashionServices.Catalog.Models.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int AvailableStock { get; set; }

        public Product()
        {

        }

        public Product(int id, string articleNumber, string name, string description, int price, int availableStock)
        {
            Id = id;
            ArticleNumber = articleNumber;
            Name = name;
            Description = description;
            Price = price;
            AvailableStock = availableStock;
        }
    }
}

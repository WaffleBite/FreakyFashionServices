namespace FreakyFashionServices.Gateway.Models.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArticleNumber { get; set; }
        public string Description { get; set; }
        public int AvailableStock { get; set; }
        public int Price { get; set; }
    }
}

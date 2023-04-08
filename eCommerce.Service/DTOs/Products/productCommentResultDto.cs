namespace eCommerce.Service.DTOs.Products
{
    public class productCommentResultDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Description { get; set; } = string.Empty;
        public string SearchByTag { get; set; } = string.Empty;

    }
}

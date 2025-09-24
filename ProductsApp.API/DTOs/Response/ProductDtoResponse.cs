namespace ProductsApp.API.DTOs.Response
{
    public class ProductDtoResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int? StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<CategoryDtoResponse> Categories { get; set; } = new();
    }
}

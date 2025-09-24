using System.ComponentModel.DataAnnotations;

namespace ProductsApp.API.DTOs.Request
{
    public class ProductDtoRequest
    {
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } = null!;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be non-negative")]
        public int StockQuantity { get; set; } = 0;

        public List<int>? CategoryIds { get; set; } = new();
    }
}

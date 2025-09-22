
namespace ProductsApp.Data.Models;

public partial class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int? StockQuantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}

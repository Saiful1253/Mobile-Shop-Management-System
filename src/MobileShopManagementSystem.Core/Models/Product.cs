namespace MobileShopManagementSystem.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public List<PurchaseItem> PurchaseItems { get; set; } = new();
        public List<SaleItem> SaleItems { get; set; } = new();
    }
}

namespace MobileShopManagementSystem.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}

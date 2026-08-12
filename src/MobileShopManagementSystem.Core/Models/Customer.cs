namespace MobileShopManagementSystem.Core.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public List<Sale> Sales { get; set; } = new();
    }
}

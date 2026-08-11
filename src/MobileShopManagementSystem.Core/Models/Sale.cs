namespace MobileShopManagementSystem.Core.Models
{
    public class Sale : BaseEntity
    {
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public List<SaleItem> Items { get; set; } = new();
    }
}

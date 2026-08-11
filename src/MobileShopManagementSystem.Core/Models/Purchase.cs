namespace MobileShopManagementSystem.Core.Models
{
    public class Purchase : BaseEntity
    {
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public List<PurchaseItem> Items { get; set; } = new();
    }
}

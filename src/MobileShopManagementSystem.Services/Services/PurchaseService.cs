using Microsoft.EntityFrameworkCore;
using MobileShopManagementSystem.Core.Interfaces;
using MobileShopManagementSystem.Core.Models;
using MobileShopManagementSystem.Data;
using MobileShopManagementSystem.Services.Interfaces;

namespace MobileShopManagementSystem.Services.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _repository;
        private readonly ApplicationDbContext _context;

        public PurchaseService(IPurchaseRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public Task<IEnumerable<Purchase>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Purchase?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public async Task AddAsync(Purchase purchase)
        {
            foreach (var item in purchase.Items)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product != null)
                {
                    product.StockQuantity += item.Quantity;
                    _context.Products.Update(product);
                }
            }
            await _repository.AddAsync(purchase);
        }

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
        public Task<IEnumerable<Purchase>> GetBySupplierAsync(int supplierId) => _repository.GetBySupplierAsync(supplierId);
    }
}

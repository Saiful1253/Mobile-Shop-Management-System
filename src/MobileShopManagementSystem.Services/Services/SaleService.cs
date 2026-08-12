using Microsoft.EntityFrameworkCore;
using MobileShopManagementSystem.Core.Interfaces;
using MobileShopManagementSystem.Core.Models;
using MobileShopManagementSystem.Data;
using MobileShopManagementSystem.Services.Interfaces;

namespace MobileShopManagementSystem.Services.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;
        private readonly ApplicationDbContext _context;

        public SaleService(ISaleRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public Task<IEnumerable<Sale>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Sale?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public async Task AddAsync(Sale sale)
        {
            foreach (var item in sale.Items)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product != null)
                {
                    product.StockQuantity -= item.Quantity;
                    _context.Products.Update(product);
                }
            }
            await _repository.AddAsync(sale);
        }

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
        public Task<IEnumerable<Sale>> GetByCustomerAsync(int customerId) => _repository.GetByCustomerAsync(customerId);
    }
}

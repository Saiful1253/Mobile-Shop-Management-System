using Microsoft.EntityFrameworkCore;
using MobileShopManagementSystem.Core.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context) => _context = context;

        public async Task<IEnumerable<Product>> GetByBrandAsync(int brandId)
        {
            return await _dbSet.Where(p => p.BrandId == brandId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _dbSet.Where(p => p.CategoryId == categoryId).ToListAsync();
        }
    }
}

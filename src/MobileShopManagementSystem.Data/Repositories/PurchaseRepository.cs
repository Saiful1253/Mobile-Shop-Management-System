using Microsoft.EntityFrameworkCore;
using MobileShopManagementSystem.Core.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Data.Repositories
{
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;
        public PurchaseRepository(ApplicationDbContext context) : base(context) => _context = context;

        public async Task<IEnumerable<Purchase>> GetBySupplierAsync(int supplierId)
        {
            return await _dbSet.Where(p => p.SupplierId == supplierId).ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MobileShopManagementSystem.Core.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Data.Repositories
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleRepository(ApplicationDbContext context) : base(context) => _context = context;

        public async Task<IEnumerable<Sale>> GetByCustomerAsync(int customerId)
        {
            return await _dbSet.Where(s => s.CustomerId == customerId).ToListAsync();
        }
    }
}

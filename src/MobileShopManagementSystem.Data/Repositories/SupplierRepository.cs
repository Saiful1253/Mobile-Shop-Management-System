using Microsoft.EntityFrameworkCore;
using MobileShopManagementSystem.Core.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Data.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context) : base(context) { }
    }
}

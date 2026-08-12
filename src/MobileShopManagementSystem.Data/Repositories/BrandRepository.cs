using Microsoft.EntityFrameworkCore;
using MobileShopManagementSystem.Core.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Data.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context) { }
    }
}

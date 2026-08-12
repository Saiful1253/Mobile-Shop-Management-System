using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetByBrandAsync(int brandId);
        Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
    }
}

using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Core.Interfaces
{
    public interface IPurchaseRepository : IGenericRepository<Purchase>
    {
        Task<IEnumerable<Purchase>> GetBySupplierAsync(int supplierId);
    }
}

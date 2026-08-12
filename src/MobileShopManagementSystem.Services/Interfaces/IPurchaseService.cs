using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<IEnumerable<Purchase>> GetAllAsync();
        Task<Purchase?> GetByIdAsync(int id);
        Task AddAsync(Purchase purchase);
        Task DeleteAsync(int id);
        Task<IEnumerable<Purchase>> GetBySupplierAsync(int supplierId);
    }
}

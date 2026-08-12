using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Services.Interfaces
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetAllAsync();
        Task<Sale?> GetByIdAsync(int id);
        Task AddAsync(Sale sale);
        Task DeleteAsync(int id);
        Task<IEnumerable<Sale>> GetByCustomerAsync(int customerId);
    }
}

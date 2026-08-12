using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Core.Interfaces
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Task<IEnumerable<Sale>> GetByCustomerAsync(int customerId);
    }
}

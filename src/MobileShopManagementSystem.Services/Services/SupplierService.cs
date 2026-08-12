using MobileShopManagementSystem.Core.Interfaces;
using MobileShopManagementSystem.Core.Models;
using MobileShopManagementSystem.Services.Interfaces;

namespace MobileShopManagementSystem.Services.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;
        public SupplierService(ISupplierRepository repository) => _repository = repository;

        public Task<IEnumerable<Supplier>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Supplier?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Supplier supplier) => _repository.AddAsync(supplier);
        public Task UpdateAsync(Supplier supplier) => _repository.UpdateAsync(supplier);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}

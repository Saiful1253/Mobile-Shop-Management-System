using MobileShopManagementSystem.Core.Interfaces;
using MobileShopManagementSystem.Core.Models;
using MobileShopManagementSystem.Services.Interfaces;

namespace MobileShopManagementSystem.Services.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;
        public BrandService(IBrandRepository repository) => _repository = repository;

        public Task<IEnumerable<Brand>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Brand?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Brand brand) => _repository.AddAsync(brand);
        public Task UpdateAsync(Brand brand) => _repository.UpdateAsync(brand);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}

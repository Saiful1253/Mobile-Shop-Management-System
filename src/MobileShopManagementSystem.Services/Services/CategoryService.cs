using MobileShopManagementSystem.Core.Interfaces;
using MobileShopManagementSystem.Core.Models;
using MobileShopManagementSystem.Services.Interfaces;

namespace MobileShopManagementSystem.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository) => _repository = repository;

        public Task<IEnumerable<Category>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Category?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Category category) => _repository.AddAsync(category);
        public Task UpdateAsync(Category category) => _repository.UpdateAsync(category);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}

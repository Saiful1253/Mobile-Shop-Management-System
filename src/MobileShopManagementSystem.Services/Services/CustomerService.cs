using MobileShopManagementSystem.Core.Interfaces;
using MobileShopManagementSystem.Core.Models;
using MobileShopManagementSystem.Services.Interfaces;

namespace MobileShopManagementSystem.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository) => _repository = repository;

        public Task<IEnumerable<Customer>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Customer?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Customer customer) => _repository.AddAsync(customer);
        public Task UpdateAsync(Customer customer) => _repository.UpdateAsync(customer);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}

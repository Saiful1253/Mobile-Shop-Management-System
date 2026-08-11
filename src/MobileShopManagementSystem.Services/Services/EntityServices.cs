using MobileShopManagementSystem.Core.Interfaces;
using MobileShopManagementSystem.Core.Models;
using MobileShopManagementSystem.Services.Interfaces;

namespace MobileShopManagementSystem.Services.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;
        public BrandService(IBrandRepository repository) => _repository = repository;

        public async Task AddAsync(Brand brand) => await _repository.AddAsync(brand);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        public async Task<IEnumerable<Brand>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Brand?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task UpdateAsync(Brand brand) => await _repository.UpdateAsync(brand);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository) => _repository = repository;

        public async Task AddAsync(Category category) => await _repository.AddAsync(category);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        public async Task<IEnumerable<Category>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Category?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task UpdateAsync(Category category) => await _repository.UpdateAsync(category);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository) => _repository = repository;

        public async Task AddAsync(Product product) => await _repository.AddAsync(product);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        public async Task<IEnumerable<Product>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Product?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task UpdateAsync(Product product) => await _repository.UpdateAsync(product);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository) => _repository = repository;

        public async Task AddAsync(Customer customer) => await _repository.AddAsync(customer);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        public async Task<IEnumerable<Customer>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Customer?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task UpdateAsync(Customer customer) => await _repository.UpdateAsync(customer);
    }

    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;
        public SupplierService(ISupplierRepository repository) => _repository = repository;

        public async Task AddAsync(Supplier supplier) => await _repository.AddAsync(supplier);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
        public async Task<IEnumerable<Supplier>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Supplier?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task UpdateAsync(Supplier supplier) => await _repository.UpdateAsync(supplier);
    }

    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _repository;
        public PurchaseService(IPurchaseRepository repository) => _repository = repository;

        public async Task AddAsync(Purchase purchase) => await _repository.AddAsync(purchase);
        public async Task<IEnumerable<Purchase>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Purchase?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return Task.FromResult<IEnumerable<Supplier>>(new List<Supplier>());
        }
    }

    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;
        public SaleService(ISaleRepository repository) => _repository = repository;

        public async Task AddAsync(Sale sale) => await _repository.AddAsync(sale);
        public async Task<IEnumerable<Sale>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Sale?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return Task.FromResult<IEnumerable<Customer>>(new List<Customer>());
        }
    }
}

using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Core.Interfaces
{
    public interface IBrandRepository : IGenericRepository<Brand> { }
    public interface ICategoryRepository : IGenericRepository<Category> { }
    public interface IProductRepository : IGenericRepository<Product> { }
    public interface ICustomerRepository : IGenericRepository<Customer> { }
    public interface ISupplierRepository : IGenericRepository<Supplier> { }
    public interface IPurchaseRepository : IGenericRepository<Purchase> { }
    public interface ISaleRepository : IGenericRepository<Sale> { }
}

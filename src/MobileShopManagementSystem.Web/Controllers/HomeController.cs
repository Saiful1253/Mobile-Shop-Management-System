using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MobileShopManagementSystem.Services.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;
        private readonly ICustomerService _customerService;
        private readonly ISupplierService _supplierService;

        public HomeController(IProductService productService, ISaleService saleService, ICustomerService customerService, ISupplierService supplierService)
        {
            _productService = productService;
            _saleService = saleService;
            _customerService = customerService;
            _supplierService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalProducts = (await _productService.GetAllAsync()).Count();
            ViewBag.TotalSales = (await _saleService.GetAllAsync()).Count();
            ViewBag.TotalCustomers = (await _customerService.GetAllAsync()).Count();
            ViewBag.TotalSuppliers = (await _supplierService.GetAllAsync()).Count();
            return View();
        }
        public IActionResult About() => View();
        public IActionResult Contact() => View();
    }
}

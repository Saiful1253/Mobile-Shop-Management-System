using Microsoft.AspNetCore.Mvc;
using MobileShopManagementSystem.Services.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;

        public HomeController(IProductService productService, ISaleService saleService)
        {
            _productService = productService;
            _saleService = saleService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products.Take(8));
        }

        public IActionResult Privacy() => View();
    }
}

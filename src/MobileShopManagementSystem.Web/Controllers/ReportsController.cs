using Microsoft.AspNetCore.Mvc;
using MobileShopManagementSystem.Services.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Web.Controllers
{
    public class ReportsController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IPurchaseService _purchaseService;
        private readonly ISaleService _saleService;

        public ReportsController(IProductService productService, IPurchaseService purchaseService, ISaleService saleService)
        {
            _productService = productService;
            _purchaseService = purchaseService;
            _saleService = saleService;
        }

        public async Task<IActionResult> InventoryReport()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

        public async Task<IActionResult> PurchaseReport()
        {
            var purchases = await _purchaseService.GetAllAsync();
            return View(purchases);
        }

        public async Task<IActionResult> SalesReport()
        {
            var sales = await _saleService.GetAllAsync();
            return View(sales);
        }
    }
}

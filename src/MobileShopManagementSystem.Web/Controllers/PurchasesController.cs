using Microsoft.AspNetCore.Mvc;
using MobileShopManagementSystem.Services.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Web.Controllers
{
    public class PurchasesController : BaseController
    {
        private readonly IPurchaseService _service;
        private readonly ISupplierService _supplierService;
        private readonly IProductService _productService;

        public PurchasesController(IPurchaseService service, ISupplierService supplierService, IProductService productService)
        {
            _service = service;
            _supplierService = supplierService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var purchases = await _service.GetAllAsync();
            return View(purchases);
        }

        public async Task<IActionResult> Details(int id)
        {
            var purchase = await _service.GetByIdAsync(id);
            if (purchase == null) return NotFound();
            return View(purchase);
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(purchase);
            }
            await _service.AddAsync(purchase);
            SetSuccessMessage("Purchase recorded successfully.");
            return RedirectToAction(nameof(Index));
        }
        private async Task PopulateDropdowns()
        {
            var suppliers = await _supplierService.GetAllAsync();
            ViewBag.Suppliers = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(suppliers, "Id", "Name");
            var products = await _productService.GetAllAsync();
            ViewBag.Products = products.ToList();
        }
    }
}

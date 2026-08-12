using Microsoft.AspNetCore.Mvc;
using MobileShopManagementSystem.Services.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Web.Controllers
{
    public class SalesController : BaseController
    {
        private readonly ISaleService _service;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public SalesController(ISaleService service, ICustomerService customerService, IProductService productService)
        {
            _service = service;
            _customerService = customerService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var sales = await _service.GetAllAsync();
            return View(sales);
        }

        public async Task<IActionResult> Details(int id)
        {
            var sale = await _service.GetByIdAsync(id);
            if (sale == null) return NotFound();
            return View(sale);
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sale sale)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(sale);
            }
            await _service.AddAsync(sale);
            SetSuccessMessage("Sale recorded successfully.");
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdowns()
        {
            var customers = await _customerService.GetAllAsync();
            ViewBag.Customers = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(customers, "Id", "Name");
            var products = await _productService.GetAllAsync();
            ViewBag.Products = products.ToList();
        }
    }
}

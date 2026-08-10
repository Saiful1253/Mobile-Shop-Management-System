using Microsoft.AspNetCore.Mvc;
using MobileShopManagementSystem.Services.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Web.Controllers
{
    public class SalesController : BaseController
    {
        private readonly ISaleService _service;
        public SalesController(ISaleService service) => _service = service;

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

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sale sale)
        {
            if (!ModelState.IsValid) return View(sale);
            await _service.AddAsync(sale);
            SetSuccessMessage("Sale recorded successfully.");
            return RedirectToAction(nameof(Index));
        }
    }
}

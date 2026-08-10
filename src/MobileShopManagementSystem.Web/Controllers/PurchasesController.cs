using Microsoft.AspNetCore.Mvc;
using MobileShopManagementSystem.Services.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Web.Controllers
{
    public class PurchasesController : BaseController
    {
        private readonly IPurchaseService _service;
        public PurchasesController(IPurchaseService service) => _service = service;

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

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Purchase purchase)
        {
            if (!ModelState.IsValid) return View(purchase);
            await _service.AddAsync(purchase);
            SetSuccessMessage("Purchase recorded successfully.");
            return RedirectToAction(nameof(Index));
        }
    }
}

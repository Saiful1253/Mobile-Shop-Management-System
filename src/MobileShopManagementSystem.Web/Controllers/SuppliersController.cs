using Microsoft.AspNetCore.Mvc;
using MobileShopManagementSystem.Services.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Web.Controllers
{
    public class SuppliersController : BaseController
    {
        private readonly ISupplierService _service;
        public SuppliersController(ISupplierService service) => _service = service;

        public async Task<IActionResult> Index()
        {
            var suppliers = await _service.GetAllAsync();
            return View(suppliers);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (!ModelState.IsValid) return View(supplier);
            await _service.AddAsync(supplier);
            SetSuccessMessage("Supplier created successfully.");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var supplier = await _service.GetByIdAsync(id);
            if (supplier == null) return NotFound();
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Supplier supplier)
        {
            if (id != supplier.Id) return BadRequest();
            if (!ModelState.IsValid) return View(supplier);
            await _service.UpdateAsync(supplier);
            SetSuccessMessage("Supplier updated successfully.");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            SetSuccessMessage("Supplier deleted successfully.");
            return RedirectToAction(nameof(Index));
        }
    }
}

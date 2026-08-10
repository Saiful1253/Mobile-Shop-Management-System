using Microsoft.AspNetCore.Mvc;
using MobileShopManagementSystem.Services.Interfaces;
using MobileShopManagementSystem.Core.Models;
using MobileShopManagementSystem.Web.Models;

namespace MobileShopManagementSystem.Web.Controllers
{
    public class BrandsController : BaseController
    {
        private readonly IBrandService _service;
        public BrandsController(IBrandService service) => _service = service;

        public async Task<IActionResult> Index()
        {
            var brands = await _service.GetAllAsync();
            return View(brands);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (!ModelState.IsValid) return View(brand);
            await _service.AddAsync(brand);
            SetSuccessMessage("Brand created successfully.");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _service.GetByIdAsync(id);
            if (brand == null) return NotFound();
            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Brand brand)
        {
            if (id != brand.Id) return BadRequest();
            if (!ModelState.IsValid) return View(brand);
            await _service.UpdateAsync(brand);
            SetSuccessMessage("Brand updated successfully.");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            SetSuccessMessage("Brand deleted successfully.");
            return RedirectToAction(nameof(Index));
        }
    }
}

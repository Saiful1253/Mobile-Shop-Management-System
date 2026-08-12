using Microsoft.AspNetCore.Mvc;
using MobileShopManagementSystem.Services.Interfaces;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Web.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _service;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService service, IBrandService brandService, ICategoryService categoryService)
        {
            _service = service;
            _brandService = brandService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllAsync();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(product);
            }
            await _service.AddAsync(product);
            SetSuccessMessage("Product created successfully.");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();
            await PopulateDropdowns(product.BrandId, product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(product.BrandId, product.CategoryId);
                return View(product);
            }
            await _service.UpdateAsync(product);
            SetSuccessMessage("Product updated successfully.");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            SetSuccessMessage("Product deleted successfully.");
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdowns(int? selectedBrand = null, int? selectedCategory = null)
        {
            var brands = await _brandService.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Brands = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(brands, "Id", "Name", selectedBrand);
            ViewBag.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(categories, "Id", "Name", selectedCategory);
        }
    }
}

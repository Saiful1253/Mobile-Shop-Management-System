using Microsoft.AspNetCore.Mvc;

namespace MobileShopManagementSystem.Web.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult SalesReport() => View();
        public IActionResult PurchaseReport() => View();
        public IActionResult InventoryReport() => View();
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MobileShopManagementSystem.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected void SetSuccessMessage(string message) => TempData["Success"] = message;
        protected void SetErrorMessage(string message) => TempData["Error"] = message;
    }
}

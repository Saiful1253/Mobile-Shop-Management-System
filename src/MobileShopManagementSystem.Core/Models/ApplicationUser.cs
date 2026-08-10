using Microsoft.AspNetCore.Identity;

namespace MobileShopManagementSystem.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}

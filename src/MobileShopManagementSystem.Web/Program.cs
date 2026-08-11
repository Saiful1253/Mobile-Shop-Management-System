using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MobileShopManagementSystem.Data;
using MobileShopManagementSystem.Core.Models;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    "Server=localhost\\SQLEXPRESS;Database=MobileShopDb;Trusted_Connection=True;MultipleActiveResultSets=true";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddScoped<MobileShopManagementSystem.Core.Interfaces.IBrandRepository, MobileShopManagementSystem.Data.Repositories.BrandRepository>();
builder.Services.AddScoped<MobileShopManagementSystem.Core.Interfaces.ICategoryRepository, MobileShopManagementSystem.Data.Repositories.CategoryRepository>();
builder.Services.AddScoped<MobileShopManagementSystem.Core.Interfaces.IProductRepository, MobileShopManagementSystem.Data.Repositories.ProductRepository>();
builder.Services.AddScoped<MobileShopManagementSystem.Core.Interfaces.ICustomerRepository, MobileShopManagementSystem.Data.Repositories.CustomerRepository>();
builder.Services.AddScoped<MobileShopManagementSystem.Core.Interfaces.ISupplierRepository, MobileShopManagementSystem.Data.Repositories.SupplierRepository>();
builder.Services.AddScoped<MobileShopManagementSystem.Core.Interfaces.IPurchaseRepository, MobileShopManagementSystem.Data.Repositories.PurchaseRepository>();
builder.Services.AddScoped<MobileShopManagementSystem.Core.Interfaces.ISaleRepository, MobileShopManagementSystem.Data.Repositories.SaleRepository>();

builder.Services.AddScoped<MobileShopManagementSystem.Services.Interfaces.IBrandService, MobileShopManagementSystem.Services.Services.BrandService>();
builder.Services.AddScoped<MobileShopManagementSystem.Services.Interfaces.ICategoryService, MobileShopManagementSystem.Services.Services.CategoryService>();
builder.Services.AddScoped<MobileShopManagementSystem.Services.Interfaces.IProductService, MobileShopManagementSystem.Services.Services.ProductService>();
builder.Services.AddScoped<MobileShopManagementSystem.Services.Interfaces.ICustomerService, MobileShopManagementSystem.Services.Services.CustomerService>();
builder.Services.AddScoped<MobileShopManagementSystem.Services.Interfaces.ISupplierService, MobileShopManagementSystem.Services.Services.SupplierService>();
builder.Services.AddScoped<MobileShopManagementSystem.Services.Interfaces.IPurchaseService, MobileShopManagementSystem.Services.Services.PurchaseService>();
builder.Services.AddScoped<MobileShopManagementSystem.Services.Interfaces.ISaleService, MobileShopManagementSystem.Services.Services.SaleService>();

builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.AreaViewLocationFormats.Clear();
        options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}.cshtml");
        options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
    });
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    DbInitializer.SeedAsync(dbContext, userManager, roleManager).GetAwaiter().GetResult();
}

app.Run();

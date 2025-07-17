using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using QuanLyTTNgoaiNgu.Data;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký DbContext
builder.Services.AddDbContext<QuanLyTTNgoaiNguContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuanLyTTNgoaiNguContext")
        ?? throw new InvalidOperationException("Connection string not found.")));

// Đăng ký Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/TAIKHOANs/SignIn";
        options.AccessDeniedPath = "/TAIKHOANs/SignIn";
    });

// Add MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TAIKHOANs}/{action=SignIn}/{id?}");

app.Run();

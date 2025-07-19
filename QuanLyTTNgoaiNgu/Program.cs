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
        options.AccessDeniedPath = "/TAIKHOANs/AccessDenied";
    });

// Đăng ký Authorization Policy (nếu cần chi tiết chính sách phân quyền)
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("GiangVienOnly", policy => policy.RequireRole("GiangVien"));
    options.AddPolicy("HocVienOnly", policy => policy.RequireRole("HocVien"));
});

// Add MVC Controllers with Views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Sử dụng file tĩnh (css, js)
app.UseStaticFiles();

app.UseRouting();

// Xác thực người dùng trước khi phân quyền
app.UseAuthentication();
app.UseAuthorization();

// Routing mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TAIKHOANs}/{action=SignIn}/{id?}");

// Run application
app.Run();

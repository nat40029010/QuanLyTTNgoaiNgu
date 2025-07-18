using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyTTNgoaiNgu.Data;
using QuanLyTTNgoaiNgu.Models.ViewModels;

namespace QuanLyTTNgoaiNgu.Controllers
{
    public class TAIKHOANsController : Controller
    {
        private readonly QuanLyTTNgoaiNguContext _context;

        public TAIKHOANsController(QuanLyTTNgoaiNguContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult SignIn(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(TAIKHOANViewModel vm, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = await _context.TAIKHOAN
                .FirstOrDefaultAsync(u => u.TenDangNhap == vm.TenDangNhap && u.MatKhau == vm.MatKhau);

            if (user == null)
            {
                ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
                return View(vm);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.TenDangNhap),
                new Claim(ClaimTypes.Role, user.VaiTro),
                new Claim("MaTaiKhoan", user.MaTaiKhoan.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties { IsPersistent = vm.GhiNho });

            return RedirectToAction("Index", "Home");
        }

        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn");
        }

        [HttpGet]
        public IActionResult QuenMatKhau()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuenMatKhau(QuenMatKhauViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = await _context.TAIKHOAN
                .Where(x => x.TenDangNhap == vm.TenDangNhap)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                ModelState.AddModelError("", "Không tìm thấy tài khoản!");
                return View(vm);
            }

            // Kiểm tra email (ví dụ bạn lưu email bên HOCVIEN)
            var hocvien = await _context.HOCVIEN
                .FirstOrDefaultAsync(hv => hv.MaTaiKhoan == user.MaTaiKhoan && hv.Email == vm.Email);

            if (hocvien == null)
            {
                ModelState.AddModelError("", "Email không khớp với tài khoản!");
                return View(vm);
            }

            // Trả về mật khẩu
            vm.MatKhauHienThi = user.MatKhau;
            ViewBag.ThanhCong = true;
            return View(vm);
        }


    }
}
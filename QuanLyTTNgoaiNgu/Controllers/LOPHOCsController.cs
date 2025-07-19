using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyTTNgoaiNgu.Data;
using QuanLyTTNgoaiNgu.Models;

namespace QuanLyTTNgoaiNgu.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class LOPHOCsController : Controller
    {
        private readonly QuanLyTTNgoaiNguContext _context;

        public LOPHOCsController(QuanLyTTNgoaiNguContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int khoaHocId)
        {
            var danhSachLop = await _context.LOPHOC
                .Include(l => l.GIANGVIEN)
                .Where(l => l.MaKhoaHoc == khoaHocId)
                .ToListAsync();

            ViewBag.MaKhoaHoc = khoaHocId;
            var khoaHoc = await _context.KHOAHOC.FindAsync(khoaHocId);
            ViewBag.TenKhoaHoc = khoaHoc?.TenKhoaHoc;

            return View(danhSachLop);
        }

        public IActionResult Create(int maKhoaHoc)
        {
            ViewBag.MaKhoaHoc = maKhoaHoc;
            ViewBag.ListGiangVien = new SelectList(_context.GIANGVIEN, "MaGiangVien", "HoTen");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LOPHOC lh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lh);
                await _context.SaveChangesAsync();
                return RedirectToAction("LopHoc", "KHOAHOC", new { id = lh.MaKhoaHoc });
            }
            ViewBag.ListGiangVien = new SelectList(_context.GIANGVIEN, "MaGiangVien", "HoTen", lh.MaGiangVien);
            return View(lh);
        }
    }
}

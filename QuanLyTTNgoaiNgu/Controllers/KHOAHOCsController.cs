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
    [Authorize(Roles = "Admin")]
    public class KHOAHOCsController : Controller
    {
        private readonly QuanLyTTNgoaiNguContext _context;

        public KHOAHOCsController(QuanLyTTNgoaiNguContext context)
        {
            _context = context;
        }

        // GET: KHOAHOCs
        public async Task<IActionResult> Index()
        {
            return View(await _context.KHOAHOC.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KHOAHOC kh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kh);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var kh = await _context.KHOAHOC.FindAsync(id);
            if (kh == null) return NotFound();
            return View(kh);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(KHOAHOC kh)
        {
            if (ModelState.IsValid)
            {
                _context.Update(kh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kh);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var khoahoc = await _context.KHOAHOC.FirstOrDefaultAsync(m => m.MaKhoaHoc == id);
            if (khoahoc == null) return NotFound();

            return View(khoahoc); // View Delete.cshtml
        }

        // POST: KHOAHOC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khoahoc = await _context.KHOAHOC.FindAsync(id);
            if (khoahoc != null)
            {
                _context.KHOAHOC.Remove(khoahoc);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // Quản lý lớp học theo khóa học
        public async Task<IActionResult> LopHoc(int id)
        {
            var kh = await _context.KHOAHOC.Include(k => k.LOPHOCs).FirstOrDefaultAsync(k => k.MaKhoaHoc == id);
            if (kh == null) return NotFound();
            ViewBag.TenKhoaHoc = kh.TenKhoaHoc;
            ViewBag.MaKhoaHoc = kh.MaKhoaHoc;
            return View(kh.LOPHOCs?.ToList());
        }
    }
}

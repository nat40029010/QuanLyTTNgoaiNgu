using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyTTNgoaiNgu.Data;
using QuanLyTTNgoaiNgu.Models;

namespace QuanLyTTNgoaiNgu.Controllers
{
    public class PHIEUDANGKYsController : Controller
    {
        private readonly QuanLyTTNgoaiNguContext _context;

        public PHIEUDANGKYsController(QuanLyTTNgoaiNguContext context)
        {
            _context = context;
        }

        // GET: PHIEUDANGKYs
        public async Task<IActionResult> Index()
        {
            var quanLyTTNgoaiNguContext = _context.PHIEUDANGKY.Include(p => p.HOCVIEN).Include(p => p.LOPHOC);
            return View(await quanLyTTNgoaiNguContext.ToListAsync());
        }

        // GET: PHIEUDANGKYs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pHIEUDANGKY = await _context.PHIEUDANGKY
                .Include(p => p.HOCVIEN)
                .Include(p => p.LOPHOC)
                .FirstOrDefaultAsync(m => m.MaDangKy == id);
            if (pHIEUDANGKY == null)
            {
                return NotFound();
            }

            return View(pHIEUDANGKY);
        }

        // GET: PHIEUDANGKYs/Create
        public IActionResult Create()
        {
            ViewData["MaHocVien"] = new SelectList(_context.HOCVIEN, "MaHocVien", "DiaChi");
            ViewData["MaLopHoc"] = new SelectList(_context.LOPHOC, "MaLopHoc", "TenLop");
            return View();
        }

        // POST: PHIEUDANGKYs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDangKy,NgayDangKy,MaHocVien,MaLopHoc")] PHIEUDANGKY pHIEUDANGKY)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pHIEUDANGKY);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHocVien"] = new SelectList(_context.HOCVIEN, "MaHocVien", "DiaChi", pHIEUDANGKY.MaHocVien);
            ViewData["MaLopHoc"] = new SelectList(_context.LOPHOC, "MaLopHoc", "TenLop", pHIEUDANGKY.MaLopHoc);
            return View(pHIEUDANGKY);
        }

        // GET: PHIEUDANGKYs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pHIEUDANGKY = await _context.PHIEUDANGKY.FindAsync(id);
            if (pHIEUDANGKY == null)
            {
                return NotFound();
            }
            ViewData["MaHocVien"] = new SelectList(_context.HOCVIEN, "MaHocVien", "DiaChi", pHIEUDANGKY.MaHocVien);
            ViewData["MaLopHoc"] = new SelectList(_context.LOPHOC, "MaLopHoc", "TenLop", pHIEUDANGKY.MaLopHoc);
            return View(pHIEUDANGKY);
        }

        // POST: PHIEUDANGKYs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDangKy,NgayDangKy,MaHocVien,MaLopHoc")] PHIEUDANGKY pHIEUDANGKY)
        {
            if (id != pHIEUDANGKY.MaDangKy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pHIEUDANGKY);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PHIEUDANGKYExists(pHIEUDANGKY.MaDangKy))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHocVien"] = new SelectList(_context.HOCVIEN, "MaHocVien", "DiaChi", pHIEUDANGKY.MaHocVien);
            ViewData["MaLopHoc"] = new SelectList(_context.LOPHOC, "MaLopHoc", "TenLop", pHIEUDANGKY.MaLopHoc);
            return View(pHIEUDANGKY);
        }

        // GET: PHIEUDANGKYs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pHIEUDANGKY = await _context.PHIEUDANGKY
                .Include(p => p.HOCVIEN)
                .Include(p => p.LOPHOC)
                .FirstOrDefaultAsync(m => m.MaDangKy == id);
            if (pHIEUDANGKY == null)
            {
                return NotFound();
            }

            return View(pHIEUDANGKY);
        }

        // POST: PHIEUDANGKYs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pHIEUDANGKY = await _context.PHIEUDANGKY.FindAsync(id);
            if (pHIEUDANGKY != null)
            {
                _context.PHIEUDANGKY.Remove(pHIEUDANGKY);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PHIEUDANGKYExists(int id)
        {
            return _context.PHIEUDANGKY.Any(e => e.MaDangKy == id);
        }
    }
}

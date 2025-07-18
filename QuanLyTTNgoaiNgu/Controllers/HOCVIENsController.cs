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
    public class HOCVIENsController : Controller
    {
        private readonly QuanLyTTNgoaiNguContext _context;

        public HOCVIENsController(QuanLyTTNgoaiNguContext context)
        {
            _context = context;
        }

        // GET: HOCVIENs
        public async Task<IActionResult> Index()
        {
            return View(await _context.HOCVIEN.ToListAsync());
        }

        // GET: HOCVIENs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var hocVien = await _context.HOCVIEN
                              .FirstOrDefaultAsync(m => m.MaHocVien == id);
            if (hocVien == null) return NotFound();

            return View(hocVien);
        }

        // GET: HOCVIENs/DetailsWithHistory/5
        public async Task<IActionResult> DetailsWithHistory(int? id)
        {
            if (id == null) return NotFound();
            var hocVien = await _context.HOCVIEN.FindAsync(id);
            if (hocVien == null) return NotFound();

            ViewBag.LichSuDK = await _context.PHIEUDANGKY
                .Include(d => d.LOPHOC)
                .Where(d => d.MaHocVien == id)
                .ToListAsync();

            ViewBag.KetQua = await _context.KETQUAHOCTAP
                .Include(k => k.LOPHOC)
                .Where(k => k.MaHocVien == id)
                .ToListAsync();

            return View(hocVien);
        }



        // GET: HOCVIENs/Create
        public IActionResult Create()
        {
            // Optionally load accounts for dropdown
            ViewBag.MaTaiKhoanList = new SelectList(
                _context.TAIKHOAN.OrderBy(t => t.TenDangNhap),
                "MaTaiKhoan", "TenDangNhap");
            return View();
        }

        // POST: HOCVIENs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("MaHocVien,HoTen,SoDienThoai,NgaySinh,Email,DiaChi,MaTaiKhoan")] HOCVIEN hocVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MaTaiKhoanList = new SelectList(
                _context.TAIKHOAN.OrderBy(t => t.TenDangNhap),
                "MaTaiKhoan", "TenDangNhap", hocVien.MaTaiKhoan);
            return View(hocVien);
        }

        // GET: HOCVIENs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var hocVien = await _context.HOCVIEN.FindAsync(id);
            if (hocVien == null)
                return NotFound();

            // Khởi tạo dropdown Tài khoản
            ViewBag.MaTaiKhoanList = new SelectList(
                _context.TAIKHOAN
                        .AsNoTracking()
                        .OrderBy(t => t.TenDangNhap)
                        .ToList(),
                "MaTaiKhoan",
                "TenDangNhap",
                hocVien.MaTaiKhoan
            );

            return View(hocVien);
        }

        // POST: HOCVIENs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("MaHocVien,HoTen,SoDienThoai,NgaySinh,Email,DiaChi,MaTaiKhoan")] HOCVIEN hocVien)
        {
            if (id != hocVien.MaHocVien)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                // Refill dropdown nếu có lỗi
                ViewBag.MaTaiKhoanList = new SelectList(
                    _context.TAIKHOAN
                            .AsNoTracking()
                            .OrderBy(t => t.TenDangNhap)
                            .ToList(),
                    "MaTaiKhoan",
                    "TenDangNhap",
                    hocVien.MaTaiKhoan
                );
                return View(hocVien);
            }

            try
            {
                _context.Update(hocVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.HOCVIEN.Any(e => e.MaHocVien == id))
                    return NotFound();
                throw;
            }
        }

        // GET: HOCVIENs/AssignClass/5
        public async Task<IActionResult> AssignClass(int? id)
        {
            if (id == null) return NotFound();
            var hocVien = await _context.HOCVIEN.FindAsync(id);
            if (hocVien == null) return NotFound();

            ViewBag.LopHocList = new SelectList(
                _context.LOPHOC.OrderBy(l => l.TenLop),
                "MaLopHoc", "TenLop");
            return View(hocVien);
        }

        // POST: HOCVIENs/AssignClass/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignClass(int id, int MaLopHoc)
        {
            var phieu = new PHIEUDANGKY
            {
                MaHocVien = id,
                MaLopHoc = MaLopHoc,
                NgayDangKy = DateTime.Now
            };
            _context.PHIEUDANGKY.Add(phieu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DetailsWithHistory), new { id });
        }

        // GET: HOCVIENs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var hocVien = await _context.HOCVIEN
                              .FirstOrDefaultAsync(m => m.MaHocVien == id);
            if (hocVien == null) return NotFound();

            return View(hocVien);
        }

        // POST: HOCVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hocVien = await _context.HOCVIEN.FindAsync(id);
            if (hocVien != null)
                _context.HOCVIEN.Remove(hocVien);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HOCVIENExists(int id)
        {
            return _context.HOCVIEN.Any(e => e.MaHocVien == id);
        }
    }
}

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
    public class KETQUAHOCTAPsController : Controller
    {
        private readonly QuanLyTTNgoaiNguContext _context;

        public KETQUAHOCTAPsController(QuanLyTTNgoaiNguContext context)
        {
            _context = context;
        }

        public IActionResult DanhSachKhoaHoc()
        {
            var listKhoaHoc = _context.KHOAHOC.ToList();
            return View(listKhoaHoc);
        }

        public IActionResult Lop(int maKhoaHoc)
        {
            var listLop = _context.LOPHOC.Where(x => x.MaKhoaHoc == maKhoaHoc).ToList();
            ViewBag.MaKhoaHoc = maKhoaHoc;
            return View(listLop);
        }

        public async Task<IActionResult> XemKetQua(int lopHocId)
        {
            var list = await _context.KETQUAHOCTAP
                        .Include(x => x.HOCVIEN)
                        .Where(x => x.MaLopHoc == lopHocId)
                        .ToListAsync();

            // Lấy mã khóa học từ lớp học để quay lại lớp đúng
            var maKhoaHoc = await _context.LOPHOC
                                  .Where(x => x.MaLopHoc == lopHocId)
                                  .Select(x => x.MaKhoaHoc)
                                  .FirstOrDefaultAsync();

            ViewBag.MaKhoaHoc = maKhoaHoc;
            ViewBag.LopHocId = lopHocId;
            return View(list);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var kq = await _context.KETQUAHOCTAP
                .Include(x => x.HOCVIEN) // Bao gồm thông tin học viên
                .FirstOrDefaultAsync(x => x.MaKetQua == id);

            if (kq == null) return NotFound();

            // Truyền danh sách học viên vào ViewBag
            ViewBag.HocViens = new SelectList(_context.HOCVIEN, "MaHocVien", "HoTen", kq.MaHocVien);

            return View(kq);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KETQUAHOCTAP kq)
        {
            if (id != kq.MaKetQua) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kq);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("XemKetQua", new { lopHocId = kq.MaLopHoc });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.KETQUAHOCTAP.Any(e => e.MaKetQua == id))
                        return NotFound();
                    else
                        throw;
                }
            }

            // Nếu có lỗi, load lại ViewBag để giữ danh sách học viên
            ViewBag.HocViens = new SelectList(_context.HOCVIEN, "MaHocVien", "HoTen", kq.MaHocVien);
            return View(kq);
        }


        public async Task<IActionResult> ExportScoreboard(int lopHocId)
        {
            var list = await _context.KETQUAHOCTAP.Include(k => k.HOCVIEN).Where(k => k.MaLopHoc == lopHocId).ToListAsync();
            return View("Export", list);
        }

        public async Task<IActionResult> PhanLoai(int lopHocId)
        {
            var list = await _context.KETQUAHOCTAP.Include(x => x.HOCVIEN).Where(x => x.MaLopHoc == lopHocId).ToListAsync();
            return View(list);
        }
    }
}

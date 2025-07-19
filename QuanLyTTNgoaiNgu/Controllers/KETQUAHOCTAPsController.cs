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
    public class KETQUAHOCTAPsController : Controller
    {
        private readonly QuanLyTTNgoaiNguContext _context;

        public KETQUAHOCTAPsController(QuanLyTTNgoaiNguContext context)
        {
            _context = context;
        }

        //public async Task<IActionResult> Index(int? lopHocId)
        //{
        //    var query = _context.KETQUAHOCTAP.Include(k => k.HOCVIEN).AsQueryable();

        //    if (lopHocId.HasValue)
        //    {
        //        query = query.Where(k => k.MaLopHoc == lopHocId);
        //    }

        //    var list = await query.ToListAsync();
        //    ViewBag.LopHocId = lopHocId;
        //    return View(list);
        //}

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
            var list = await _context.KETQUAHOCTAP.Include(x => x.HOCVIEN)
                        .Where(x => x.MaLopHoc == lopHocId).ToListAsync();
            return View(list);
        }


        public IActionResult Create(int lopHocId)
        {
            ViewBag.LopHocId = lopHocId;
            ViewBag.HocViens = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.HOCVIEN, "MaHocVien", "HoTen");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(KETQUAHOCTAP kq)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kq);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { lopHocId = kq.MaLopHoc });
            }
            return View(kq);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var kq = await _context.KETQUAHOCTAP.FindAsync(id);
            if (kq == null) return NotFound();
            ViewBag.HocViens = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.HOCVIEN, "MaHocVien", "HoTen", kq.MaHocVien);
            return View(kq);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(KETQUAHOCTAP kq)
        {
            if (ModelState.IsValid)
            {
                _context.Update(kq);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { lopHocId = kq.MaLopHoc });
            }
            return View(kq);
        }

        public async Task<IActionResult> LockScoreboard(int lopHocId)
        {
            var list = await _context.KETQUAHOCTAP.Where(x => x.MaLopHoc == lopHocId).ToListAsync();
            list.ForEach(x => x.ChuyenCan = -1); // ví dụ: gán -1 để đánh dấu khóa bảng điểm
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { lopHocId });
        }

        public async Task<IActionResult> ExportScoreboard(int lopHocId)
        {
            var list = await _context.KETQUAHOCTAP.Include(k => k.HOCVIEN).Where(k => k.MaLopHoc == lopHocId).ToListAsync();
            return View("Export", list);
        }
    }
}

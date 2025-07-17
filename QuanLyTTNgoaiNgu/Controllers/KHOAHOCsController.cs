﻿using System;
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

        // GET: KHOAHOCs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kHOAHOC = await _context.KHOAHOC
                .FirstOrDefaultAsync(m => m.MaKhoaHoc == id);
            if (kHOAHOC == null)
            {
                return NotFound();
            }

            return View(kHOAHOC);
        }

        // GET: KHOAHOCs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KHOAHOCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKhoaHoc,TenKhoaHoc,MucHocPhi,MoTa")] KHOAHOC kHOAHOC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kHOAHOC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kHOAHOC);
        }

        // GET: KHOAHOCs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kHOAHOC = await _context.KHOAHOC.FindAsync(id);
            if (kHOAHOC == null)
            {
                return NotFound();
            }
            return View(kHOAHOC);
        }

        // POST: KHOAHOCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaKhoaHoc,TenKhoaHoc,MucHocPhi,MoTa")] KHOAHOC kHOAHOC)
        {
            if (id != kHOAHOC.MaKhoaHoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kHOAHOC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KHOAHOCExists(kHOAHOC.MaKhoaHoc))
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
            return View(kHOAHOC);
        }

        // GET: KHOAHOCs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kHOAHOC = await _context.KHOAHOC
                .FirstOrDefaultAsync(m => m.MaKhoaHoc == id);
            if (kHOAHOC == null)
            {
                return NotFound();
            }

            return View(kHOAHOC);
        }

        // POST: KHOAHOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kHOAHOC = await _context.KHOAHOC.FindAsync(id);
            if (kHOAHOC != null)
            {
                _context.KHOAHOC.Remove(kHOAHOC);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KHOAHOCExists(int id)
        {
            return _context.KHOAHOC.Any(e => e.MaKhoaHoc == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaThuocWeb.Models;

namespace QuanLyNhaThuocWeb.Controllers
{
    public class ThuocsController : Controller
    {
        private readonly QuanLyNhaThuocDbContext _context;

        public ThuocsController(QuanLyNhaThuocDbContext context)
        {
            _context = context;
        }

        // GET: Thuocs
        public async Task<IActionResult> Index()
        {
            var quanLyNhaThuocDbContext = _context.Thuocs.Include(t => t.MaDanhMucNavigation);
            return View(await quanLyNhaThuocDbContext.ToListAsync());
        }

        // GET: Thuocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuoc = await _context.Thuocs
                .Include(t => t.MaDanhMucNavigation)
                .FirstOrDefaultAsync(m => m.MaThuoc == id);
            if (thuoc == null)
            {
                return NotFound();
            }

            return View(thuoc);
        }

        // GET: Thuocs/Create
        public IActionResult Create()
        {
            ViewData["MaDanhMuc"] = new SelectList(_context.DanhMucs, "MaDanhMuc", "MaDanhMuc");
            return View();
        }

        // POST: Thuocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaThuoc,TenThuoc,HoatChat,DangBaoChe,SoDangKy,GiaBan,SoLuongTon,HanSuDung,MaDanhMuc,HinhAnh")] Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDanhMuc"] = new SelectList(_context.DanhMucs, "MaDanhMuc", "MaDanhMuc", thuoc.MaDanhMuc);
            return View(thuoc);
        }

        // GET: Thuocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuoc = await _context.Thuocs.FindAsync(id);
            if (thuoc == null)
            {
                return NotFound();
            }
            ViewData["MaDanhMuc"] = new SelectList(_context.DanhMucs, "MaDanhMuc", "MaDanhMuc", thuoc.MaDanhMuc);
            return View(thuoc);
        }

        // POST: Thuocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaThuoc,TenThuoc,HoatChat,DangBaoChe,SoDangKy,GiaBan,SoLuongTon,HanSuDung,MaDanhMuc,HinhAnh")] Thuoc thuoc)
        {
            if (id != thuoc.MaThuoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuocExists(thuoc.MaThuoc))
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
            ViewData["MaDanhMuc"] = new SelectList(_context.DanhMucs, "MaDanhMuc", "MaDanhMuc", thuoc.MaDanhMuc);
            return View(thuoc);
        }

        // GET: Thuocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuoc = await _context.Thuocs
                .Include(t => t.MaDanhMucNavigation)
                .FirstOrDefaultAsync(m => m.MaThuoc == id);
            if (thuoc == null)
            {
                return NotFound();
            }

            return View(thuoc);
        }

        // POST: Thuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thuoc = await _context.Thuocs.FindAsync(id);
            if (thuoc != null)
            {
                _context.Thuocs.Remove(thuoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuocExists(int id)
        {
            return _context.Thuocs.Any(e => e.MaThuoc == id);
        }
    }
}

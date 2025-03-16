using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ETicaretWeb.Data;
using ETicaretWeb.Models;

namespace ETicaretWeb.Controllers
{
    public class SiparisDetaylarisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiparisDetaylarisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SiparisDetaylaris
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SiparisDetaylaris.Include(s => s.Siparis).Include(s => s.Urun);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SiparisDetaylaris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siparisDetaylari = await _context.SiparisDetaylaris
                .Include(s => s.Siparis)
                .Include(s => s.Urun)
                .FirstOrDefaultAsync(m => m.SiparisDetayId == id);
            if (siparisDetaylari == null)
            {
                return NotFound();
            }

            return View(siparisDetaylari);
        }

        // GET: SiparisDetaylaris/Create
        public IActionResult Create()
        {
            ViewData["SiparisId"] = new SelectList(_context.Siparislers, "SiparisId", "SiparisId");
            ViewData["UrunId"] = new SelectList(_context.Urunlers, "UrunId", "UrunId");
            return View();
        }

        // POST: SiparisDetaylaris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiparisDetayId,SiparisId,UrunId,BirimFiyat,Miktar,Indirim")] SiparisDetaylari siparisDetaylari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siparisDetaylari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SiparisId"] = new SelectList(_context.Siparislers, "SiparisId", "SiparisId", siparisDetaylari.SiparisId);
            ViewData["UrunId"] = new SelectList(_context.Urunlers, "UrunId", "UrunId", siparisDetaylari.UrunId);
            return View(siparisDetaylari);
        }

        // GET: SiparisDetaylaris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siparisDetaylari = await _context.SiparisDetaylaris.FindAsync(id);
            if (siparisDetaylari == null)
            {
                return NotFound();
            }
            ViewData["SiparisId"] = new SelectList(_context.Siparislers, "SiparisId", "SiparisId", siparisDetaylari.SiparisId);
            ViewData["UrunId"] = new SelectList(_context.Urunlers, "UrunId", "UrunId", siparisDetaylari.UrunId);
            return View(siparisDetaylari);
        }

        // POST: SiparisDetaylaris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SiparisDetayId,SiparisId,UrunId,BirimFiyat,Miktar,Indirim")] SiparisDetaylari siparisDetaylari)
        {
            if (id != siparisDetaylari.SiparisDetayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siparisDetaylari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiparisDetaylariExists(siparisDetaylari.SiparisDetayId))
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
            ViewData["SiparisId"] = new SelectList(_context.Siparislers, "SiparisId", "SiparisId", siparisDetaylari.SiparisId);
            ViewData["UrunId"] = new SelectList(_context.Urunlers, "UrunId", "UrunId", siparisDetaylari.UrunId);
            return View(siparisDetaylari);
        }

        // GET: SiparisDetaylaris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siparisDetaylari = await _context.SiparisDetaylaris
                .Include(s => s.Siparis)
                .Include(s => s.Urun)
                .FirstOrDefaultAsync(m => m.SiparisDetayId == id);
            if (siparisDetaylari == null)
            {
                return NotFound();
            }

            return View(siparisDetaylari);
        }

        // POST: SiparisDetaylaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siparisDetaylari = await _context.SiparisDetaylaris.FindAsync(id);
            if (siparisDetaylari != null)
            {
                _context.SiparisDetaylaris.Remove(siparisDetaylari);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiparisDetaylariExists(int id)
        {
            return _context.SiparisDetaylaris.Any(e => e.SiparisDetayId == id);
        }
    }
}

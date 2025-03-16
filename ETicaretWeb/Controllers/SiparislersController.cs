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
    public class SiparislersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiparislersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Siparislers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Siparislers.Include(s => s.Musteri);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Siparislers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siparisler = await _context.Siparislers
                .Include(s => s.Musteri)
                .FirstOrDefaultAsync(m => m.SiparisId == id);
            if (siparisler == null)
            {
                return NotFound();
            }

            return View(siparisler);
        }

        // GET: Siparislers/Create
        public IActionResult Create()
        {
            ViewData["MusteriId"] = new SelectList(_context.Musterilers, "MusteriId", "MusteriId");
            return View();
        }

        // POST: Siparislers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiparisId,MusteriId,SiparisTarihi,TeslimTarihi,SiparisDurumu,ToplamTutar,TeslimatAdresi")] Siparisler siparisler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siparisler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MusteriId"] = new SelectList(_context.Musterilers, "MusteriId", "MusteriId", siparisler.MusteriId);
            return View(siparisler);
        }

        // GET: Siparislers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siparisler = await _context.Siparislers.FindAsync(id);
            if (siparisler == null)
            {
                return NotFound();
            }
            ViewData["MusteriId"] = new SelectList(_context.Musterilers, "MusteriId", "MusteriId", siparisler.MusteriId);
            return View(siparisler);
        }

        // POST: Siparislers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SiparisId,MusteriId,SiparisTarihi,TeslimTarihi,SiparisDurumu,ToplamTutar,TeslimatAdresi")] Siparisler siparisler)
        {
            if (id != siparisler.SiparisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siparisler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiparislerExists(siparisler.SiparisId))
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
            ViewData["MusteriId"] = new SelectList(_context.Musterilers, "MusteriId", "MusteriId", siparisler.MusteriId);
            return View(siparisler);
        }

        // GET: Siparislers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siparisler = await _context.Siparislers
                .Include(s => s.Musteri)
                .FirstOrDefaultAsync(m => m.SiparisId == id);
            if (siparisler == null)
            {
                return NotFound();
            }

            return View(siparisler);
        }

        // POST: Siparislers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siparisler = await _context.Siparislers.FindAsync(id);
            if (siparisler != null)
            {
                _context.Siparislers.Remove(siparisler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiparislerExists(int id)
        {
            return _context.Siparislers.Any(e => e.SiparisId == id);
        }
    }
}

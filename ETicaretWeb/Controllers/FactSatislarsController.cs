using ETicaretWeb.Data;
using ETicaretWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class FactSatislarsController : Controller
{
    private readonly ApplicationDbContext _context;

    public FactSatislarsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: FactSatislars
    public async Task<IActionResult> Index()
    {
        var satislar = await _context.FactSatislars
            .Include(f => f.MusteriKeyNavigation)
            .Include(f => f.UrunKeyNavigation)
            .OrderByDescending(f => f.SatisKey)
            .ToListAsync();
        return View(satislar);
    }

    // GET: FactSatislars/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var factSatislar = await _context.FactSatislars
            .Include(f => f.MusteriKeyNavigation)
            .Include(f => f.UrunKeyNavigation)
            .FirstOrDefaultAsync(m => m.SatisKey == id);
        if (factSatislar == null)
        {
            return NotFound();
        }

        return View(factSatislar);
    }

    // GET: FactSatislars/Create
    public IActionResult Create()
    {
        ViewData["MusteriKey"] = new SelectList(_context.DimMusterilers.OrderBy(m => m.Ad), "MusteriKey", "Ad");
        ViewData["UrunKey"] = new SelectList(_context.DimUrunlers.OrderBy(u => u.UrunAdi), "UrunKey", "UrunAdi");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MusteriKey,UrunKey,SatisMiktari,BirimFiyat,IndirimTutari")] FactSatislar factSatislar)
    {
        if (ModelState.IsValid)
        {
            // Toplam tutarı hesapla
            factSatislar.ToplamTutar = factSatislar.SatisMiktari * factSatislar.BirimFiyat;

            // Net tutarı hesapla
            factSatislar.NetTutar = factSatislar.ToplamTutar - factSatislar.IndirimTutari;

            _context.Add(factSatislar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["MusteriKey"] = new SelectList(_context.DimMusterilers.OrderBy(m => m.Ad), "MusteriKey", "Ad", factSatislar.MusteriKey);
        ViewData["UrunKey"] = new SelectList(_context.DimUrunlers.OrderBy(u => u.UrunAdi), "UrunKey", "UrunAdi", factSatislar.UrunKey);
        return View(factSatislar);
    }

    // GET: FactSatislars/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var factSatislar = await _context.FactSatislars.FindAsync(id);
        if (factSatislar == null)
        {
            return NotFound();
        }

        ViewData["MusteriKey"] = new SelectList(_context.DimMusterilers.OrderBy(m => m.Ad), "MusteriKey", "Ad", factSatislar.MusteriKey);
        ViewData["UrunKey"] = new SelectList(_context.DimUrunlers.OrderBy(u => u.UrunAdi), "UrunKey", "UrunAdi", factSatislar.UrunKey);
        return View(factSatislar);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("SatisKey,MusteriKey,UrunKey,SatisMiktari,BirimFiyat,IndirimTutari")] FactSatislar factSatislar)
    {
        if (id != factSatislar.SatisKey)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                // Toplam tutarı hesapla
                factSatislar.ToplamTutar = factSatislar.SatisMiktari * factSatislar.BirimFiyat;

                // Net tutarı hesapla
                factSatislar.NetTutar = factSatislar.ToplamTutar - factSatislar.IndirimTutari;

                _context.Update(factSatislar);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactSatislarExists(factSatislar.SatisKey))
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

        ViewData["MusteriKey"] = new SelectList(_context.DimMusterilers.OrderBy(m => m.Ad), "MusteriKey", "Ad", factSatislar.MusteriKey);
        ViewData["UrunKey"] = new SelectList(_context.DimUrunlers.OrderBy(u => u.UrunAdi), "UrunKey", "UrunAdi", factSatislar.UrunKey);
        return View(factSatislar);
    }

    // GET: FactSatislars/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var factSatislar = await _context.FactSatislars
            .Include(f => f.MusteriKeyNavigation)
            .Include(f => f.UrunKeyNavigation)
            .FirstOrDefaultAsync(m => m.SatisKey == id);
        if (factSatislar == null)
        {
            return NotFound();
        }

        return View(factSatislar);
    }

    // POST: FactSatislars/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var factSatislar = await _context.FactSatislars.FindAsync(id);
        if (factSatislar != null)
        {
            _context.FactSatislars.Remove(factSatislar);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool FactSatislarExists(int id)
    {
        return _context.FactSatislars.Any(e => e.SatisKey == id);
    }
}

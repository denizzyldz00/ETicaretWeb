using ETicaretWeb.Data;
using ETicaretWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class DimMusterilersController : Controller
{
    private readonly ApplicationDbContext _context;

    public DimMusterilersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DimMusterilers
    public async Task<IActionResult> Index()
    {
        return View(await _context.DimMusterilers.OrderBy(m => m.Soyad).ThenBy(m => m.Ad).ToListAsync());
    }

    // GET: DimMusterilers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dimMusteriler = await _context.DimMusterilers
            .FirstOrDefaultAsync(m => m.MusteriKey == id);
        if (dimMusteriler == null)
        {
            return NotFound();
        }

        return View(dimMusteriler);
    }

    // GET: DimMusterilers/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Ad,Soyad,Email")] DimMusteriler dimMusteriler)
    {
        if (ModelState.IsValid)
        {
            _context.Add(dimMusteriler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(dimMusteriler);
    }

    // GET: DimMusterilers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dimMusteriler = await _context.DimMusterilers.FindAsync(id);
        if (dimMusteriler == null)
        {
            return NotFound();
        }
        return View(dimMusteriler);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("MusteriKey,Ad,Soyad,Email")] DimMusteriler dimMusteriler)
    {
        if (id != dimMusteriler.MusteriKey)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(dimMusteriler);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimMusterilerExists(dimMusteriler.MusteriKey))
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
        return View(dimMusteriler);
    }

    // GET: DimMusterilers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dimMusteriler = await _context.DimMusterilers
            .FirstOrDefaultAsync(m => m.MusteriKey == id);
        if (dimMusteriler == null)
        {
            return NotFound();
        }

        return View(dimMusteriler);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var dimMusteriler = await _context.DimMusterilers
            .Include(m => m.FactSatislars)
            .FirstOrDefaultAsync(m => m.MusteriKey == id);

        if (dimMusteriler != null)
        {
            if (dimMusteriler.FactSatislars.Any())
            {
                TempData["Error"] = "Bu müşteriye ait satış kayıtları bulunduğu için silinemez.";
                return RedirectToAction(nameof(Index));
            }

            _context.DimMusterilers.Remove(dimMusteriler);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }


    private bool DimMusterilerExists(int id)
    {
        return _context.DimMusterilers.Any(e => e.MusteriKey == id);
    }
}

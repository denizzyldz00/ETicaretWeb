using ETicaretWeb.Data;
using ETicaretWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class DimKategorilersController : Controller
{
    private readonly ApplicationDbContext _context;

    public DimKategorilersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DimKategorilers
    public async Task<IActionResult> Index()
    {
        return View(await _context.DimKategorilers.OrderBy(k => k.KategoriAdi).ToListAsync());
    }

    // GET: DimKategorilers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dimKategoriler = await _context.DimKategorilers
            .FirstOrDefaultAsync(m => m.KategoriKey == id);
        if (dimKategoriler == null)
        {
            return NotFound();
        }

        return View(dimKategoriler);
    }

    // GET: DimKategorilers/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("KategoriAdi,Aciklama")] DimKategoriler dimKategoriler)
    {
        if (ModelState.IsValid)
        {
            _context.Add(dimKategoriler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(dimKategoriler);
    }

    // GET: DimKategorilers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dimKategoriler = await _context.DimKategorilers.FindAsync(id);
        if (dimKategoriler == null)
        {
            return NotFound();
        }
        return View(dimKategoriler);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("KategoriKey,KategoriAdi,Aciklama")] DimKategoriler dimKategoriler)
    {
        if (id != dimKategoriler.KategoriKey)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(dimKategoriler);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimKategorilerExists(dimKategoriler.KategoriKey))
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
        return View(dimKategoriler);
    }

    // GET: DimKategorilers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dimKategoriler = await _context.DimKategorilers
            .FirstOrDefaultAsync(m => m.KategoriKey == id);
        if (dimKategoriler == null)
        {
            return NotFound();
        }

        return View(dimKategoriler);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var dimKategoriler = await _context.DimKategorilers.FindAsync(id);
        if (dimKategoriler != null)
        {
            _context.DimKategorilers.Remove(dimKategoriler);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private bool DimKategorilerExists(int id)
    {
        return _context.DimKategorilers.Any(e => e.KategoriKey == id);
    }
}

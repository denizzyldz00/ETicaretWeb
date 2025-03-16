using ETicaretWeb.Data;
using ETicaretWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class DimUrunlersController : Controller
{
    private readonly ApplicationDbContext _context;

    public DimUrunlersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DimUrunlers
    public async Task<IActionResult> Index()
    {
        return View(await _context.DimUrunlers.OrderBy(u => u.UrunAdi).ToListAsync());
    }

    // GET: DimUrunlers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dimUrunler = await _context.DimUrunlers
            .FirstOrDefaultAsync(m => m.UrunKey == id);
        if (dimUrunler == null)
        {
            return NotFound();
        }

        return View(dimUrunler);
    }

    // GET: DimUrunlers/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("UrunAdi,BirimFiyat")] DimUrunler dimUrunler)
    {
        if (ModelState.IsValid)
        {
            _context.Add(dimUrunler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(dimUrunler);
    }

    // GET: DimUrunlers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dimUrunler = await _context.DimUrunlers.FindAsync(id);
        if (dimUrunler == null)
        {
            return NotFound();
        }
        return View(dimUrunler);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("UrunKey,UrunAdi,BirimFiyat")] DimUrunler dimUrunler)
    {
        if (id != dimUrunler.UrunKey)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(dimUrunler);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimUrunlerExists(dimUrunler.UrunKey))
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
        return View(dimUrunler);
    }

    // GET: DimUrunlers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dimUrunler = await _context.DimUrunlers
            .FirstOrDefaultAsync(m => m.UrunKey == id);
        if (dimUrunler == null)
        {
            return NotFound();
        }

        return View(dimUrunler);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var dimUrunler = await _context.DimUrunlers.FindAsync(id);
        if (dimUrunler != null)
        {
            _context.DimUrunlers.Remove(dimUrunler);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private bool DimUrunlerExists(int id)
    {
        return _context.DimUrunlers.Any(e => e.UrunKey == id);
    }
}

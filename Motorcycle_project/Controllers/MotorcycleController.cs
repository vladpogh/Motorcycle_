using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorcycleMarketplace.Models;

public class MotorcycleController : Controller
{
    private readonly ApplicationDbContext _context;

    public MotorcycleController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Motorcycles
    public async Task<IActionResult> Index()
    {
        var motorcycles = await _context.Motorcycles.ToListAsync();
        return View(motorcycles);
    }

    // GET: Motorcycles/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Motorcycles/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Brand,Model,Description,Price,ImageUrl")] Motorcycle motorcycle)
    {
        if (ModelState.IsValid)
        {
            _context.Add(motorcycle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(motorcycle);
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorcycleStore.Data;
using MotorcycleStore.Models;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;
    public AdminController(ApplicationDbContext context) => _context = context;

    public async Task<IActionResult> Index() =>
        View(await _context.Motorcycles.ToListAsync());

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Motorcycle m)
    {
        _context.Motorcycles.Add(m);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id) =>
        View(await _context.Motorcycles.FindAsync(id));

    [HttpPost]
    public async Task<IActionResult> Edit(Motorcycle m)
    {
        _context.Motorcycles.Update(m);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id) =>
        View(await _context.Motorcycles.FindAsync(id));

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var m = await _context.Motorcycles.FindAsync(id);
        _context.Motorcycles.Remove(m);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Orders() =>
        View(await _context.Orders.Include(x => x.Motorcycle).ToListAsync());
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorcycleStore.Data;
using MotorcycleStore.Models;

public class MotorcycleController : Controller
{
    private readonly ApplicationDbContext _context;
    public MotorcycleController(ApplicationDbContext context) => _context = context;

    public async Task<IActionResult> Index() =>
        View(await _context.Motorcycles.ToListAsync());

    public async Task<IActionResult> Details(int id)
    {
        var moto = await _context.Motorcycles.FindAsync(id);
        return View(moto);
    }

    [Authorize]
    public IActionResult Buy(int id) =>
        View(new Order { MotorcycleId = id });

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Buy(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return RedirectToAction("Thanks");
    }

    public IActionResult Thanks() => View();
}

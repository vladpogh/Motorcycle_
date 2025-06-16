using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorcycleStore.Models;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var motorcycles = await _context.Motorcycles.ToListAsync();

        // Проверка да не е null (ако няма мотори, връща празен списък, а не null)
        if (motorcycles == null)
        {
            motorcycles = new List<Motorcycle>();
        }

        return View(motorcycles);
    }
}

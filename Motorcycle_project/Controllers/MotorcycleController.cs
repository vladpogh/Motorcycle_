using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class MotorcycleController : Controller
{
    private readonly ApplicationDbContext _context;

    public MotorcycleController(ApplicationDbContext context)
    {
        _context = context;
    }

  

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Brand,Model,Description,Price,ImageUrl")] Motorcycle motorcycle)
    {
   
        }
        return View(motorcycle);
    }
}

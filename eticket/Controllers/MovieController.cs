using Eticket.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticket.Controllers
{

    [Authorize]
    public class MovieController : Controller
    {
        public readonly AppDbContext _context;

        public MovieController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Movie()
        {
            var allmovie = await _context.Mocie.Include(n=> n.Cinema).OrderBy(n=> n.Name).ToListAsync();
            return View(allmovie);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NinjaManager.Data;

namespace NinjaManager.Controllers
{
    public class NinjaController : Controller
    {
        private readonly NinjaManagerDbContext _context;

        public NinjaController(NinjaManagerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ninjas = _context.Ninjas.ToList();

            return View("Ninjas", ninjas);
        }
    }
}

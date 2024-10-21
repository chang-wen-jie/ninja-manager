using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NinjaManager.Data;

namespace NinjaManager.Controllers
{
    public class InventoryController : Controller
    {
        private readonly NinjaManagerDbContext _context;

        public InventoryController(NinjaManagerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int ninjaId)
        {
            var ninjaEquipment = _context.Ninjas
                .Include(n => n.Inventory)
                .ThenInclude(i => i.Equipment)
                .FirstOrDefault(n => n.NinjaId == ninjaId);

            if (ninjaEquipment == null) return NotFound();

            return View("Index", ninjaEquipment);
        }
    }
}

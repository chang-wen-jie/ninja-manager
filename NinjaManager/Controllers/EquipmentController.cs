using Microsoft.AspNetCore.Mvc;

namespace NinjaManager.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

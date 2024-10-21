using Microsoft.AspNetCore.Mvc;
using NinjaManager.Data;
using NinjaManager.Models;

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

            return View("Index", ninjas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NinjaModel ninjaModel)
        {
            if (ModelState.IsValid)
            {
                var ninja = new NinjaModel()
                {
                    NinjaId = ninjaModel.NinjaId,
                    Name = ninjaModel.Name,
                    Gold = ninjaModel.Gold,
                };

                _context.Ninjas.Add(ninja);
                _context.SaveChanges();

                return RedirectToAction("Index");
            } else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    System.Console.WriteLine(error.ErrorMessage);
                }
            }

            return View(ninjaModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ninja = _context.Ninjas.Find(id);
            if (ninja == null) return NotFound();

            var ninjaModel = new NinjaModel()
            {
                NinjaId = ninja.NinjaId,
                Name = ninja.Name,
                Gold = ninja.Gold,
            };

            return View(ninjaModel);
        }

        [HttpPost]
        public IActionResult Edit(NinjaModel ninjaModel)
        {
            if (ModelState.IsValid)
            {
                var ninja = _context.Ninjas.Find(ninjaModel.NinjaId);
                if (ninja == null) return NotFound();

                ninja.NinjaId = ninjaModel.NinjaId;
                ninja.Name = ninjaModel.Name;
                ninja.Gold = ninjaModel.Gold;

                _context.SaveChanges();

                return RedirectToAction("Index");
            } else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    System.Console.WriteLine(error.ErrorMessage);
                }
            }

            return View(ninjaModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var ninja = _context.Ninjas.Find(id);
            if (ninja == null) return NotFound();

            _context.Ninjas.Remove(ninja);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

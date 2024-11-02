using Microsoft.AspNetCore.Mvc;
using NinjaManager.Business.Models;
using NinjaManager.Data.Context;
using NinjaManager.Web.ViewModels;

namespace NinjaManager.Web.Controllers
{
    public class NinjaController(NinjaManagerDbContext context) : Controller
    {
        private readonly NinjaManagerDbContext _context = context;

        public IActionResult Index()
        {
            var ninjas = _context.Ninjas.ToList();

            var ninjaViewModels = ninjas.Select(n => new NinjaViewModel
            {
                NinjaId = n.NinjaId,
                Name = n.Name,
                Gold = n.Gold,
            }).ToList();

            return View("Index", ninjaViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NinjaViewModel ninjaViewModel)
        {
            if (ModelState.IsValid)
            {
                var ninjaModel = new NinjaModel()
                {
                    Name = ninjaViewModel.Name,
                    Gold = ninjaViewModel.Gold,
                };

                _context.Ninjas.Add(ninjaModel);
                _context.SaveChanges();

                TempData["SuccessMessage"] = $"Successfully created {ninjaModel.Name}!";

                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            return View(ninjaViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ninja = _context.Ninjas.Find(id);
            if (ninja == null) return NotFound();

            var ninjaViewModel = new NinjaViewModel()
            {
                NinjaId = ninja.NinjaId,
                Name = ninja.Name,
                Gold = ninja.Gold,
            };

            return View(ninjaViewModel);
        }

        [HttpPost]
        public IActionResult Edit(NinjaViewModel ninjaViewModel)
        {
            if (ModelState.IsValid)
            {
                var ninja = _context.Ninjas.Find(ninjaViewModel.NinjaId);
                if (ninja == null) return NotFound();

                ninja.NinjaId = ninjaViewModel.NinjaId;
                ninja.Name = ninjaViewModel.Name;
                ninja.Gold = ninjaViewModel.Gold;

                _context.SaveChanges();

                TempData["SuccessMessage"] = $"Successfully updated {ninja.Name}!";

                return RedirectToAction("Index", "Inventory", new { ninja.NinjaId });
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            return View(ninjaViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var ninja = _context.Ninjas.Find(id);
            if (ninja == null) return NotFound();

            _context.Ninjas.Remove(ninja);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"Successfully removed {ninja.Name}!";

            return RedirectToAction("Index");
        }
    }
}

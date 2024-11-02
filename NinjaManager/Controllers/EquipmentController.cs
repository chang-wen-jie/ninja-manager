using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NinjaManager.Business.Models;
using NinjaManager.Data.Context;
using NinjaManager.Web.ViewModels;

namespace NinjaManager.Web.Controllers
{
    public class EquipmentController(NinjaManagerDbContext context) : Controller
    {
        private readonly NinjaManagerDbContext _context = context;

        public IActionResult Index()
        {
            var equipment = _context.Equipment.ToList();

            var equipmentViewModels = equipment.Select(e => new EquipmentViewModel
            {
                EquipmentId = e.EquipmentId,
                Name = e.Name,
                GoldValue = e.GoldValue,
                Category = e.Category,
                Strength = e.Strength,
                Intelligence = e.Intelligence,
                Agility = e.Agility,
            }).ToList();

            return View("Index", equipmentViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryDropdown = new SelectList(Enum.GetValues(typeof(EquipmentCategory)));

            return View();
        }

        [HttpPost]
        public IActionResult Create(EquipmentViewModel equipmentViewModel)
        {
            if (ModelState.IsValid)
            {
                var equipmentModel = new EquipmentModel()
                {
                    Name = equipmentViewModel.Name,
                    GoldValue = equipmentViewModel.GoldValue,
                    Category = equipmentViewModel.Category,
                    Strength = equipmentViewModel.Strength,
                    Intelligence = equipmentViewModel.Intelligence,
                    Agility = equipmentViewModel.Agility,
                };

                _context.Equipment.Add(equipmentModel);
                _context.SaveChanges();

                TempData["SuccessMessage"] = $"Successfully created {equipmentModel.Name}!";

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

            ViewBag.CategoryDropdown = new SelectList(Enum.GetValues(typeof(EquipmentCategory)));

            return View(equipmentViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var equipment = _context.Equipment.Find(id);
            if (equipment == null) return NotFound();

            var equipmentModel = new EquipmentViewModel()
            {
                EquipmentId = equipment.EquipmentId,
                Name = equipment.Name,
                GoldValue = equipment.GoldValue,
                Category = equipment.Category,
                Strength = equipment.Strength,
                Intelligence = equipment.Intelligence,
                Agility = equipment.Agility,
            };

            ViewBag.CategoryDropdown = new SelectList(Enum.GetValues(typeof(EquipmentCategory)), equipment.Category);

            return View(equipmentModel);
        }

        [HttpPost]
        public IActionResult Edit(EquipmentViewModel equipmentModel)
        {
            if (ModelState.IsValid)
            {
                var equipment = _context.Equipment.Find(equipmentModel.EquipmentId);
                if (equipment == null) return NotFound();

                equipment.EquipmentId = equipmentModel.EquipmentId;
                equipment.Name = equipmentModel.Name;
                equipment.GoldValue = equipmentModel.GoldValue;
                equipment.Category = equipmentModel.Category;
                equipment.Strength = equipmentModel.Strength;
                equipment.Intelligence = equipmentModel.Intelligence;
                equipmentModel.Agility = equipmentModel.Agility;

                _context.SaveChanges();

                TempData["SuccessMessage"] = $"Successfully updated {equipment.Name}!";

                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                ViewBag.CategoryDropdown = new SelectList(Enum.GetValues(typeof(EquipmentCategory)), equipmentModel.Category);

                return View(equipmentModel);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var equipment = _context.Equipment.Find(id);
            if (equipment == null) return NotFound();

            var ninjasWithEquipment = _context.Ninjas
                .Where(n => n.Inventory.Any(e => e.EquipmentId == id))
                .ToList();

            foreach (var ninja in ninjasWithEquipment)
            {
                ninja.Gold += equipment.GoldValue;

                var inventoryItemToRemove = ninja.Inventory.Where(i => i.EquipmentId == id).ToList();
                foreach (var item in inventoryItemToRemove)
                {
                    ninja.Inventory.Remove(item);
                }
            }
            _context.SaveChanges();

            _context.Equipment.Remove(equipment);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"Successfully removed {equipment.Name}!";

            return RedirectToAction("Index");
        }
    }
}

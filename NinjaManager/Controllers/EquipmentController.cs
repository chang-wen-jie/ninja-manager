using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NinjaManager.Data;
using NinjaManager.Models;

namespace NinjaManager.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly NinjaManagerDbContext _context;

        public EquipmentController(NinjaManagerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var equipment = _context.Equipment.ToList();

            return View("Index", equipment);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryDropdown = new SelectList(Enum.GetValues(typeof(EquipmentCategory)));

            return View();
        }

        [HttpPost]
        public IActionResult Create(EquipmentModel equipmentModel)
        {
            if (ModelState.IsValid)
            {
                var equipment = new EquipmentModel()
                {
                    Name = equipmentModel.Name,
                    GoldValue = equipmentModel.GoldValue,
                    Category = equipmentModel.Category,
                    Strength = equipmentModel.Strength,
                    Intelligence = equipmentModel.Intelligence,
                    Agility = equipmentModel.Agility,
                };

                _context.Equipment.Add(equipment);
                _context.SaveChanges();

                TempData["SuccessMessage"] = $"Successfully created {equipment.Name}!";

                return RedirectToAction("Index");
            } else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    System.Console.WriteLine(error.ErrorMessage);
                }
            }

            ViewBag.CategoryDropdown = new SelectList(Enum.GetValues(typeof(EquipmentCategory)));

            return View(equipmentModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var equipment = _context.Equipment.Find(id);
            if (equipment == null) return NotFound();

            var equipmentModel = new EquipmentModel()
            {
                EquipmentId = equipment.EquipmentId,
                Name = equipment.Name,
                GoldValue = equipment.GoldValue,
                Category = equipment.Category,
                Strength = equipment.Strength,
                Intelligence= equipment.Intelligence,
                Agility = equipment.Agility,
            };

            ViewBag.CategoryDropdown = new SelectList(Enum.GetValues(typeof(EquipmentCategory)), equipment.Category);

            return View(equipmentModel);
        }

        [HttpPost]
        public IActionResult Edit(EquipmentModel equipmentModel)
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
            } else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    System.Console.WriteLine(error.ErrorMessage);
                }

                ViewBag.CategoryDropdown = new SelectList(Enum.GetValues(typeof(EquipmentCategory)), equipmentModel.Category);

                return View(equipmentModel);
            }
        }

        [HttpPost]
        public IActionResult Delete (int id)
        {
            var equipment = _context.Equipment.Find(id);
            if (equipment == null) return NotFound();

            _context.Equipment.Remove(equipment);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"Successfully removed {equipment.Name}!";

            return RedirectToAction("Index");
        }
    }
}

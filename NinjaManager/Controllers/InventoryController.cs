﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NinjaManager.Data;
using NinjaManager.Models;

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

        [HttpGet]
        public IActionResult Buy(int ninjaId, EquipmentCategory? category = null)
        {
            var ninja = _context.Ninjas
                .Include(n => n.Inventory)
                .FirstOrDefault(n => n.NinjaId == ninjaId);
            if (ninja == null) return NotFound();

            var ninjaEquipmentIds = ninja.Inventory.Select(i => i.EquipmentId).ToList();
            var equipmentQuery = _context.Equipment.AsQueryable();

            if (category.HasValue)
            {
                equipmentQuery = equipmentQuery.Where(e => e.Category == category.Value);
            }

            var availableEquipment = equipmentQuery
                .Where(e => !ninjaEquipmentIds.Contains(e.EquipmentId))
                .ToList();

            ViewBag.NinjaId = ninjaId;
            ViewBag.SelectedCategory = category;

            return View(availableEquipment);
        }

        [HttpPost]
        public IActionResult Buy(int ninjaId, int equipmentId)
        {
            var ninja = _context.Ninjas
                .Include(n => n.Inventory)
                .ThenInclude(i => i.Equipment)
                .FirstOrDefault(n => n.NinjaId == ninjaId);
            if (ninja == null) return NotFound();


            var equipment = _context.Equipment.Find(equipmentId);
            if (equipment == null) return NotFound();

            var existingCategoryEquipment = ninja.Inventory.Any(i => i.Equipment.Category == equipment.Category);
            if (existingCategoryEquipment)
            {
                TempData["ErrorMessage"] = $"You already have equipment in the {equipment.Category} category!";

                return RedirectToAction("Buy", new { ninjaId = ninjaId });
            }

            if (ninja.Gold >= equipment.GoldValue)
            {
                ninja.Gold -= equipment.GoldValue;

                _context.Inventories.Add(new InventoryModel
                {
                    NinjaId = ninjaId,
                    EquipmentId = equipmentId,
                });
                _context.SaveChanges();

                TempData["SuccessMessage"] = $"Successfully bought {equipment.Name}!";

            } else {
                TempData["ErrorMessage"] = $"You lack {equipment.GoldValue - ninja.Gold} gold to purchase this equipment!";
            }

            return RedirectToAction("Buy", new { ninjaId });
        }

        [HttpPost]
        public IActionResult Sell(int ninjaId, int equipmentId)
        {
            var ninja = _context.Ninjas
                .Include(n => n.Inventory)
                .ThenInclude(i => i.Equipment)
                .FirstOrDefault(n => n.NinjaId == ninjaId);
            if (ninja == null) return NotFound();

            var inventoryItem = ninja.Inventory.FirstOrDefault(i => i.EquipmentId == equipmentId);
            if (inventoryItem == null) return NotFound();

            var equipment = inventoryItem.Equipment;
            if (equipment == null) return NotFound();

            ninja.Gold += equipment.GoldValue;

            _context.Inventories.Remove(inventoryItem);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"Successfully sold {equipment.Name}!";

            return RedirectToAction("Index", new { ninjaId });
        }

        [HttpPost]
        public IActionResult SellAll(int ninjaId)
        {
            var ninja = _context.Ninjas
                .Include(n => n.Inventory)
                .ThenInclude(i => i.Equipment)
                .FirstOrDefault(n => n.NinjaId == ninjaId);
            if (ninja == null) return NotFound();

            var totalGearValue = ninja.TotalGearValue;
            ninja.Gold += totalGearValue;

            _context.Inventories.RemoveRange(ninja.Inventory);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"Successfully sold all equipment and gained {totalGearValue} gold!";

            return RedirectToAction("Index", new { ninjaId });
        }
    }
}

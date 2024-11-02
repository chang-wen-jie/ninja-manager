using Microsoft.EntityFrameworkCore;
using NinjaManager.Business.Models;

namespace NinjaManager.Data.Context
{
    public class NinjaManagerDbContext : DbContext
    {
        public NinjaManagerDbContext(DbContextOptions<NinjaManagerDbContext> options) : base(options)
        {
        }

        public DbSet<NinjaModel> Ninjas { get; set; }
        public DbSet<EquipmentModel> Equipment { get; set; }
        public DbSet<InventoryModel> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NinjaModel>().HasData(
                new NinjaModel { NinjaId = 1, Name = "Naruto Uzumaki", Gold = 100 },
                new NinjaModel { NinjaId = 2, Name = "Sasuke Uchiha", Gold = 150 },
                new NinjaModel { NinjaId = 3, Name = "Sakura Haruno", Gold = 120 },
                new NinjaModel { NinjaId = 4, Name = "Kakashi Hatake", Gold = 200 },
                new NinjaModel { NinjaId = 5, Name = "Rock Lee", Gold = 90 },
                new NinjaModel { NinjaId = 6, Name = "Neji Hyuga", Gold = 110 },
                new NinjaModel { NinjaId = 7, Name = "Tenten", Gold = 130 },
                new NinjaModel { NinjaId = 8, Name = "Orochimaru", Gold = 250 },
                new NinjaModel { NinjaId = 9, Name = "Hinata Hyuga", Gold = 160 },
                new NinjaModel { NinjaId = 10, Name = "Shino Aburame", Gold = 140 }
            );

            modelBuilder.Entity<EquipmentModel>().HasData(
                new EquipmentModel { EquipmentId = 1, Name = "Headband", Category = EquipmentCategory.Head, GoldValue = 10, Strength = 1, Intelligence = 0, Agility = 0 },
                new EquipmentModel { EquipmentId = 2, Name = "Steel Helmet", Category = EquipmentCategory.Head, GoldValue = 50, Strength = 3, Intelligence = 0, Agility = 1 },
                new EquipmentModel { EquipmentId = 3, Name = "Golden Crown", Category = EquipmentCategory.Head, GoldValue = 100, Strength = 5, Intelligence = 2, Agility = 0 },
                new EquipmentModel { EquipmentId = 4, Name = "Jacket", Category = EquipmentCategory.Chest, GoldValue = 20, Strength = 2, Intelligence = 1, Agility = 0 },
                new EquipmentModel { EquipmentId = 5, Name = "Weighted Clothes", Category = EquipmentCategory.Chest, GoldValue = 15, Strength = 3, Intelligence = 0, Agility = 2 },
                new EquipmentModel { EquipmentId = 6, Name = "Dragon Armor", Category = EquipmentCategory.Chest, GoldValue = 80, Strength = 8, Intelligence = 0, Agility = 1 },
                new EquipmentModel { EquipmentId = 7, Name = "Shuriken", Category = EquipmentCategory.Hands, GoldValue = 5, Strength = 0, Intelligence = 0, Agility = 1 },
                new EquipmentModel { EquipmentId = 8, Name = "Kunai", Category = EquipmentCategory.Hands, GoldValue = 8, Strength = 0, Intelligence = 1, Agility = 0 },
                new EquipmentModel { EquipmentId = 9, Name = "Blade of Destiny", Category = EquipmentCategory.Hands, GoldValue = 100, Strength = 10, Intelligence = 0, Agility = 0 },
                new EquipmentModel { EquipmentId = 10, Name = "Ninja Sandals", Category = EquipmentCategory.Feet, GoldValue = 12, Strength = 0, Intelligence = 0, Agility = 3 },
                new EquipmentModel { EquipmentId = 11, Name = "Steel Boots", Category = EquipmentCategory.Feet, GoldValue = 30, Strength = 2, Intelligence = 0, Agility = 1 },
                new EquipmentModel { EquipmentId = 12, Name = "Boots of Swiftness", Category = EquipmentCategory.Feet, GoldValue = 60, Strength = 1, Intelligence = 0, Agility = 5 },
                new EquipmentModel { EquipmentId = 13, Name = "Necklace of Wisdom", Category = EquipmentCategory.Necklace, GoldValue = 25, Strength = 0, Intelligence = 3, Agility = 0 },
                new EquipmentModel { EquipmentId = 14, Name = "Amulet of Power", Category = EquipmentCategory.Necklace, GoldValue = 40, Strength = 2, Intelligence = 1, Agility = 1 },
                new EquipmentModel { EquipmentId = 15, Name = "Silver Chain", Category = EquipmentCategory.Necklace, GoldValue = 70, Strength = 0, Intelligence = 5, Agility = 2 },
                new EquipmentModel { EquipmentId = 16, Name = "Ring of Strength", Category = EquipmentCategory.Ring, GoldValue = 30, Strength = 4, Intelligence = 0, Agility = 0 },
                new EquipmentModel { EquipmentId = 17, Name = "Ring of Intelligence", Category = EquipmentCategory.Ring, GoldValue = 35, Strength = 0, Intelligence = 4, Agility = 0 },
                new EquipmentModel { EquipmentId = 18, Name = "Ring of Speed", Category = EquipmentCategory.Ring, GoldValue = 50, Strength = 0, Intelligence = 1, Agility = 4 }
            );


            //modelBuilder.Entity<InventoryModel>().HasData(
            //    new InventoryModel { InventoryId = 1, NinjaId = 1, EquipmentId = 1 },
            //    new InventoryModel { InventoryId = 2, NinjaId = 1, EquipmentId = 2 },
            //    new InventoryModel { InventoryId = 3, NinjaId = 1, EquipmentId = 3 },
            //    new InventoryModel { InventoryId = 4, NinjaId = 1, EquipmentId = 4 },
            //    new InventoryModel { InventoryId = 5, NinjaId = 2, EquipmentId = 1 },
            //    new InventoryModel { InventoryId = 6, NinjaId = 2, EquipmentId = 5 },
            //    new InventoryModel { InventoryId = 7, NinjaId = 2, EquipmentId = 6 },
            //    new InventoryModel { InventoryId = 8, NinjaId = 3, EquipmentId = 2 },
            //    new InventoryModel { InventoryId = 9, NinjaId = 3, EquipmentId = 7 },
            //    new InventoryModel { InventoryId = 10, NinjaId = 4, EquipmentId = 2 },
            //    new InventoryModel { InventoryId = 11, NinjaId = 4, EquipmentId = 8 },
            //    new InventoryModel { InventoryId = 12, NinjaId = 5, EquipmentId = 1 },
            //    new InventoryModel { InventoryId = 13, NinjaId = 5, EquipmentId = 3 },
            //    new InventoryModel { InventoryId = 14, NinjaId = 5, EquipmentId = 9 },
            //    new InventoryModel { InventoryId = 15, NinjaId = 6, EquipmentId = 1 },
            //    new InventoryModel { InventoryId = 16, NinjaId = 6, EquipmentId = 6 },
            //    new InventoryModel { InventoryId = 17, NinjaId = 6, EquipmentId = 5 },
            //    new InventoryModel { InventoryId = 18, NinjaId = 7, EquipmentId = 4 },
            //    new InventoryModel { InventoryId = 19, NinjaId = 7, EquipmentId = 2 },
            //    new InventoryModel { InventoryId = 20, NinjaId = 8, EquipmentId = 10 },
            //    new InventoryModel { InventoryId = 21, NinjaId = 9, EquipmentId = 1 },
            //    new InventoryModel { InventoryId = 22, NinjaId = 9, EquipmentId = 7 },
            //    new InventoryModel { InventoryId = 23, NinjaId = 10, EquipmentId = 1 },
            //    new InventoryModel { InventoryId = 24, NinjaId = 10, EquipmentId = 2 },
            //    new InventoryModel { InventoryId = 25, NinjaId = 10, EquipmentId = 3 }
            //);
        }
    }
}
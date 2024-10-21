using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Models
{
    public class NinjaModel
    {
        [Key]
        public int NinjaId { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }

        public virtual ICollection<InventoryModel> Inventory { get; set; }

        public int TotalStrength => CalculateTotalStat("Strength");
        public int TotalIntelligence => CalculateTotalStat("Intelligence");
        public int TotalAgility => CalculateTotalStat("Agility");
        public int TotalGearValue => CalculateTotalStat("GoldValue");

        private int CalculateTotalStat(string stat)
        {
            var total = 0;
            foreach (var item in Inventory)
            {
                var equipment = item.Equipment;
                if (equipment == null) continue;

                switch (stat)
                {
                    case "Strength":
                        total += equipment.Strength;
                        break;
                    case "Intelligence":
                        total += equipment.Intelligence;
                        break;
                    case "Agility":
                        total += equipment.Agility;
                        break;
                    case "GoldValue":
                        total += equipment.GoldValue;
                        break;
                }
            }
            return total;

        }

        public NinjaModel()
        {
            Inventory = new List<InventoryModel>();
        }
    }
}
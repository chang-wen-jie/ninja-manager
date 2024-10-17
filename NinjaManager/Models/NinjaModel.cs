using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Models
{
    public class NinjaModel
    {
        [Key]
        public int NinjaId { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }

        public virtual ICollection<EquipmentModel> Inventory { get; set; }

        public int TotalStrength => CalculateTotalStat("Strength");
        public int TotalIntelligence => CalculateTotalStat("Intelligence");
        public int TotalAgility => CalculateTotalStat("Agility");
        public int TotalGearValue => CalculateTotalStat("GoldValue");

        private int CalculateTotalStat(string stat)
        {
            var total = 0;
            foreach (var item in Inventory)
            {
                switch (stat)
                {
                    case "Strength":
                        total += item.Strength;
                        break;
                    case "Intelligence":
                        total += item.Intelligence;
                        break;
                    case "Agility":
                        total += item.Agility;
                        break;
                    case "GoldValue":
                        total += item.GoldValue;
                        break;
                }
            }
            return total;

        }

        public NinjaModel()
        {
            Inventory = [];
        }
    }
}
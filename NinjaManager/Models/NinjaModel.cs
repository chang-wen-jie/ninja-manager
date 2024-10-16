using System.ComponentModel.DataAnnotations;

namespace ninja_manager.Models
{
    public class NinjaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Gold must be a positive number.")]
        public int Gold { get; set; }

        public virtual ICollection<EquipmentModel> Inventory { get; set; }

        public int TotalStrength => CalculateTotalStat("Strength");
        public int TotalIntelligence => CalculateTotalStat("Intelligence");
        public int TotalAgility => CalculateTotalStat("Agility");
        public int TotalGearValue => CalculateTotalStat("Gold");

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
                    case "Gold":
                        total += item.Gold;
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

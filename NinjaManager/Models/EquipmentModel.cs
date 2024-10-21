using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Models
{
    public enum EquipmentCategory
    {
        Head,
        Necklace,
        Chest,
        Hands,
        Ring,
        Feet,
    }

    public class EquipmentModel
    {
        [Key]
        public int EquipmentId { get; set; }

        public string Name { get; set; }
        public int GoldValue { get; set; }
        public EquipmentCategory Category { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }

        public EquipmentModel()
        {
           
        }
    }
}
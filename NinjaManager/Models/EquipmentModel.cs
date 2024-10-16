using System.ComponentModel.DataAnnotations;

namespace ninja_manager.Models
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
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Goudwaarde moet hoger dan nul zijn.")]
        public int Gold { get; set; }

        [Required]
        public EquipmentCategory Category { get; set; }

        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }

        public virtual ICollection<NinjaModel> Ninjas { get; set; }

        public EquipmentModel()
        {
            Ninjas = [];
        }
    }
}

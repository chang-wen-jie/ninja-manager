using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Models
{
    public class InventoryModel
    {
        [Key]
        public int InventoryId { get; set; }

        public int NinjaId { get; set; }
        public int EquipmentId { get; set; }

        public virtual NinjaModel Ninja { get; set; }
        public virtual EquipmentModel Equipment { get; set; }
    }
}

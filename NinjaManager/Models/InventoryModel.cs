using Microsoft.EntityFrameworkCore;
using ninja_manager.Models;

namespace NinjaManager.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int NinjaId { get; set; }
        public int EquipmentId { get; set; }

        // Navigation properties
        public virtual Ninja Ninja { get; set; }
        public virtual Equipment Equipment { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}
    }
}

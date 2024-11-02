using NinjaManager.Business.Models;

namespace NinjaManager.Web.ViewModels
{
    public class EquipmentViewModel
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public int GoldValue { get; set; }
        public EquipmentCategory Category { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
    }
}
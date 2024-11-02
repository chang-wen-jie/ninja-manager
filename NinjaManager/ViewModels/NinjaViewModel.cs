namespace NinjaManager.Web.ViewModels
{
    public class NinjaViewModel
    {
        public int NinjaId { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }
        public virtual ICollection<InventoryViewModel>? Inventory { get; set; } = new List<InventoryViewModel>();
        public int TotalStrength { get; set; }
        public int TotalIntelligence { get; set; }
        public int TotalAgility { get; set; }
        public int TotalGearValue { get; set; }
    }
}
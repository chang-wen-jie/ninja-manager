using Microsoft.EntityFrameworkCore;
using ninja_manager.Models;
using NinjaManager.Models;

namespace NinjaManager.Data
{
    public class NinjaManagerDbContext : DbContext
    {
        public NinjaManagerDbContext(DbContextOptions<NinjaManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
    }
}

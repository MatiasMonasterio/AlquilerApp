using Microsoft.EntityFrameworkCore;

namespace AlquilerApp.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base (options)
        {}
        public DbSet<Lessee> Lessee { get; set; }
        public DbSet<Renter> Renter { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Fee> Fee { get; set; }
        public DbSet<AditionalAmount> AditionalAmount { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // EF Core no es compatible con la asignacion de claves compuesta mediante DataAnnotations
            // SE usa Fluent API la funcion HasKey de EF Core para oslucionarlo
            builder.Entity<Fee>().HasKey( t => new { t.Id, t.ContractId });
            builder.Entity<Fee>().Property( t => t.Id ).ValueGeneratedOnAdd();
        }
    }
}
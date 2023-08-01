using Microsoft.EntityFrameworkCore;

namespace CarApp1.Pages.Models
{
    public class CarsDbContext : DbContext
    {
        public DbSet<Car>Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("CarsDb");
        }
    }
}

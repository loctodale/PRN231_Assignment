using KoiTravelShop.Model;
using Microsoft.EntityFrameworkCore;

namespace KoiTravelShop.TravelService.Data
{
    public class TravelDbContext : DbContext
    {

        public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TravelModel>().HasData(new TravelModel { Id = Guid.NewGuid(), Location = "123 ABC",Name = "Khoi", Price = 150000});
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TravelModel>Travels { get; set; }

    }
}

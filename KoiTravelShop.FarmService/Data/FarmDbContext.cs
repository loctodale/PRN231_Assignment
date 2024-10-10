using KoiTravelShop.Model;
using Microsoft.EntityFrameworkCore;

namespace KoiTravelShop.FarmService.Data
{
    public class FarmDbContext : DbContext
    {

        public FarmDbContext(DbContextOptions<FarmDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FarmModel>().HasData(new FarmModel { Id = Guid.NewGuid(), Name = "Quan's Farm", Owner = "Quan", Address = "Q7HCM",Phone = "0908977171", Email = "quancm@gmail.com" });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<FarmModel> Farms { get; set; }

    }
}

using KoiTravelShop.Model;
using Microsoft.EntityFrameworkCore;

namespace KoiTravelShop.KoiFishService.Data
{
    public class KoiFishDbContext : DbContext
    {
        public KoiFishDbContext(DbContextOptions<KoiFishDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<koiFishModel>().HasData(new koiFishModel { Id = Guid.NewGuid(), SizeId = Guid.NewGuid(), Price = 1000000, Description = "Koi Japan" });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<koiFishModel> Fishs { get; set; }

    }
}

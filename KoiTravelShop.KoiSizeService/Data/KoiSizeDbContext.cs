using KoiTravelShop.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace KoiTravelShop.KoiSizeService.Data
{
    public class KoiSizeDbContext : DbContext 
    {
        public KoiSizeDbContext(DbContextOptions<KoiSizeDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SizeModel>().HasData(new SizeModel { Id = Guid.NewGuid(), SizeInCm = 100});
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<SizeModel> Sizes { get; set; }
    }
}

using KoiTravelShop.Model;
using Microsoft.EntityFrameworkCore;

namespace KoiTravelShop.KoiOrderService.Data
{
    public class KoiOrderDbContext : DbContext
    {
        public KoiOrderDbContext(DbContextOptions<KoiOrderDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KoiOrderModel>().HasData(new KoiOrderModel { Id = Guid.NewGuid(), InvoiceId = Guid.NewGuid(), Quantity = 1, TotalPrice = 12000 });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<KoiOrderModel>KoiOrders {  get; set; }
    }
}

using KoiTravelShop.Model;
using Microsoft.EntityFrameworkCore;

namespace KoiTravelShop.InvoiceService.Data
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceModel>().HasData(new InvoiceModel { Id = Guid.NewGuid(), PaymentAmount = 2000, PaymentDate = DateTime.Now });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<InvoiceModel> Invoice { get; set; }
    }
}

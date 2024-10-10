using KoiTravelShop.Model;
using Microsoft.EntityFrameworkCore;

namespace KoiTravelShop.ServiceService.Data
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceModel>().ToTable("Service");
            var services = new List<ServiceModel>();
            for (int i = 1; i <= 10; i++)
            {
                services.Add(new ServiceModel
                {
                    Id = Guid.NewGuid(),
                    ServiceName = $"Service {i}",
                    Description = $"Description for service {i}",
                    Price = 12000 + (i * 1000) 
                });
            }

            modelBuilder.Entity<ServiceModel>().HasData(services.ToArray());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ServiceModel> Services { get; set; }
    }
}

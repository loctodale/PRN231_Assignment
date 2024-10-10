using KoiTravelShop.Model;
using Microsoft.EntityFrameworkCore;

namespace KoiTravelShop.BookingRequest.Data
{
    public class BookingRequestDbContext : DbContext
    {
        public BookingRequestDbContext(DbContextOptions<BookingRequestDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingRequestModel>().ToTable("BookingRequest");
            var random = new Random();
            var statuses = Enum.GetValues(typeof(BookingRequestStatus));

            var BookingRequests = new List<BookingRequestModel>();
            for (int i = 1; i <= 10; i++)
            {
                BookingRequests.Add(new BookingRequestModel
                {
                    Id = Guid.NewGuid(),
                    CustomerId = null,
                    TravelId = null,
                    QuantityService = 1,
                    NumberOfPerson = random.Next(1,5),
                    Status = (BookingRequestStatus)statuses.GetValue(random.Next(statuses.Length))
                });
            }

            modelBuilder.Entity<BookingRequestModel>().HasData(BookingRequests.ToArray());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<BookingRequestModel> BookingRequests { get; set; }
    }
}

using KoiTravelShop.BookingRequest.Data;
using KoiTravelShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KoiTravelShop.AppHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingRequestController(BookingRequestDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<List<BookingRequestModel>> GetAll()
        {
            return await dbContext.BookingRequests.ToListAsync();
        }

        [HttpPost]
        public async Task<BookingRequestModel> Create(BookingRequestModel model)
        {
            dbContext.BookingRequests.Add(model);
            await dbContext.SaveChangesAsync();
            
            return model;
        }
    }
}

using KoiTravelShop.Model;
using KoiTravelShop.ServiceService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KoiTravelShop.ServiceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController(ServiceDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<List<ServiceModel>> GetAll()
        {
            return await dbContext.Services.ToListAsync();
        }
    }
}

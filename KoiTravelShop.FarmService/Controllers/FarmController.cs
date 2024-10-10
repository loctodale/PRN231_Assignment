using KoiTravelShop.FarmService.Data;
using KoiTravelShop.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KoiTravelShop.FarmService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController(FarmDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<List<FarmModel>> GetAll()
        {
            return await dbContext.Farms.ToListAsync();
        }
    }
}

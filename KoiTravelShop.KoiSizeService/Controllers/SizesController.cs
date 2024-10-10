using KoiTravelShop.KoiSizeService.Data;
using KoiTravelShop.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KoiTravelShop.KoiSizeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController(KoiSizeDbContext koiSizeDb)  : ControllerBase
    {
        [HttpGet]
        public async Task<List<SizeModel>> GetAll()
        {
            return await koiSizeDb.Sizes.ToListAsync();

        }
    }
}

using Confluent.Kafka;
using KoiTravelShop.KoiFishService.Data;
using KoiTravelShop.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static Confluent.Kafka.ConfigPropertyNames;

namespace KoiTravelShop.KoiFishService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishsController (KoiFishDbContext dbContext): ControllerBase
    {
        [HttpGet]
        public async Task<List<koiFishModel>> GetAll()
        {
            return await dbContext.Fishs.ToListAsync();
        }
        [HttpPost]
        public async Task<koiFishModel> CreateFish(koiFishModel model)

            
        {
            model.Id = Guid.NewGuid();
            model.SizeId = Guid.NewGuid();
            dbContext.Fishs.Add(model);
            await dbContext.SaveChangesAsync();
            return model;
        }
    }
}

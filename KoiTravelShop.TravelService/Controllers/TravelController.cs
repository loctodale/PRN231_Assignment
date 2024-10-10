using Confluent.Kafka;
using KoiTravelShop.Model;
using KoiTravelShop.TravelService.Data;
using KoiTravelShop.TravelService.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace KoiTravelShop.TravelService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController(TravelDbContext dbContext, ITravelKafkaProducer producer) : ControllerBase
    {
        [HttpGet]
        public async Task<List<TravelModel>> GetAll()
        {
            return await dbContext.Travels.ToListAsync();
        }
        [HttpPost]
        public async Task<TravelModel> CreateTravel(TravelModel model)
        {
            dbContext.Travels.Add(model);
            await dbContext.SaveChangesAsync();
            await producer.ProduceAsync("travel-topic", new Message<string, string>
            {
                Key = model.Id.ToString(),
                Value = JsonConvert.SerializeObject(model)
            });
            return model;
        }

    }
}

using Confluent.Kafka;
using KoiTravelShop.KoiOrderService.Data;
using KoiTravelShop.KoiOrderService.Infrastructure;
using KoiTravelShop.KoiOrderService.Kafka;
using KoiTravelShop.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace KoiTravelShop.KoiOrderService.Controllers
{
    [Route("api/odata/[controller]")]
    [ApiController]
    public class KoiOrderController(KoiOrderDbContext dbContext, IKafkaProducer producer, TokenProvider tokenProvider) : ODataController
    {
        [EnableQuery]
        [HttpGet]
        [Authorize]
        public async Task<List<KoiOrderModel>> GetAll()
        {
            return await dbContext.KoiOrders.ToListAsync();
        }

        [HttpPost]
        public async Task<KoiOrderModel> CreateOrder(KoiOrderModel model)
        {
            dbContext.KoiOrders.Add(model);
            await dbContext.SaveChangesAsync();

            await producer.ProduceAsync("order-topic", new Message<string, string>
            {
                Key = model.Id.ToString(),
                Value = JsonConvert.SerializeObject(model)

            });
            return model;
        }
        [HttpPost ("login")]
        public async Task<string> Login (User user)
        {
            if(user.Email != "admin" || user.Password != "admin")
            {
                throw new Exception("Login fail");
            }
            var token = tokenProvider.Create(user);
            return token;
        }
    }
}

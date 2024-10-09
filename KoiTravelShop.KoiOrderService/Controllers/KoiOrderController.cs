﻿using Confluent.Kafka;
using KoiTravelShop.KoiOrderService.Data;
using KoiTravelShop.KoiOrderService.Kafka;
using KoiTravelShop.Model;
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
    public class KoiOrderController(KoiOrderDbContext dbContext, IKafkaProducer producer) : ODataController
    {
        [EnableQuery]
        [HttpGet]
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
    }
}

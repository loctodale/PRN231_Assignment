
using Confluent.Kafka;
using KoiTravelShop.FarmService.Data;
using KoiTravelShop.Model;
using Newtonsoft.Json;

namespace KoiTravelShop.FarmService.Kafka
{
    public class TravelKafkaConsumer(IServiceScopeFactory scopeFactory) : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                _ = ConsumeAsync("travel-topic", stoppingToken);
            }, stoppingToken);
        }
        public async Task ConsumeAsync(string topic, CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                GroupId = "travel-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };
            using var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe(topic);
            while (!stoppingToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(stoppingToken);

                var farm = JsonConvert.DeserializeObject<FarmModel>(consumeResult.Message.Value);
                using var scope = scopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<FarmDbContext>();

                var farmEntity = new FarmModel
                {
                    Id = (Guid)farm.Id,
                    Name = farm.Name,
                    Address = farm.Address,
                    Owner = farm.Owner,
                    Phone = farm.Phone,
                    Email = farm.Email,
                };
                dbContext.Farms.Add(farmEntity);
                await dbContext.SaveChangesAsync();
            }
            consumer.Close();
        }
    }
}

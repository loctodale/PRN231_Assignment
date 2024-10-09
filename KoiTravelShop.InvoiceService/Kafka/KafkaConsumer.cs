
using Confluent.Kafka;
using KoiTravelShop.InvoiceService.Data;
using KoiTravelShop.Model;
using Newtonsoft.Json;

namespace KoiTravelShop.InvoiceService.Kafka
{
    public class KafkaConsumer(IServiceScopeFactory scopeFactory) : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                _ = ConsumeAsync("order-topic", stoppingToken);
            }, stoppingToken);
        }

        public async Task ConsumeAsync(string topic, CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                GroupId = "order-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };

            using var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe(topic);

            while (!stoppingToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(stoppingToken);

                var order = JsonConvert.DeserializeObject<KoiOrderModel>(consumeResult.Message.Value);
                using var scope = scopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<InvoiceDbContext>();

                var invoiceEntity = new InvoiceModel
                {
                    Id = (Guid)order.InvoiceId,
                    PaymentAmount = order.TotalPrice,
                    PaymentDate = DateTime.Now,
                };
                dbContext.Invoice.Add(invoiceEntity);
                await dbContext.SaveChangesAsync();
            }
            consumer.Close();
        }
    }
}

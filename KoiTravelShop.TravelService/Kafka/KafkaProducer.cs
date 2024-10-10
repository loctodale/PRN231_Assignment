using Confluent.Kafka;
using Microsoft.IdentityModel.Tokens;

namespace KoiTravelShop.TravelService.Kafka
{
    public interface ITravelKafkaProducer
    {
        Task ProduceAsync(string topic, Message<string, string> message);
    }
    public class TravelKafkaProducer : ITravelKafkaProducer
    {
        private readonly IProducer<string, string> _producer;
        public TravelKafkaProducer()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",

            };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }
        public async Task ProduceAsync(string topic, Message<string, string> message)
        {
            await _producer.ProduceAsync(topic, message);
        }
    }
}

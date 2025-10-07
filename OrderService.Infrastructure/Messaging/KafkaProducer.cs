
using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace OrderService.Infrastructure.Messaging
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly IProducer<string, string> _producer;

        public KafkaProducer(IConfiguration configuration)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:29092"
            };

            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task PublishAsync<T>(string topic, string key, T message)
        {
            var json = JsonSerializer.Serialize(message);
            await _producer.ProduceAsync(topic, new Message<string, string> { Key = key, Value = json });
        }
    }
}
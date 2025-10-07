using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Infrastructure.Messaging;

namespace OrderService.Infrastructure.Extensions.Messaging
{
    public static class KafkaExtension
    {
        public static IServiceCollection AddKafka(this IServiceCollection services)
        {
            services.AddSingleton<IKafkaProducer, KafkaProducer>();
            return services;
        }
    }
}
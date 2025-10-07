namespace OrderService.Infrastructure.Messaging
{
    public interface IKafkaProducer
    {
        Task PublishAsync<T>(string topic, string key, T message);
    }
}
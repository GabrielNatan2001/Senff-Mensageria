using RabbitMqLibrary.Enum;

namespace RabbitMqLibrary.Extensions
{
    public static class ExchangeTypeExtensions
    {
        public static string ToRabbitMQType(this EExchangeType type)
        {
            return type switch
            {
                EExchangeType.DIRECT => RabbitMQ.Client.ExchangeType.Direct,
                EExchangeType.TOPIC => RabbitMQ.Client.ExchangeType.Topic,
                EExchangeType.FANOUT => RabbitMQ.Client.ExchangeType.Fanout,
                EExchangeType.HEADERS => RabbitMQ.Client.ExchangeType.Headers,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}

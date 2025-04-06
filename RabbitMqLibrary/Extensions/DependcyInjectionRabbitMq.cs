using Microsoft.Extensions.DependencyInjection;
using RabbitMqLibrary.Consumer;
using RabbitMqLibrary.Publisher;

namespace RabbitMqLibrary.Extensions
{
    public static class DependcyInjectionRabbitMq
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, string hostname, string user, string password, int port = 5672)
        {
            services.AddSingleton<IRabbitMqPublisher>(x => new RabbitMqPublisher(hostname, user, password, port));
            services.AddSingleton<IRabbitMqConsumer>(x => new RabbitMqConsumer(hostname, user, password, port));

            return services;
        }
    }
}

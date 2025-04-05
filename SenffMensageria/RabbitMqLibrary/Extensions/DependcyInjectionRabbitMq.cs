using Microsoft.Extensions.DependencyInjection;
using RabbitMqLibrary.Consumer;
using RabbitMqLibrary.Publisher;

namespace RabbitMqLibrary.Extensions
{
    public static class DependcyInjectionRabbitMq
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services)
        {
            services.AddScoped<IRabbitMqPublisher, RabbitMqPublisher>();
            services.AddScoped<IRabbitMqConsumer, RabbitMqConsumer>();

            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMqLibrary.Extensions;
using SenffMensageria.Application.UseCase.Aluno;
using SenffMensageria.Application.UseCase.Matricula;

namespace SenffMensageria.Application
{
    public static class DependecyInjectionApplication
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddServices(services);
            if(configuration != null)
            {
                AddRabbitMqLib(services, configuration);
            }
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IMatriculaService, MatriculaService>();
        }

        private static void AddRabbitMqLib(IServiceCollection services, IConfiguration configuration)
        {
            var hostname = configuration["RabbitMqConfig:Hostname"];
            var user = configuration["RabbitMqConfig:User"];
            var password = configuration["RabbitMqConfig:Password"];
            var port = int.Parse(configuration["RabbitMqConfig:Port"] ?? "5672");

            services.AddRabbitMQ(hostname, user, password, port);
        }
    }
}

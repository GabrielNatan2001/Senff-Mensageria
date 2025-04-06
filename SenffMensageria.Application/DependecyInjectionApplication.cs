using Microsoft.Extensions.DependencyInjection;
using RabbitMqLibrary.Extensions;
using SenffMensageria.Application.UseCase.Aluno;
using SenffMensageria.Application.UseCase.Matricula;

namespace SenffMensageria.Application
{
    public static class DependecyInjectionApplication
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddServices(services);
            services.AddRabbitMQ();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IMatriculaService, MatriculaService>();
        }
    }
}

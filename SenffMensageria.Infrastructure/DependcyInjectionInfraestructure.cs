using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SenffMensageria.Domain.Repositories;
using SenffMensageria.Infrastructure.DataAccess;
using SenffMensageria.Infrastructure.DataAccess.Repositories;

namespace SenffMensageria.Infrastructure
{
    public static class DependcyInjectionInfraestructure
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddDbContext(services, configuration);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                   //options.UseSqlite("Data Source=Mensageria.db")
                   options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();
        }
    }
}

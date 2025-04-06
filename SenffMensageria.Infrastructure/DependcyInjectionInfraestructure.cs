using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SenffMensageria.Domain.Repositories;
using SenffMensageria.Infrastructure.DataAccess;
using SenffMensageria.Infrastructure.DataAccess.Repositories;

namespace SenffMensageria.Infrastructure
{
    public static class DependcyInjectionInfraestructure
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddRepositories(services);
            AddDbContext(services);
        }

        private static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                   options.UseSqlite("Data Source=Mensageria.db")
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

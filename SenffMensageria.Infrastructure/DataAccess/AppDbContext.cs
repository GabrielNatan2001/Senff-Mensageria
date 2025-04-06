using Microsoft.EntityFrameworkCore;
using SenffMensageria.Domain.Entities;
using SenffMensageria.Infrastructure.DataAccess.Mapping;

namespace SenffMensageria.Infrastructure.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AlunoMap).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

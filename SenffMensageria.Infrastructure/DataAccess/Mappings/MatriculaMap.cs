using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SenffMensageria.Domain.Entities;

namespace SenffMensageria.Infrastructure.DataAccess.Mappings
{
    public class MatriculaMap : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.Property(a => a.Id)
               .HasColumnName("Id")
               .ValueGeneratedOnAdd();

            builder.Property(a => a.Turma)
                .HasColumnName("Turma")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(a => a.Status)
                .HasColumnName("Status")
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(m => m.Aluno)
                .WithOne(a => a.Matricula)
                .HasForeignKey<Matricula>(m => m.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SenffMensageria.Domain.Entities;

namespace SenffMensageria.Infrastructure.DataAccess.Mapping
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.Property(a => a.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(a => a.Email)
                .HasColumnName("Email")
                .IsRequired();

            builder.HasOne(a => a.Matricula)
                .WithOne(m => m.Aluno)
                .HasForeignKey<Matricula>(m => m.AlunoId);
        }
    }
}

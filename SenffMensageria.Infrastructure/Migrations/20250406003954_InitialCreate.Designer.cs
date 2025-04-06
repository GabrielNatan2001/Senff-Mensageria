﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SenffMensageria.Infrastructure.DataAccess;

#nullable disable

namespace SenffMensageria.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250406003954_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("SenffMensageria.Domain.Entities.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Email");

                    b.PrimitiveCollection<string>("Events")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("SenffMensageria.Domain.Entities.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.PrimitiveCollection<string>("Events")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Turma")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId")
                        .IsUnique();

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("SenffMensageria.Domain.Entities.Matricula", b =>
                {
                    b.HasOne("SenffMensageria.Domain.Entities.Aluno", "Aluno")
                        .WithOne("Matricula")
                        .HasForeignKey("SenffMensageria.Domain.Entities.Matricula", "AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("SenffMensageria.Domain.Entities.Aluno", b =>
                {
                    b.Navigation("Matricula")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

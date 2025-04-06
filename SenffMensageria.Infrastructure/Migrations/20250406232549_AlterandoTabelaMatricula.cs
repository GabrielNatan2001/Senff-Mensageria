using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SenffMensageria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoTabelaMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Matriculas",
                newName: "Turma");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Turma",
                table: "Matriculas",
                newName: "Nome");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SenffMensageria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Events",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "Events",
                table: "Alunos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Events",
                table: "Matriculas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Events",
                table: "Alunos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

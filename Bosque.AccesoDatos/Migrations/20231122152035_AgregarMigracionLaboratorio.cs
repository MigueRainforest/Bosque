using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bosque.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarMigracionLaboratorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Personal",
                table: "Laboratorios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Personal",
                table: "Laboratorios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}

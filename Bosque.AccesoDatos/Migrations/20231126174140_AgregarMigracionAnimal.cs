using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bosque.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarMigracionAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreComun = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreCientifico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstatusAmenaza = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dieta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animales", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animales");
        }
    }
}

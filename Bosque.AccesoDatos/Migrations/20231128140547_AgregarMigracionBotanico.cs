using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bosque.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarMigracionBotanico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Botanicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PersonalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Botanicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Botanicos_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Botanicos_PersonalId",
                table: "Botanicos",
                column: "PersonalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Botanicos");
        }
    }
}

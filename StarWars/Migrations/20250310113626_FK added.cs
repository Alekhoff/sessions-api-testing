using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class FKadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planets_Persons_PersonModelId",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Planets_PersonModelId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "PersonModelId",
                table: "Planets");

            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PlanetId",
                table: "Persons",
                column: "PlanetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Planets_PlanetId",
                table: "Persons",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Planets_PlanetId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PlanetId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "PersonModelId",
                table: "Planets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planets_PersonModelId",
                table: "Planets",
                column: "PersonModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_Persons_PersonModelId",
                table: "Planets",
                column: "PersonModelId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}

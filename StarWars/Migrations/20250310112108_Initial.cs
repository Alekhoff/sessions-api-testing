using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Mass = table.Column<int>(type: "int", nullable: false),
                    HairColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SkinColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EyeColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false),
                    Climate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Terrain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Diameter = table.Column<int>(type: "int", nullable: false),
                    PersonModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planets_Persons_PersonModelId",
                        column: x => x.PersonModelId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planets_PersonModelId",
                table: "Planets",
                column: "PersonModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}

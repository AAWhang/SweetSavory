using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetSavory.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flavors",
                columns: table => new
                {
                    FlavorsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flavors", x => x.FlavorsId);
                });

            migrationBuilder.CreateTable(
                name: "Treats",
                columns: table => new
                {
                    TreatId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treats", x => x.TreatId);
                });

            migrationBuilder.CreateTable(
                name: "FlavorsTreat",
                columns: table => new
                {
                    FlavorsTreatId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TreatId = table.Column<int>(nullable: false),
                    FlavorsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlavorsTreat", x => x.FlavorsTreatId);
                    table.ForeignKey(
                        name: "FK_FlavorsTreat_Flavors_FlavorsId",
                        column: x => x.FlavorsId,
                        principalTable: "Flavors",
                        principalColumn: "FlavorsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlavorsTreat_Treats_TreatId",
                        column: x => x.TreatId,
                        principalTable: "Treats",
                        principalColumn: "TreatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlavorsTreat_FlavorsId",
                table: "FlavorsTreat",
                column: "FlavorsId");

            migrationBuilder.CreateIndex(
                name: "IX_FlavorsTreat_TreatId",
                table: "FlavorsTreat",
                column: "TreatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlavorsTreat");

            migrationBuilder.DropTable(
                name: "Flavors");

            migrationBuilder.DropTable(
                name: "Treats");
        }
    }
}

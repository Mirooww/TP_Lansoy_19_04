using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lansoy.RG.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Props : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Espions",
                columns: table => new
                {
                    EspionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomDeCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ville = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espions", x => x.EspionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    MissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Lieu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Annee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.MissionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EspionEspion",
                columns: table => new
                {
                    EspionsEspionId = table.Column<int>(type: "int", nullable: false),
                    VillesEspionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspionEspion", x => new { x.EspionsEspionId, x.VillesEspionId });
                    table.ForeignKey(
                        name: "FK_EspionEspion_Espions_EspionsEspionId",
                        column: x => x.EspionsEspionId,
                        principalTable: "Espions",
                        principalColumn: "EspionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspionEspion_Espions_VillesEspionId",
                        column: x => x.VillesEspionId,
                        principalTable: "Espions",
                        principalColumn: "EspionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EspionMission",
                columns: table => new
                {
                    EspionsEspionId = table.Column<int>(type: "int", nullable: false),
                    MissionsMissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspionMission", x => new { x.EspionsEspionId, x.MissionsMissionId });
                    table.ForeignKey(
                        name: "FK_EspionMission_Espions_EspionsEspionId",
                        column: x => x.EspionsEspionId,
                        principalTable: "Espions",
                        principalColumn: "EspionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspionMission_Missions_MissionsMissionId",
                        column: x => x.MissionsMissionId,
                        principalTable: "Missions",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EspionEspion_VillesEspionId",
                table: "EspionEspion",
                column: "VillesEspionId");

            migrationBuilder.CreateIndex(
                name: "IX_EspionMission_MissionsMissionId",
                table: "EspionMission",
                column: "MissionsMissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EspionEspion");

            migrationBuilder.DropTable(
                name: "EspionMission");

            migrationBuilder.DropTable(
                name: "Espions");

            migrationBuilder.DropTable(
                name: "Missions");
        }
    }
}

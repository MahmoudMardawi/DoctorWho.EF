using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class FunctionsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThreeMostFrequenlyAppearingEnemies",
                columns: table => new
                {
                    _ThreeMostFrequentlyAppearingEnemies = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ThreeMostFrequentlyAppearingCompanions",
                columns: table => new
                {
                    _ThreeMostFrequentlyAppearingCompanions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "EpisodeCompanions",
                columns: new[] { "EpisodeCompanionId", "CompanionId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 3, 2 },
                    { 2, 2, 1 },
                    { 3, 2, 3 },
                    { 4, 4, 1 },
                    { 5, 5, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThreeMostFrequenlyAppearingEnemies");

            migrationBuilder.DropTable(
                name: "ThreeMostFrequentlyAppearingCompanions");

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 5);
        }
    }
}

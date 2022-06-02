using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Companions",
                columns: table => new
                {
                    CompanionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanionName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    WhoPlayed = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companions", x => x.CompanionId);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    DoctorNumber = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "NULL"),
                    FirstEpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "NULL"),
                    LastEpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    EnemyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnemyName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.EnemyId);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesNumber = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    EpisodeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "NULL"),
                    EpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "NULL"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.EpisodeId);
                    table.ForeignKey(
                        name: "FK_Episodes_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Episodes_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeCompanions",
                columns: table => new
                {
                    EpisodeCompanionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    CompanionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeCompanions", x => x.EpisodeCompanionId);
                    table.ForeignKey(
                        name: "FK_EpisodeCompanions_Companions_CompanionId",
                        column: x => x.CompanionId,
                        principalTable: "Companions",
                        principalColumn: "CompanionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeCompanions_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeEnemies",
                columns: table => new
                {
                    EpisodeEnemyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    EnemyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeEnemies", x => x.EpisodeEnemyId);
                    table.ForeignKey(
                        name: "FK_EpisodeEnemies_Enemies_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemies",
                        principalColumn: "EnemyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeEnemies_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Allen Cooper" },
                    { 2, "Edward Norton" },
                    { 3, "Martin Jobs" },
                    { 4, "Green" },
                    { 5, "Fredrick" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "Medhat", "Foster" },
                    { 2, "Ameen", "Skirtel" },
                    { 3, "Mahdi", "Lauren" },
                    { 4, "Elina", "Austin" },
                    { 5, "Karim", "Edward" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1954, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jack Rocheld", 123, new DateTime(1994, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1960, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alesandro", 234, new DateTime(1990, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1967, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel", 345, new DateTime(2000, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1970, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven", 456, new DateTime(2002, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2003, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1965, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frank", 567, new DateTime(1993, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "EnemyName" },
                values: new object[] { 1, "Alonso" });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 2, "Enemy 2", "Kane" },
                    { 3, "Dom enemy", "Larvel" }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "EnemyName" },
                values: new object[,]
                {
                    { 4, "Leon" },
                    { 5, "David" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(1995, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Semi-Pro", 123, "Red Rose" },
                    { 2, 2, 2, new DateTime(1991, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Professional", 234, "White Knight" },
                    { 3, 3, 3, new DateTime(2001, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "World Class", 345, "Red Sky" },
                    { 4, 4, 5, new DateTime(2002, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Legendary", 456, "Black Burl" },
                    { 5, 5, 5, new DateTime(1994, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "World-Class", 567, "In hell" }
                });

            migrationBuilder.InsertData(
                table: "EpisodeEnemies",
                columns: new[] { "EpisodeEnemyId", "EnemyId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 4, 2 },
                    { 2, 3, 1 },
                    { 3, 4, 3 },
                    { 4, 5, 2 },
                    { 5, 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeCompanions_CompanionId",
                table: "EpisodeCompanions",
                column: "CompanionId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeCompanions_EpisodeId",
                table: "EpisodeCompanions",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeEnemies_EnemyId",
                table: "EpisodeEnemies",
                column: "EnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeEnemies_EpisodeId",
                table: "EpisodeEnemies",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_AuthorId",
                table: "Episodes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_DoctorId",
                table: "Episodes",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodeCompanions");

            migrationBuilder.DropTable(
                name: "EpisodeEnemies");

            migrationBuilder.DropTable(
                name: "Companions");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}

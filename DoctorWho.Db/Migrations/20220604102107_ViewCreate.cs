using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class ViewCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW viewEpisodes AS
                                   SELECT A.AuthorName AS Author_Name, 
	                                      D.DoctorName AS Doctor_Name,
	                                      dbo.fnCompanions(E.EpisodeId) AS Companions,
	                                      dbo.fnEnemies(E.EpisodeId) AS Enemies
                                   FROM Episodes E
	                                            LEFT JOIN Authors A ON E.AuthorId = A.AuthorId
	                                            LEFT JOIN Doctors D ON E.DoctorId = D.DoctorId 
                                   GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS viewEpisodes");

        }
    }
}

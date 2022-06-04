using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class FunctionsCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS fnCompanions;
GO

CREATE FUNCTION fnCompanions(@EpisodeId int)
RETURNS varchar(100)
AS
begin
	declare @c varchar(100) = ''

	SELECT
		@c = @c + 
			case when len(@c) > 0 THEN ', ' ELSE '' END + 
			c.CompanionName
			
	FROM
		EpisodeCompanions as ec
		INNER JOIN Companions as c on ec.CompanionId = c.CompanionId
	WHERE
		ec.EpisodeId = @EpisodeId

	return @c
end
GO");
            migrationBuilder.Sql(@"CREATE FUNCTION fnEnemies(@EpisodeId int)
								RETURNS varchar(100)
													AS
begin
	declare @c varchar(100) = ''

	SELECT
		@c = @c + 
			CASE WHEN len(@c) > 0 THEN ', ' ELSE '' END + 
			c.EnemyName
			
	FROM
		EpisodeEnemies AS ec
		INNER JOIN Enemies AS c ON ec.EnemyId = c.EnemyId
	WHERE
		ec.EpisodeId = @EpisodeId

	return @c
end
GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS fnCompanions;");
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS fnEnemies;");

        }
    }
}

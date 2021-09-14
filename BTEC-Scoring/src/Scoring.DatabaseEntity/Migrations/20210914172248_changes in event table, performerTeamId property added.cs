using Microsoft.EntityFrameworkCore.Migrations;

namespace Scoring.DatabaseEntity.Migrations
{
    public partial class changesineventtableperformerTeamIdpropertyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerformerTeamId",
                table: "Events",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerformerTeamId",
                table: "Events");
        }
    }
}

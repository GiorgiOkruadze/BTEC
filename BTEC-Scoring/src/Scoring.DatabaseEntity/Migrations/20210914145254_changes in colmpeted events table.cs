using Microsoft.EntityFrameworkCore.Migrations;

namespace Scoring.DatabaseEntity.Migrations
{
    public partial class changesincolmpetedeventstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "სSuccessfullyCompleted",
                table: "EventPerformers",
                newName: "SuccessfullyCompleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SuccessfullyCompleted",
                table: "EventPerformers",
                newName: "სSuccessfullyCompleted");
        }
    }
}

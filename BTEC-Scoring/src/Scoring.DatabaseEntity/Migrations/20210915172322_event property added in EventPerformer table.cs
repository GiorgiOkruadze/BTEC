using Microsoft.EntityFrameworkCore.Migrations;

namespace Scoring.DatabaseEntity.Migrations
{
    public partial class eventpropertyaddedinEventPerformertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Events_PerformerId",
                table: "Events");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PerformerId",
                table: "Events",
                column: "PerformerId",
                unique: true,
                filter: "[PerformerId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Events_PerformerId",
                table: "Events");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PerformerId",
                table: "Events",
                column: "PerformerId");
        }
    }
}

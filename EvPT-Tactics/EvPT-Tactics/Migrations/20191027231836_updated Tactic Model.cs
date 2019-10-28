using Microsoft.EntityFrameworkCore.Migrations;

namespace EvPT_Tactics.Migrations
{
    public partial class updatedTacticModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Map",
                table: "Movie",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Map",
                table: "Movie");
        }
    }
}

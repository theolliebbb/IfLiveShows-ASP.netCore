using Microsoft.EntityFrameworkCore.Migrations;

namespace IFLiveShows.Data.Migrations
{
    public partial class maps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MapsUrl",
                table: "Live",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MapsUrl",
                table: "Live");
        }
    }
}

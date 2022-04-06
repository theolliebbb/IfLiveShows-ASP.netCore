using Microsoft.EntityFrameworkCore.Migrations;

namespace IFLiveShows.Data.Migrations
{
    public partial class live : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Live",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Live");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieShop.Backend.Migrations
{
    public partial class AddMessAttrToRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "message",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "message",
                table: "Ratings");
        }
    }
}

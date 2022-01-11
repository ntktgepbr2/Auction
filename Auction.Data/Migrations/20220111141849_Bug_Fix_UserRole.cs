using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction.Data.Migrations
{
    public partial class Bug_Fix_UserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder){}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "User",
                type: "int",
                nullable: true);
        }
    }
}

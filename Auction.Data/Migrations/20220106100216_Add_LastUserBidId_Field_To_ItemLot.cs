using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction.Data.Migrations
{
    public partial class Add_LastUserBidId_Field_To_ItemLot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LastUserBidId",
                table: "Lots",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUserBidId",
                table: "Lots");
        }
    }
}

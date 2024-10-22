using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class addactualdatetoborrwing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Reviews",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualReturnDate",
                table: "BorrowingSystems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReteurned",
                table: "BorrowingSystems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualReturnDate",
                table: "BorrowingSystems");

            migrationBuilder.DropColumn(
                name: "IsReteurned",
                table: "BorrowingSystems");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reviews",
                newName: "id");
        }
    }
}

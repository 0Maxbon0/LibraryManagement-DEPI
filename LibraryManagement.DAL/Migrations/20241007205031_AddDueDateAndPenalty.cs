using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDueDateAndPenalty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CheckoutID1",
                table: "Penalties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "PenaltyAmount",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_CheckoutID1",
                table: "Penalties",
                column: "CheckoutID1",
                unique: true,
                filter: "[CheckoutID1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Penalties_Checkouts_CheckoutID1",
                table: "Penalties",
                column: "CheckoutID1",
                principalTable: "Checkouts",
                principalColumn: "CheckoutID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Penalties_Checkouts_CheckoutID1",
                table: "Penalties");

            migrationBuilder.DropIndex(
                name: "IX_Penalties_CheckoutID1",
                table: "Penalties");

            migrationBuilder.DropColumn(
                name: "CheckoutID1",
                table: "Penalties");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PenaltyAmount",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

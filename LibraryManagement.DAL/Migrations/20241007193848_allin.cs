using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class allin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkout_AspNetUsers_UsersId",
                table: "Checkout");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkout_Book_BookID",
                table: "Checkout");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalty_AspNetUsers_UsersId",
                table: "Penalty");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalty_Checkout_CheckoutID",
                table: "Penalty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Penalty",
                table: "Penalty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checkout",
                table: "Checkout");

            migrationBuilder.DropIndex(
                name: "IX_Checkout_UsersId",
                table: "Checkout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Checkout");

            migrationBuilder.RenameTable(
                name: "Penalty",
                newName: "Penalties");

            migrationBuilder.RenameTable(
                name: "Checkout",
                newName: "Checkouts");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_Penalty_UsersId",
                table: "Penalties",
                newName: "IX_Penalties_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Penalty_CheckoutID",
                table: "Penalties",
                newName: "IX_Penalties_CheckoutID");

            migrationBuilder.RenameIndex(
                name: "IX_Checkout_BookID",
                table: "Checkouts",
                newName: "IX_Checkouts_BookID");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Checkouts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Penalties",
                table: "Penalties",
                column: "PenaltyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checkouts",
                table: "Checkouts",
                column: "CheckoutID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "BookID");

            migrationBuilder.CreateTable(
                name: "Returns",
                columns: table => new
                {
                    ReturnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckoutID = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDamaged = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Returns", x => x.ReturnID);
                    table.ForeignKey(
                        name: "FK_Returns_Checkouts_CheckoutID",
                        column: x => x.CheckoutID,
                        principalTable: "Checkouts",
                        principalColumn: "CheckoutID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_UserID",
                table: "Checkouts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_CheckoutID",
                table: "Returns",
                column: "CheckoutID");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_AspNetUsers_UserID",
                table: "Checkouts",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Books_BookID",
                table: "Checkouts",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Penalties_AspNetUsers_UsersId",
                table: "Penalties",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Penalties_Checkouts_CheckoutID",
                table: "Penalties",
                column: "CheckoutID",
                principalTable: "Checkouts",
                principalColumn: "CheckoutID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_AspNetUsers_UserID",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Books_BookID",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalties_AspNetUsers_UsersId",
                table: "Penalties");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalties_Checkouts_CheckoutID",
                table: "Penalties");

            migrationBuilder.DropTable(
                name: "Returns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Penalties",
                table: "Penalties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checkouts",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_UserID",
                table: "Checkouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Penalties",
                newName: "Penalty");

            migrationBuilder.RenameTable(
                name: "Checkouts",
                newName: "Checkout");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_Penalties_UsersId",
                table: "Penalty",
                newName: "IX_Penalty_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Penalties_CheckoutID",
                table: "Penalty",
                newName: "IX_Penalty_CheckoutID");

            migrationBuilder.RenameIndex(
                name: "IX_Checkouts_BookID",
                table: "Checkout",
                newName: "IX_Checkout_BookID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Checkout",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Checkout",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Penalty",
                table: "Penalty",
                column: "PenaltyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checkout",
                table: "Checkout",
                column: "CheckoutID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Checkout_UsersId",
                table: "Checkout",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkout_AspNetUsers_UsersId",
                table: "Checkout",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkout_Book_BookID",
                table: "Checkout",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Penalty_AspNetUsers_UsersId",
                table: "Penalty",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Penalty_Checkout_CheckoutID",
                table: "Penalty",
                column: "CheckoutID",
                principalTable: "Checkout",
                principalColumn: "CheckoutID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

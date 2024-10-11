using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "CoverImageUrl",
                table: "Books",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Books",
                newName: "CoverImageUrl");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Technology" },
                    { 2, "Education" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Author", "CategoryID", "CopiesAvailable", "CoverImageUrl", "DateAdded", "Description", "DueDate", "Genre", "ISBN", "IsAvailable", "PenaltyAmount", "PublishedYear", "Publisher", "Title", "TotalCopies" },
                values: new object[,]
                {
                    { 1, "John McCarthy", 1, 5, "~/images/ai.jpg", new DateTime(2024, 10, 11, 0, 56, 47, 804, DateTimeKind.Local).AddTicks(5390), "An in-depth look into AI.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Technology", "978-1234567890", true, 0m, 2020, "Tech Books", "Artificial Intelligence", 10 },
                    { 2, "Jane Doe", 2, 2, "~/images/cs.jpg", new DateTime(2024, 10, 11, 0, 56, 47, 804, DateTimeKind.Local).AddTicks(5560), "Basic principles of computer science.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Education", "978-0987654321", true, 0m, 2018, "Edu Books", "Computer Science Fundamentals", 5 },
                    { 3, "Robert Sedgewick", 2, 3, "~/images/algo.jpg", new DateTime(2024, 10, 11, 0, 56, 47, 804, DateTimeKind.Local).AddTicks(5567), "A comprehensive guide to algorithm design.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Education", "978-1111111111", true, 0m, 2019, "Algo Press", "Algorithm Design", 8 }
                });
        }
    }
}

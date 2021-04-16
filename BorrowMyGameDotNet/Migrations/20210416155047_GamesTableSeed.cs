using Microsoft.EntityFrameworkCore.Migrations;

namespace BorrowMyGameDotNet.Migrations
{
    public partial class GamesTableSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "IsBorrowed", "Title" },
                values: new object[,]
                {
                    { 1, false, "Half-Life 3" },
                    { 2, true, "Half-Life 2" },
                    { 3, false, "Age of Empires 2" },
                    { 4, true, "SimCity 4000" },
                    { 5, false, "The Elder Scrolls V: Skyrim" },
                    { 6, false, "Fallout 3" },
                    { 7, true, "God Of War" },
                    { 8, false, "Warcraft 3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace BorrowMyGameDotNet.Migrations
{
    public partial class FriendsTableSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ellen Ripley" },
                    { 2, "Bruce Wayne" },
                    { 3, "Tony Stark" },
                    { 4, "Lara Croft" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

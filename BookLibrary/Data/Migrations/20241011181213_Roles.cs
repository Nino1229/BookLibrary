using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibrary.Data.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "001cfdd5-8690-4e82-8110-b3d1dae334e1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f235a26b-7836-4325-b6fd-a9bf4d6bb6c0", "87696fb6-0284-4c2a-9c31-1a8f4654e419", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f235a26b-7836-4325-b6fd-a9bf4d6bb6c0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "001cfdd5-8690-4e82-8110-b3d1dae334e1", "40dc0f12-dcab-44b1-8f15-8b04a3391b8b", "Admin", "ADMIN" });
        }
    }
}

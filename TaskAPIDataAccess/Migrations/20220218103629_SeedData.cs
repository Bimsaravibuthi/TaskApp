using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskAPIDataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Created", "Description", "Due", "Status", "Title" },
                values: new object[] { 1, new DateTime(2022, 2, 18, 16, 6, 28, 569, DateTimeKind.Local).AddTicks(2293), "Get some text books for school", new DateTime(2022, 2, 23, 16, 6, 28, 570, DateTimeKind.Local).AddTicks(1922), 0, "Get books for school - DB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

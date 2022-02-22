using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskAPIDataAccess.Migrations
{
    public partial class AuthorEntityAndData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Bimsara Vibuthi" },
                    { 2, "Chamara Madhusanka" },
                    { 3, "Dinesh Indunil" },
                    { 4, "Ravidu Hasmitha" }
                });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Created", "Due" },
                values: new object[] { 1, new DateTime(2022, 2, 22, 12, 32, 58, 482, DateTimeKind.Local).AddTicks(7344), new DateTime(2022, 2, 27, 12, 32, 58, 484, DateTimeKind.Local).AddTicks(2898) });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "AuthorId", "Created", "Description", "Due", "Status", "Title" },
                values: new object[] { 2, 1, new DateTime(2022, 2, 22, 12, 32, 58, 484, DateTimeKind.Local).AddTicks(4359), "Get vegitables for the week", new DateTime(2022, 2, 24, 12, 32, 58, 484, DateTimeKind.Local).AddTicks(4367), 0, "Get vegitables - DB" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "AuthorId", "Created", "Description", "Due", "Status", "Title" },
                values: new object[] { 3, 2, new DateTime(2022, 2, 22, 12, 32, 58, 484, DateTimeKind.Local).AddTicks(4380), "Water the all plants quickly", new DateTime(2022, 2, 23, 12, 32, 58, 484, DateTimeKind.Local).AddTicks(4383), 0, "Water the plants" });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_AuthorId",
                table: "Todos",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Authors_AuthorId",
                table: "Todos",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Authors_AuthorId",
                table: "Todos");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Todos_AuthorId",
                table: "Todos");

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Todos");

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Due" },
                values: new object[] { new DateTime(2022, 2, 22, 12, 24, 27, 776, DateTimeKind.Local).AddTicks(3401), new DateTime(2022, 2, 27, 12, 24, 27, 777, DateTimeKind.Local).AddTicks(4103) });
        }
    }
}

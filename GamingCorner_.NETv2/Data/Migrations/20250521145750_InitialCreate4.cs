using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "VideogameGenders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "VideogameGenders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 1, 1 },
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 2, 1 },
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 2, 2 },
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 3, 2 },
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 1, 3 },
                column: "Id",
                value: 1);
        }
    }
}

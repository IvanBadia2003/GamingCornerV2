using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VideogameGenders",
                table: "VideogameGenders");

            migrationBuilder.DropIndex(
                name: "IX_VideogameGenders_VideogameId",
                table: "VideogameGenders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideogameGenders",
                table: "VideogameGenders",
                columns: new[] { "VideogameId", "GenderId" });

            migrationBuilder.InsertData(
                table: "VideogameGenders",
                columns: new[] { "GenderId", "VideogameId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 1 },
                    { 1, 3, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VideogameGenders",
                table: "VideogameGenders");

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideogameGenders",
                table: "VideogameGenders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VideogameGenders_VideogameId",
                table: "VideogameGenders",
                column: "VideogameId");
        }
    }
}

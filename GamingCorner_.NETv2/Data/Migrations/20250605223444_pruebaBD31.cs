using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class pruebaBD31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrincipalImageURL",
                table: "Videogames");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "SecondHandProducts");

            migrationBuilder.DropColumn(
                name: "PrincipalImageURL",
                table: "Consoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrincipalImageURL",
                table: "Videogames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "SecondHandProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrincipalImageURL",
                table: "Consoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class pruebaBD30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentImages1",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentImages2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentImages3",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentImages4",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ContentImages1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ContentImages2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ContentImages3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ContentImages4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Products");
        }
    }
}

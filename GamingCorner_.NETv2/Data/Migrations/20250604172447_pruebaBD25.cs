using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class pruebaBD25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SecondHandProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SecondHandProducts_UserId",
                table: "SecondHandProducts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SecondHandProducts_Users_UserId",
                table: "SecondHandProducts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecondHandProducts_Users_UserId",
                table: "SecondHandProducts");

            migrationBuilder.DropIndex(
                name: "IX_SecondHandProducts_UserId",
                table: "SecondHandProducts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SecondHandProducts");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Baskets_BasketUserId_BasketProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Baskets_BasketUserId_BasketProductId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BasketUserId_BasketProductId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_BasketUserId_BasketProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BasketProductId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BasketUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BasketProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BasketUserId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlatformId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlatformId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "PlatformId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "PlatformId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "PlatformId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "PlatformId",
                value: 6);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ProductId",
                table: "Baskets",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Products_ProductId",
                table: "Baskets",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Products_ProductId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_ProductId",
                table: "Baskets");

            migrationBuilder.AddColumn<int>(
                name: "BasketProductId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BasketUserId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BasketProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BasketUserId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlatformId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlatformId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "PlatformId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "PlatformId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "PlatformId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "PlatformId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BasketUserId_BasketProductId",
                table: "Users",
                columns: new[] { "BasketUserId", "BasketProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BasketUserId_BasketProductId",
                table: "Products",
                columns: new[] { "BasketUserId", "BasketProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Baskets_BasketUserId_BasketProductId",
                table: "Products",
                columns: new[] { "BasketUserId", "BasketProductId" },
                principalTable: "Baskets",
                principalColumns: new[] { "UserId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Baskets_BasketUserId_BasketProductId",
                table: "Users",
                columns: new[] { "BasketUserId", "BasketProductId" },
                principalTable: "Baskets",
                principalColumns: new[] { "UserId", "ProductId" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class pruebaBD23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_Users_UserId",
                table: "OrderHeaders");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "OrderHeaders",
                newName: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "OrderHeaders",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigitalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderHeaderId",
                table: "OrderLines",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_Users_UserId",
                table: "OrderHeaders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_Users_UserId",
                table: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "OrderHeaders");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "OrderHeaders",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "OrderHeaders",
                newName: "Fecha");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_Users_UserId",
                table: "OrderHeaders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}

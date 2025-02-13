using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWebApi.Migrations
{
    public partial class addordertbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_product_tbl_category_CategoryId",
                table: "tbl_product");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "tbl_product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tbl_order_detail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_order_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_order_detail_tbl_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tbl_product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_order_tbl_order_detail_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "tbl_order_detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_order_OrderDetailId",
                table: "tbl_order",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_order_detail_ProductId",
                table: "tbl_order_detail",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_product_tbl_category_CategoryId",
                table: "tbl_product",
                column: "CategoryId",
                principalTable: "tbl_category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_product_tbl_category_CategoryId",
                table: "tbl_product");

            migrationBuilder.DropTable(
                name: "tbl_order");

            migrationBuilder.DropTable(
                name: "tbl_order_detail");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "tbl_product",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_product_tbl_category_CategoryId",
                table: "tbl_product",
                column: "CategoryId",
                principalTable: "tbl_category",
                principalColumn: "Id");
        }
    }
}

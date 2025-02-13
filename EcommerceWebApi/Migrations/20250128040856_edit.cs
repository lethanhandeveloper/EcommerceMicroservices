using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWebApi.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_order_tbl_order_detail_OrderDetailId",
                table: "tbl_order");

            migrationBuilder.DropIndex(
                name: "IX_tbl_order_OrderDetailId",
                table: "tbl_order");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "tbl_order");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "tbl_order_detail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tbl_order_detail_OrderId",
                table: "tbl_order_detail",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_order_detail_tbl_order_OrderId",
                table: "tbl_order_detail",
                column: "OrderId",
                principalTable: "tbl_order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_order_detail_tbl_order_OrderId",
                table: "tbl_order_detail");

            migrationBuilder.DropIndex(
                name: "IX_tbl_order_detail_OrderId",
                table: "tbl_order_detail");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "tbl_order_detail");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderDetailId",
                table: "tbl_order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tbl_order_OrderDetailId",
                table: "tbl_order",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_order_tbl_order_detail_OrderDetailId",
                table: "tbl_order",
                column: "OrderDetailId",
                principalTable: "tbl_order_detail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

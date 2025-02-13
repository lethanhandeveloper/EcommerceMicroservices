using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWebApi.Migrations
{
    public partial class fo_prod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "tbl_product",
                newName: "Price");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "tbl_product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tbl_category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_product_CategoryId",
                table: "tbl_product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_product_tbl_category_CategoryId",
                table: "tbl_product",
                column: "CategoryId",
                principalTable: "tbl_category",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_product_tbl_category_CategoryId",
                table: "tbl_product");

            migrationBuilder.DropTable(
                name: "tbl_category");

            migrationBuilder.DropIndex(
                name: "IX_tbl_product_CategoryId",
                table: "tbl_product");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "tbl_product");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "tbl_product",
                newName: "price");
        }
    }
}

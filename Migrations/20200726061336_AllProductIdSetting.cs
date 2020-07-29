using Microsoft.EntityFrameworkCore.Migrations;

namespace Zedx.Migrations
{
    public partial class AllProductIdSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetail_AllProducts_AllProductProductId",
                table: "BillDetail");

            migrationBuilder.DropIndex(
                name: "IX_BillDetail_AllProductProductId",
                table: "BillDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllProducts",
                table: "AllProducts");

            migrationBuilder.DropColumn(
                name: "AllProductProductId",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "AllProducts");

            migrationBuilder.AddColumn<long>(
                name: "AllProductId",
                table: "BillDetail",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AllProductId",
                table: "AllProducts",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllProducts",
                table: "AllProducts",
                column: "AllProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_AllProductId",
                table: "BillDetail",
                column: "AllProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetail_AllProducts_AllProductId",
                table: "BillDetail",
                column: "AllProductId",
                principalTable: "AllProducts",
                principalColumn: "AllProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetail_AllProducts_AllProductId",
                table: "BillDetail");

            migrationBuilder.DropIndex(
                name: "IX_BillDetail_AllProductId",
                table: "BillDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllProducts",
                table: "AllProducts");

            migrationBuilder.DropColumn(
                name: "AllProductId",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "AllProductId",
                table: "AllProducts");

            migrationBuilder.AddColumn<long>(
                name: "AllProductProductId",
                table: "BillDetail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "BillDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "AllProducts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllProducts",
                table: "AllProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_AllProductProductId",
                table: "BillDetail",
                column: "AllProductProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetail_AllProducts_AllProductProductId",
                table: "BillDetail",
                column: "AllProductProductId",
                principalTable: "AllProducts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

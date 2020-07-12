using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zedx.Migrations
{
    public partial class ProductypeAndAllProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    CreatedById = table.Column<long>(nullable: false),
                    ModifiedById = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AllProducts",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rate = table.Column<float>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    ModifiedById = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false),
                    AluminumColorId = table.Column<int>(nullable: true),
                    AluminumGageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllProducts", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_AllProducts_AluminumColor_AluminumColorId",
                        column: x => x.AluminumColorId,
                        principalTable: "AluminumColor",
                        principalColumn: "AluminumColorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllProducts_AluminumGage_AluminumGageId",
                        column: x => x.AluminumGageId,
                        principalTable: "AluminumGage",
                        principalColumn: "AluminumGageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllProducts_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllProducts_AluminumColorId",
                table: "AllProducts",
                column: "AluminumColorId");

            migrationBuilder.CreateIndex(
                name: "IX_AllProducts_AluminumGageId",
                table: "AllProducts",
                column: "AluminumGageId");

            migrationBuilder.CreateIndex(
                name: "IX_AllProducts_ProductTypeId",
                table: "AllProducts",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllProducts");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}

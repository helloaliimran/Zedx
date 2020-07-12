using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zedx.Migrations
{
    public partial class BillAndBillDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillId = table.Column<long>(nullable: false),
                    NetAmount = table.Column<float>(nullable: false),
                    TotalDiscount = table.Column<float>(nullable: false),
                    Total = table.Column<float>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    CustomersCustomerId = table.Column<long>(nullable: true),
                    CreatedById = table.Column<long>(nullable: false),
                    ModifiedById = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bill_Customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillDetail",
                columns: table => new
                {
                    BillDetailId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    AllProductProductId = table.Column<long>(nullable: true),
                    AluminumColorId = table.Column<int>(nullable: true),
                    AluminumGageId = table.Column<int>(nullable: true),
                    Rate = table.Column<float>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    Feet = table.Column<float>(nullable: false),
                    Quantity = table.Column<float>(nullable: false),
                    TotalFeet = table.Column<float>(nullable: false),
                    NetAmount = table.Column<float>(nullable: false),
                    DiscountedAmount = table.Column<float>(nullable: false),
                    AmountToBePaid = table.Column<float>(nullable: false),
                    BillId = table.Column<long>(nullable: false),
                    SheetHeight = table.Column<float>(nullable: false),
                    SheetWidth = table.Column<float>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    ModifiedById = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetail", x => x.BillDetailId);
                    table.ForeignKey(
                        name: "FK_BillDetail_AllProducts_AllProductProductId",
                        column: x => x.AllProductProductId,
                        principalTable: "AllProducts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillDetail_AluminumColor_AluminumColorId",
                        column: x => x.AluminumColorId,
                        principalTable: "AluminumColor",
                        principalColumn: "AluminumColorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillDetail_AluminumGage_AluminumGageId",
                        column: x => x.AluminumGageId,
                        principalTable: "AluminumGage",
                        principalColumn: "AluminumGageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillDetail_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_CustomersCustomerId",
                table: "Bill",
                column: "CustomersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_AllProductProductId",
                table: "BillDetail",
                column: "AllProductProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_AluminumColorId",
                table: "BillDetail",
                column: "AluminumColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_AluminumGageId",
                table: "BillDetail",
                column: "AluminumGageId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_BillId",
                table: "BillDetail",
                column: "BillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDetail");

            migrationBuilder.DropTable(
                name: "Bill");
        }
    }
}

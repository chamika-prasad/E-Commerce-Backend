using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "testOrderorderId",
                table: "ProductOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "testOrders",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false),
                    transactionid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    testemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    useremail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testOrders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_testOrders_Users_useremail",
                        column: x => x.useremail,
                        principalTable: "Users",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestProductOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestProductOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestProductOrders_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestProductOrders_testOrders_orderId",
                        column: x => x.orderId,
                        principalTable: "testOrders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_testOrderorderId",
                table: "ProductOrders",
                column: "testOrderorderId");

            migrationBuilder.CreateIndex(
                name: "IX_testOrders_useremail",
                table: "testOrders",
                column: "useremail");

            migrationBuilder.CreateIndex(
                name: "IX_TestProductOrders_orderId",
                table: "TestProductOrders",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_TestProductOrders_productId",
                table: "TestProductOrders",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_testOrders_testOrderorderId",
                table: "ProductOrders",
                column: "testOrderorderId",
                principalTable: "testOrders",
                principalColumn: "orderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_testOrders_testOrderorderId",
                table: "ProductOrders");

            migrationBuilder.DropTable(
                name: "TestProductOrders");

            migrationBuilder.DropTable(
                name: "testOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrders_testOrderorderId",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "testOrderorderId",
                table: "ProductOrders");
        }
    }
}

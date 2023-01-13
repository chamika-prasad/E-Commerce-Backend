using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Orders_orderId",
                table: "ProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Products_productId",
                table: "ProductOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrders",
                table: "ProductOrders");

            migrationBuilder.RenameTable(
                name: "ProductOrders",
                newName: "ProductOrder");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrders_productId",
                table: "ProductOrder",
                newName: "IX_ProductOrder_productId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrders_orderId",
                table: "ProductOrder",
                newName: "IX_ProductOrder_orderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Orders_orderId",
                table: "ProductOrder",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Products_productId",
                table: "ProductOrder",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Orders_orderId",
                table: "ProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Products_productId",
                table: "ProductOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder");

            migrationBuilder.RenameTable(
                name: "ProductOrder",
                newName: "ProductOrders");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrder_productId",
                table: "ProductOrders",
                newName: "IX_ProductOrders_productId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrder_orderId",
                table: "ProductOrders",
                newName: "IX_ProductOrders_orderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrders",
                table: "ProductOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Orders_orderId",
                table: "ProductOrders",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Products_productId",
                table: "ProductOrders",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

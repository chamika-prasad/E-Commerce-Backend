using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class newmigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "NewOrderId",
                table: "ProductOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrders",
                table: "ProductOrders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "NewProductOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewProductOrders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_NewOrderId",
                table: "ProductOrders",
                column: "NewOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_NewProductOrders_NewOrderId",
                table: "ProductOrders",
                column: "NewOrderId",
                principalTable: "NewProductOrders",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_NewProductOrders_NewOrderId",
                table: "ProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Orders_orderId",
                table: "ProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Products_productId",
                table: "ProductOrders");

            migrationBuilder.DropTable(
                name: "NewProductOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrders",
                table: "ProductOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrders_NewOrderId",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "NewOrderId",
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
    }
}

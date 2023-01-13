using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class newmigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Useremail",
                table: "NewProductOrders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "NewProductOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "NewProductOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "NewProductOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NewProductOrders_productId",
                table: "NewProductOrders",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_NewProductOrders_Useremail",
                table: "NewProductOrders",
                column: "Useremail");

            migrationBuilder.AddForeignKey(
                name: "FK_NewProductOrders_Products_productId",
                table: "NewProductOrders",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewProductOrders_Users_Useremail",
                table: "NewProductOrders",
                column: "Useremail",
                principalTable: "Users",
                principalColumn: "email",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewProductOrders_Products_productId",
                table: "NewProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_NewProductOrders_Users_Useremail",
                table: "NewProductOrders");

            migrationBuilder.DropIndex(
                name: "IX_NewProductOrders_productId",
                table: "NewProductOrders");

            migrationBuilder.DropIndex(
                name: "IX_NewProductOrders_Useremail",
                table: "NewProductOrders");

            migrationBuilder.DropColumn(
                name: "Useremail",
                table: "NewProductOrders");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "NewProductOrders");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "NewProductOrders");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "NewProductOrders");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transactionid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderId);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    NewOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOrders_NewProductOrders_NewOrderId",
                        column: x => x.NewOrderId,
                        principalTable: "NewProductOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductOrders_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_NewOrderId",
                table: "ProductOrders",
                column: "NewOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_orderId",
                table: "ProductOrders",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_productId",
                table: "ProductOrders",
                column: "productId");
        }
    }
}

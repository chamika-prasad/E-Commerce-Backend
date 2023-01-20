using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class productorderss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewOrders_Products_productId",
                table: "NewOrders");

            migrationBuilder.DropIndex(
                name: "IX_NewOrders_productId",
                table: "NewOrders");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "NewOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "NewOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewOrders_productId",
                table: "NewOrders",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewOrders_Products_productId",
                table: "NewOrders",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId");
        }
    }
}

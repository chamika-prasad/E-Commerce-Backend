using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class newmigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewProductOrders_Products_productId",
                table: "NewProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_NewProductOrders_Users_Useremail",
                table: "NewProductOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewProductOrders",
                table: "NewProductOrders");

            migrationBuilder.RenameTable(
                name: "NewProductOrders",
                newName: "NewOrders");

            migrationBuilder.RenameIndex(
                name: "IX_NewProductOrders_Useremail",
                table: "NewOrders",
                newName: "IX_NewOrders_Useremail");

            migrationBuilder.RenameIndex(
                name: "IX_NewProductOrders_productId",
                table: "NewOrders",
                newName: "IX_NewOrders_productId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewOrders",
                table: "NewOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewOrders_Products_productId",
                table: "NewOrders",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewOrders_Users_Useremail",
                table: "NewOrders",
                column: "Useremail",
                principalTable: "Users",
                principalColumn: "email",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewOrders_Products_productId",
                table: "NewOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_NewOrders_Users_Useremail",
                table: "NewOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewOrders",
                table: "NewOrders");

            migrationBuilder.RenameTable(
                name: "NewOrders",
                newName: "NewProductOrders");

            migrationBuilder.RenameIndex(
                name: "IX_NewOrders_Useremail",
                table: "NewProductOrders",
                newName: "IX_NewProductOrders_Useremail");

            migrationBuilder.RenameIndex(
                name: "IX_NewOrders_productId",
                table: "NewProductOrders",
                newName: "IX_NewProductOrders_productId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewProductOrders",
                table: "NewProductOrders",
                column: "Id");

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class productorderssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewOrders_Users_userEmail",
                table: "NewOrders");

            migrationBuilder.DropIndex(
                name: "IX_NewOrders_userEmail",
                table: "NewOrders");

            migrationBuilder.DropColumn(
                name: "userEmail",
                table: "NewOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userEmail",
                table: "NewOrders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_NewOrders_userEmail",
                table: "NewOrders",
                column: "userEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_NewOrders_Users_userEmail",
                table: "NewOrders",
                column: "userEmail",
                principalTable: "Users",
                principalColumn: "email",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class newmigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewOrders_Users_Useremail",
                table: "NewOrders");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "NewOrders");

            migrationBuilder.RenameColumn(
                name: "Useremail",
                table: "NewOrders",
                newName: "userEmail");

            migrationBuilder.RenameIndex(
                name: "IX_NewOrders_Useremail",
                table: "NewOrders",
                newName: "IX_NewOrders_userEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_NewOrders_Users_userEmail",
                table: "NewOrders",
                column: "userEmail",
                principalTable: "Users",
                principalColumn: "email",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewOrders_Users_userEmail",
                table: "NewOrders");

            migrationBuilder.RenameColumn(
                name: "userEmail",
                table: "NewOrders",
                newName: "Useremail");

            migrationBuilder.RenameIndex(
                name: "IX_NewOrders_userEmail",
                table: "NewOrders",
                newName: "IX_NewOrders_Useremail");

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "NewOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_NewOrders_Users_Useremail",
                table: "NewOrders",
                column: "Useremail",
                principalTable: "Users",
                principalColumn: "email",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

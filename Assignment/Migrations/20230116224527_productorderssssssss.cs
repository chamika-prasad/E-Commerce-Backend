using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class productorderssssssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Users_Useremail",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "Useremail",
                table: "Cart",
                newName: "userEmail");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Useremail",
                table: "Cart",
                newName: "IX_Cart_userEmail");

            migrationBuilder.AlterColumn<string>(
                name: "userEmail",
                table: "Cart",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Users_userEmail",
                table: "Cart",
                column: "userEmail",
                principalTable: "Users",
                principalColumn: "email",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Users_userEmail",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "userEmail",
                table: "Cart",
                newName: "Useremail");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_userEmail",
                table: "Cart",
                newName: "IX_Cart_Useremail");

            migrationBuilder.AlterColumn<string>(
                name: "Useremail",
                table: "Cart",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Users_Useremail",
                table: "Cart",
                column: "Useremail",
                principalTable: "Users",
                principalColumn: "email");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Ef.Core.Migrations
{
    /// <inheritdoc />
    public partial class reupdateAddtoCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddToCart_Users_ProductId",
                table: "AddToCart");

            migrationBuilder.CreateIndex(
                name: "IX_AddToCart_UserId",
                table: "AddToCart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddToCart_Users_UserId",
                table: "AddToCart",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddToCart_Users_UserId",
                table: "AddToCart");

            migrationBuilder.DropIndex(
                name: "IX_AddToCart_UserId",
                table: "AddToCart");

            migrationBuilder.AddForeignKey(
                name: "FK_AddToCart_Users_ProductId",
                table: "AddToCart",
                column: "ProductId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

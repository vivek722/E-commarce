using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Ef.Core.Migrations
{
    /// <inheritdoc />
    public partial class updateWishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishList_Users_ProductId",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_ProductId",
                table: "WishList");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_ProductId",
                table: "WishList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_UserId",
                table: "WishList",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_Users_UserId",
                table: "WishList",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishList_Users_UserId",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_ProductId",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_UserId",
                table: "WishList");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_ProductId",
                table: "WishList",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_Users_ProductId",
                table: "WishList",
                column: "ProductId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

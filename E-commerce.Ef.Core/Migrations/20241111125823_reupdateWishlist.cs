using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Ef.Core.Migrations
{
    /// <inheritdoc />
    public partial class reupdateWishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WishList_UserId",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_AddToCart_ProductId",
                table: "AddToCart");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_UserId",
                table: "WishList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AddToCart_ProductId",
                table: "AddToCart",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WishList_UserId",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_AddToCart_ProductId",
                table: "AddToCart");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_UserId",
                table: "WishList",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddToCart_ProductId",
                table: "AddToCart",
                column: "ProductId",
                unique: true);
        }
    }
}

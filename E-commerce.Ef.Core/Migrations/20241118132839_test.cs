using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Ef.Core.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItemDto",
                columns: table => new
                {
                    AddToCartId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductOrignalprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductActualPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductImag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ProductDto",
                columns: table => new
                {
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductOrignalprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductActualprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductImag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItemDto");

            migrationBuilder.DropTable(
                name: "ProductDto");
        }
    }
}

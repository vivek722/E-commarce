using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Ef.Core.Migrations
{
    /// <inheritdoc />
    public partial class new161024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_Countrieid",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_Countrieid",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Countrieid",
                table: "Addresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Countrieid",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Countrieid",
                table: "Addresses",
                column: "Countrieid");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_Countrieid",
                table: "Addresses",
                column: "Countrieid",
                principalTable: "Countries",
                principalColumn: "id");
        }
    }
}

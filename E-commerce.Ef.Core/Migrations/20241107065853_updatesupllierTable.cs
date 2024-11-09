using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Ef.Core.Migrations
{
    /// <inheritdoc />
    public partial class updatesupllierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_RoleId",
                table: "Supplier",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Roles_RoleId",
                table: "Supplier",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Roles_RoleId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_RoleId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Supplier");
        }
    }
}

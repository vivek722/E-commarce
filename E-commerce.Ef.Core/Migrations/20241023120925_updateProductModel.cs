using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Ef.Core.Migrations
{
    /// <inheritdoc />
    public partial class updateProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupplierName",
                table: "Supplier",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "ProductOrignalprice");

            migrationBuilder.AddColumn<DateTime>(
                name: "CrateAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ProductActualprice",
                table: "Products",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductDesc",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductImag",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Supplierid",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Supplierid",
                table: "Addresses",
                column: "Supplierid");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Supplier_Supplierid",
                table: "Addresses",
                column: "Supplierid",
                principalTable: "Supplier",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Supplier_Supplierid",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_Supplierid",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CrateAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductActualprice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductDesc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductImag",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Supplierid",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Supplier",
                newName: "SupplierName");

            migrationBuilder.RenameColumn(
                name: "ProductOrignalprice",
                table: "Products",
                newName: "Price");
        }
    }
}

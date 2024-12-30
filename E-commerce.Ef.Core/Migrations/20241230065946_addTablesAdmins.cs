using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Ef.Core.Migrations
{
    /// <inheritdoc />
    public partial class addTablesAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer-Page-setting",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPageActive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLoderActive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTosterActive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleteDialogActive = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer-Page-setting", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier-Page-setting",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPageActive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLoderActive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTosterActive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleteDialogActive = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier-Page-setting", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer-Page-setting");

            migrationBuilder.DropTable(
                name: "Supplier-Page-setting");
        }
    }
}

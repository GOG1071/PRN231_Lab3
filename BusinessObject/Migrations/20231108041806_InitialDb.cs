using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Banh" },
                    { 2, "Keo" },
                    { 3, "Trai Cay" },
                    { 4, "Do Uong" },
                    { 5, "Do An" },
                    { 6, "Do Khac" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ProductName", "UnitPrice", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, 1, "Banh Mi", 3620m, 90 },
                    { 2, 1, "Banh Quy", 6081m, 8 },
                    { 3, 1, "Banh Trang", 3205m, 98 },
                    { 4, 2, "Keo", 5140m, 83 },
                    { 5, 2, "Keo Mut", 8105m, 41 },
                    { 6, 3, "Trai Cay", 6419m, 28 },
                    { 7, 3, "Trai Cay Say", 7678m, 44 },
                    { 8, 3, "Trai Cay Tuoi", 1309m, 44 },
                    { 9, 4, "Nuoc Ngot", 1804m, 25 },
                    { 10, 4, "Nuoc Ngot Co Gas", 2442m, 14 },
                    { 11, 4, "Nuoc Ngot Khong Gas", 3447m, 36 },
                    { 12, 5, "Do An Vat", 7818m, 37 },
                    { 13, 5, "Do An Nhanh", 5371m, 47 },
                    { 14, 6, "Pin", 333m, 72 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

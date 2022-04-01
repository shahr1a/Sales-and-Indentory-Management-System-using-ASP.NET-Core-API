using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddedSaleAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "DealerTypes",
                columns: table => new
                {
                    DealerTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerTypes", x => x.DealerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    BuyingPrice = table.Column<float>(type: "real", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Inventories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    DealerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealerName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DealerLocation = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    DealerUsername = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DealerPassword = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    DealerDiscount = table.Column<double>(type: "float", nullable: true),
                    DealerTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.DealerId);
                    table.ForeignKey(
                        name: "FK_Dealers_DealerTypes_DealerTypeId",
                        column: x => x.DealerTypeId,
                        principalTable: "DealerTypes",
                        principalColumn: "DealerTypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_DealerTypeId",
                table: "Dealers",
                column: "DealerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CategoryId",
                table: "Inventories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "DealerTypes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

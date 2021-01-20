using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyFashionServices.Catalog.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    AvailableStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvailableStock", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 25, "Must have basic t-shirt.", "White T-shirt", 200 },
                    { 2, 20, "Must have basic t-shirt.", "Black T-shirt", 200 },
                    { 3, 34, "Must have basic t-shirt.", "Pink T-shirt", 200 },
                    { 4, 4, "A casual black dress.", "Casual Black Dress", 590 },
                    { 5, 17, "A nice shirt for parties.", "Dotted Shirt", 365 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

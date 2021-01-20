using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyFashionServices.Order.Migrations
{
    public partial class RemoveCustomerclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Orders",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Orders",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Orders",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Orders",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitPrice",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

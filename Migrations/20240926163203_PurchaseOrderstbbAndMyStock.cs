using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillBookApi.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseOrderstbbAndMyStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "ItemCode",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "ItemHSNCode",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "PurchaseOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "PurchaseOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ItemCode",
                table: "PurchaseOrders",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ItemHSNCode",
                table: "PurchaseOrders",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "PurchaseOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "PurchaseOrders",
                type: "float",
                nullable: true);
        }
    }
}

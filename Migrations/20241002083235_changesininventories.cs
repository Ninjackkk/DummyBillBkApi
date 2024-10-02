using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillBookApi.Migrations
{
    /// <inheritdoc />
    public partial class changesininventories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Inventories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Inventories",
                type: "int",
                nullable: true);
        }
    }
}

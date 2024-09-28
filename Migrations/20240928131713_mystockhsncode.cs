using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillBookApi.Migrations
{
    /// <inheritdoc />
    public partial class mystockhsncode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemHSNCode",
                table: "MyStocks",
                newName: "HSNCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HSNCode",
                table: "MyStocks",
                newName: "ItemHSNCode");
        }
    }
}

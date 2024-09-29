using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillBookApi.Migrations
{
    /// <inheritdoc />
    public partial class Parties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    PartyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<double>(type: "float", nullable: true),
                    OpeningBalance = table.Column<double>(type: "float", nullable: true),
                    GSTINNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PanCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditPeriod = table.Column<double>(type: "float", nullable: true),
                    CreditLimit = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.PartyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parties");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApplication.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<long>(type: "bigint", nullable: false),
                    CityOfSender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AddressOfSender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CityOfRecipient = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AddressOfRecipient = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CargoWeight = table.Column<double>(type: "float", nullable: false),
                    CargoPickupDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManagementService.Migrations
{
    public partial class CreateAirlines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inventoryTbls",
                columns: table => new
                {
                    FlightNumber = table.Column<string>(nullable: false),
                    AirlineNo = table.Column<string>(nullable: true),
                    FromPlace = table.Column<string>(nullable: true),
                    ToPlace = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    ScheduleDays = table.Column<string>(nullable: true),
                    InstrumentUsed = table.Column<string>(nullable: true),
                    BusinessClassSeat = table.Column<int>(nullable: true),
                    NonBusinessClassSeat = table.Column<int>(nullable: true),
                    TicketCost = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    NoOfRows = table.Column<int>(nullable: true),
                    Meal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventoryTbls", x => x.FlightNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventoryTbls");
        }
    }
}

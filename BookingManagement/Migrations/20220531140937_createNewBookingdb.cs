using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingManagement.Migrations
{
    public partial class createNewBookingdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookflightTbl",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    EmailId = table.Column<string>(maxLength: 50, nullable: true),
                    Meal = table.Column<string>(maxLength: 50, nullable: true),
                    FlightNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Pnr = table.Column<string>(maxLength: 50, nullable: true),
                    peopleid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookflightTbl", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTbls",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightNo = table.Column<string>(nullable: true),
                    FromPlace = table.Column<string>(nullable: true),
                    ToPlace = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    BusinessClassSeat = table.Column<int>(nullable: false),
                    NonBusinessClassSeat = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    NoOfRows = table.Column<int>(nullable: false),
                    Meal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTbls", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserDetailTbl",
                columns: table => new
                {
                    PeopleId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(maxLength: 50, nullable: true),
                    Age = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    Class = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetailTbl", x => x.PeopleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookflightTbl");

            migrationBuilder.DropTable(
                name: "InventoryTbls");

            migrationBuilder.DropTable(
                name: "UserDetailTbl");
        }
    }
}

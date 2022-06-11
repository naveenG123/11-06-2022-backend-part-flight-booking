using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManagementService.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_inventoryTbls",
                table: "inventoryTbls");

            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "inventoryTbls");

            migrationBuilder.DropColumn(
                name: "AirlineNo",
                table: "inventoryTbls");

            migrationBuilder.DropColumn(
                name: "InstrumentUsed",
                table: "inventoryTbls");

            migrationBuilder.DropColumn(
                name: "TicketCost",
                table: "inventoryTbls");

            migrationBuilder.RenameColumn(
                name: "ScheduleDays",
                table: "inventoryTbls",
                newName: "FlightNo");

            migrationBuilder.AlterColumn<int>(
                name: "NonBusinessClassSeat",
                table: "inventoryTbls",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NoOfRows",
                table: "inventoryTbls",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Meal",
                table: "inventoryTbls",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessClassSeat",
                table: "inventoryTbls",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "inventoryTbls",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "inventoryTbls",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventoryTbls",
                table: "inventoryTbls",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_inventoryTbls",
                table: "inventoryTbls");

            migrationBuilder.DropColumn(
                name: "id",
                table: "inventoryTbls");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "inventoryTbls");

            migrationBuilder.RenameColumn(
                name: "FlightNo",
                table: "inventoryTbls",
                newName: "ScheduleDays");

            migrationBuilder.AlterColumn<int>(
                name: "NonBusinessClassSeat",
                table: "inventoryTbls",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "NoOfRows",
                table: "inventoryTbls",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Meal",
                table: "inventoryTbls",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BusinessClassSeat",
                table: "inventoryTbls",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "FlightNumber",
                table: "inventoryTbls",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AirlineNo",
                table: "inventoryTbls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstrumentUsed",
                table: "inventoryTbls",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TicketCost",
                table: "inventoryTbls",
                type: "decimal(8,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventoryTbls",
                table: "inventoryTbls",
                column: "FlightNumber");
        }
    }
}

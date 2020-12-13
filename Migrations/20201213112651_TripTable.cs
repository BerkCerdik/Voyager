using Microsoft.EntityFrameworkCore.Migrations;

namespace Voyager.Migrations
{
    public partial class TripTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Drivers_DriverID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Passengers_PassengerID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_DriverID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PassengerID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DriverID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PassengerID",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverID",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassengerID",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DriverID",
                table: "Comments",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PassengerID",
                table: "Comments",
                column: "PassengerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Drivers_DriverID",
                table: "Comments",
                column: "DriverID",
                principalTable: "Drivers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Passengers_PassengerID",
                table: "Comments",
                column: "PassengerID",
                principalTable: "Passengers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

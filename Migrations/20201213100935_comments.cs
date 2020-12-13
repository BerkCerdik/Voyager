using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Voyager.Migrations
{
    public partial class comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Confirmpassword",
                table: "DriverVM",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateTable(
                name: "CommentVM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PassengerName = table.Column<string>(type: "text", nullable: true),
                    PassengerLastname = table.Column<string>(type: "text", nullable: true),
                    DriverName = table.Column<string>(type: "text", nullable: true),
                    DriverLastname = table.Column<string>(type: "text", nullable: true),
                    TripID = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Point = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentVM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TripVM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PassengerName = table.Column<string>(type: "text", nullable: true),
                    PassengerLastname = table.Column<string>(type: "text", nullable: true),
                    DriverName = table.Column<string>(type: "text", nullable: true),
                    DriverLastname = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    DeparturePoint = table.Column<string>(type: "text", nullable: true),
                    ArrivalPoint = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripVM", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Drivers_DriverID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Passengers_PassengerID",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "CommentVM");

            migrationBuilder.DropTable(
                name: "TripVM");

            migrationBuilder.DropIndex(
                name: "IX_Comments_DriverID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PassengerID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Confirmpassword",
                table: "DriverVM");

            migrationBuilder.DropColumn(
                name: "DriverID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PassengerID",
                table: "Comments");
        }
    }
}

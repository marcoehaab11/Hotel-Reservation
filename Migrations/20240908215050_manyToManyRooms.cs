using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Reservation.Migrations
{
    /// <inheritdoc />
    public partial class manyToManyRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RateEndDate",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RatePerRoom",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RateStartDate",
                table: "Rooms");

            migrationBuilder.CreateTable(
                name: "RoomSeasonStartAndEnds",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeasonStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeasonEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSeasonStartAndEnds", x => x.SeasonId);
                });

            migrationBuilder.CreateTable(
                name: "RoomSeasons",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    RoomSeasonStartAndEndID = table.Column<int>(type: "int", nullable: false),
                    RatePerRoom = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSeasons", x => new { x.RoomTypeId, x.RoomSeasonStartAndEndID });
                    table.ForeignKey(
                        name: "FK_RoomSeasons_RoomSeasonStartAndEnds_RoomSeasonStartAndEndID",
                        column: x => x.RoomSeasonStartAndEndID,
                        principalTable: "RoomSeasonStartAndEnds",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomSeasons_Rooms_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomSeasons_RoomSeasonStartAndEndID",
                table: "RoomSeasons",
                column: "RoomSeasonStartAndEndID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomSeasons");

            migrationBuilder.DropTable(
                name: "RoomSeasonStartAndEnds");

            migrationBuilder.AddColumn<DateTime>(
                name: "RateEndDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "RatePerRoom",
                table: "Rooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "RateStartDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

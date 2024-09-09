using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Reservation.Migrations
{
    /// <inheritdoc />
    public partial class manytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_MealPlans_MealPlanID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Rooms_RoomID",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "MealPlanSeasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_RoomID",
                table: "Reservations",
                newName: "IX_Reservations_RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_MealPlanID",
                table: "Reservations",
                newName: "IX_Reservations_MealPlanID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "ReservationID");

            migrationBuilder.CreateTable(
                name: "MealSeasonStartAndEndSeasons",
                columns: table => new
                {
                    MealSeasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeasonStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeasonEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealSeasonStartAndEndSeasons", x => x.MealSeasonId);
                });

            migrationBuilder.CreateTable(
                name: "MealPlanPerSeasons",
                columns: table => new
                {
                    MealPlanID = table.Column<int>(type: "int", nullable: false),
                    MealSeasonStartAndEndID = table.Column<int>(type: "int", nullable: false),
                    RatePerPerson = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanPerSeasons", x => new { x.MealPlanID, x.MealSeasonStartAndEndID });
                    table.ForeignKey(
                        name: "FK_MealPlanPerSeasons_MealPlans_MealPlanID",
                        column: x => x.MealPlanID,
                        principalTable: "MealPlans",
                        principalColumn: "MealPlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealPlanPerSeasons_MealSeasonStartAndEndSeasons_MealSeasonStartAndEndID",
                        column: x => x.MealSeasonStartAndEndID,
                        principalTable: "MealSeasonStartAndEndSeasons",
                        principalColumn: "MealSeasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanPerSeasons_MealSeasonStartAndEndID",
                table: "MealPlanPerSeasons",
                column: "MealSeasonStartAndEndID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_MealPlans_MealPlanID",
                table: "Reservations",
                column: "MealPlanID",
                principalTable: "MealPlans",
                principalColumn: "MealPlanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomID",
                table: "Reservations",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_MealPlans_MealPlanID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomID",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "MealPlanPerSeasons");

            migrationBuilder.DropTable(
                name: "MealSeasonStartAndEndSeasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_RoomID",
                table: "Reservation",
                newName: "IX_Reservation_RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MealPlanID",
                table: "Reservation",
                newName: "IX_Reservation_MealPlanID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "ReservationID");

            migrationBuilder.CreateTable(
                name: "MealPlanSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealPlanID = table.Column<int>(type: "int", nullable: false),
                    RatePerPerson = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SeasonEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeasonStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealPlanSeasons_MealPlans_MealPlanID",
                        column: x => x.MealPlanID,
                        principalTable: "MealPlans",
                        principalColumn: "MealPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanSeasons_MealPlanID",
                table: "MealPlanSeasons",
                column: "MealPlanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_MealPlans_MealPlanID",
                table: "Reservation",
                column: "MealPlanID",
                principalTable: "MealPlans",
                principalColumn: "MealPlanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Rooms_RoomID",
                table: "Reservation",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

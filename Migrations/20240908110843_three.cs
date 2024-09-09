using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Reservation.Migrations
{
    /// <inheritdoc />
    public partial class three : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealPlanSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeasonEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RatePerPerson = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MealPlanID = table.Column<int>(type: "int", nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealPlanSeasons");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Reservation.Migrations
{
    /// <inheritdoc />
    public partial class changeRoomName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomType",
                table: "Rooms",
                newName: "RoomTypeName");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Rooms",
                newName: "RoomTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomTypeName",
                table: "Rooms",
                newName: "RoomType");

            migrationBuilder.RenameColumn(
                name: "RoomTypeId",
                table: "Rooms",
                newName: "RoomId");
        }
    }
}

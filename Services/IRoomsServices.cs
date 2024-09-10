using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel_Reservation.Services
{
    public interface IRoomsServices
    {
        IEnumerable<RoomSeason> GetAll();
        IEnumerable<RoomSeason> GetRoomById(int id);
        IEnumerable<SelectListItem> GetSelectList();
        string GetRoomNameById(int roomId);
        decimal RoomPriceForReservation(DateTime checkInDate, DateTime checkOutDate, int roomTypeId, int numberOfGuests);
    }
}

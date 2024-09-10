using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel_Reservation.Services
{
    public interface IRoomsServices
    {
        IEnumerable<RoomSeason> GetAll();
        IEnumerable<RoomSeason> GetRoomById(int id);
        IEnumerable<SelectListItem> GetSelectList();
        decimal GetPriceForRooms(int roomTypeId, DateTime checkInDate, DateTime checkOutDate);
        string GetRoomNameById(int roomId);
    }
}

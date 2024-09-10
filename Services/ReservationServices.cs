using Hotel_Reservation.Data;
using Hotel_Reservation.Models;
using System.Runtime.InteropServices.JavaScript;

namespace Hotel_Reservation.Services
{
    public class ReservationServices : IReservationServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMealPlansServices _mealServices;
        private readonly IRoomsServices _roomsServices;

        public ReservationServices(ApplicationDbContext context, IRoomsServices roomsServices, IMealPlansServices mealServices)
        {
            _context = context;
            _roomsServices = roomsServices;
            _mealServices = mealServices;
        }

        public decimal GetReservationTotal(DateTime checkInDate, DateTime checkOutDate, int numberOfAdult, int numberOfChildren, int roomType, int mealPlan)
        {
            decimal total = 0;
            total += _roomsServices.RoomPriceForReservation(checkInDate,  checkOutDate,  roomType, numberOfAdult);
            total += _mealServices.MealPriceForReservation(checkInDate, checkOutDate, mealPlan, numberOfAdult, numberOfChildren); 

            return total;
        }

        
       



    }
}

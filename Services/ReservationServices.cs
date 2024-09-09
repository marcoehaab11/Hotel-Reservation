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
            total += RoomPriceForReservation(checkInDate,  checkOutDate,  roomType, numberOfAdult);
            total += MealPriceForReservation(checkInDate, checkOutDate, mealPlan, numberOfAdult, numberOfChildren); 

            return total;
        }

        public decimal RoomPriceForReservation(DateTime checkInDate, DateTime checkOutDate, int roomType, int numberOfGuests)
        {
            return numberOfGuests * RoomPriceForOnePerson(checkInDate, checkOutDate, roomType);
        }
        public decimal MealPriceForReservation(DateTime checkInDate, DateTime checkOutDate, int mealPlan, int numberOfAdult, int numberOfChildren)
        {
            return (numberOfAdult+ numberOfChildren) * MealPriceForOnePerson(checkInDate, checkOutDate, mealPlan);
        }

        public decimal RoomPriceForOnePerson(DateTime checkInDate, DateTime checkOutDate, int roomType)
        {
            return _roomsServices.GetPriceForRooms(roomType, checkInDate, checkOutDate);
        }
        public decimal MealPriceForOnePerson(DateTime checkInDate, DateTime checkOutDate, int mealPlan)
        {
            return _mealServices.GetPriceForMeals(mealPlan, checkInDate, checkOutDate);
        }



    }
}

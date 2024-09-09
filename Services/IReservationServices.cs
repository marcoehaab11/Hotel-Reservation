using Hotel_Reservation.Models;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotel_Reservation.Services
{
    public interface IReservationServices
    {
       decimal GetReservationTotal(DateTime checkInDate, DateTime checkOutDate, int numberOfAdult, int numberOfChildren, int roomType,int mealPlan);
    }
}

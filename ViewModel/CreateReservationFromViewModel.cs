using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation.ViewModel
{
    public class CreateReservationFromViewModel
    {

        [Range(1, 2,ErrorMessage = "The number of adults must be between 1 and 2")]
        public int NumberOfAdult { get; set; }
        [Range(0, 2, ErrorMessage = "The number of Children between 1 and 2 only")]
        public int NumberOfChildren { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int RoomTypeId { get; set; }
        public int MealPlanId { get; set; }
        public IEnumerable<SelectListItem> RoomTypies { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> MealPlans { get; set; } = Enumerable.Empty<SelectListItem>();


    }
}

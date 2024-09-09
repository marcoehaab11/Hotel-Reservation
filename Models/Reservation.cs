using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Reservation.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        [Range(1,2)]
        public int NumberOfAdult { get; set; }
        [Range(0,2)]
        public int NumberOfChildren { get; set; }

        [ForeignKey("Room")]
        public int RoomID { get; set; }
        [ForeignKey("MealPlan")]
        public int MealPlanID { get; set; }

        public Room Room { get; set; }
        public MealPlan MealPlan { get; set; } 
   

    }
}

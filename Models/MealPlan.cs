using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;

namespace Hotel_Reservation.Models
{
    public class MealPlan
    {
        public int MealPlanId { get; set; }
        public string MealPlanName { get; set; }


        public ICollection<Reservation> Reservations { get; set; }

        public ICollection<MealPlanPerSeason> MealPlanPerSeason { get; set; }

    }
}

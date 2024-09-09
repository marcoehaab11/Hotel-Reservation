using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Reservation.Models
{
    public class MealPlanPerSeason
    {   
     
        public int MealPlanID { get; set; }
        public MealPlan MealPlan { get; set; }



      
        public int MealSeasonStartAndEndID { get; set; }
        public MealSeasonStartAndEnd MealSeasonStartAndEnd { get; set; }


        public decimal RatePerPerson { get; set; }





    }
}

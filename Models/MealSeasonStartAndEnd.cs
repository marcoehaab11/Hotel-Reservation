using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation.Models
{
    public class MealSeasonStartAndEnd
    {
        [Key]
        public int MealSeasonId { get; set; }
        public string SeasonName { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }

        public ICollection<MealPlanPerSeason> MealPlanPerSeason { get; set; }


    }
}

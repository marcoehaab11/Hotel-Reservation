using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation.Models
{
    public class RoomSeasonStartAndEnd
    {
        [Key]
        public int SeasonId { get; set; }
        public string SeasonName { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }

        public ICollection<RoomSeason> RoomSeasons { get; set; }
    }
}

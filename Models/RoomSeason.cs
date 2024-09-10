namespace Hotel_Reservation.Models
{
    public class RoomSeason
    {
        public int RoomTypeId { get; set; }
        public RoomType Rooms { get; set; }

        public int RoomSeasonStartAndEndID { get; set; }
        public RoomSeasonStartAndEnd RoomSeasonStartAndEnds { get; set; }

        public decimal RatePerRoom { get; set; }

    }
}

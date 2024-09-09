namespace Hotel_Reservation.Models
{
    public class Room
    {
        public int RoomId { get; set; } 
        public string RoomType { get; set; }
       

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<RoomSeason> RoomSeasons { get; set; }


    }
}

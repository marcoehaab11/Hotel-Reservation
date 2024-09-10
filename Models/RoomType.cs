namespace Hotel_Reservation.Models
{
    public class RoomType
    {
        
        public int RoomTypeId { get; set; } 
        public string RoomTypeName { get; set; }
       

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<RoomSeason> RoomSeasons { get; set; }


    }
}

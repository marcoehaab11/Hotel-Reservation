namespace Hotel_Reservation.ViewModel
{
    public class InvoiceInformationViewModel
    {
        public string RoomType { get; set; }
        public string MealPlanType { get; set; }

        public int NumberOfAdult{ get; set; }

        public int NumberOfChildren { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        
        public decimal Total {  get; set; } 
    }
}

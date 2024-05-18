namespace Hotel_Booking.Shared
{
    public class Reservation
    {
        public int Id_Reservation { get; set; }
        public string? Id_Customer { get; set; }
        public string? Id_Room { get; set; }
        public string? Checkin { get; set; }
        public string? Checkout { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
    }
}
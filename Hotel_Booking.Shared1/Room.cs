namespace Hotel_Booking.Shared
{
    public class Room
    {
        public int Id_Room { get; set; }
        public string? Status { get; set; }
        public string? Id_Category { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
    }
}
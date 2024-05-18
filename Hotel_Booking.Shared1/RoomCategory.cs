namespace Hotel_Booking.Shared
{
    public class Room_Category
    {
        public int Id_Category { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
    }
}
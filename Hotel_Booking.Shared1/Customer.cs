namespace Hotel_Booking.Shared
{
    public class Customer
    {
        public int Id_customer { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
    }
}
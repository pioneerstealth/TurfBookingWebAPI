namespace TurfBooking.Models
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int Duration { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } // Assuming you want to include the user's name
        public int TurfId { get; set; }
        public string TurfName { get; set; } // Assuming you want to include the turf's name
    }
    public class NewBookingDTO {
        public DateTime BookingDate { get; set; }
        public int Duration { get; set; }


        public int UserId { get; set; }
        public int TurfId { get; set; }

    }


}

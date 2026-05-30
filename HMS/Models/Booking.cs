namespace HMS.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime? ActualCheckIn { get; set; }
        public DateTime? ActualCheckOut { get; set; }
        public int Adults { get; set; } = 1;
        public int Children { get; set; } = 0;
        public string Status { get; set; } = "Reserved";
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        // Navigation / display
        public string CustomerName { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }

        public int Nights => (CheckOutDate - CheckInDate).Days;
        public decimal Balance => TotalAmount - PaidAmount;

        public static readonly string[] Statuses = { "Reserved", "Checked-In", "Checked-Out", "Cancelled" };
    }
}

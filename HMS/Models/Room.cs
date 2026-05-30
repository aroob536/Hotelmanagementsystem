namespace HMS.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public int Floor { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; } = "Available";
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public static readonly string[] Types = { "Standard", "Deluxe", "Suite", "Presidential Suite" };
        public static readonly string[] Statuses = { "Available", "Occupied", "Reserved", "Under Maintenance" };
    }
}

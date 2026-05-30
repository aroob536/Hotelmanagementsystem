namespace HMS.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Cnic { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string Nationality { get; set; } = "Pakistani";
        public DateTime CreatedDate { get; set; }
    }
}

namespace HMS.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public int BookingId { get; set; }
        public decimal RoomCharges { get; set; }
        public decimal ExtraCharges { get; set; }
        public decimal TaxPercent { get; set; } = 10;
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaymentMethod { get; set; } = "Cash";
        public DateTime BillDate { get; set; }
        public string? Notes { get; set; }

        // Display
        public string CustomerName { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public decimal Balance => TotalAmount - PaidAmount;
    }
}

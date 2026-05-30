using System.Data.SQLite;
using HMS.Models;

namespace HMS.Database
{
    public class BillRepository : BaseRepository
    {
        private const string SelectJoin = @"
            SELECT
                bl.bill_id, bl.booking_id,
                bl.room_charges, bl.extra_charges, bl.tax_percent,
                bl.discount, bl.total_amount, bl.paid_amount,
                bl.payment_method, bl.bill_date, bl.notes,
                c.full_name   AS customer_name,
                r.room_number
            FROM Bills bl
            INNER JOIN Bookings  b ON bl.booking_id = b.booking_id
            INNER JOIN Customers c ON b.customer_id = c.customer_id
            INNER JOIN Rooms     r ON b.room_id      = r.room_id";

        public List<Bill> GetAll() =>
            ExecuteList(SelectJoin + " ORDER BY bl.bill_id DESC", MapBill);

        public Bill? GetById(int id) =>
            ExecuteSingle(SelectJoin + " WHERE bl.bill_id=@id", MapBill,
                [new SQLiteParameter("@id", id)]);

        public Bill? GetByBookingId(int bookingId) =>
            ExecuteSingle(SelectJoin + " WHERE bl.booking_id=@bid", MapBill,
                [new SQLiteParameter("@bid", bookingId)]);

        // ── INSERT ───────────────────────────────────────────────────────────
        public int Add(Bill b)
        {
            string billDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using var conn = GetConnection();
            conn.Open();

            const string sql = @"
                INSERT INTO Bills
                    (booking_id, room_charges, extra_charges, tax_percent,
                     discount, total_amount, paid_amount, payment_method,
                     bill_date, notes)
                VALUES
                    (@bid, @rc, @ec, @tp,
                     @dc, @ta, @pa, @pm,
                     @bd, @no)";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@bid", b.BookingId);
            cmd.Parameters.AddWithValue("@rc",  (double)b.RoomCharges);
            cmd.Parameters.AddWithValue("@ec",  (double)b.ExtraCharges);
            cmd.Parameters.AddWithValue("@tp",  (double)b.TaxPercent);
            cmd.Parameters.AddWithValue("@dc",  (double)b.Discount);
            cmd.Parameters.AddWithValue("@ta",  (double)b.TotalAmount);
            cmd.Parameters.AddWithValue("@pa",  (double)b.PaidAmount);
            cmd.Parameters.AddWithValue("@pm",  b.PaymentMethod ?? "Cash");
            cmd.Parameters.AddWithValue("@bd",  billDate);
            cmd.Parameters.AddWithValue("@no",  (object?)b.Notes ?? DBNull.Value);

            int rows = cmd.ExecuteNonQuery();
            if (rows <= 0) return 0;

            using var idCmd = new SQLiteCommand("SELECT last_insert_rowid()", conn);
            return Convert.ToInt32(idCmd.ExecuteScalar());
        }

        // ── DELETE ───────────────────────────────────────────────────────────
        public bool Delete(int id)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand("DELETE FROM Bills WHERE bill_id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        // ── REVENUE — reads ALL bills, no date filter (avoids date format issues) ──
        public decimal GetTotalRevenue()
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(
                "SELECT COALESCE(SUM(total_amount), 0.0) FROM Bills", conn);
            var v = cmd.ExecuteScalar();
            if (v == null || v == DBNull.Value) return 0m;
            return Convert.ToDecimal(v);
        }

        // Daily revenue — today only
        public decimal GetDailyRevenue()
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(
                "SELECT COALESCE(SUM(total_amount), 0.0) FROM Bills " +
                "WHERE substr(bill_date, 1, 10) = @d", conn);
            cmd.Parameters.AddWithValue("@d", today);
            var v = cmd.ExecuteScalar();
            if (v == null || v == DBNull.Value) return 0m;
            return Convert.ToDecimal(v);
        }

        // ── MAPPER ───────────────────────────────────────────────────────────
        private Bill MapBill(SQLiteDataReader r) => new()
        {
            BillId        = GetInt(r,     "bill_id"),
            BookingId     = GetInt(r,     "booking_id"),
            RoomCharges   = GetDecimal(r, "room_charges"),
            ExtraCharges  = GetDecimal(r, "extra_charges"),
            TaxPercent    = GetDecimal(r, "tax_percent"),
            Discount      = GetDecimal(r, "discount"),
            TotalAmount   = GetDecimal(r, "total_amount"),
            PaidAmount    = GetDecimal(r, "paid_amount"),
            PaymentMethod = GetString(r,  "payment_method"),
            BillDate      = ParseDate(GetString(r, "bill_date")),
            Notes         = r.IsDBNull(r.GetOrdinal("notes"))
                              ? null : GetString(r, "notes"),
            CustomerName  = GetString(r, "customer_name"),
            RoomNumber    = GetString(r, "room_number")
        };

        private static DateTime ParseDate(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return DateTime.Now;
            return DateTime.TryParse(s, out var d) ? d : DateTime.Now;
        }
    }
}

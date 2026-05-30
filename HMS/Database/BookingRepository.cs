using System.Data;
using System.Data.SQLite;
using HMS.Models;

namespace HMS.Database
{
    public class BookingRepository : BaseRepository
    {
        private const string SelectJoin = @"
            SELECT
                b.booking_id, b.customer_id, b.room_id,
                b.check_in_date, b.check_out_date,
                b.actual_check_in, b.actual_check_out,
                b.adults, b.children, b.status,
                b.total_amount, b.paid_amount,
                b.notes, b.created_date, b.created_by,
                c.full_name      AS customer_name,
                r.room_number,
                r.room_type,
                r.price_per_night
            FROM Bookings b
            INNER JOIN Customers c ON b.customer_id = c.customer_id
            INNER JOIN Rooms     r ON b.room_id      = r.room_id";

        // ── Queries ─────────────────────────────────────────────────────────
        public List<Booking> GetAll() =>
            ExecuteList(SelectJoin + " ORDER BY b.booking_id DESC", MapBooking);

        public List<Booking> GetActive() =>
            ExecuteList(SelectJoin +
                " WHERE b.status IN ('Reserved','Checked-In') ORDER BY b.check_in_date",
                MapBooking);

        public Booking? GetById(int id) =>
            ExecuteSingle(SelectJoin + " WHERE b.booking_id = @id", MapBooking,
                [new SQLiteParameter("@id", id)]);

        public List<Booking> GetByCustomer(int customerId) =>
            ExecuteList(SelectJoin +
                " WHERE b.customer_id = @cid ORDER BY b.booking_id DESC",
                MapBooking, [new SQLiteParameter("@cid", customerId)]);

        public List<Booking> GetCheckedIn() =>
            ExecuteList(SelectJoin +
                " WHERE b.status = 'Checked-In' ORDER BY b.check_in_date",
                MapBooking);

        // Returns Checked-Out bookings (for billing)
        public List<Booking> GetCheckedOut() =>
            ExecuteList(SelectJoin +
                " WHERE b.status = 'Checked-Out' ORDER BY b.check_out_date DESC",
                MapBooking);

        // ── Insert ──────────────────────────────────────────────────────────
        public int Add(Booking b)
        {
            using var conn = GetConnection();
            conn.Open();

            string sql = @"
                INSERT INTO Bookings
                    (customer_id, room_id, check_in_date, check_out_date,
                     adults, children, status, total_amount, paid_amount,
                     notes, created_date, created_by)
                VALUES
                    (@ci, @ri, @chid, @chod,
                     @ad, @ch, @st, @ta, @pa,
                     @no, @cd, @cb)";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ci",   b.CustomerId);
            cmd.Parameters.AddWithValue("@ri",   b.RoomId);
            cmd.Parameters.AddWithValue("@chid", b.CheckInDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@chod", b.CheckOutDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@ad",   b.Adults);
            cmd.Parameters.AddWithValue("@ch",   b.Children);
            cmd.Parameters.AddWithValue("@st",   b.Status);
            cmd.Parameters.AddWithValue("@ta",   (double)b.TotalAmount);
            cmd.Parameters.AddWithValue("@pa",   (double)b.PaidAmount);
            cmd.Parameters.AddWithValue("@no",   (object?)b.Notes ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@cd",   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@cb",   (object?)b.CreatedBy ?? DBNull.Value);

            int rows = cmd.ExecuteNonQuery();
            if (rows <= 0) return 0;

            using var idCmd = new SQLiteCommand("SELECT last_insert_rowid()", conn);
            return Convert.ToInt32(idCmd.ExecuteScalar());
        }

        // ── Update ──────────────────────────────────────────────────────────
        public bool Update(Booking b)
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = @"
                UPDATE Bookings SET
                    customer_id   = @ci,
                    room_id       = @ri,
                    check_in_date = @chid,
                    check_out_date= @chod,
                    adults        = @ad,
                    children      = @ch,
                    status        = @st,
                    total_amount  = @ta,
                    paid_amount   = @pa,
                    notes         = @no
                WHERE booking_id = @id";
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ci",   b.CustomerId);
            cmd.Parameters.AddWithValue("@ri",   b.RoomId);
            cmd.Parameters.AddWithValue("@chid", b.CheckInDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@chod", b.CheckOutDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@ad",   b.Adults);
            cmd.Parameters.AddWithValue("@ch",   b.Children);
            cmd.Parameters.AddWithValue("@st",   b.Status);
            cmd.Parameters.AddWithValue("@ta",   (double)b.TotalAmount);
            cmd.Parameters.AddWithValue("@pa",   (double)b.PaidAmount);
            cmd.Parameters.AddWithValue("@no",   (object?)b.Notes ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@id",   b.BookingId);
            return cmd.ExecuteNonQuery() > 0;
        }

        // ── Status changes ───────────────────────────────────────────────────
        public bool CheckIn(int bookingId)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(
                "UPDATE Bookings SET status='Checked-In', actual_check_in=@d WHERE booking_id=@id", conn);
            cmd.Parameters.AddWithValue("@d",  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@id", bookingId);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool CheckOut(int bookingId)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(
                "UPDATE Bookings SET status='Checked-Out', actual_check_out=@d WHERE booking_id=@id", conn);
            cmd.Parameters.AddWithValue("@d",  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@id", bookingId);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Cancel(int bookingId)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(
                "UPDATE Bookings SET status='Cancelled' WHERE booking_id=@id", conn);
            cmd.Parameters.AddWithValue("@id", bookingId);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(
                "DELETE FROM Bookings WHERE booking_id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        // ── Dashboard stats ──────────────────────────────────────────────────
        public int GetTodayCheckIns()
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(
                "SELECT COUNT(*) FROM Bookings WHERE date(check_in_date)=@d AND status IN('Reserved','Checked-In')",
                conn);
            cmd.Parameters.AddWithValue("@d", today);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int GetTodayCheckOuts()
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(
                "SELECT COUNT(*) FROM Bookings WHERE date(check_out_date)=@d AND status='Checked-Out'",
                conn);
            cmd.Parameters.AddWithValue("@d", today);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // Dashboard monthly revenue comes from Bills table — handled by BillRepository
        public decimal GetMonthlyRevenue()
        {
            string month = DateTime.Now.ToString("yyyy-MM");
            using var conn = GetConnection();
            conn.Open();
            // Pull from Bills table for accurate revenue
            using var cmd = new SQLiteCommand(
                @"SELECT COALESCE(SUM(bl.total_amount), 0)
                  FROM Bills bl
                  WHERE strftime('%Y-%m', bl.bill_date) = @m",
                conn);
            cmd.Parameters.AddWithValue("@m", month);
            var result = cmd.ExecuteScalar();
            return result == null || result == DBNull.Value ? 0m : Convert.ToDecimal(result);
        }

        // ── Mapper ──────────────────────────────────────────────────────────
        private Booking MapBooking(SQLiteDataReader r)
        {
            DateTime ParseDate(string col)
            {
                int i = r.GetOrdinal(col);
                if (r.IsDBNull(i)) return DateTime.Today;
                return DateTime.TryParse(r.GetString(i), out var d) ? d : DateTime.Today;
            }

            return new Booking
            {
                BookingId     = GetInt(r, "booking_id"),
                CustomerId    = GetInt(r, "customer_id"),
                RoomId        = GetInt(r, "room_id"),
                CheckInDate   = ParseDate("check_in_date"),
                CheckOutDate  = ParseDate("check_out_date"),
                ActualCheckIn = r.IsDBNull(r.GetOrdinal("actual_check_in"))
                                    ? null : ParseDate("actual_check_in"),
                ActualCheckOut= r.IsDBNull(r.GetOrdinal("actual_check_out"))
                                    ? null : ParseDate("actual_check_out"),
                Adults        = GetInt(r, "adults"),
                Children      = GetInt(r, "children"),
                Status        = GetString(r, "status"),
                TotalAmount   = GetDecimal(r, "total_amount"),
                PaidAmount    = GetDecimal(r, "paid_amount"),
                Notes         = r.IsDBNull(r.GetOrdinal("notes")) ? null : GetString(r, "notes"),
                CreatedDate   = ParseDate("created_date"),
                CustomerName  = GetString(r, "customer_name"),
                RoomNumber    = GetString(r, "room_number"),
                RoomType      = GetString(r, "room_type"),
                PricePerNight = GetDecimal(r, "price_per_night")
            };
        }
    }
}

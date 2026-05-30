using System.Data.SQLite;

namespace HMS.Database
{
    public static class DbInitializer
    {
        public static void Initialize()
        {
            string dir = Path.GetDirectoryName(DbConnection.DatabasePath)!;
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!File.Exists(DbConnection.DatabasePath))
                SQLiteConnection.CreateFile(DbConnection.DatabasePath);

            using var conn = DbConnection.GetConnection();
            conn.Open();

            // Enable foreign keys
            Exec(conn, "PRAGMA foreign_keys = ON;");

            // ── Create tables ────────────────────────────────────────────────
            Exec(conn, @"CREATE TABLE IF NOT EXISTS Users (
                user_id       INTEGER PRIMARY KEY AUTOINCREMENT,
                username      TEXT NOT NULL UNIQUE,
                password_hash TEXT NOT NULL,
                full_name     TEXT NOT NULL,
                role          TEXT NOT NULL DEFAULT 'staff',
                email         TEXT,
                is_active     INTEGER NOT NULL DEFAULT 1,
                created_date  TEXT NOT NULL,
                last_login    TEXT
            );");

            Exec(conn, @"CREATE TABLE IF NOT EXISTS Rooms (
                room_id         INTEGER PRIMARY KEY AUTOINCREMENT,
                room_number     TEXT NOT NULL UNIQUE,
                room_type       TEXT NOT NULL,
                floor           INTEGER NOT NULL DEFAULT 1,
                price_per_night REAL NOT NULL,
                capacity        INTEGER NOT NULL DEFAULT 2,
                status          TEXT NOT NULL DEFAULT 'Available',
                description     TEXT,
                created_date    TEXT NOT NULL
            );");

            Exec(conn, @"CREATE TABLE IF NOT EXISTS Customers (
                customer_id  INTEGER PRIMARY KEY AUTOINCREMENT,
                full_name    TEXT NOT NULL,
                cnic         TEXT,
                phone        TEXT NOT NULL,
                email        TEXT,
                address      TEXT,
                nationality  TEXT DEFAULT 'Pakistani',
                created_date TEXT NOT NULL
            );");

            Exec(conn, @"CREATE TABLE IF NOT EXISTS Bookings (
                booking_id      INTEGER PRIMARY KEY AUTOINCREMENT,
                customer_id     INTEGER NOT NULL,
                room_id         INTEGER NOT NULL,
                check_in_date   TEXT NOT NULL,
                check_out_date  TEXT NOT NULL,
                actual_check_in  TEXT,
                actual_check_out TEXT,
                adults          INTEGER NOT NULL DEFAULT 1,
                children        INTEGER NOT NULL DEFAULT 0,
                status          TEXT NOT NULL DEFAULT 'Reserved',
                total_amount    REAL NOT NULL DEFAULT 0,
                paid_amount     REAL NOT NULL DEFAULT 0,
                notes           TEXT,
                created_date    TEXT NOT NULL,
                created_by      INTEGER,
                FOREIGN KEY(customer_id) REFERENCES Customers(customer_id),
                FOREIGN KEY(room_id)     REFERENCES Rooms(room_id)
            );");

            // Bills — NO UNIQUE on booking_id
            Exec(conn, @"CREATE TABLE IF NOT EXISTS Bills (
                bill_id        INTEGER PRIMARY KEY AUTOINCREMENT,
                booking_id     INTEGER NOT NULL,
                room_charges   REAL NOT NULL DEFAULT 0,
                extra_charges  REAL NOT NULL DEFAULT 0,
                tax_percent    REAL NOT NULL DEFAULT 10,
                discount       REAL NOT NULL DEFAULT 0,
                total_amount   REAL NOT NULL DEFAULT 0,
                paid_amount    REAL NOT NULL DEFAULT 0,
                payment_method TEXT DEFAULT 'Cash',
                bill_date      TEXT NOT NULL,
                notes          TEXT,
                FOREIGN KEY(booking_id) REFERENCES Bookings(booking_id)
            );");

            // ── Auto-migrate: remove UNIQUE constraint on Bills.booking_id ───
            try
            {
                using var chk = new SQLiteCommand(
                    "SELECT sql FROM sqlite_master WHERE type='table' AND name='Bills'", conn);
                string? tblSql = chk.ExecuteScalar()?.ToString() ?? "";
                if (tblSql.Contains("UNIQUE") || tblSql.Contains("unique"))
                {
                    using var tx = conn.BeginTransaction();
                    Exec(conn, "ALTER TABLE Bills RENAME TO _Bills_bak;");
                    Exec(conn, @"CREATE TABLE Bills (
                        bill_id        INTEGER PRIMARY KEY AUTOINCREMENT,
                        booking_id     INTEGER NOT NULL,
                        room_charges   REAL NOT NULL DEFAULT 0,
                        extra_charges  REAL NOT NULL DEFAULT 0,
                        tax_percent    REAL NOT NULL DEFAULT 10,
                        discount       REAL NOT NULL DEFAULT 0,
                        total_amount   REAL NOT NULL DEFAULT 0,
                        paid_amount    REAL NOT NULL DEFAULT 0,
                        payment_method TEXT DEFAULT 'Cash',
                        bill_date      TEXT NOT NULL,
                        notes          TEXT,
                        FOREIGN KEY(booking_id) REFERENCES Bookings(booking_id)
                    );");
                    Exec(conn, "INSERT INTO Bills SELECT * FROM _Bills_bak;");
                    Exec(conn, "DROP TABLE _Bills_bak;");
                    tx.Commit();
                }
            }
            catch { /* migration is best-effort */ }

            // ── Seed admin ───────────────────────────────────────────────────
            using var uc = new SQLiteCommand("SELECT COUNT(*) FROM Users", conn);
            if (Convert.ToInt64(uc.ExecuteScalar()) == 0)
            {
                string hash = BCrypt.Net.BCrypt.HashPassword("admin123", 11);
                using var ui = new SQLiteCommand(
                    "INSERT INTO Users(username,password_hash,full_name,role,is_active,created_date)" +
                    " VALUES('admin',@h,'Administrator','admin',1,@d)", conn);
                ui.Parameters.AddWithValue("@h", hash);
                ui.Parameters.AddWithValue("@d", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ui.ExecuteNonQuery();
            }

            // ── Seed rooms ───────────────────────────────────────────────────
            using var rc = new SQLiteCommand("SELECT COUNT(*) FROM Rooms", conn);
            if (Convert.ToInt64(rc.ExecuteScalar()) == 0)
            {
                string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var rooms = new (string n, string t, int f, double p, int c)[]
                {
                    ("101","Standard",          1, 3500,  2),
                    ("102","Standard",          1, 3500,  2),
                    ("103","Standard",          1, 3500,  2),
                    ("201","Deluxe",            2, 6000,  2),
                    ("202","Deluxe",            2, 6000,  2),
                    ("203","Deluxe",            2, 6500,  3),
                    ("301","Suite",             3, 12000, 4),
                    ("302","Suite",             3, 15000, 4),
                    ("401","Presidential Suite",4, 25000, 6),
                };
                foreach (var r in rooms)
                {
                    using var ri = new SQLiteCommand(
                        "INSERT INTO Rooms(room_number,room_type,floor,price_per_night,capacity,status,created_date)" +
                        " VALUES(@n,@t,@f,@p,@c,'Available',@d)", conn);
                    ri.Parameters.AddWithValue("@n", r.n);
                    ri.Parameters.AddWithValue("@t", r.t);
                    ri.Parameters.AddWithValue("@f", r.f);
                    ri.Parameters.AddWithValue("@p", r.p);
                    ri.Parameters.AddWithValue("@c", r.c);
                    ri.Parameters.AddWithValue("@d", now);
                    ri.ExecuteNonQuery();
                }
            }
        }

        private static void Exec(SQLiteConnection conn, string sql)
        {
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}

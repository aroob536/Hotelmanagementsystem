using System.Data.SQLite;

namespace HMS.Database
{
    public static class DbConnection
    {
        private static string _databasePath = string.Empty;
        private static string _connectionString = string.Empty;

        public static string DatabasePath
        {
            get
            {
                if (string.IsNullOrEmpty(_databasePath))
                {
                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    _databasePath = Path.Combine(baseDirectory, "Database", "hotel.sqlite");
                }
                return _databasePath;
            }
        }

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                    _connectionString = $"Data Source={DatabasePath};Version=3;";
                return _connectionString;
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                if (!File.Exists(DatabasePath)) return false;
                using var conn = GetConnection();
                conn.Open();
                return conn.State == System.Data.ConnectionState.Open;
            }
            catch { return false; }
        }
    }
}

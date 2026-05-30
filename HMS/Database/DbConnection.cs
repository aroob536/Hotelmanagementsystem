using System.Data.SQLite;

namespace HMS.Database
{
    //Manage SQLite database file path of application
    public static class DbConnection
    {
        private static string _databasePath = string.Empty;
        private static string _connectionString = string.Empty;

        //Build database path
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
        //Manage connection string
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                    _connectionString = $"Data Source={DatabasePath};Version=3;";
                return _connectionString;
            }
        }
        //Return new SQLite connection
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
        //Test connection with databse_used for startup check
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

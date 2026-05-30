using System.Data;
using System.Data.SQLite;

namespace HMS.Database
{//Base class of all repositories_provide common operations
    public abstract class BaseRepository
    {
        protected SQLiteConnection GetConnection() => DbConnection.GetConnection();
        // Reyurn SQL command that does not return any data
        protected int ExecuteNonQuery(string sql, SQLiteParameter[]? parameters = null)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(sql, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }
        //execute query which return single value
        protected object ExecuteScalar(string sql, SQLiteParameter[]? parameters = null)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(sql, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar()!;
        }
        //Execute query which return multiple values
        protected DataTable ExecuteReader(string sql, SQLiteParameter[]? parameters = null)
        {
            var dt = new DataTable();
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(sql, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            using var adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        //Return single object_convert row to model using mapper function
        protected T? ExecuteSingle<T>(string sql, Func<SQLiteDataReader, T> mapper, SQLiteParameter[]? parameters = null)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(sql, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? mapper(reader) : default;
        }
        //Return list of objects
        protected List<T> ExecuteList<T>(string sql, Func<SQLiteDataReader, T> mapper, SQLiteParameter[]? parameters = null)
        {
            var results = new List<T>();
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(sql, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) results.Add(mapper(reader));
            return results;
        }
        // Getter methods used to get private values
        protected string GetString(SQLiteDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? string.Empty : r.GetString(i);
        }
        protected int GetInt(SQLiteDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? 0 : r.GetInt32(i);
        }
        protected decimal GetDecimal(SQLiteDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? 0m : r.GetDecimal(i);
        }
        protected DateTime GetDateTime(SQLiteDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? DateTime.MinValue : DateTime.Parse(r.GetString(i));
        }
        protected bool GetBool(SQLiteDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return !r.IsDBNull(i) && r.GetInt32(i) == 1;
        }
    }
}

using System.Data;
using System.Data.SQLite;

namespace HMS.Database
{
    public abstract class BaseRepository
    {
        protected SQLiteConnection GetConnection() => DbConnection.GetConnection();

        protected int ExecuteNonQuery(string sql, SQLiteParameter[]? parameters = null)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(sql, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }

        protected object ExecuteScalar(string sql, SQLiteParameter[]? parameters = null)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(sql, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar()!;
        }

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

        protected T? ExecuteSingle<T>(string sql, Func<SQLiteDataReader, T> mapper, SQLiteParameter[]? parameters = null)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand(sql, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? mapper(reader) : default;
        }

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

using System.Data.SQLite;
using HMS.Models;

namespace HMS.Database
{
    public class UserRepository : BaseRepository
    {
        public User? Authenticate(string username, string password)
        {
            string sql = "SELECT * FROM Users WHERE username=@u AND is_active=1";
            var user = ExecuteSingle(sql, MapUser, [new SQLiteParameter("@u", username)]);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                ExecuteNonQuery("UPDATE Users SET last_login=@d WHERE user_id=@id",
                    [new("@d", DateTime.Now.ToString("o")), new("@id", user.UserId)]);
                return user;
            }
            return null;
        }

        public List<User> GetAll() => ExecuteList("SELECT * FROM Users ORDER BY full_name", MapUser);

        public User? GetById(int id) => ExecuteSingle("SELECT * FROM Users WHERE user_id=@id", MapUser, [new("@id", id)]);

        public bool Add(User u, string plainPwd)
        {
            if (UsernameExists(u.Username)) return false;
            string hash = BCrypt.Net.BCrypt.HashPassword(plainPwd, 11);
            return ExecuteNonQuery(@"INSERT INTO Users(username,password_hash,full_name,role,email,is_active,created_date)
                VALUES(@un,@ph,@fn,@ro,@em,@ia,@cd)",
                [new("@un",u.Username),new("@ph",hash),new("@fn",u.FullName),new("@ro",u.Role),
                 new("@em",(object?)u.Email??DBNull.Value),new("@ia",u.IsActive?1:0),new("@cd",DateTime.Now.ToString("o"))]) > 0;
        }

        public bool Update(User u)
        {
            return ExecuteNonQuery(@"UPDATE Users SET username=@un,full_name=@fn,role=@ro,email=@em,is_active=@ia WHERE user_id=@id",
                [new("@un",u.Username),new("@fn",u.FullName),new("@ro",u.Role),
                 new("@em",(object?)u.Email??DBNull.Value),new("@ia",u.IsActive?1:0),new("@id",u.UserId)]) > 0;
        }

        public bool ChangePassword(int userId, string current, string newPwd)
        {
            var u = GetById(userId);
            if (u == null || !BCrypt.Net.BCrypt.Verify(current, u.PasswordHash)) return false;
            string hash = BCrypt.Net.BCrypt.HashPassword(newPwd, 11);
            return ExecuteNonQuery("UPDATE Users SET password_hash=@h WHERE user_id=@id",
                [new("@h", hash), new("@id", userId)]) > 0;
        }

        public bool Delete(int id) => ExecuteNonQuery("DELETE FROM Users WHERE user_id=@id", [new("@id", id)]) > 0;

        public bool UsernameExists(string username)
        {
            long c = Convert.ToInt64(ExecuteScalar("SELECT COUNT(*) FROM Users WHERE username=@u", [new("@u", username)]));
            return c > 0;
        }

        private User MapUser(SQLiteDataReader r) => new()
        {
            UserId = GetInt(r, "user_id"),
            Username = GetString(r, "username"),
            PasswordHash = GetString(r, "password_hash"),
            FullName = GetString(r, "full_name"),
            Role = GetString(r, "role"),
            Email = r.IsDBNull(r.GetOrdinal("email")) ? null : GetString(r, "email"),
            IsActive = GetBool(r, "is_active"),
            CreatedDate = GetDateTime(r, "created_date"),
            LastLogin = r.IsDBNull(r.GetOrdinal("last_login")) ? null : GetDateTime(r, "last_login")
        };
    }
}

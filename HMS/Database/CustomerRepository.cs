using System.Data;
using System.Data.SQLite;
using HMS.Models;

namespace HMS.Database
{//All database operation for customer tables
    public class CustomerRepository : BaseRepository
    {// get customers in alphabetical order
        public List<Customer> GetAll() =>
            ExecuteList("SELECT * FROM Customers ORDER BY full_name", MapCustomer);
        // get customer by id
        public Customer? GetById(int id) =>
            ExecuteSingle("SELECT * FROM Customers WHERE customer_id=@id", MapCustomer,
                [new("@id", id)]);

        public List<Customer> Search(string q)
        {
            string like = $"%{q}%";
            return ExecuteList(
                "SELECT * FROM Customers WHERE full_name LIKE @q OR phone LIKE @q OR cnic LIKE @q ORDER BY full_name",
                MapCustomer, [new("@q", like)]);
        }
        //add new customer in database
        public bool Add(Customer c)
        {
            return ExecuteNonQuery(
                @"INSERT INTO Customers(full_name, cnic, phone, email, address, nationality, created_date)
                  VALUES(@fn, @cn, @ph, NULL, NULL, @na, @dt)",
                [
                    new("@fn", c.FullName),
                    new("@cn", (object?)c.Cnic ?? DBNull.Value),
                    new("@ph", c.Phone),
                    new("@na", c.Nationality),
                    new("@dt", DateTime.Now.ToString("o"))
                ]) > 0;
        }
        //update customer details
        public bool Update(Customer c)
        {
            return ExecuteNonQuery(
                @"UPDATE Customers
                  SET full_name=@fn, cnic=@cn, phone=@ph, nationality=@na
                  WHERE customer_id=@id",
                [
                    new("@fn", c.FullName),
                    new("@cn", (object?)c.Cnic ?? DBNull.Value),
                    new("@ph", c.Phone),
                    new("@na", c.Nationality),
                    new("@id", c.CustomerId)
                ]) > 0;
        }
        // delete customer_but if customer has booking then not delete
        public bool Delete(int id) =>
            ExecuteNonQuery("DELETE FROM Customers WHERE customer_id=@id",
                [new("@id", id)]) > 0;
        // return total count of customers
        public int GetTotalCount() =>
            Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM Customers"));

        private Customer MapCustomer(SQLiteDataReader r) => new()
        {
            CustomerId  = GetInt(r, "customer_id"),
            FullName    = GetString(r, "full_name"),
            Cnic        = r.IsDBNull(r.GetOrdinal("cnic"))    ? null : GetString(r, "cnic"),
            Phone       = GetString(r, "phone"),
            Email       = r.IsDBNull(r.GetOrdinal("email"))   ? null : GetString(r, "email"),
            Address     = r.IsDBNull(r.GetOrdinal("address")) ? null : GetString(r, "address"),
            Nationality = GetString(r, "nationality"),
            CreatedDate = GetDateTime(r, "created_date")
        };
    }
}

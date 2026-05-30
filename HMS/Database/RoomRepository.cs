using System.Data;
using System.Data.SQLite;
using HMS.Models;

namespace HMS.Database
{// Database operations for all room tables
    public class RoomRepository : BaseRepository
    {
        //Return all rooms
        public List<Room> GetAll() => ExecuteList("SELECT * FROM Rooms ORDER BY room_number", MapRoom);
        //Return available rooms
        public List<Room> GetAvailable() => ExecuteList("SELECT * FROM Rooms WHERE status='Available' ORDER BY room_number", MapRoom);
        //Return single room using room-id
        public Room? GetById(int id) => ExecuteSingle("SELECT * FROM Rooms WHERE room_id=@id", MapRoom, [new("@id", id)]);
        // return single room using room number
        public Room? GetByNumber(string number) => ExecuteSingle("SELECT * FROM Rooms WHERE room_number=@n", MapRoom, [new("@n", number)]);
        // Add new room to databse
        public bool Add(Room r)
        {
            return ExecuteNonQuery(@"INSERT INTO Rooms(room_number,room_type,floor,price_per_night,capacity,status,description,created_date)
                VALUES(@rn,@rt,@fl,@pr,@cp,@st,@ds,@dt)",
                [new("@rn",r.RoomNumber),new("@rt",r.RoomType),new("@fl",r.Floor),new("@pr",r.PricePerNight),
                 new("@cp",r.Capacity),new("@st",r.Status),new("@ds",(object?)r.Description??DBNull.Value),
                 new("@dt",DateTime.Now.ToString("o"))]) > 0;
        }
        //Update details of existing room
        public bool Update(Room r)
        {
            return ExecuteNonQuery(@"UPDATE Rooms SET room_number=@rn,room_type=@rt,floor=@fl,price_per_night=@pr,
                capacity=@cp,status=@st,description=@ds WHERE room_id=@id",
                [new("@rn",r.RoomNumber),new("@rt",r.RoomType),new("@fl",r.Floor),new("@pr",r.PricePerNight),
                 new("@cp",r.Capacity),new("@st",r.Status),new("@ds",(object?)r.Description??DBNull.Value),
                 new("@id",r.RoomId)]) > 0;
        }
        // Update status of room_Available/occupied/reserved
        public bool UpdateStatus(int id, string status)
            => ExecuteNonQuery("UPDATE Rooms SET status=@s WHERE room_id=@id", [new("@s", status), new("@id", id)]) > 0;
        //Delete room using id
        public bool Delete(int id) => ExecuteNonQuery("DELETE FROM Rooms WHERE room_id=@id", [new("@id", id)]) > 0;

        public DataTable GetSummary()
        {
            return ExecuteReader(@"SELECT room_type AS 'Room Type',
                SUM(CASE WHEN status='Available' THEN 1 ELSE 0 END) AS 'Available',
                SUM(CASE WHEN status='Occupied' THEN 1 ELSE 0 END) AS 'Occupied',
                SUM(CASE WHEN status='Reserved' THEN 1 ELSE 0 END) AS 'Reserved',
                SUM(CASE WHEN status='Under Maintenance' THEN 1 ELSE 0 END) AS 'Maintenance',
                COUNT(*) AS 'Total'
                FROM Rooms GROUP BY room_type");
        }

        private Room MapRoom(SQLiteDataReader r) => new()
        {
            RoomId = GetInt(r, "room_id"),
            RoomNumber = GetString(r, "room_number"),
            RoomType = GetString(r, "room_type"),
            Floor = GetInt(r, "floor"),
            PricePerNight = GetDecimal(r, "price_per_night"),
            Capacity = GetInt(r, "capacity"),
            Status = GetString(r, "status"),
            Description = r.IsDBNull(r.GetOrdinal("description")) ? null : GetString(r, "description"),
            CreatedDate = GetDateTime(r, "created_date")
        };
    }
}

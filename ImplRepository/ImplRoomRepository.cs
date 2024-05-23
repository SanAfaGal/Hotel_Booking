using Microsoft.Data.SqlClient;
using Hotel_Booking.Shared;
using System.Data;
using Repository;
using Dapper;
using System.Data.Common;

namespace ImplRepository
{
    public class ImplRoomRepository : IRoomRepository
    {
        private readonly IDbConnection _dbConnection;

        public ImplRoomRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<bool> DeleteRoom(string? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            try
            {
                string sql = @"
                SELECT r.id_room, r.room_status, rc.name_category, rc.description, rc.base_price 
                FROM tbl_rooms AS r
                INNER JOIN tbl_room_categories AS rc ON r.id_category = rc.id_category";

                var rooms = await _dbConnection.QueryAsync<Room>(sql);

                return rooms;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while retrieving all customers: {ex.Message}");
                return new List<Room>();
            }
        }

        public Task<IEnumerable<Room>> GetAvailableRooms()
        {
            return null;
        }

        public Task<Room> GetRoomById(string? id)
        {
            return null;
        }

        public Task<bool> UpdateRoom(string? id, Room? room)
        {
            return null;
        }
    }
}

using Hotel_Booking.Shared;

namespace Hotel_Booking.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<IEnumerable<Room>> GetAvailableRooms();
        Task<Room> GetRoomById(string? id);
        Task<bool> DeleteRoom(string? id);
        Task<bool> UpdateRoom(string? id, Room? room);
    }
}

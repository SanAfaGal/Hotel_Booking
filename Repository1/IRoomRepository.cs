using Hotel_Booking.Shared;
    
namespace Repository
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRoom();
        Task<IEnumerable<Room>> GetAvailableRooms();
        Task<Room> GetRoomById(string? id);
        //Task<bool> InsertRoom(Room? room);
        Task<bool> DeleteRoom(string? id);
        Task<bool> UpdateRoom(string? id, Room? room);
    }
}

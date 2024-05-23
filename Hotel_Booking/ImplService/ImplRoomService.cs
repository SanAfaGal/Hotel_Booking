using Hotel_Booking.Services;
using Hotel_Booking.Shared;
using Repository;

namespace Hotel_Booking.ImplService
{
    public class ImplRoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public ImplRoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _roomRepository.GetAllRooms();
        }

        public async Task<IEnumerable<Room>> GetAvailableRooms()
        {
            return await _roomRepository.GetAvailableRooms();
        }

        public async Task<Room> GetRoomById(string? id)
        {
            return await _roomRepository.GetRoomById(id);
        }

        public async Task<bool> DeleteRoom(string? id)
        {
            return await _roomRepository.DeleteRoom(id);
        }

        public async Task<bool> UpdateRoom(string? id, Room? room)
        {
            return await _roomRepository.UpdateRoom(id, room);
        }
    }
}

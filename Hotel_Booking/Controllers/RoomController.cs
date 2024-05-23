using Hotel_Booking.Services;
using Hotel_Booking.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRooms();
            return Ok(rooms);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var rooms = await _roomService.GetAvailableRooms();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(string id)
        {
            var room = await _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(string id)
        {
            var result = await _roomService.DeleteRoom(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(string id, [FromBody] Room room)
        {
            if (room == null)
            {
                return BadRequest();
            }
            var result = await _roomService.UpdateRoom(id, room);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}

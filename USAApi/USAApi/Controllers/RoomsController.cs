using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USAApi.Models;
using USAApi.Services;

namespace USAApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _service;
        public RoomsController(IRoomService service)
        {
            _service = service;
        }
        [HttpGet(Name = nameof(GetAllRooms))]
        public async Task<ActionResult<Collection<Room>>> GetAllRooms()
        {
            var rooms = await _service.GetAllRoomsAsync();
            var collection = new Collection<Room>
            {
                Self = Link.ToCollection(nameof(GetAllRooms)),
                Value = rooms.ToArray()
            };
            return collection;
        }

        // GET /rooms/{roomId}
        [HttpGet("{roomId}", Name = nameof(GetRoomById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Room>> GetRoomById(Guid roomId)
        {
            var room = await _service.GetRoomAsync(roomId);
            if(room == null) return NotFound();
            return Ok(room);
        }
    }
}

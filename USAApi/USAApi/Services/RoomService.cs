using Microsoft.EntityFrameworkCore;
using System;
using USAApi.Models;

namespace USAApi.Services
{
    public class RoomService : IRoomService
    {
        private readonly HotelApiDbContext _context;
        public RoomService(HotelApiDbContext context)
        {
            _context = context;
        }
        public async Task<Room> GetRoomAsync(Guid roomId)
        {
            var entity = await _context.Rooms.SingleOrDefaultAsync(x => x.Id == roomId);

            if(entity == null)
            {
                return null;
            }
            return new Room
            {
                Href = null, //Url.Link(nameof(GetRoomById), new { roomId = entity.Id }),
                Name = entity.Name,
                Rate = entity.Rate
            };
        }
    }
}

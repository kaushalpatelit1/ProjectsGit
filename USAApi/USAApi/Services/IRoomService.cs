using USAApi.Models;

namespace USAApi.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room> GetRoomAsync(Guid id);
    }
}

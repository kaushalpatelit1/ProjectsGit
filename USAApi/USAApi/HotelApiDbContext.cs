using Microsoft.EntityFrameworkCore;
using USAApi.Models;

namespace USAApi
{
    public class HotelApiDbContext : DbContext
    {
        public HotelApiDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<RoomEntity> Rooms { get; set; }
    }
}

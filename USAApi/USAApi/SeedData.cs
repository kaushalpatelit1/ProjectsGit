
using USAApi.Models;

namespace USAApi
{
    public static class SeedData
    {
        public static async Task Ininialize(IServiceProvider services)
        {
            await AddTestData(services.GetRequiredService<HotelApiDbContext>());
        }
        public static async Task AddTestData(HotelApiDbContext context)
        {
            if(context.Rooms.Any())
            {
                // Already has data
                return;
            }
            context.Rooms.Add(new RoomEntity
            {
                Id = Guid.Parse("7957315d-066f-430d-8096-d9b420809d97"),
                Name= "Marriot Suite",
                Rate = 100
            });
            context.Rooms.Add(new RoomEntity
            {
                Id = Guid.Parse("71427daf-8eec-4c85-866a-59825570ef62"),
                Name = "Economy Suite",
                Rate = 60
            });
            await context.SaveChangesAsync();
        }
    }
}

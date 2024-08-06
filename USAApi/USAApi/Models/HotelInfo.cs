namespace USAApi.Models
{
    public class HotelInfo : Resource
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public Address Location { get; set; }
    }
}

using Newtonsoft.Json;
using USAApi.Controllers;

namespace USAApi.Models
{
    public abstract class Resource : Link
    {
        [JsonIgnore]
        public Link Self { get; set; }
    }
}

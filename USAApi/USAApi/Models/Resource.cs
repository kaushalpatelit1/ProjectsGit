using Newtonsoft.Json;

namespace USAApi.Models
{
    public abstract class Resource 
    {
        [JsonProperty(Order = -2)]
        public string Href { get; set; }
    }
}

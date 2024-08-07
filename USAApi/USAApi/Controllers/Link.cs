using Newtonsoft.Json;
using System.ComponentModel;

namespace USAApi.Controllers
{
    public class Link
    {
        public const string GetMethod = "GET";
        public static Link To(string routeName, object routeValues = null)
        {
            return new Link
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = GetMethod,
                Relations = null
            };
        }

        [JsonProperty(Order =-4)] //setting the serialize order
        public string Href { get; set; }
        [JsonProperty(Order = -3, 
            PropertyName ="rel",
            NullValueHandling =NullValueHandling.Ignore)]
        public string[] Relations { get; set; }
        [JsonProperty(Order = -2,
            DefaultValueHandling =DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(GetMethod)]
        public string Method { get; set; }

        //Stores the route name and parameters before being rewritten by the LinkRewritingFilter
        [JsonIgnore] //ignoring from serialization
        public string RouteName { get; set; }
        [JsonIgnore]
        public object RouteValues { get; set; }
    }
}

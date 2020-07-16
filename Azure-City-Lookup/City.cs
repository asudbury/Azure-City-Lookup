using Newtonsoft.Json;

namespace Azure_City_Lookup
{
    public class City
    {
        [JsonProperty("c")]
        public string Country { get; set; }

        [JsonProperty("n")]
        public string Name { get; set; }
    }
}

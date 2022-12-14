using Newtonsoft.Json;

namespace WeatherAPI.DTO
{
    public class WindDTO
    {
        [JsonProperty("chill")]
        public string Chill { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("speed")]
        public string Speed { get; set; }
    }
}

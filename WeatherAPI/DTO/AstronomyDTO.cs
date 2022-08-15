using Newtonsoft.Json;

namespace WeatherAPI.DTO
{
    public class AstronomyDTO
    {
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }
    }
}

using Newtonsoft.Json;

namespace WeatherAPI.DTO
{
    public class AtmosphereDTO
    {
        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        [JsonProperty("rising")]
        public string Rising { get; set; }
    }
}

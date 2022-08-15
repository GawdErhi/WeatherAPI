using Newtonsoft.Json;

namespace WeatherAPI.DTO
{
    public class ConditionDTO
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("temperature")]
        public string Temperature { get; set; }
    }
}

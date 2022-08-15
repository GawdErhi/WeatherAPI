using Newtonsoft.Json;

namespace WeatherAPI.DTO
{
    public class WeatherObservationDTO
    {
        [JsonProperty("city")]
        public CityDTO City { get; set; }

        [JsonProperty("astronomy")]
        public AstronomyDTO Astronomy { get; set; }

        [JsonProperty("atmosphere")]
        public AtmosphereDTO Atmosphere { get; set; }

        [JsonProperty("condition")]
        public ConditionDTO Condition { get; set; }

        [JsonProperty("wind")]
        public WindDTO Wind { get; set; }

        [JsonProperty("pubDate")]
        public string DatePublished { get; set; }
    }
}

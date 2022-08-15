using Newtonsoft.Json;

namespace WeatherAPI.DTO
{
    public class CountryDTO
    {
        [JsonProperty("country")]
        public string Name { get; set; }

        [JsonProperty("alpha2")]
        public string TwoLetterCode { get; set; }

        [JsonProperty("alpha3")]
        public string ThreeLetterCode { get; set; }

        [JsonProperty("numeric")]
        public string Numeric { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }
}

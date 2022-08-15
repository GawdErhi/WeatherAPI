using Newtonsoft.Json;

namespace WeatherAPI.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }

        [JsonProperty("country")]
        public string CountryTwoLetterCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("lng")]
        public string Longitude { get; set; }

        public double LatCoords => (string.IsNullOrEmpty(Latitude)) ? 0 : double.Parse(Latitude);

        public double LongCoords => (string.IsNullOrEmpty(Longitude)) ? 0 : double.Parse(Longitude);
    }
}

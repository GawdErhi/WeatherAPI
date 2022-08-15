using Newtonsoft.Json;
using WeatherAPI.DTO;

namespace WeatherAPI.Services.ThirdParty.Models
{
    public class YahooWeatherApiResponseModel
    {
        [JsonProperty("current_observation")]
        public WeatherObservationDTO CurrentObservation { get; set; }
    }
}

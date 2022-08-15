using System.Collections.Generic;
using WeatherAPI.DTO;

namespace WeatherAPI.Controllers.Handlers.Contracts
{
    public interface IWeatherForecastHandler
    {
        /// <summary>
        /// Gets current weather observations asynchronously
        /// </summary>
        /// <param name="cityNames"></param>
        void GetCurrentWeatherData(List<CityNameDTO> cityNames);

        /// <summary>
        /// Cancels async operation fetching current weather observations
        /// </summary>
        void StopGettingCurrentWeatherObservations();
    }
}

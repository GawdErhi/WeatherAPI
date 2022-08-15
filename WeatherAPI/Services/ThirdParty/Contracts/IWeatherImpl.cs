using System.Collections.Generic;
using WeatherAPI.DTO;

namespace WeatherAPI.Services.ThirdParty.Contracts
{
    public interface IWeatherImpl
    {
        /// <summary>
        /// Gets current weather observation for specified cities
        /// </summary>
        /// <param name="cities"></param>
        void GetCurrentWeatherObservation(IEnumerable<CityDTO> cities);

        /// <summary>
        /// Cancels async operation fetching current weather observations
        /// </summary>
        void StopGettingCurrentWeatherObservation();
    }
}

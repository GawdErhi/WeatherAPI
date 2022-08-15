using System.Collections.Generic;
using WeatherAPI.DTO;
using WeatherAPI.Models;

namespace WeatherAPI.Services.Contracts
{
    public interface IWeatherObservationService
    {
        /// <summary>
        /// Adds weatherObservation records to context object and commits
        /// </summary>
        /// <param name="weatherObservation"></param>
        void SaveRecordsAndCommit(List<WeatherObservation> weatherObservations);

        /// <summary>
        /// Gets most recent weather observation data for specified city names
        /// </summary>
        /// <param name="cityNames"></param>
        /// <returns></returns>
        List<WeatherObservationDTO> GetMostRecentWeatherObservations(List<CityNameDTO> cityNames);
    }
}

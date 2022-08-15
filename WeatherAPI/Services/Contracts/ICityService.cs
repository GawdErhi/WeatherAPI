using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.DTO;
using WeatherAPI.Models;

namespace WeatherAPI.Services.Contracts
{
    public interface ICityService
    {
        /// <summary>
        /// Saves cities to db context and then confirms changes asynchronously
        /// </summary>
        /// <param name="cities"></param>
        /// <returns></returns>
        Task SaveRecords(IEnumerable<City> cities);


        /// <summary>
        /// Gets CityDTOs containing latitude and longitude values for collection of city names
        /// </summary>
        /// <param name="cityNames"></param>
        /// <returns></returns>
        IEnumerable<CityDTO> GetCitiesWithNames(IEnumerable<CityNameDTO> cityNames);
    }
}

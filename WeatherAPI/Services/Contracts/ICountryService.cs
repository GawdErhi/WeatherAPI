using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI.Services.Contracts
{
    public interface ICountryService
    {
        /// <summary>
        /// Adds countries to db context and then confirms changes asynchronously
        /// </summary>
        /// <param name="countries"></param>
        Task SaveRecords(IEnumerable<Country> countries);

        /// <summary>
        /// Gets all countries
        /// </summary>
        /// <returns></returns>
        List<Country> GetCountries();
    }
}

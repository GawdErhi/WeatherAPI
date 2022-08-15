using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.DB;
using WeatherAPI.Models;
using WeatherAPI.Services.Contracts;

namespace WeatherAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly WeatherApiDBContext _weatherApiDBContext;
        public CountryService(WeatherApiDBContext weatherApiDBContext)
        {
            _weatherApiDBContext = weatherApiDBContext;
        }

        /// <summary>
        /// Adds countries to db context and then confirms changes asynchronously
        /// </summary>
        /// <param name="countries"></param>
        public async Task SaveRecords(IEnumerable<Country> countries)
        {
            try
            {
                _weatherApiDBContext.Countries.AddRange(countries);
                await _weatherApiDBContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all countries
        /// </summary>
        /// <returns></returns>
        public List<Country> GetCountries()
        {
            try
            {
                return _weatherApiDBContext.Countries.Select(x => new Country { Id = x.Id, TwoLetterCode = x.TwoLetterCode }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

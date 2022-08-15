using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.DB;
using WeatherAPI.DTO;
using WeatherAPI.Models;
using WeatherAPI.Services.Contracts;

namespace WeatherAPI.Services
{
    public class CityService : ICityService
    {
        private readonly WeatherApiDBContext _weatherApiDBContext;
        public CityService(WeatherApiDBContext weatherApiDBContext)
        {
            _weatherApiDBContext = weatherApiDBContext;
        }

        /// <summary>
        /// Saves cities to db context and then confirms changes asynchronously
        /// </summary>
        /// <param name="cities"></param>
        /// <returns></returns>
        public async Task SaveRecords(IEnumerable<City> cities)
        {
            try
            {
                _weatherApiDBContext.Cities.AddRange(cities);
                await _weatherApiDBContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets CityDTOs containing latitude and longitude values for collection of city names
        /// </summary>
        /// <param name="cityNames"></param>
        /// <returns></returns>
        public IEnumerable<CityDTO> GetCitiesWithNames(IEnumerable<CityNameDTO> cityNames)
        {
            try
            {
                List<CityDTO> cities = new List<CityDTO>();
                foreach(var cityName in cityNames)
                {
                    cities.AddRange(_weatherApiDBContext.Cities.Where(x => x.Name.Contains(cityName.CityName) && x.Country.Name.Contains(cityName.CountryName)).Select(x => new CityDTO
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Latitude = x.Latitude,
                        Longitude = x.Longitude
                    }));
                }
                return cities;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

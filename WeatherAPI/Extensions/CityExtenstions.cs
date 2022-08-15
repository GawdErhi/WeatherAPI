using System.Collections.Generic;
using System.Linq;
using WeatherAPI.DTO;
using WeatherAPI.Models;

namespace WeatherAPI.Extensions
{
    public static class CityExtenstions
    {
        /// <summary>
        /// Transforms collection of CityDTOs to collection of City models
        /// </summary>
        /// <param name="cities"></param>
        /// <returns></returns>
        public static List<City> ToCityList(this IEnumerable<CityDTO> cities)
        {
            return cities.Select(x => new City { Name = x.Name, Latitude = x.Latitude, Longitude = x.Longitude }).ToList();
        }
    }
}

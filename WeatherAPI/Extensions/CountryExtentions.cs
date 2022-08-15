using System.Collections.Generic;
using System.Linq;
using WeatherAPI.DTO;
using WeatherAPI.Models;

namespace WeatherAPI.Extensions
{
    public static class CountryExtentions
    {
        /// <summary>
        /// Transforms a collection of CountryDTOs to a collection of Country models
        /// </summary>
        /// <param name="countries"></param>
        /// <returns></returns>
        public static List<Country> ToCountryList(this IEnumerable<CountryDTO> countries)
        {
            return countries.Select(x => new Country { Name = x.Name, Numeric = x.Numeric, TwoLetterCode = x.TwoLetterCode, ThreeLetterCode = x.ThreeLetterCode, Latitude = x.Latitude, Longitude = x.Longitude }).ToList();
        }
    }
}

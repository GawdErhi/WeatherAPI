using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Controllers.Handlers.Contracts;
using WeatherAPI.DTO;
using WeatherAPI.Extensions;
using WeatherAPI.Models;
using WeatherAPI.Services.Contracts;

namespace WeatherAPI.Controllers.Handlers
{
    public class SeedHandler : ISeedHandler
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;

        public SeedHandler(IWebHostEnvironment webHostEnvironment, ICountryService countryService, ICityService cityService)
        {
            _webHostEnvironment = webHostEnvironment;
            _countryService = countryService;
            _cityService = cityService;
        }

        /// <summary>
        /// Seed countries
        /// </summary>
        public async Task SeedCountries()
        {
            try
            {
                string countriesJson = File.ReadAllText(Path.Combine(_webHostEnvironment.ContentRootPath, "countries.json"));
                List<CountryDTO> countries = JsonConvert.DeserializeObject<List<CountryDTO>>(countriesJson);
                await _countryService.SaveRecords(countries.ToCountryList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Seed cities
        /// </summary>
        public async Task SeedCities()
        {
            try
            {
                string citiesJson = File.ReadAllText(Path.Combine(_webHostEnvironment.ContentRootPath, "cities.json"));
                List<Country> countries = _countryService.GetCountries();
                List<CityDTO> cities = JsonConvert.DeserializeObject<List<CityDTO>>(citiesJson);
                List<City> cityObjs = new List<City>();
                foreach (var city in cities.GroupBy(x => x.CountryTwoLetterCode))
                {
                    int countryId = countries.Where(x => x.TwoLetterCode == city.Key).Select(x => x.Id).SingleOrDefault();
                    if(countryId != 0) 
                    {
                        cityObjs.AddRange(city.Select(x => new City { Name = x.Name, Latitude = x.Latitude, Longitude = x.Longitude, CountryId = countryId }));
                    }
                }
                await _cityService.SaveRecords(cityObjs);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

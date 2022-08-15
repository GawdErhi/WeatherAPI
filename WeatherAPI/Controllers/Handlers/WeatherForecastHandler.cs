using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using WeatherAPI.Controllers.Handlers.Contracts;
using WeatherAPI.DTO;
using WeatherAPI.Services.Contracts;
using WeatherAPI.Services.ThirdParty.Contracts;
using System.Linq;

namespace WeatherAPI.Controllers.Handlers
{
    public class WeatherForecastHandler : IWeatherForecastHandler
    {
        private readonly IWeatherImpl _weatherImpl;
        private readonly ICityService _cityService;
        private readonly IConfiguration _configuration;
        public WeatherForecastHandler(IWeatherImpl weatherImpl, ICityService cityService, IConfiguration configuration)
        {
            _weatherImpl = weatherImpl;
            _cityService = cityService;
            _configuration = configuration;
        }

        /// <summary>
        /// Gets current weather observations asynchronously
        /// </summary>
        /// <param name="cityNames"></param>
        public void GetCurrentWeatherData(List<CityNameDTO> cityNames)
        {
            try
            {
                IEnumerable<CityDTO> cities = _cityService.GetCitiesWithNames(cityNames.Take(_configuration.GetSection("WeatherApiConfig").GetValue<int>("MaxApiCallLimit")));
                _weatherImpl.GetCurrentWeatherObservation(cities);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cancels async operation fetching current weather observations
        /// </summary>
        public void StopGettingCurrentWeatherObservations()
        {
            try
            {
                _weatherImpl.StopGettingCurrentWeatherObservation();
            }catch(Exception exception)
            {
                throw;
            }
        }
    }
}

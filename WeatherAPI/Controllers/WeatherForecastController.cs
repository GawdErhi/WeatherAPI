using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WeatherAPI.Controllers.Handlers.Contracts;
using WeatherAPI.DTO;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastHandler _weatherForecastHandler;
       public WeatherForecastController(IWeatherForecastHandler weatherForecastHandler)
        {
            _weatherForecastHandler = weatherForecastHandler;
        }


        [HttpGet]
        public ContentResult FetchCurrentWeatherObservation([FromBody]List<CityNameDTO> cityNames)
        {
            try
            {
                _weatherForecastHandler.GetCurrentWeatherData(cityNames);
                return Content("Fetching weather data...");
            }
            catch (Exception)
            {
                return Content("Unable to fetch weather data");
            }
        }

        [HttpGet]
        public ContentResult StopFetchingCurrentWeatherObservation()
        {
            try
            {
                _weatherForecastHandler.StopGettingCurrentWeatherObservations();
                return Content("No longer fetching current weather observations.");
            }
            catch (Exception)
            {
                return Content("Unable to stop fetching current weather observations");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WeatherAPI.Controllers.Handlers.Contracts;
using WeatherAPI.DTO;
using WeatherAPI.Services.Logger;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherReportController : ControllerBase
    {
        private readonly IWeatherReportHandler _weatherReportHandler;

        public WeatherReportController(IWeatherReportHandler weatherReportHandler)
        {
            _weatherReportHandler = weatherReportHandler;
        }

        [HttpGet]
        public ContentResult GetWeatherReport([FromBody] List<CityNameDTO> cityNames)
        {
            try
            {
                return Content(_weatherReportHandler.GetMostRecentWeatherReport(cityNames), "application/json");
            }
            catch (Exception)
            {
                return Content("Error getting weather report");
            }
        }

    }
}

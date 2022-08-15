using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WeatherAPI.Controllers.Handlers.Contracts;
using WeatherAPI.DTO;
using WeatherAPI.Services.Contracts;

namespace WeatherAPI.Controllers.Handlers
{
    public class WeatherReportHandler : IWeatherReportHandler
    {
        private readonly IWeatherObservationService _weatherObservationService;
        public WeatherReportHandler(IWeatherObservationService weatherObservationService)
        {
            _weatherObservationService = weatherObservationService;
        }

        /// <summary>
        /// returns json serialized collection of most recent weather observations for specified city names
        /// </summary>
        /// <param name="cityNames"></param>
        /// <returns></returns>
        public string GetMostRecentWeatherReport(List<CityNameDTO> cityNames)
        {
            try
            {
                return JsonConvert.SerializeObject(_weatherObservationService.GetMostRecentWeatherObservations(cityNames));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

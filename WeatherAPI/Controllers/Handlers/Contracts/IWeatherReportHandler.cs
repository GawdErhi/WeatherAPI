using System.Collections.Generic;
using WeatherAPI.DTO;

namespace WeatherAPI.Controllers.Handlers.Contracts
{
    public interface IWeatherReportHandler
    {
        /// <summary>
        /// returns json serialized collection of most recent weather observations for specified city names
        /// </summary>
        /// <param name="cityNames"></param>
        /// <returns></returns>
        public string GetMostRecentWeatherReport(List<CityNameDTO> cityNames);
    }
}

using System;
using WeatherAPI.DB;
using WeatherAPI.Models;
using WeatherAPI.Services.Contracts;

namespace WeatherAPI.Services
{
    public class AstronomyService : IAstronomyService
    {
        private readonly WeatherApiDBContext _weatherApiDBContext;
        public AstronomyService(WeatherApiDBContext weatherApiDBContext)
        {
            _weatherApiDBContext = weatherApiDBContext;
        }

        /// <summary>
        /// Adds astronomy record to context object without commiting
        /// </summary>
        /// <param name="astronomy"></param>
        public void SaveRecordWithoutCommit(Astronomy astronomy)
        {
            try
            {
                _weatherApiDBContext.Add(astronomy);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

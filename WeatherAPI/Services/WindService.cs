using System;
using WeatherAPI.DB;
using WeatherAPI.Models;
using WeatherAPI.Services.Contracts;

namespace WeatherAPI.Services
{
    public class WindService : IWindService
    {
        private readonly WeatherApiDBContext _weatherApiDBContext;
        public WindService(WeatherApiDBContext weatherApiDBContext)
        {
            _weatherApiDBContext = weatherApiDBContext;
        }

        /// <summary>
        /// Adds wind record to context object without commiting
        /// </summary>
        /// <param name="wind"></param>
        public void SaveRecordWithoutCommit(Wind wind)
        {
            try
            {
                _weatherApiDBContext.Add(wind);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

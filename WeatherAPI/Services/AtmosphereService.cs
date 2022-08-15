using System;
using WeatherAPI.DB;
using WeatherAPI.Models;
using WeatherAPI.Services.Contracts;

namespace WeatherAPI.Services
{
    public class AtmosphereService : IAtmosphereService
    {
        private readonly WeatherApiDBContext _weatherApiDBContext;
        public AtmosphereService(WeatherApiDBContext weatherApiDBContext)
        {
            _weatherApiDBContext = weatherApiDBContext;
        }

        /// <summary>
        /// Adds atmosphere record to context object without commiting
        /// </summary>
        /// <param name="atmosphere"></param>
        public void SaveRecordWithoutCommit(Atmosphere atmosphere)
        {
            try
            {
                _weatherApiDBContext.Add(atmosphere);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

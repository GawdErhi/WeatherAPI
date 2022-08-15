using System;
using WeatherAPI.DB;
using WeatherAPI.Models;
using WeatherAPI.Services.Contracts;

namespace WeatherAPI.Services
{
    public class ConditionService : IConditionService
    {
        private readonly WeatherApiDBContext _weatherApiDBContext;
        public ConditionService(WeatherApiDBContext weatherApiDBContext)
        {
            _weatherApiDBContext = weatherApiDBContext;
        }

        /// <summary>
        /// Adds condition record to context object without commiting
        /// </summary>
        /// <param name="condition"></param>
        public void SaveRecordWithoutCommit(Condition condition)
        {
            try
            {
                _weatherApiDBContext.Add(condition);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

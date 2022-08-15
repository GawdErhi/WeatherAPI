using WeatherAPI.Models;

namespace WeatherAPI.Services.Contracts
{
    public interface IConditionService
    {
        /// <summary>
        /// Adds condition record to context object without commiting
        /// </summary>
        /// <param name="condition"></param>
        void SaveRecordWithoutCommit(Condition condition);
    }
}

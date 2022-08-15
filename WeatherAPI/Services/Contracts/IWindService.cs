using WeatherAPI.Models;

namespace WeatherAPI.Services.Contracts
{
    public interface IWindService
    {
        /// <summary>
        /// Adds wind record to context object without commiting
        /// </summary>
        /// <param name="wind"></param>
        void SaveRecordWithoutCommit(Wind wind);
    }
}

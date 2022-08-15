using WeatherAPI.Models;

namespace WeatherAPI.Services.Contracts
{
    public interface IAstronomyService
    {
        /// <summary>
        /// Adds astronomy record to context object without commiting
        /// </summary>
        /// <param name="astronomy"></param>
        void SaveRecordWithoutCommit(Astronomy astronomy);
    }
}

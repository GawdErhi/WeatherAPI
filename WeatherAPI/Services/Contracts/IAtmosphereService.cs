using WeatherAPI.Models;

namespace WeatherAPI.Services.Contracts
{
    public interface IAtmosphereService
    {
        /// <summary>
        /// Adds atmosphere record to context object without commiting
        /// </summary>
        /// <param name="atmosphere"></param>
        void SaveRecordWithoutCommit(Atmosphere atmosphere);
    }
}

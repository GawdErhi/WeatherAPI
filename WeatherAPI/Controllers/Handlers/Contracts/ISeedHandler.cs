using System.Threading.Tasks;

namespace WeatherAPI.Controllers.Handlers.Contracts
{
    public interface ISeedHandler
    {
        /// <summary>
        /// Seed countries
        /// </summary>
        Task SeedCountries();

        /// <summary>
        /// Seed cities
        /// </summary>
        Task SeedCities();
    }
}

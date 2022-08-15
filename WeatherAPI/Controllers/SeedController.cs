using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeatherAPI.Controllers.Handlers.Contracts;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SeedController : ControllerBase
    {
        private readonly ISeedHandler _seedHandler;
        public SeedController(ISeedHandler seedHandler)
        {
            _seedHandler = seedHandler;
        }

        [HttpGet]
        public async Task<ContentResult> SeedCountries()
        {
            try
            {
                await _seedHandler.SeedCountries();
                return Content("Countries Seeded Successfully!");
            }
            catch (Exception)
            {
                return Content("Failed to seed countries");
            }
        }

        [HttpGet]
        public async Task<ContentResult> SeedCities()
        {
            try
            {
                await _seedHandler.SeedCities();
                return Content("Cities Seeded Successfully!");
            }catch(Exception)
            {
                return Content("Failed to seed cities");
            }
        }
    }
}

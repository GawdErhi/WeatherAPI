using System;
using System.Collections.Generic;
using System.Linq;
using WeatherAPI.DB;
using WeatherAPI.Models;
using WeatherAPI.Services.Contracts;
using WeatherAPI.DTO;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Services
{
    public class WeatherObservationService : IWeatherObservationService
    {
        private readonly WeatherApiDBContext _weatherApiDBContext;
        public WeatherObservationService(WeatherApiDBContext weatherApiDBContext)
        {
            _weatherApiDBContext = weatherApiDBContext;
        }

        /// <summary>
        /// Adds weatherObservation records to context object and commits
        /// </summary>
        /// <param name="weatherObservation"></param>
        public void SaveRecordsAndCommit(List<WeatherObservation> weatherObservations)
        {
            try
            {
                var _weatherApiDBContext = new WeatherApiDBContext();
                _weatherApiDBContext.Database.BeginTransaction();
                foreach(var weatherObservation in weatherObservations)
                {
                    _weatherApiDBContext.Add(weatherObservation.Astronomy);
                    _weatherApiDBContext.Add(weatherObservation.Atmosphere);
                    _weatherApiDBContext.Add(weatherObservation.Condition);
                    _weatherApiDBContext.Add(weatherObservation.Wind);
                    _weatherApiDBContext.Add(weatherObservation);
                }
                _weatherApiDBContext.SaveChanges();
                _weatherApiDBContext.Database.CommitTransaction();
            }
            catch (Exception exception)
            {
                _weatherApiDBContext.Database.RollbackTransaction();
                throw;
            }
        }

        /// <summary>
        /// Gets most recent weather observation data for specified city names
        /// </summary>
        /// <param name="cityNames"></param>
        /// <returns></returns>
        public List<WeatherObservationDTO> GetMostRecentWeatherObservations(List<CityNameDTO> cityNames)
        {
            try
            {
                List<WeatherObservationDTO> weatherObservations = new List<WeatherObservationDTO>();
                foreach(var cityName in cityNames)
                {
                    weatherObservations.AddRange(_weatherApiDBContext.WeatherObservations.AsNoTracking()
                        .Where(x => x.City.Name.Contains(cityName.CityName) && x.City.Country.Name.Contains(cityName.CountryName))
                        .OrderByDescending(x => x.CreatedAt)
                        .Take(1)
                        .Select(x => new WeatherObservationDTO
                        {

                            City = new CityDTO { Name = x.City.Name, CountryTwoLetterCode = x.City.Country.TwoLetterCode, Latitude = x.City.Latitude, Longitude = x.City.Longitude },
                            Astronomy = new AstronomyDTO { Sunrise = x.Astronomy.Sunrise, Sunset = x.Astronomy.Sunset },
                            Atmosphere = new AtmosphereDTO { Humidity = x.Atmosphere.Humidity, Pressure = x.Atmosphere.Pressure, Rising = x.Atmosphere.Rising, Visibility = x.Atmosphere.Visibility },
                            Condition = new ConditionDTO { Code = x.Condition.Code, Text = x.Condition.Text, Temperature = x.Condition.Temperature },
                            Wind = new WindDTO { Chill = x.Wind.Chill, Direction = x.Wind.Direction, Speed = x.Wind.Speed },
                            DatePublished = x.DatePublished.ToString("dd/MM/yyyy h:mm:ss tt")
                        }));
                }

                return weatherObservations;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
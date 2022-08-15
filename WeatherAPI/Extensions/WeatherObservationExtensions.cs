using System;
using WeatherAPI.DTO;
using WeatherAPI.Models;

namespace WeatherAPI.Extensions
{
    public static class WeatherObservationExtensions
    {
        public static WeatherObservation ToWeatherObservationModel(this WeatherObservationDTO weatherObservationDTO, int cityId=0)
        {
            return new WeatherObservation
            {
                Astronomy = new Astronomy
                {
                    Sunrise = weatherObservationDTO.Astronomy.Sunrise,
                    Sunset = weatherObservationDTO.Astronomy.Sunset
                },
                Atmosphere = new Atmosphere
                {
                    Humidity = weatherObservationDTO.Atmosphere.Humidity,
                    Visibility = weatherObservationDTO.Atmosphere.Visibility,
                    Pressure = weatherObservationDTO.Atmosphere.Pressure,
                    Rising = weatherObservationDTO.Atmosphere.Rising
                },
                Condition = new Condition
                {
                    Code = weatherObservationDTO.Condition.Code,
                    Text = weatherObservationDTO.Condition.Text,
                    Temperature = weatherObservationDTO.Condition.Temperature
                },
                Wind = new Wind
                {
                    Chill = weatherObservationDTO.Wind.Chill,
                    Speed = weatherObservationDTO.Wind.Speed,
                    Direction = weatherObservationDTO.Wind.Direction
                },
                CityId = cityId,
                DatePublished = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(double.Parse(weatherObservationDTO.DatePublished)),
                CreatedAt = DateTime.Now.ToLocalTime()
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.DTO;
using WeatherAPI.Services.ThirdParty.Contracts;
using System.Collections.Concurrent;
using System.Net.Http;
using WeatherAPI.Services.ThirdParty.Models;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using Microsoft.Extensions.Configuration;
using WeatherAPI.Services.Contracts;
using WeatherAPI.Models;
using WeatherAPI.Extensions;

namespace WeatherAPI.Services.ThirdParty
{
    public class YahooWeatherApiImpl : IWeatherImpl
    {
        private ConcurrentBag<WeatherObservation> _weatherObservationModels;
        private static CancellationTokenSource _cancellationSource = new CancellationTokenSource();
        private CancellationToken _cancellationToken;
        private readonly IConfiguration _configuration;
        private readonly IWeatherObservationService _weatherObservationService;
        private readonly HttpClient _httpClient;
        public YahooWeatherApiImpl(IConfiguration configuration, IWeatherObservationService weatherObservationService)
        {
            _weatherObservationModels = new ConcurrentBag<WeatherObservation>();
            _cancellationToken = _cancellationSource.Token;
            _configuration = configuration;
            _weatherObservationService = weatherObservationService;
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Gets current weather observation for specified cities
        /// </summary>
        /// <param name="cities"></param>
        public void GetCurrentWeatherObservation(IEnumerable<CityDTO> cities)
        {
            int callIntervalInSeconds = _configuration.GetSection("WeatherApiConfig").GetValue<int>("CallInterval");
            try
            {
                Task.Run(async() =>
                {
                    while (!_cancellationToken.IsCancellationRequested)
                    {
                        var weatherProcess = Parallel.ForEach(cities, (x) =>
                        {
                            GetCurrentWeatherData(x);
                        });
                        if (weatherProcess.IsCompleted)
                        {
                            _weatherObservationService.SaveRecordsAndCommit(_weatherObservationModels.ToList());
                            _weatherObservationModels = new ConcurrentBag<WeatherObservation>();
                        }
                        await Task.Delay(TimeSpan.FromSeconds(callIntervalInSeconds), _cancellationToken);
                    }
                }, _cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Cancels async operation fetching current weather observations
        /// </summary>
        public void StopGettingCurrentWeatherObservation()
        {
            try
            {
                _cancellationSource.Cancel();
                _cancellationSource = new CancellationTokenSource();
                _cancellationToken = _cancellationSource.Token;
            }catch(Exception exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Makes api call to fetch current weather observation
        /// </summary>
        /// <param name="city"></param>
        private void GetCurrentWeatherData(CityDTO city)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://yahoo-weather5.p.rapidapi.com/weather?lat={city.LatCoords}&long={city.LongCoords}&format=json&u=f"),
                Headers = {
                    { "X-RapidAPI-Key", "ha6h9Ci3ePmshpkD1bTaaFvHm4Oop195eSQjsnrgzJsNkNBW51" },
                    { "X-RapidAPI-Host", "yahoo-weather5.p.rapidapi.com" },
                },
            };
            var response = _httpClient.Send(request);
            response.EnsureSuccessStatusCode();
            using(var reader = new StreamReader(response.Content.ReadAsStream()))
            {
                var body = reader.ReadToEnd();
                YahooWeatherApiResponseModel responseModel = JsonConvert.DeserializeObject<YahooWeatherApiResponseModel>(body);
                _weatherObservationModels.Add(responseModel.CurrentObservation.ToWeatherObservationModel(city.Id));
            }
        }
    }
}

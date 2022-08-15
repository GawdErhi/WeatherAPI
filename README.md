# WeatherAPI
## Instructions
1. Seed countries by calling the SeedCountries action in the SeedController

2. Seed cities by calling the SeedController

3. After both countries and cities have seeded successfully you can now call the FetchCurrentWeatherObservation action in the WeatherForecastController to start fetching the most recent weather observations asynchronously at a predefined interval determined by the CallInterval key(this value is in seconds) in the appsettings.json file.

4. To stop the asynchronous operation fetching the most recent weather observations call the StopFetchingCurrentWeatherObservation action in the same controller.

5. To get a report of the most recent weather observation call the GetWeatherReport action in the WeatherReportController.
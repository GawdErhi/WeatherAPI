using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WeatherAPI.Controllers.Handlers;
using WeatherAPI.Controllers.Handlers.Contracts;
using WeatherAPI.Services;
using WeatherAPI.Services.Contracts;
using WeatherAPI.Services.ThirdParty;
using WeatherAPI.Services.ThirdParty.Contracts;

namespace WeatherAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DB.WeatherApiDBContext>(x => x.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddTransient<ISeedHandler, SeedHandler>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IAstronomyService, AstronomyService>();
            services.AddTransient<IAtmosphereService, AtmosphereService>();
            services.AddTransient<IConditionService, ConditionService>();
            services.AddTransient<IWindService, WindService>();
            services.AddTransient<IWeatherObservationService, WeatherObservationService>();
            services.AddTransient<IWeatherForecastHandler, WeatherForecastHandler>();
            services.AddTransient<IWeatherImpl, YahooWeatherApiImpl>();
            services.AddTransient<IWeatherReportHandler, WeatherReportHandler>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WeatherAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherAPI v1"));
            }
            loggerFactory.AddLog4Net();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

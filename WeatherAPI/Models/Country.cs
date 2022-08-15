using System.Collections.Generic;

namespace WeatherAPI.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TwoLetterCode { get; set; }

        public string ThreeLetterCode { get; set; }

        public string Numeric { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}

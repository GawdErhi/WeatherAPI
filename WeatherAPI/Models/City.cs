using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherAPI.Models
{
    public class City
    {
        public int Id { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public string Name { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}

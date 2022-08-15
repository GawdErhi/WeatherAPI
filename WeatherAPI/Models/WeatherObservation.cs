using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherAPI.Models
{
    public class WeatherObservation
    {
        public long Id { get; set; }

        [ForeignKey("Astronomy")]
        public long AstronomyId { get; set; }

        public virtual Astronomy Astronomy { get; set; }

        [ForeignKey("Atmosphere")]
        public long AtmosphereId { get; set; }

        public virtual Atmosphere Atmosphere { get; set; }

        [ForeignKey("Condition")]
        public long ConditionId { get; set; }

        public virtual Condition Condition { get; set; }

        [ForeignKey("Wind")]
        public long WindId { get; set; }

        public virtual Wind Wind { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public DateTime DatePublished { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

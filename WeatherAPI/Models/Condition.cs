namespace WeatherAPI.Models
{
    public class Condition
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Text { get; set; }

        public string Temperature { get; set; }
    }
}

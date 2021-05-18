using System.Collections.Generic;

namespace WebApplication.Models
{
    public class ValuesWithWeather
    {
        public Values values { get; set; }
        
        public List<WeatherRecord> record { get; set; }
    }
}
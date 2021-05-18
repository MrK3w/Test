using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication
{
    public class WeatherRecord
    {
        public DateTime Timestamp { get; set; }
        
        public int Temp2m { get; set; }
        
        public int Wind10mSpeed { get; set; }
        
        public int Cloucover { get; set; }
        
    }
}
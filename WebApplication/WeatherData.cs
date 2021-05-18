using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace WebApplication
{
    public class WeatherData
    {
        public List<WeatherRecord> weathers = new List<WeatherRecord>();
        
        public string myJsonData { get; set; }
        
        public void GetJson()
        {
            using (WebClient wc = new WebClient())
            {
                myJsonData =
                    wc.DownloadString(
                        "https://www.7timer.info/bin/api.pl?lon=18.283&lat=49.833&product=astro&output=json");
            }
        }

        public void ParseJson()
        {
          
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonData);
            int year = Int32.Parse(myDeserializedClass.init.Substring(0,4));
            int month =  Int32.Parse(myDeserializedClass.init.Substring(4,2));
            int day =  Int32.Parse(myDeserializedClass.init.Substring(6,2));
            DateTime date = new DateTime(year, month, day);
            foreach (var datasery in myDeserializedClass.dataseries)
            {
                WeatherRecord record = new WeatherRecord();
                TimeSpan time = new TimeSpan(datasery.timepoint, 0, 0);
                record.Timestamp = date + time;
                record.Cloucover = datasery.cloudcover;
                record.Temp2m = datasery.temp2m;
                record.Wind10mSpeed = datasery.wind10m.speed;
                weathers.Add(record);
            }
          
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private WeatherData weather = new WeatherData();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            weather.GetJson();
            weather.ParseJson();
        }

        public IActionResult Index()
        {
            Values values = new Values();
            values.averageTemperature = (int)weather.weathers.Average(x => x.Temp2m);
            values.maxWind = weather.weathers.Max(x => x.Wind10mSpeed);
            values.minCloud = weather.weathers.Min(x => x.Cloucover);
            ValuesWithWeather valuesWithWeather = new ValuesWithWeather();
            valuesWithWeather.values = values;
            valuesWithWeather.record = weather.weathers;
            return View(valuesWithWeather);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}